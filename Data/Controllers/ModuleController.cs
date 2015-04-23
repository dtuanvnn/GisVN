using Core.Applications;
using Data.Services;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers
{
    [Export(typeof(IModuleController)), Export]
    public class ModuleController : IModuleController
    {
        private readonly SearchGiayController _searchGiayController;
        private readonly Lazy<SearchGiayViewModel> _searchGiayViewModel;
        private readonly SearchGiayService _searchGiayService;

        [ImportingConstructor]
        public ModuleController(IPresentationService presentationService, 
            SearchGiayController searchGiayController, 
            Lazy<SearchGiayViewModel> searchGiayViewModel,
            SearchGiayService searchGiayService)
        {
            presentationService.InitializeCultures();
            this._searchGiayController = searchGiayController;
            this._searchGiayService = searchGiayService;
        }

        private SearchGiayViewModel SearchGiayViewModel { get { return _searchGiayViewModel.Value; } }

        public void Initialize()
        {
            _searchGiayService.SearchGiayView = SearchGiayViewModel.View;

            //_searchGiayController.
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}
