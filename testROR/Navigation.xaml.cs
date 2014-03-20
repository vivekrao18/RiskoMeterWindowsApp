using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace testROR
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        public PanoramaPage1()
        {
            InitializeComponent();
         
        }

        private void Panorama_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          //  NavigationService.Navigate(new Uri("/Navigation.xaml?goto=2", UriKind.Relative));
            Panorama al=(Panorama)ROR.SelectedItem;
            age.Text = al.ToString();
        }

        private void hello_TextChanged(object sender, TextChangedEventArgs e)
        {
            String ageInput = hello.Text;
           
        }
        

       
    }
}