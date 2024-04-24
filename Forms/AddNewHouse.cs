using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class AddNewHouse : Form
    {
        public AddNewHouse()
        {
            InitializeComponent();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as NumericUpDown).Value < 0)
            {
                (sender as NumericUpDown).Value = 0;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Metin kutusunu boş bırakamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Sell.Checked){
                SaveLine("satilik.txt");
            }
            else if (Rent.Checked){
                SaveLine("kiralik.txt");
            }
            MessageBox.Show("Kaydedildi!", "Success");
        }
        private void SaveLine(string path)
        {
            File.AppendAllText(path, "\n" +
                    comboBox.Text + " " +
                    numericUpDownRoom.Value.ToString() + " " +
                    (checkBox1.Checked ? "true" : "false") + " " +
                    numericUpDownRoom.Value.ToString() + " " +
                    textBox1.Text + " " +
                    comboBox1.Text + " " +
                    numericUpDown1.Value.ToString() + " " +
                    dateTimePicker1.Value.Year.ToString() + "-" +
                    dateTimePicker1.Value.Month.ToString());
        }
    }
}
