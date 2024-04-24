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
    public partial class RentList : Form
    {
        public RentList()
        {
            InitializeComponent();
            MainPage.TextRead(MainPage.RentHouseList);
            SalesHouseView(MainPage.RentHouseList);
        }
        private void SalesHouseView<T>(List<T> rateHouses) where T : House
        {
            int layer = 0;
            System.Collections.IList list = rateHouses;
            for (int i = 0; i < list.Count; i++)
            {
                RentHouse rentHouse = (RentHouse)list[i];
                if (rentHouse.Active)
                {
                    Label typelabel = new Label();
                    typelabel.Text = rentHouse.HouseType.ToString();
                    typelabel.Location = new System.Drawing.Point(30, 15 + (75 * layer));
                    typelabel.Font = new Font("Ebrima", 10, FontStyle.Bold);
                    typelabel.AutoSize = true;

                    Label pasLabel = new Label();
                    pasLabel.Text = rentHouse.District + " / " + rentHouse.Area;
                    pasLabel.Location = new System.Drawing.Point(200, 16 + (75 * layer));
                    pasLabel.Font = new Font("Ebrima", 8, FontStyle.Bold);
                    pasLabel.AutoSize = true;

                    Label infoLabel = new Label();
                    infoLabel.Text = rentHouse.ToString();
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
