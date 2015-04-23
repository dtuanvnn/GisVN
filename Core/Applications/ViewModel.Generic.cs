using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Applications
{
    public abstract class ViewModel<TView> : ViewModel where TView : IView
    {
        private readonly TView view;

        protected ViewModel(TView view) : base(view) 
        {
            this.view = view;
        }

        protected TView ViewCore { get { return view; } }
    }
}
