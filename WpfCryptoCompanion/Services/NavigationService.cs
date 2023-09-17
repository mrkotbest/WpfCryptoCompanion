using System;
using WpfCryptoCompanion.Stores;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion.Services
{
	public class NavigationService<TViewModel>
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _naviStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _naviStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _naviStore.CurrentViewModel = _createViewModel();
        }
    }
}