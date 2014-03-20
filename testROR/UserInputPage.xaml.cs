using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using testROR.Resources;

namespace testROR
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        
        static String userSelectedRace;
        static String userSelectedGender;
        static String userSelectedHospitalization;
        static String userSelectedDiabetes;
        static String userSelectedStroke;
        static String userSelectedBP;
        static String userSelectedBMI;
        static String userSelectedEFV;
        static String userSelectedLengthOfStay= String.Empty;
       
        public PivotPage1()
        {
            InitializeComponent();
       //     BuildLocalizedApplicationBar();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            // Turn on Tab Stops.  You can set this in XAML as well.  
            this.IsTabStop = true;

            // Set focus on the TextBox.
            userEnteredAge.Focus();
        }

            
        private void Age_entered(object sender, RoutedEventArgs e)
        {
            UserNavigation.SelectedItem = Gender;
        }

       
        private void MaleSelected(object sender, RoutedEventArgs e)
        {
            userSelectedGender = Male.Name;
            UserNavigation.SelectedItem = Race;
        }

        private void FemaleSelected(object sender, RoutedEventArgs e)
        {
            userSelectedGender = Female.Name;
            UserNavigation.SelectedItem = Race;
        }

       public void HandleChecked(object sender, RoutedEventArgs e)
        {

            if (AfricanAmerican.IsChecked ==true)
            {
                userSelectedRace=AfricanAmerican.Name;
            }
            else if(AmericanIndian.IsChecked==true)
            {
                userSelectedRace=AmericanIndian.Name;
            }
                 else if(Asian.IsChecked==true)
            {
                userSelectedRace=Asian.Name;
            }
                 else if(HispanicLatino.IsChecked==true)
            {
                userSelectedRace=HispanicLatino.Name;
            }
                 else if(Caucasian.IsChecked==true)
            {
                userSelectedRace=Caucasian.Name;
            }
                 else if(MultiRacial.IsChecked==true)
            {
                userSelectedRace=MultiRacial.Name;
            }
                 else if(Others.IsChecked==true)
            {
                userSelectedRace = Others.Name;

            }
                else if(PacificIslander.IsChecked==true)
            {
                userSelectedRace = PacificIslander.Name;
            }
         
                UserNavigation.SelectedItem = PriorToHospitalization;
         
        }

       private void HospitalizationNo_Click(object sender, RoutedEventArgs e)
       {
           userSelectedHospitalization = "No";
           UserNavigation.SelectedItem = Diabetes;
       }

       private void DiabetesYes_Click(object sender, RoutedEventArgs e)
       {
           userSelectedDiabetes = "Yes";
           UserNavigation.SelectedItem = Stroke;
       }

       private void DiabetesNo_Click(object sender, RoutedEventArgs e)
       {
           userSelectedDiabetes = "No";
           UserNavigation.SelectedItem = Stroke;
       }

       private void StrokeYes_Click(object sender, RoutedEventArgs e)
       {
           userSelectedStroke = "Yes";
           UserNavigation.SelectedItem = BP;
       }

       private void StrokeNo_Click(object sender, RoutedEventArgs e)
       {
           userSelectedStroke = "No";
           UserNavigation.SelectedItem = BP;
       }

       private void nextButtonBMI_Click(object sender, RoutedEventArgs e)
       {
                userSelectedBMI = userEnteredBMI.Name;
                UserNavigation.SelectedItem = EFV;
       }

       private void BPRadioChecked(object sender, RoutedEventArgs e)
       {
           if (BPC1.IsChecked == true)
           {
               userSelectedBP = "&lt130/80";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC2.IsChecked == true)
           {
               userSelectedBP = "151-159/95-99";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC3.IsChecked == true)
           {
               userSelectedBP = "130-139/80-89";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC4.IsChecked == true)
           {
               userSelectedBP = "140-150/90-95";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC5.IsChecked == true)
           {
               userSelectedBP = "160-180/100-110";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC6.IsChecked == true)
           {
               userSelectedBP = "130-139/&lt80";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC7.IsChecked == true)
           {
               userSelectedBP = "181-200/100-110";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC8.IsChecked == true)
           {
               userSelectedBP = "201-219/100-110";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC9.IsChecked == true)
           {
               userSelectedBP = "&lt130/80-89";
               UserNavigation.SelectedItem = BMI;
           }

           else if (BPC10.IsChecked == true)
           {
               userSelectedBP = "&gt=220/&gt=120";
               UserNavigation.SelectedItem = BMI;
           }

       }

       private void lengthOfStay_entered( object sender, RoutedEventArgs e)
       {
           
           UserNavigation.SelectedItem = Diabetes;
       }

       private void HospitalizationYes_Click(object sender, RoutedEventArgs e)
       {
           userSelectedHospitalization = "Yes";

           UserNavigation.SelectedItem = LengthOfStay;
           LengthOfStay.IsEnabled = true;
          
       }

       private void calculateRiskButton_Click(object sender, RoutedEventArgs e)
             {
                 userSelectedLengthOfStay = lengthofstay.Text;
                 userSelectedBMI = userEnteredBMI.Text;
                 userSelectedEFV = userEnteredEFV.Text;
                 NavigationService.Navigate(new Uri("/ResultsPage.xaml?age="+userEnteredAge.Text+"&gender="+userSelectedGender+
                    "&race="+userSelectedRace+"&BMI="+userSelectedBMI+"&diabetes="+userSelectedDiabetes+"&stroke="+userSelectedStroke+
                    "&hospitalization="+userSelectedHospitalization+"&efv="+userSelectedEFV+"&BP="+userSelectedBP+"&Stay="+userSelectedLengthOfStay
                    , UriKind.Relative));
                
             }
     
       
    }
}