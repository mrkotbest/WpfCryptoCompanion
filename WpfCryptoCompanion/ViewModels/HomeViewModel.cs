using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfCryptoCompanion.Commands;
using WpfCryptoCompanion.Models;
using WpfCryptoCompanion.Services;
using WpfCryptoCompanion.Stores;

namespace WpfCryptoCompanion.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		private readonly ApiHandler _apiHandler = new();
		private readonly ObservableCollection<Coin> _coins = new();

		private Coin _selectedCoin;
		private string _searchText = string.Empty;

		public IEnumerable<Coin> Coins => _coins;
		public ICollectionView CoinsView => CollectionViewSource.GetDefaultView(Coins);

		public ICommand ShowDetailsCommand { get; }

		public bool CanShowDetails => SelectedCoin != null;
		public string CoinId { get; set; } = "Currency";
		public Coin SelectedCoin
		{
			get => _selectedCoin;
			set
			{
				if (value == null) return;

				_selectedCoin = value;
				CoinId = SelectedCoin.Id;
				OnPropertyChanged(nameof(SelectedCoin));
				OnPropertyChanged(nameof(CoinId));
				OnPropertyChanged(nameof(CanShowDetails));
			}
		}
		public string SearchText
		{
			get => _searchText;
			set
			{
				_searchText = value;
				CoinsView.Refresh();
				OnPropertyChanged(nameof(SearchText));
			}
		}

		public HomeViewModel(NavigationStore navigationStore)
        {
			ParamNavigationService<Coin, DetailsViewModel> detailsNaviService = new(navigationStore,
				(parameter) => new DetailsViewModel(parameter));
			ShowDetailsCommand = new ShowDetailsCommand(this, detailsNaviService);

			InitCoins();
			CoinsView.Filter = FilterCoins;
        }

		private bool FilterCoins(object? obj)
		{
			if (obj is Coin coin)
			{
				return coin.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
					coin.Symbol.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		private async void InitCoins()
		{
			await LoadCoinsAsync();
		}

		private async Task LoadCoinsAsync()
		{
			_coins.Clear();
			var coins = await _apiHandler.GetCoinsAsync();
			foreach (Coin? coin in coins)
			{
				_coins.Add(coin);
			}
		}
	}
}