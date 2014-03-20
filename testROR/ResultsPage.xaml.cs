using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace testROR
{
    public partial class Page1 : PhoneApplicationPage
    {
        string age;
        string bp;
        string gender;
        string diabetes;
        string stroke;
        string hospitalization;
        string race;
        string bmi;
        string efv;
        string lengthOfStay = String.Empty;


        public Page1()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            age = NavigationContext.QueryString["age"];
            gender = NavigationContext.QueryString["gender"];
            race = NavigationContext.QueryString["race"];
            hospitalization = NavigationContext.QueryString["hospitalization"];
            stroke = NavigationContext.QueryString["stroke"];
            diabetes = NavigationContext.QueryString["diabetes"];
            bmi = NavigationContext.QueryString["BMI"];
            efv = NavigationContext.QueryString["efv"];
            bp = NavigationContext.QueryString["BP"];
            lengthOfStay = NavigationContext.QueryString["Stay"];

        }
        public void ResultPageLoaded(object sender, RoutedEventArgs e)
        {

            String url = "http://charuch-ror.cloudapp.net/RoR?age=" + age + "&gender=" + gender + "&ethnicGroup=" + race +
                         "&inpatientBMI=" + bmi + "&diabetes=" + diabetes + "&stroke=" + stroke + "&priorHospitalization=" + hospitalization +
                         "&ejectionFraction=" + efv + "&bloodPressureCategory=" + bp + "&lengthOfStay=" + lengthOfStay.Replace(" ", String.Empty);

            var request = (HttpWebRequest)WebRequest.Create(
           // new Uri("http://charuch-ror.cloudapp.net/RoR?age=74&gender=Female&ethnicGroup=Asian&inpatientBMI=19&diabetes=Yes&stroke=No&priorHospitalization=No&ejectionFraction=20&bloodPressureCategory=201-219%20/%20100-110"));
            new Uri(url));
            request.BeginGetResponse(r =>
          {
              var httpRequest = (HttpWebRequest)r.AsyncState;
              var httpResponse = (HttpWebResponse)httpRequest.EndGetResponse(r);

              using (var reader = new StreamReader(httpResponse.GetResponseStream()))
              {
                  var response = reader.ReadToEnd();
                  int lastIndex = response.LastIndexOf('}');
                  string responseString = response.Replace("TRUE", string.Empty);

                  JObject objJsonObject = JObject.Parse(responseString);

                  string probability = objJsonObject["probability"].ToString();
                  JObject riskFactorsObject = (JObject)objJsonObject["riskFactors"];
                  JArray riskFactorsArray = (JArray)riskFactorsObject["name"];
                  String[] risksStringList = new String[3];

                  JObject riskContributorsObject = (JObject)objJsonObject["readmissionContributors"];
                  JArray riskContributorsArray = (JArray)riskContributorsObject["name"];
                  String[] riskContributorsList = new String[3];


                  Deployment.Current.Dispatcher.BeginInvoke(new Action(() =>
                  {


                      TextBlock probabilityTextBlock = new TextBlock();

                      probabilityTextBlock.Text = "Probability of readmission in next 30 days is = " + probability;
                      probabilityTextBlock.Margin = new Thickness(5, 0, 5, 5);
                      probabilityTextBlock.FontSize = 25;
                      probabilityTextBlock.TextAlignment = TextAlignment.Left;
                      Probability.Text = probabilityTextBlock.Text.ToString();
                      Double probabilityInDouble = Double.Parse(probability);
                     //String data = "<html>"
                     //     + "<head>"
                     //     + "<script type='text/javascript' src='https://www.google.com/jsapi'></script>"
                     //     + "<script type='text/javascript'>"
                     //     + "google.load('visualization', '1', {packages:['gauge']});"
                     //     + " google.setOnLoadCallback(drawChart);"
                     //     + " function drawChart() {"
                     //     + " var data = google.visualization.arrayToDataTable(["
                     //     + " ['Label', 'Value'],"
                     //     + " ['Probability', "
                     //     + probabilityInDouble
                     //     + "],"

                     //     + " ]); var options = {"
                     //     + " width: 200, height: 200,"
                     //     + " redFrom: 75, redTo: 100,"
                     //     + " yellowFrom:50, yellowTo: 75,"

                     //     + " minorTicks: 5"
                     //     + "};"
                     //     + "var chart = new google.visualization.Gauge(document.getElementById('chart_div'));"
                     //     + " chart.draw(data, options);" + "  }" + " </script>"
                     //     + "</head>" + " <body>"
                     //     + "   <div id='chart_div'></div>" + "  </body>"
                     //     + "</html>";
                     //string data = "http://chart.googleapis.com/chart?chs=750x400&cht=gom&chd=t:" + probabilityInDouble + "&chco=FF0000,FF8040,FFFF00,00FF00,00FFFF,0000FF,800080&chxt=x,y&chxl=0:|Probability|1:|low|high";
                     string data = "http://chart.googleapis.com/chart?chs=750x400&cht=gom&chd=t:"+ probabilityInDouble+ "&chco=00FF00,00FF00,00FF00,00FE00,00FF00,FFFF00,FFFF00,FFFF00,FF0000,FF0000&chxt=x,y&chxl=0:|Probability|1:|low|high";
                      //  graph.NavigateToString(data);
                        
                         webview.Navigate(new Uri(data));
                           
                      // webview.NavigateToString(data);
                     
                    // webview.NavigateToString("<html><head><script type='text/javascript'src='http://www.google.com/jsapi'></script><script type='text/javascript'>google.load('visualization', '1', {packages:['gauge']}); google.setOnLoadCallback(drawChart); function drawChart(){ var data = google.visualization.arrayToDataTable([ ['Label', 'Value'], ['Probability', 63.05], ]); var options = { width: 200, height: 200, redFrom: 75, redTo: 100, yellowFrom:50, yellowTo: 75, minorTicks: 5};var chart = new google.visualization.Gauge(document.getElementById('chart_div')); chart.draw(data, options);  } </script></head> <body>   <div id='chart_div'></div>  </body></html>");
                   
                   //   webview.NavigateToString("<html><head><script type=\"text/javascript\" language=\"javascript\">function callme(){var test = alert(\"hello\");}</script></head><body onload=callme();> </body></html>");



                      TextBlock riskFactorsHeading = new TextBlock();
                      riskFactorsHeading.Text = "Top Associated Risk Factors are : ";
                      riskFactorsHeading.FontSize = 25;
                      riskFactorsHeading.TextAlignment = TextAlignment.Left;
                      riskFactorsHeading.Margin = new Thickness(10, 10, 5, 10);
                      ContentPanel.Children.Add(riskFactorsHeading);

                      int i = 0;
                      foreach (var riskFactors in riskFactorsArray)
                      {
                          TextBlock riskFactorsTextBlock = new TextBlock();
                          risksStringList[i] = riskFactors.ToString();
                          riskFactorsTextBlock.Text = i + 1 + ") " + risksStringList[i].Replace("&lt", " < ");
                          riskFactorsTextBlock.Margin = new Thickness(10, 0, 5, 5);
                          riskFactorsTextBlock.FontSize = 20;
                          riskFactorsTextBlock.TextAlignment = TextAlignment.Left;
                          ContentPanel.Children.Add(riskFactorsTextBlock);
                          i++;

                      }

                      TextBlock riskContributorsHeading = new TextBlock();
                      riskContributorsHeading.Text = "Top 3 Contributors are : ";
                      riskContributorsHeading.FontSize = 25;
                      riskContributorsHeading.TextAlignment = TextAlignment.Left;
                      riskContributorsHeading.Margin = new Thickness(10, 10, 5, 10);
                      ContentPanel.Children.Add(riskContributorsHeading);

                      int j = 0;
                      foreach (var riskContributors in riskContributorsArray)
                      {
                          TextBlock riskContributorsTextBlock = new TextBlock();
                          riskContributorsList[j] = j + 1 + ") " + riskContributors.ToString();
                          riskContributorsTextBlock.Text = riskContributorsList[j];
                          riskContributorsTextBlock.Margin = new Thickness(10, 0, 5, 5);
                          riskContributorsTextBlock.TextAlignment = TextAlignment.Left;
                          riskContributorsTextBlock.FontSize = 20;
                          ContentPanel.Children.Add(riskContributorsTextBlock);
                          j++;

                      }
                  }));


              }
          }, request);

        }


    }
}