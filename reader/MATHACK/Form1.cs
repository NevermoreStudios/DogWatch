using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MATHACK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort port;
        int prevel=-1;
        DateTime lastsent = DateTime.Now;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            notifyIcon1.Text = "Dog Watch";
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Da li ste sigurn da zelite da iskljucite Dog Watch?", "Iskluci?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                port.Close();
                Application.Exit();
            }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hide();
            port = new SerialPort(comboBox1.GetItemText(this.comboBox1.SelectedItem), 9600);
            port.DataReceived += Port_DataReceived;
            port.Open();
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = port.ReadLine();
            if (s.Length == 3)
            {
                Console.WriteLine(s);
                int level = Convert .ToInt32(s.Substring(0, 1));
                int drink = Convert.ToInt32(s.Substring(1, 1));
                StreamWriter sw = new StreamWriter("data", false);
                sw.WriteLine(level.ToString());
                sw.WriteLine(drink.ToString());
                sw.Close();
                if (level == 3 && level != prevel )
                {
                    Console.WriteLine("sent");
                    const string accountSid = "<stripped>";
                    const string authToken = "<stripped>";
                    TwilioClient.Init(accountSid, authToken);
                    MessageResource.Create(
                        from: new PhoneNumber("+14438636193"), // From number, must be an SMS-enabled Twilio number
                        to: new PhoneNumber("+381<stripped>"), // To number, if using Sandbox see note above
                                                              // Message content
                        body: "Cinija sa vodom vaseg psa je prazna");
                    lastsent = DateTime.Now;
                }
                prevel = level;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "00";
            Console.WriteLine(s);
            int level = Convert.ToInt32(s.Substring(0, 1));
            int drink = Convert.ToInt32(s.Substring(1, 1));
            StreamWriter sw = new StreamWriter("data", false);
            sw.WriteLine(level.ToString());
            sw.WriteLine(drink.ToString());
            sw.Close();
            if (level == 3 && level != prevel )
            {
                Console.WriteLine("sent");
                const string accountSid = "<stripped>";
                const string authToken = "<stripped>";
                TwilioClient.Init(accountSid, authToken);
                MessageResource.Create(
                    from: new PhoneNumber("+14438636193"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+381<stripped>"), // To number, if using Sandbox see note above
                                                          // Message content
                    body: "Cinija sa vodom vaseg psa je prazna");
                lastsent = DateTime.Now;
            }
            prevel = level;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "10";
            Console.WriteLine(s);
            int level = Convert.ToInt32(s.Substring(0, 1));
            int drink = Convert.ToInt32(s.Substring(1, 1));
            StreamWriter sw = new StreamWriter("data", false);
            sw.WriteLine(level.ToString());
            sw.WriteLine(drink.ToString());
            sw.Close();
            if (level == 3 && level != prevel)
            {
                Console.WriteLine("sent");
                const string accountSid = "<stripped>";
                const string authToken = "<stripped>";
                TwilioClient.Init(accountSid, authToken);
                MessageResource.Create(
                    from: new PhoneNumber("+14438636193"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+381<stripped>"), // To number, if using Sandbox see note above
                                                          // Message content
                    body: "Cinija sa vodom vaseg psa je prazna");
                lastsent = DateTime.Now;
            }
            prevel = level;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "20";
            Console.WriteLine(s);
            int level = Convert.ToInt32(s.Substring(0, 1));
            int drink = Convert.ToInt32(s.Substring(1, 1));
            StreamWriter sw = new StreamWriter("data", false);
            sw.WriteLine(level.ToString());
            sw.WriteLine(drink.ToString());
            sw.Close();
            if (level == 3 && level != prevel )
            {
                Console.WriteLine("sent");
                const string accountSid = "<stripped>";
                const string authToken = "<stripped>";
                TwilioClient.Init(accountSid, authToken);
                MessageResource.Create(
                    from: new PhoneNumber("+14438636193"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+381<stripped>"), // To number, if using Sandbox see note above
                                                          // Message content
                    body: "Cinija sa vodom vaseg psa je prazna");
                lastsent = DateTime.Now;
            }
            prevel = level;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "30";
            Console.WriteLine(s);
            int level = Convert.ToInt32(s.Substring(0, 1));
            int drink = Convert.ToInt32(s.Substring(1, 1));
            StreamWriter sw = new StreamWriter("data", false);
            sw.WriteLine(level.ToString());
            sw.WriteLine(drink.ToString());
            sw.Close();
            if (level == 3 && level != prevel)
            {
                Console.WriteLine("sent");
                const string accountSid = "<stripped>";
                const string authToken = "<stripped>";
                TwilioClient.Init(accountSid, authToken);
                MessageResource.Create(
                    from: new PhoneNumber("+14438636193"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+381<stripped>"), // To number, if using Sandbox see note above
                                                          // Message content
                    body: "Cinija sa vodom vaseg psa je prazna");
                lastsent = DateTime.Now;
            }
            prevel = level;
        }
    }
}
