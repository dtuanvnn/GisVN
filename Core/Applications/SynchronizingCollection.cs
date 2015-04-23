using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;
using Core.Helpers;

namespace Core.Applications
{
    public class SynchronizingCollection<T, TOriginal> : ReadOnlyObservableCollection<T>
    {
        private readonly ObservableCollection<T> innerCollection;
        private readonly List<Tuple<TOriginal, T>> mapping;
        private readonly IEnumerable<TOriginal> originalCollection;
        private readonly Func<TOriginal, T> factory;
        private readonly IEqualityComparer<T> itemComparer;
        private readonly IEqualityComparer<TOriginal> originalItemComparer;

        public SynchronizingCollection(IEnumerable<TOriginal> originalCollection, Func<TOriginal, T> factory)
            : base(new ObservableCollection<T>())
        {
            ValidationHelper.ThrowNullException(originalCollection);
            ValidationHelper.ThrowNullException(factory);

            this.mapping = new List<Tuple<TOriginal, T>>();
            this.originalCollection = originalCollection;
            this.factory = factory;
            this.itemComparer = EqualityComparer<T>.Default;
            this.originalItemComparer = EqualityComparer<TOriginal>.Default;

            var collectionChanged = originalCollection as INotifyCollectionChanged;
            if (collectionChanged != null)
            {
                CollectionChangedEventManager.AddHandler(collectionChanged, OriginalCollectionChanged);
            }

            innerCollection = (ObservableCollection<T>)this.Items;
            foreach (TOriginal item in originalCollection)
            {
                innerCollection.Add(CreateItem(item));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged
        {
            add { base.PropertyChanged += value; }
            remove { base.PropertyChanged -= value; }
        }

        private T CreateItem(TOriginal oldItem)
        {
            T newItem = factory(oldItem);
            mapping.Add(new Tuple<TOriginal, T>(oldItem, newItem));
            return newItem;
        }
        
        private void OriginalCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewStartingIndex >= 0)
                {
                    var index = e.NewStartingIndex;
                    foreach (TOriginal item in e.NewItems)
                    {
                        innerCollection.Insert(index, CreateItem(item));
                        index++;
                    }
                }
                else
                {
                    foreach (TOriginal item in e.NewItems)
                    {
                        innerCollection.Add(CreateItem(item));
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldStartingIndex >= 0)
                {
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        RemoveAtCore(e.OldStartingIndex);
                    }
                }
                else
                {
                    foreach (TOriginal item in e.OldItems)
                    {
                        RemoveCore(item);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                if (e.NewStartingIndex >= 0)
                {
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        innerCollection[i + e.NewStartingIndex] = CreateItem((TOriginal)e.NewItems[i]);
                    }
                }
                else
                {
                    foreach (TOriginal item in e.OldItems)
                    {
                        RemoveCore(item);
                    }

                    foreach (TOriginal item in e.NewItems)
                    {
                        innerCollection.Add(CreateItem(item));
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    innerCollection.Move(e.OldStartingIndex + i, e.NewStartingIndex + i);
                }
            }
            // Reset
            else
            {
                ClearCore();
                foreach (TOriginal item in originalCollection)
                {
                    innerCollection.Add(CreateItem(item));
                }
            }
        }

        private void ClearCore()
        {
            innerCollection.Clear();
            mapping.Clear();
        }

        private void RemoveCore(TOriginal item)
        {
            Tuple<TOriginal, T> tuple = mapping.First(t => originalItemComparer.Equals(t.Item1, item));
            mapping.Remove(tuple);
            innerCollection.Remove(tuple.Item2);
        }

        private void RemoveAtCore(int index)
        {
            T newItem = this[index];
            Tuple<TOriginal, T> tuple = mapping.First(t => itemComparer.Equals(t.Item2, newItem));
            mapping.Remove(tuple);
            innerCollection.RemoveAt(index);
        }
    }
}
