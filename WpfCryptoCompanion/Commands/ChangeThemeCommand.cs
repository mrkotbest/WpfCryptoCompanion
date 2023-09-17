using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion.Commands
{
	public class ChangeThemeCommand : BaseCommand
	{
        public override void Execute(object? parameter)
		{
			NavigationBarViewModel.ChangeTheme();
		}
	}
}