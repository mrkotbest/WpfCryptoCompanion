using System.Windows;
using WpfCryptoCompanion.Services;
using WpfCryptoCompanion.Stores;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion
{
	public partial class App : Application
	{
		private NavigationStore _naviStore;
		private NavigationBarViewModel _naviBarViewModel;

		public App()
		{
			_naviStore = new();
			_naviBarViewModel = new(CreateHomeNavigationService(),
				CreateConverterNavigationService());
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			NavigationService<HomeViewModel> homeNaviService = CreateHomeNavigationService();
			homeNaviService.Navigate();

			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel(_naviStore)
			};
			MainWindow.Show();

			base.OnStartup(e);
		}

		private NavigationService<HomeViewModel> CreateHomeNavigationService()
		{
			return new NavigationService<HomeViewModel>(_naviStore,
				() => new HomeViewModel(_naviBarViewModel, _naviStore));
		}

		private NavigationService<ConverterViewModel> CreateConverterNavigationService()
		{
			return new NavigationService<ConverterViewModel>(_naviStore,
				() => new ConverterViewModel(_naviBarViewModel));
		}
	} 
}