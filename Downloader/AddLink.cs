using System;
using System.Windows.Forms;

namespace Downloader
{
    public partial class AddLink : Form
    {
        public AddLink()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Data._URL = textBox1.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}