using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Leasing.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateLeasing : Page
    {
        public CreateLeasing()
        {
            this.InitializeComponent();
        }

        public void ListeAfLeasinger(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListeAfLeasinger));
        }
        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;
        }

        private void Kunde_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OpretKundePage));
        }

        private void Medarbejder_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OpretMedarbejderPage));
        }

        private void Biler_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
