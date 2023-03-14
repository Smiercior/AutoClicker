using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        String choose1 = ""; // Special key
        String choose2 = ""; // Normal key
        bool ready = true;
        
        
        public Form1()
        {
            InitializeComponent();
            timer.Elapsed += new System.Timers.ElapsedEventHandler((sender,e) => SendKey(sender,e,choose1,choose2));

            // Set attributes
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.button2.Enabled = false;
            this.label5.Text = "Off";
            this.label5.ForeColor = Color.Red;
            this.label6.Text = "";

        }

        private void button1_Click(object sender, EventArgs e) // Start                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        {
            if(CheckReady() & ready) // If everything is selected
            {
                choose1 = comboBox1.SelectedItem.ToString();
                choose2 = textBox1.Text;
                timer.Interval = Convert.ToDouble(this.comboBox2.SelectedItem.ToString()) * 1000;
                timer.Enabled = true;

                // Set attributes
                this.button1.Enabled = false;
                this.button2.Enabled = true;
                this.label5.Text = "On";
                this.label5.ForeColor = Color.LightGreen;
            }    
        }

        private void button2_Click(object sender, EventArgs e) // Stop
        {
            timer.Enabled = false;

            // Set attributes
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            this.label5.Text = "Off";
            this.label5.ForeColor = Color.Red;

        }

        private void SendKey(object source, System.Timers.ElapsedEventArgs e, String cB1T, String tB1T)
        {
            if(cB1T != "None" & tB1T == "") // Someone choose special key
            {
                if(cB1T == "Space")
                {
                    SendKeys.SendWait(" ");
                }
                else if(cB1T == "Shift")
                {
                    SendKeys.SendWait("+");
                }
                else if(cB1T == "Ctrl")
                {
                    SendKeys.SendWait("^");
                }
                else if (cB1T == "Alt")
                {
                    SendKeys.SendWait("%");
                }
                else
                {
                    SendKeys.SendWait("{" + cB1T + "}");
                }
            }
            else if(cB1T == "None" & tB1T != "") // Someone choose normal key
            {
                SendKeys.SendWait(choose2);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "None") // Special key is set
            {
                this.label6.Text = "Set special keys to 'None'";
                this.textBox1.Text = "";
                ready = false;
            }
            else if(this.textBox1.Text.Length > 1) // User pass more than 1 char
            {
                this.label6.Text = "You can only pass one letter";
                ready = false;
            }
            else // Everything is good
            {
                this.label6.Text = "";
                ready = true;
            }
            
        }

        private bool CheckReady() // Check if everything is ready
        {
            if (comboBox1.SelectedItem.ToString() == "None" & textBox1.Text == "")
            {
                this.label6.Text = "Choose any key";
                return false;
            }
            else if (comboBox1.SelectedItem.ToString() != "None" & textBox1.Text != "")
            {
                this.label6.Text = "You can pass many keys at once";
                return false;
            }
            else if (this.textBox1.Text.Length > 1) // User pass more than 1 char
            {
                this.label6.Text = "You can only pass one key";
                return false;
            }
            else
            {    
                ready = true;
                this.label6.Text = "";
                return true;
            }
        }
    }
}
