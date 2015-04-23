using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Core.Applications
{
    public abstract class ViewModel
    {
        private readonly IView view;

        protected ViewModel(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }
            this.view = view;

            if (SynchronizationContext.Current is DispatcherSynchronizationContext)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate()
                {
                    this.view.DataContext = this;
                });
            }
            else
            {
                view.DataContext = this;
            }
        }

        public object View { get { return view; } }
    }
}
