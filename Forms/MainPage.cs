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
    public partial class MainPage : Form
    {
        public static List<SaleHouse> SaleHouseList = new List<SaleHouse>();
        public static List<RentHouse> RentHouseList = new List<RentHouse>();
        public MainPage()
        {
            InitializeComponent();
        }
        public void loadForm(object Form)
        {
            if (this.panel.Controls.Count > 0)
                this.panel.Controls.RemoveAt(0);
            Form f=Form as Form;
            f.TopLevel = false;
            //f.Dock = DockStyle.Fill;
            f.StartPosition = FormStartPosition.CenterParent;
            this.panel.Controls.Add(f);
            this.panel.Tag = f;
            f.Show();
        }
        public static void TextRead<T> (List<T> inputList) where T : House
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }
            inputList.Clear();
             if (typeof(T) == typeof(SaleHouse)) {
                SaleHouseList = SaleHouse.CreateProduct();}
             else if (typeof(T) == typeof(RentHouse)){
                RentHouseList = RentHouse.CreateProduct();}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new SaleList());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new RentList());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new AddNewHouse());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadForm(SearchHouse.Instance);
        }
    }
}
