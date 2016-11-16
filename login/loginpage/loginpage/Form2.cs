using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginpage
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void logoff(object sender, EventArgs e)
        {
            MessageBox.Show("Logoff Successful");
            this.Hide();
            Form1 logoffsuccess = new Form1();
            logoffsuccess.Show();
        }
    }
}
