using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class CollectionHelper
    {
        public static T GetNextElementOrDefault<T>(IEnumerable<T> collection, T current)
        {
            ValidationHelper.ThrowNullException(collection);

            bool found = false;
            IEnumerator<T> enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (EqualityComparer<T>.Default.Equals(enumerator.Current, current))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new ArgumentException("The collection does not contain the current item.");
            }

            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
            else 
            {
                return default(T);    
            }
        }
    }
}
