using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmlakClassLibrary;

namespace Emlak
{
    public partial class SearchHouse : Form
    {
        string[]? lines;
        private static SearchHouse instance;
        public static SearchHouse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SearchHouse();
                }
                return instance;
            }
        }
        public SearchHouse()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            int layer = 0;
            if (Sell.Checked){
                lines = File.ReadAllLines("satilik.txt", Encoding.UTF8);
            }
            if (Rent.Checked) {
                lines = File.ReadAllLines("kiralik.txt", Encoding.UTF8);
            }
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                SearchFonk(layer, parts);
                layer++;
            }
        }

        private void SearchFonk(int layer, string[] parts)
        {
            HouseType house = (HouseType)Enum.Parse(typeof(HouseType), parts[0]);
            int room = Convert.ToInt32(parts[1]);
            bool active = bool.Parse(parts[2]);
            int floor = Convert.ToInt32(parts[3]);
            DateTime constDate = DateTime.ParseExact(parts[7], "yyyy-MM", null);
            if ((HouseType)Enum.Parse(typeof(HouseType), comboBox.Text) == house &&
                checkBox1.Checked == active && comboBox1.Text == parts[5] &&
                DateTime.Now.Year - constDate.Year == numericUpDown.Value
                )
            {
                SearchView(layer, parts, house, room, active, floor, constDate);
            }
        }

        public void SearchView(int layer, string[] parts, HouseType house, int room, bool active, int floor, DateTime constDate)
        {
            Label typelabel = new Label();
            typelabel.Text = house.ToString();
            typelabel.Location = new System.Drawing.Point(30, 130 + (75 * layer));
            typelabel.Font = new Font("Ebrima", 10, FontStyle.Bold);
            typelabel.AutoSize = true;

            Label pasLabel = new Label();
            pasLabel.Text = parts[4] + " / " + parts[5];
            pasLabel.Location = new System.Drawing.Point(200, 131 + (75 * layer));
            pasLabel.Font = new Font("Ebrima", 8, FontStyle.Bold);
            pasLabel.AutoSize = true;

            Label infoLabel = new Label();
            infoLabel.Text = active.ToString() + "  Oda sayısı : " + room +
                "  Kat sayısı : " + floor + "  Yapım tarihi : " + constDate +
                "  Fiyat / Depozito : " + parts[6];
            infoLabel.Location = new System.Drawing.Point(30, 160 + (75 * layer));
            infoLabel.Font = new Font("Ebrima", 8, FontStyle.Regular);
            infoLabel.AutoSize = true;

            this.Controls.Add(typelabel);
            this.Controls.Add(infoLabel);
            this.Controls.Add(pasLabel);
        }
    }
}
