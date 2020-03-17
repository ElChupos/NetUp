using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestFluent
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public bool TestingInProcess = false;
        private DispatcherTimer checkTimer;

        public int TimeDuration = 1000 * 10;

        public struct ConnectionPing
        {
            public DateTime PingTime;
            public IPStatus PingStatus;
        }

        public List<ConnectionPing> pings = new List<ConnectionPing>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ToggleTestButton_Click(object sender, RoutedEventArgs e)
        {
            TestingInProcess = !TestingInProcess;
            ToggleTestButton.Content = TestingInProcess ? "Stop Testing" : "Start Testing";

            if (TestingInProcess)
            {
                checkTimer?.Stop();
                checkTimer = new DispatcherTimer();
                checkTimer.Interval = TimeSpan.FromMilliseconds(TimeDuration);
                checkTimer.Start();
                checkTimer.Tick += Dt_Tick;
                
                
            }
            else
            {
                checkTimer?.Stop();
            }
        }

        private void Dt_Tick(object sender, object e)
        {
            PingNet();
        }


        private void PingNet()
        {
            var p = new Ping();
            var po = new PingOptions(64, true);
            var available = NetworkInterface.GetIsNetworkAvailable();

            /*
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            var result = IPStatus.TimedOut;
            try
            {
                var reply = p.Send("www.google.com", 1000 * 5, buffer);
                result = reply.Status;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                result = IPStatus.DestinationHostUnreachable;
            }
            */

            var cp = new ConnectionPing()
            {
                PingTime = System.DateTime.Now,
                PingStatus = available ? IPStatus.Success : IPStatus.Unknown
            };

            pings.Add(cp);

            UpdateLabels();

            p.Dispose();
        }

        private void UpdateLabels()
        {
            SuccessCount.Text = SucceedCount.ToString();

            FailedCount.Text = FailCount.ToString();

            FailedRoot.Visibility = HasFailed ? Visibility.Visible : Visibility.Collapsed;
            if (HasFailed)
            {
                LastFailText.Text = LastFail.ToShortTimeString();
            }

            SuccessRoot.Visibility = HasSucceeded ? Visibility.Visible : Visibility.Collapsed;
            if (HasSucceeded)
            {
                LastSuccess.Text = LastSucceed.ToShortTimeString();
            }
        }

        public int SucceedCount
        {
            get
            {
                int count = 0;
                foreach (var p in pings)
                {
                    if (p.PingStatus == IPStatus.Success)
                        count++;
                }

                return count;
            }
        }

        public int FailCount => pings.Count - SucceedCount;

        private bool HasFailed
        {
            get
            {
                foreach (var p in pings)
                {
                    if (p.PingStatus != IPStatus.Success)
                        return true;
                }

                return false;
            }
        }

        private bool HasSucceeded
        {
            get
            {
                foreach (var p in pings)
                {
                    if (p.PingStatus == IPStatus.Success)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private DateTime LastFail
        {
            get
            {
                foreach (var p in pings)
                {
                    if (p.PingStatus != IPStatus.Success)
                    {
                        return p.PingTime;
                    }
                }

                return DateTime.MinValue;
            }
        }

        private DateTime LastSucceed
        {
            get
            {
                foreach (var p in pings)
                {
                    if (p.PingStatus == IPStatus.Success)
                    {
                        return p.PingTime;
                    }
                }

                return DateTime.MinValue;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = SaveFile();
        }

        private async Task SaveFile()
        {
            //save!

            var dialog = new FileSavePicker();
            dialog.SuggestedStartLocation = PickerLocationId.Desktop;
            dialog.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });

            StorageFile file = await dialog.PickSaveFileAsync();


            StringBuilder sb = new StringBuilder();
            foreach (var p in pings)
            {
                sb.AppendLine($"{p.PingStatus} = {p.PingTime.ToShortTimeString()} {p.PingTime.ToShortDateString()}");
            }
            
            CachedFileManager.DeferUpdates(file);
            // write to file
            await FileIO.WriteTextAsync(file, sb.ToString());
            // Let Windows know that we're finished changing the file so the other app can update the remote version of the file.
            // Completing updates may require Windows to ask for user input.
            await CachedFileManager.CompleteUpdatesAsync(file);

        }
    }
}
