namespace WpfCryptoCompanion.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public BaseViewModel CurrentViewModel => new HomeViewModel();
	}
}