﻿using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using WpfCryptoCompanion.Commands;
using WpfCryptoCompanion.Services;

namespace WpfCryptoCompanion.ViewModels
{
	public class NavigationBarViewModel : BaseViewModel
	{
		private static bool _isDark;

		public ICommand NavigateHomeCommand { get; }
		public ICommand NavigateConverterCommand { get; }
		public ICommand ChangeThemeCommand { get; }

        public NavigationBarViewModel(NavigationService<HomeViewModel> homeNaviService,
			NavigationService<ConverterViewModel> converterNaviService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNaviService);
			NavigateConverterCommand = new NavigateCommand<ConverterViewModel>(converterNaviService);
			ChangeThemeCommand = new ChangeThemeCommand();
        }

        public static void ChangeTheme()
        {
			_isDark = !_isDark;
			PaletteHelper paletteHelper = new();

			ITheme theme = paletteHelper.GetTheme();
			IBaseTheme baseTheme = _isDark ? new MaterialDesignDarkTheme() : new MaterialDesignLightTheme();

			theme.SetBaseTheme(baseTheme);
			paletteHelper.SetTheme(theme);
		}
    }
}