using Core.Applications;
using Data.Models;
using Data.Services;
using Data.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    [Export]
    public class SearchGiayViewModel : ViewModel<ISearchGiayView>
    {
        private readonly ISearchService searchService;
        private readonly ObservableCollection<LoaiGiayChungNhanModel> selectedLoaiGiays;
        private IEnumerable<LoaiGiayChungNhanModel> loaiGiays;
        private LoaiGiayChungNhanModel selectedLoaiGiay;

        [ImportingConstructor]
        public SearchGiayViewModel(ISearchGiayView view)
            : base(view)
        {
            this.selectedLoaiGiays = new ObservableCollection<LoaiGiayChungNhanModel>();
        }

        public IEnumerable<LoaiGiayChungNhanModel> SelectedLoaiGiays { get { return selectedLoaiGiays; } }

        public IEnumerable<LoaiGiayChungNhanModel> LoaiGiays { get { return loaiGiays; } }
    }
}
