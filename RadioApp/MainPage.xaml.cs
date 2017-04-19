using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.Media;
using Windows.Devices.Sensors;
using Windows.Graphics.Display;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RadioApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {



        
        internal List<Station> listStation { get; set; }
        private string urlsource = "./";
        private string imageURL = "ms-appx:///resources/Images/";
        private string logoURL = "ms-appx:///resources/logo/";
        private string Address;

        

       




        public MainPage()
        {
            this.InitializeComponent();

            MediaControl.PlayPressed += MediaControl_PlayPressed;
            MediaControl.PausePressed += MediaControl_PausePressed;
            MediaControl.PlayPauseTogglePressed += MediaControl_PlayPauseTogglePressed;
            MediaControl.StopPressed += MediaControl_StopPressed; 


            if (!MainPage.IsNetworkConnected())
            {
                new MessageDialog("Please connect to the internet.").ShowAsync();
            }
            else
            {
                IEnumerable<Station> source = Enumerable.Select<XElement, Station>(XDocument.Load(this.urlsource + "RadioStations.xml").Descendants((XName)"Station"), (Func<XElement, Station>)(query => new Station()
                {
                    name = (string)query.Element((XName)"name"),
                    urlsource = (string)query.Element((XName)"urlsource"),
                    image = (string) query.Element((XName)"image"),
                    fm = (string)query.Element((XName)"fm"),
                    website = (string)query.Element((XName)"web"),
                    logo =logoURL+ (string)query.Element((XName)"logo"),
                    /*groups = (string)query.Element((XName)"groups"),

                    category = (string)query.Element((XName)"category"),*/
               
                  
                  
                }));
                this.listStation = Enumerable.ToList<Station>(source);
                this.volumeSlider.Value = 40;
                this.ItemGridView.ItemsSource = listStation;
                Web_Button.Visibility = Visibility.Collapsed;
                
              

            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private static bool IsNetworkConnected()
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            NetworkInformation.GetConnectionProfiles();
            return connectionProfile != null;
        }





        private void ItemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Web_Button.Visibility = Visibility.Visible;
            this.ItemGridView.Margin = new Thickness(52.0, 0.0, 0.0, 0.0);
            Station station = this.ItemGridView.SelectedItem as Station;
            this.stationName.Text = station.name;
            this.stationFM.Text = station.fm;
            this.urlsource = station.urlsource;           
            this.Address = station.website;
            string imagepath = this.imageURL + station.image;
            string logopath = this.logoURL + station.logo;
            this.stationImage.Source = new BitmapImage(new Uri(imagepath));
            this.myMediaElement.Source = (new Uri(station.urlsource));
           
            
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }

        private void Pause_Button_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.PlaybackRate = 0;
        }

        private void volumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            
            this.myMediaElement.Volume = this.volumeSlider.Value/100;
        }

        private void myMediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
          /*  if (myMediaElement.CurrentState != MediaElementState.Buffering )
            {
               
                pRing.Visibility = Visibility.Visible;
                volumeSlider.Visibility = Visibility.Collapsed;
                Play_Button.Visibility = Visibility.Collapsed;
                Pause_Button.Visibility = Visibility.Collapsed;

            }*/
        }

        private async void MediaControl_StopPressed(object sender, object e)
        {
            sender = sender ?? new object();
            e = e ?? new object();

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => myMediaElement.Stop());
        }

        private async void MediaControl_PlayPauseTogglePressed(object sender, object e)
        {
            sender = sender ?? new object();
            e = e ?? new object();

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                try
                {
                    if (myMediaElement.CurrentState == MediaElementState.Stopped)
                        myMediaElement.Play();
                    else
                        myMediaElement.Stop();
                }
                catch
                {
                }
            });
        }

        private async void MediaControl_PausePressed(object sender, object e)
        {
            sender = sender ?? new object();
            e = e ?? new object();

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => myMediaElement.Stop());
        }

        private async void MediaControl_PlayPressed(object sender, object e)
        {
            sender = sender ?? new object();
            e = e ?? new object();

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => myMediaElement.Play());
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Web_Button_Click(object sender, RoutedEventArgs e)
        {
           
        
                Uri targeturi = new Uri(Address, UriKind.Absolute);

                MyWebView.Navigate(targeturi);
                if (MyWebView.Visibility == Visibility.Visible)
                    MyWebView.Visibility = Visibility.Collapsed;
                else if (MyWebView.Visibility == Visibility.Collapsed)
                    MyWebView.Visibility = Visibility.Visible;
            
        }



       

        }


    }


