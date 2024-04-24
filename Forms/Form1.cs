using EmlakClassLibrary;
namespace Emlak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dosyaYolu = "C:\\Users\\Bahadir\\source\\repos\\Emlak\\bin\\Debug\\net6.0-windows\\users.txt";

            // StreamReader kullanarak dosyay� a�
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                string satir;

                // Dosyan�n sonuna kadar sat�r sat�r oku
                while ((satir = sr.ReadLine()) != null)
                {
                    // Sat�r� bo�luklara g�re ay�r
                    string[] kelimeler = satir.Split(' ');

                    // Belirli bir �art sa�land���nda sat�r� ekrana yazd�r
                    if (kelimeler.Length > 1 &&
                        kelimeler[0] == idtextBox.Text &&
                        kelimeler[1] == passwordtextBox.Text)
                    {
                        MainPage mainPage = new MainPage();
                        mainPage.Show();
                    }
                }
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true; // Bo�luk karakterini i�leme almay� engelle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp form2 = new SignUp();
            form2.Show();
        }
    }
}