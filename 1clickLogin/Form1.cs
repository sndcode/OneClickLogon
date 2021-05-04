using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace _1clickLogin
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void m_SaveSettings()
        {
            try
            {
                if (File.Exists("C:\\users\\public\\oneclick.db"))
                {
                    var ini = new classINI("C:\\users\\public\\oneclick.db");
                    ini.Write("username1", textBox1.Text);
                    ini.Write("password1", classAtom128.Encode(textBox2.Text));
                    ini.Write("username2", textBox3.Text);
                    ini.Write("password2", classAtom128.Encode(textBox4.Text));
                    ini.Write("username3", textBox5.Text);
                    ini.Write("password3", classAtom128.Encode(textBox6.Text));
                    ini.Write("username4", textBox7.Text);
                    ini.Write("password4", classAtom128.Encode(textBox8.Text));
                }
                else
                {
                    File.Create("C:\\users\\public\\oneclick.db").Close();//Close file after spawning
                    var ini = new classINI("C:\\users\\public\\oneclick.db");
                    ini.Write("username1", textBox1.Text);
                    ini.Write("password1", classAtom128.Encode(textBox2.Text));
                    ini.Write("username2", textBox3.Text);
                    ini.Write("password2", classAtom128.Encode(textBox4.Text));
                    ini.Write("username3", textBox5.Text);
                    ini.Write("password3", classAtom128.Encode(textBox6.Text));
                    ini.Write("username4", textBox7.Text);
                    ini.Write("password4", classAtom128.Encode(textBox8.Text));
                }
            }
            catch
            {
                File.Create("C:\\users\\public\\oneclick.db").Close();//Close file after spawning
            }
        }
        public void m_loadSettings()
        {
            try
            {
                if (File.Exists("C:\\users\\public\\oneclick.db"))
                {
                    var ini = new classINI("C:\\users\\public\\oneclick.db");
                    textBox1.Text = ini.Read("username1");
                    textBox2.Text = classAtom128.Decode(ini.Read("password1"));
                    textBox3.Text = ini.Read("username2");
                    textBox4.Text = classAtom128.Decode(ini.Read("password2"));
                    textBox5.Text = ini.Read("username3");
                    textBox6.Text = classAtom128.Decode(ini.Read("password3"));
                    textBox7.Text = ini.Read("username4");
                    textBox8.Text = classAtom128.Decode(ini.Read("password4"));

                }
                else
                {
                    File.Create("C:\\users\\public\\oneclick.db").Close();//Close file after spawning
                    var ini = new classINI("C:\\users\\public\\oneclick.db");
                    ini.Write("username1", textBox1.Text);
                    ini.Write("password1", classAtom128.Encode(textBox2.Text));
                    ini.Write("username2", textBox3.Text);
                    ini.Write("password2", classAtom128.Encode(textBox4.Text));
                    ini.Write("username3", textBox5.Text);
                    ini.Write("password3", classAtom128.Encode(textBox6.Text));
                    ini.Write("username4", textBox7.Text);
                    ini.Write("password4", classAtom128.Encode(textBox8.Text));
                }
            }
            catch
            {
                File.Create("C:\\users\\public\\oneclick.db").Close();//Close file after spawning
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            m_SaveSettings();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Website will launch in default broser now");
            System.Diagnostics.Process.Start("http://");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i_accselected = 0;
            if(radioButton1.Checked == true)
            {
                i_accselected = 1;
            }
            else if (radioButton2.Checked == true)
            {
                i_accselected = 2;
            }
            else if (radioButton3.Checked == true)
            {
                i_accselected = 3;
            }
            else if (radioButton4.Checked == true)
            {
                i_accselected = 4;
            }


            try
            {
                if (File.Exists("C:\\users\\public\\oneclick.db") && i_accselected != 0)
                {
                    //Retrieve saved ones
                    //Timer waiter = new Timer();
                    //waiter.Interval = 2500;
                    //waiter.Start();
                    System.Threading.Thread.Sleep(2100);
                    //Free some ram
                    //Do Login
                    // Find The Window Handle For VPN
                    //IntPtr handle = FindWindow("Pulse", "PulseApplicationLauncher");
                    //if (!handle.Equals(IntPtr.Zero))
                    //{
                    // Activate The VPN Window
                    //if (SetForegroundWindow(handle))

                    //var proc = Process.GetProcessesByName("Verbinden mit:SAPROV").FirstOrDefault();
                    //if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
                    //{
                    //SetForegroundWindow(proc.MainWindowHandle);

                    string selectedUser = "";
                    string selectedPass = "";
                    
                    if(i_accselected == 1)
                    {
                        selectedUser = textBox1.Text;
                        selectedPass = textBox2.Text;
                    }
                    else if (i_accselected == 2)
                    {
                        selectedUser = textBox3.Text;
                        selectedPass = textBox4.Text;
                    }
                    else if (i_accselected == 3)
                    {
                        selectedUser = textBox5.Text;
                        selectedPass = textBox6.Text;
                    }
                    else if (i_accselected == 4)
                    {
                        selectedUser = textBox7.Text;
                        selectedPass = textBox8.Text;
                    }

                    SendKeys.Send(selectedUser);
                    System.Threading.Thread.Sleep(500);//Free some ram
                    SendKeys.Send("{TAB}");
                    System.Threading.Thread.Sleep(500);//Free some ram
                    SendKeys.Send(selectedPass);
                    System.Threading.Thread.Sleep(500);//Free some ram
                    SendKeys.Send("{ENTER}");
                }
                else
                {
                    File.Create("C:\\users\\public\\oneclick.db").Close();//Close file after spawning
                }
            }
            catch
            {
                MessageBox.Show("Error while logging in. Make sure you entered logins and clicked a button which account to use.");
            }
        }

        private bool SetForegroundWindow(IntPtr handle)
        {
            throw new NotImplementedException();
        }

        private IntPtr FindWindow(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\users\\public\\oneclick.db"))
            {
                m_loadSettings();
            }
            else
            {
                MessageBox.Show("no settings found, please enter login data and click save.");
            }
        }
    }
}
