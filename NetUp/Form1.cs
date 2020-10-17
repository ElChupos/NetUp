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
        private DateTime testStartTime;

        public int TimeDuration = 1000 * 10;

        public struct ConnectionBlock
        {
            public DateTime StartTime;
            public DateTime EndTime;
            public IPStatus Status;
            public int Pings;
        }

        public List<ConnectionBlock> connections = new List<ConnectionBlock>();

        public Form1()
        {
            InitializeComponent();
            this.Icon = NetUp.Properties.Resources.wifi_router_I33_icon;
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


            var makeNew = connections.Count == 0 || connections[connections.Count - 1].Status != result;
            if(makeNew)
            {
                var newConnection = new ConnectionBlock()
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                    Status = result,
                    Pings = 1
                };
                connections.Add(newConnection);
            }
            else
            {
                var oldConnection = connections[connections.Count - 1];
                oldConnection.EndTime = DateTime.Now;
                oldConnection.Pings++;
                connections[connections.Count - 1] = oldConnection;
            }

            UpdateLabels();

            p.Dispose();
        }

        private void UpdateLabels()
        {
            SucceedLabel.Text = SucceedCount.ToString();
            FailedLabel.Text = FailedCount.ToString();

            SuccessRoot.Visible = HasSucceeded;
            FailRoot.Visible = HasFailed;
            if(GetLastBlock(out ConnectionBlock failBlock, p => p.Status != IPStatus.Success) )
            {
                LastFailLabel.Text = failBlock.EndTime.ToShortTimeString();
            }

            if(GetLastBlock(out ConnectionBlock successBlock, p => p.Status == IPStatus.Success))
            {
                LastSuccessLabel.Text = successBlock.EndTime.ToShortTimeString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestingInProcess = !TestingInProcess;
            button1.Text = TestingInProcess ? "Stop Testing" : "Start Testing";
            testStartTime = DateTime.Now;
            startTestingLabel.Text = $"Started testing: {testStartTime.ToString()}";
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
                foreach(var p in connections)
                {
                    if (p.Status == IPStatus.Success)
                        count += p.Pings;
                }

                return count;
            }
        }

        public int TotalPings
        {
            get
            {
                int count = 0;
                foreach (var p in connections)
                {
                    count += p.Pings;
                }

                return count;
            }
        }

        public int FailedCount => TotalPings - SucceedCount;

        private bool HasFailed
        {
            get
            {
                foreach( var p in connections)
                {
                    if (p.Status != IPStatus.Success)
                        return true;
                }

                return false;
            }
        }

        private bool GetLastBlock (out ConnectionBlock block, Predicate<ConnectionBlock> predicate)
        {
            if (connections.Count > 0)
            {
                for( int i = connections.Count - 1; i >= 0; i--)
                {
                    if( predicate.Invoke(connections[i]))
                    {
                        block = connections[i];
                        return true;
                    }
                }
            }

            block = new ConnectionBlock();
            return false;
        }
        
        private bool HasSucceeded
        {
            get
            {
                foreach(var p in connections)
                {
                    if( p.Status == IPStatus.Success)
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
                foreach(var p in connections)
                {
                    var dur = p.EndTime - p.StartTime;
                    sb.AppendLine($"{p.Status} = {p.StartTime.ToString()} to {p.EndTime.ToString()}. Duration: {dur.ToString()}");
                }
                //save file
                System.IO.File.WriteAllText(dialog.FileName, sb.ToString());
            }
        }
    }
}
