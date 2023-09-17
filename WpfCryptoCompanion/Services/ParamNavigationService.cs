using System;
using WpfCryptoCompanion.Stores;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion.Services
{
	public class ParamNavigationService<TParameter, TViewModel>
        where TViewModel : BaseViewModel
	{
		private readonly NavigationStore _naviStore;
		private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParamNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _naviStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _naviStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}