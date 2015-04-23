using Core.Applications;
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers
{
    [Export]
    internal class SearchGiayController
    {
        private readonly SearchGiayViewModel searchGiayViewModel;
        

        private SynchronizingCollection<LoaiGiayChungNhanModel, LoaiGiayChungNhan> loaiGiayModels;

        [ImportingConstructor]
        public SearchGiayController(SearchGiayViewModel searchGiayViewModel)
        {
            this.searchGiayViewModel = searchGiayViewModel;
        }

        public void Initialize()
        {
            PropertyChangedEventManager.AddHandler(searchGiayViewModel, SearchGiayViewModelPrropertyChanged, "");

        }

        private void SearchGiayViewModelPrropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsValid")
            {
                //saveCommand.RaiseCanExecuteChanged();
            }
        }

    }
}
