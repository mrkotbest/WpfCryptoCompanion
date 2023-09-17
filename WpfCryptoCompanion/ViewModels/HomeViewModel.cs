using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfCryptoCompanion.Models;

namespace WpfCryptoCompanion.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		private readonly ObservableCollection<Coin> _coins = new();

		public IEnumerable<Coin> Coins => _coins;
		public ICollectionView CoinsView => CollectionViewSource.GetDefaultView(Coins);

        public HomeViewModel()
        {
			_coins.Add(new Coin() { Id = "first", Rank = 1, Name = "BITCOIN", Price = 143.5f });
        }
    }
}