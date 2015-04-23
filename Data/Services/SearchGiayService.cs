using Core.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    [Export(typeof(ISearchService)), Export]
    public class SearchGiayService : Model, ISearchService
    {
        private object _searchGiayView;

        public object SearchGiayView
        {
            get { return this._searchGiayView;}
            set { SetProperty(ref _searchGiayView, value); }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
    }
}
