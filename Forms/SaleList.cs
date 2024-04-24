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
    public partial class SaleList : Form
    {
        public SaleList()
        {
            InitializeComponent();
            MainPage.TextRead(MainPage.SaleHouseList);
            SalesHouseView(MainPage.SaleHouseList);
        }
        private void SalesHouseView(List<SaleHouse> saleHouses)
        {
            int layer = 0;
            foreach (SaleHouse saleHouse in saleHouses)
            {
                if (saleHouse.Active)
                {
                    Label typelabel = new Label();
                    typelabel.Text = saleHouse.HouseType.ToString();
                    typelabel.Location = new System.Drawing.Point(30, 15 + (75 * layer));
                    typelabel.Font = new Font("Ebrima", 10, FontStyle.Bold);
                    typelabel.AutoSize = true;

                    Label pasLabel = new Label();
                    pasLabel.Text = saleHouse.District + " / " + saleHouse.Area;
                    pasLabel.Location = new System.Drawing.Point(200, 16 + (75 * layer));
                    pasLabel.Font = new Font("Ebrima", 8, FontStyle.Bold);
                    pasLabel.AutoSize = true;

                    Label infoLabel = new Label();
                    infoLabel.Text = saleHouse.ToString();
                    infoLabel.Location = new System.Drawing.Point(30, 40 + (75 * layer));
                    infoLabel.Font = new Font("Ebrima", 8, FontStyle.Regular);
                    infoLabel.AutoSize = true;

                    this.Controls.Add(typelabel);
                    this.Controls.Add(infoLabel);
                    this.Controls.Add(pasLabel);
                    layer++;
                }
            }
        }
    }
}
