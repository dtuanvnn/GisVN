using Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Core.Helpers
{
    public static class ViewHelper
    {
        public static ViewModel GetViewModel(this IView view)
        {
            ValidationHelper.ThrowNullException(view);

            object dataContext = view.DataContext;

            if (dataContext == null && SynchronizationContext.Current is DispatcherSynchronizationContext)
            {
                DispatcherHelper.DoEvents();
                dataContext = view.DataContext;
            }

            return dataContext as ViewModel;
        }

        public static T GetViewModel<T>(this IView view) where T : ViewModel
        {
            return GetViewModel(view) as T;
        }
    }
}
