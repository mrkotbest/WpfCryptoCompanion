using System.Windows;
using WpfCryptoCompanion.Stores;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion
{
	public partial class App : Application
	{
		private NavigationStore _naviStore;

        public App()
        {
			_naviStore = new();
        }

        protected override void OnStartup(StartupEventArgs e)
		{
			_naviStore.CurrentViewModel = new HomeViewModel(_naviStore);

			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel(_naviStore)
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}