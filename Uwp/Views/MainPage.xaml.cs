using System;

using Marimo.MappingGames.Uwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Marimo.MappingGames.Uwp.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
