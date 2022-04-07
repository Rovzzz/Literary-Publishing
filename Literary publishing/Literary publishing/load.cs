using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Literary_publishing
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            panel4.Width += 3;
            if (panel4.Width >= 700)
            {
                timer1.Stop();
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void load_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
