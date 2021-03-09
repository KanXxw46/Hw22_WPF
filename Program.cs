using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _221020
{
    class Program
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();

                List<string> styles = new List<string> { "light", "dark" };
                styleBox.SelectionChanged += ThemeChange;
                styleBox.ItemsSource = styles;
                styleBox.SelectedItem = "dark";
            }

            private void ThemeChange(object sender, SelectionChangedEventArgs e)
            {
                string style = styleBox.SelectedItem as string;
                var uri = new Uri(style + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
    }
}
