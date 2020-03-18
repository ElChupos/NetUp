using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace NetUptimeMonitor
{
    public partial class Form1 : Form
    {
        public bool TestingInProcess = false;
        private Timer checkTimer;

        public int TimeDuration = 1000 * 10;

        public struct ConnectionPing
        {
            public DateTime PingTime;
            public IPStatus PingStatus;
        }

        public List<ConnectionPing> pings = new List<ConnectionPing>();

        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            PingNet();
        }

        private void PingNet()
        {
            var p = new Ping();
            var po = new PingOptions(64, true);

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            var result = IPStatus.TimedOut;
            try
            {
                var reply = p.Send("www.google.com", 1000 * 5, buffer);
                result = reply.Status;
            }
            catch
            {
                result = IPStatus.DestinationHostUnreachable;
            }

            //tick! check the net!
            var cp = new ConnectionPing()
            {
                PingTime = System.DateTime.Now,
                PingStatus = result
            };

            pings.Add(cp);

            UpdateLabels();

            p.Dispose();
        }

        private void UpdateLabels()
        {
            SucceedLabel.Text = SucceedCount.ToString();
            FailedLabel.Text = FailedCount.ToString();

            SuccessRoot.Visible = HasSucceeded;
            FailRoot.Visible = HasFailed;
            if( HasFailed)
            {
                LastFailLabel.Text = LastFail.ToShortTimeString();
            }

            if( HasSucceeded)
            {
                LastSuccessLabel.Text = LastSuccess.ToShortTimeString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestingInProcess = !TestingInProcess;
            button1.Text = TestingInProcess ? "Stop Testing" : "Start Testing";

            if (TestingInProcess)
            {
                checkTimer?.Dispose();
                checkTimer = new Timer();
                checkTimer.Interval = TimeDuration;
                checkTimer.Start();
                checkTimer.Tick += CheckTimer_Tick;
            }
            else
            {
                checkTimer.Stop();
                checkTimer.Dispose();
            }
        }

        public int SucceedCount
        {
            get
            {
                int count = 0;
                foreach(var p in pings)
                {
                    if (p.PingStatus == IPStatus.Success)
                        count++;
                }

                return count;
            }
        }

        public int FailedCount => pings.Count - SucceedCount;

        private bool HasFailed
        {
            get
            {
                foreach( var p in pings)
                {
                    if (p.PingStatus != IPStatus.Success)
                        return true;
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
                        return p.PingTime;
                }

                return DateTime.MinValue;
            }
        }

        private DateTime LastSuccess
        {
            get
            {
                foreach (var p in pings)
                {
                    if (p.PingStatus == IPStatus.Success)
                        return p.PingTime;
                }

                return DateTime.MinValue;
            }
        }


        private bool HasSucceeded
        {
            get
            {
                foreach(var p in pings)
                {
                    if( p.PingStatus == IPStatus.Success)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;

            if( dialog.ShowDialog() == DialogResult.OK )
            {
                StringBuilder sb = new StringBuilder();
                foreach(var p in pings)
                {
                    sb.AppendLine($"{p.PingStatus} = {p.PingTime.ToShortTimeString()} {p.PingTime.ToShortDateString()}");
                }
                //save file
                System.IO.File.WriteAllText(dialog.FileName, sb.ToString());
            }
        }
    }
}
