using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Raport_domowych_wydatków
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            decimal kwota;
            string gdzie;
            int dzien, miesiac, rok;

            bool sp_kwota = false, sp_dzien = false, sp_miesiac = false, sp_rok = false;


            //Sprawdzenie poprawności wpisanych danych 
            /*************************************************************/
            if (decimal.TryParse(textBox1.Text, out kwota))
            {
                sp_kwota = true;
            }
            gdzie = textBox2.Text;
            int.TryParse(textBox3.Text, out dzien);
            int.TryParse(textBox4.Text, out miesiac);
            int.TryParse(textBox5.Text, out rok);

            if ((dzien >= 1) && (dzien <= 31))
            {
                sp_dzien = true;

                if ((miesiac >= 1) && (miesiac <= 12))
                {
                    sp_miesiac = true;

                    if (rok >= 2005)
                    {
                        sp_rok = true;
                    }
                }
            }
            /*************************************************************************/
            //koniec sprawdzania poprawności wpisanych danych

            //jeżeli dane wypisane w nawiasach mają wartość bool=true, 
            //wtedy wykona się metoda "ZapisDoRaportuMiesięcznego"
            if (sp_kwota && sp_dzien && sp_miesiac && sp_rok)
            {
                ZapisDoRaportuMiesięcznego(miesiac, kwota, gdzie, dzien, rok);

                try
                {
                    string pokazRaport;
                    StreamReader podgladRaportu;
                    podgladRaportu = File.OpenText("raport.txt");

                    CzyszczenieListBox1();
                    while (!podgladRaportu.EndOfStream)
                    {
                        pokazRaport = podgladRaportu.ReadLine();
                        listBox1.Items.Add(pokazRaport);
                    }
                    podgladRaportu.Close();

                    listBox1.TopIndex = listBox1.Items.Count - 1;//wyświetla ostatnią pozycję w listBox1
                    podgladRaportu.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Popraw dane");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CzyszczenieListBox1();
            try
            {
                string odczytaneDane;
                StreamReader odczytPlik;

                odczytPlik = File.OpenText("raport.txt");

                while (!odczytPlik.EndOfStream)
                {
                    odczytaneDane = odczytPlik.ReadLine();
                    listBox1.Items.Add(odczytaneDane);
                }
                odczytPlik.Close();
                listBox1.TopIndex = listBox1.Items.Count - 1;//wyświetla ostatnią pozycję w listBox1
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string linia;
                double suma = 0, liczba;
                openFileDialog.Title = "Otwórz";
                StreamReader openFile;

                try
                {
                    openFile = File.OpenText(openFileDialog.FileName);

                    while (!openFile.EndOfStream)
                    {
                        linia = openFile.ReadLine();
                        listBox1.Items.Add(linia + "zł");
                        double.TryParse(linia, out liczba);
                        suma = suma + liczba;
                    }
                    label4.Text = suma.ToString("c");

                    openFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //*****Metody:
        private void CzyszczenieListBox1()
        {
            listBox1.Items.Clear();
        }
        private void ZapisDoRaportuMiesięcznego(int miesiac, decimal kwota, string gdzie, int dzien, int rok)
        {
            try
            {
                StreamWriter zapisPlikmiesiac;

                switch (miesiac)
                {
                    case 1:
                        {
                            zapisPlikmiesiac = File.AppendText("styczen.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 2:
                        {
                            zapisPlikmiesiac = File.AppendText("luty.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 3:
                        {
                            zapisPlikmiesiac = File.AppendText("marzec.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 4:
                        {
                            zapisPlikmiesiac = File.AppendText("kwiecien.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 5:
                        {
                            zapisPlikmiesiac = File.AppendText("maj.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 6:
                        {
                            zapisPlikmiesiac = File.AppendText("czerwiec.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 7:
                        {
                            zapisPlikmiesiac = File.AppendText("lipiec.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 8:
                        {
                            zapisPlikmiesiac = File.AppendText("sierpien.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 9:
                        {
                            zapisPlikmiesiac = File.AppendText("wrzesien.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 10:
                        {
                            zapisPlikmiesiac = File.AppendText("pazdziernik.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 11:
                        {
                            zapisPlikmiesiac = File.AppendText("listopad.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                    case 12:
                        {
                            zapisPlikmiesiac = File.AppendText("grudzien.txt");
                            zapisPlikmiesiac.WriteLine(kwota);
                            zapisPlikmiesiac.Close();
                            break;
                        }
                }
                StreamWriter zapisPlikraport;
                zapisPlikraport = File.AppendText("raport.txt");

                zapisPlikraport.WriteLine(kwota + "zł" + "   " + gdzie.ToUpper() + "   " + dzien.ToString("d2") + "." + miesiac.ToString("d2") + "." + rok);
                zapisPlikraport.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

