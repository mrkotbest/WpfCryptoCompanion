using System.ComponentModel;
using WpfCryptoCompanion.Models;
using WpfCryptoCompanion.Services;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion.Commands
{
	public class ShowDetailsCommand : BaseCommand
	{
		private readonly HomeViewModel _homeViewModel;
		private readonly ParamNavigationService<Coin, DetailsViewModel> _navigationService;

        public ShowDetailsCommand(HomeViewModel homeViewModel,
			ParamNavigationService<Coin, DetailsViewModel> navigationService)
        {
			_navigationService = navigationService;

            _homeViewModel = homeViewModel;
			_homeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

		public override bool CanExecute(object? parameter)
		{
			return _homeViewModel.CanShowDetails && base.CanExecute(parameter);
		}

		public override void Execute(object? parameter)
		{
			Coin selectedCoin = _homeViewModel.SelectedCoin;
			_navigationService.Navigate(selectedCoin);
		}

		private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(HomeViewModel.CanShowDetails))
			{
				OnCanExecuteChanged();
			}
		}
	}
}