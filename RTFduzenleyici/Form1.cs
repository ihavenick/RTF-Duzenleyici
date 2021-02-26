using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Xceed.Words.NET;
using System.Text.RegularExpressions;

namespace RTFduzenleyici
{
    public partial class Form1 : Form
    {
        private string DosyaAdi;
        private string DosyaYolu;
        private string kaydedilenDosya;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dosyaSec_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = dosyaSec;
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Filter = "Word Dosyası |*.docx";
            file.FilterIndex = 1;
            file.Title = "Word Dosyası Seçiniz..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = file.FileName;
                DosyaAdi = file.SafeFileName;
                txtCevrilcekYol.Text = DosyaYolu;
            }
        }

        private void btnCevrilmisDosyaSec_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = dosyaKaydet;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Title = "Dosyayı nereye kaydetmek istersiniz?";
            saveFileDialog.Filter = "Word Dosyası |*.docx";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                kaydedilenDosya = saveFileDialog.FileName;
                txtCevrilmisDosya.Text = kaydedilenDosya;
            }
        }

        public string tirnakCevirici(string gelen)
        {
            string pattern = @"[']+\w+[']";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(gelen, pattern, options))
            {
                string temp = m.Value;
                temp = temp.Substring(1, temp.Length - 2);
                temp = @"""" + temp + "\"";

                return gelen.Replace(m.Value, temp);
            }

            return gelen;
        }

        public string saatCevirici(string gelen)
        {
            string pattern = @"\d+\d+[:]+\d+\d";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(gelen, pattern, options))
            {
                string temp = "";
                string[] cumleler = gelen.Split(':');
                foreach (var cumle in cumleler)
                {
                    if (temp.Length == 0)
                    {
                        temp += cumleler[0];
                    }
                    else
                    {

                        temp = temp + "-" + cumle;
                    }
                }
                return temp;
            }

            return gelen;
        }

        public string sayiCevirici(string gelen)
        {
            string pattern = @"\d+[.]+\d";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(gelen, pattern, options))
            {
                string temp = "";
                string[] cumleler = gelen.Split('.');
                foreach (var cumle in cumleler)
                {
                    temp += cumle;
                }
                return temp;
            }

            return gelen;
        }

        public string satirsonuCizgiAlgilayici(string gelen)
        {
            string pattern = @"\w+[-]";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(gelen, pattern, options))
            {
                string temp = "";
                temp = gelen.TrimEnd('-');

                return temp;
            }

            return gelen;
        }


        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

        public static int RomanToInteger(string roman)
        {
            int number = 0;
            char previousChar = roman[0];
            foreach (char currentChar in roman)
            {
                number += RomanMap[currentChar];
                if (RomanMap[previousChar] < RomanMap[currentChar])
                {
                    number -= RomanMap[previousChar] * 2;
                }
                previousChar = currentChar;
            }
            return number;
        }

        public string romenRakamCevirici(string gelen)
        {
            string pattern = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            RegexOptions options = RegexOptions.Multiline;

            string[] cumleler = gelen.Split(' ');
            string temp = "";
            bool degisti = false;
            bool yazma = false;
            foreach (var cumle in cumleler)
            {
                if (cumle.Length > 0)
                {
                    yazma = false;
                    foreach (Match m in Regex.Matches(cumle, pattern, options))
                    {
                        int cevrilen = RomanToInteger(cumle);
                        degisti = true;
                        yazma = true;
                        temp += " " + cevrilen.ToString();
                    }
                    if (!yazma)
                    {
                        temp += " " + cumle;
                    }

                }
            }
            if (degisti)
            {
                return temp;
            }
            return gelen;
        }

        public string satirbasiAlintiCevirici(string gelen)
        {
            string pattern = @"(^|\s)[-]+\w";
            RegexOptions options = RegexOptions.Multiline;


            foreach (Match m in Regex.Matches(gelen, pattern, options))
            {
                string temp = "";
                temp += "-" + gelen;
                return temp;

            }

            return gelen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DosyaYolu.Length != 0 && kaydedilenDosya.Length != 0)
            {

                using (DocX acilanDosya = DocX.Load(DosyaYolu))
                {

                    foreach (Paragraph p in acilanDosya.Paragraphs)
                    {
                        string temp = p.Text;
                        string temp2 = "  ";
                        int birparagraftakiAltiCizililer = 0;
                        foreach (var item in p.MagicText)
                        {
                            if (item.formatting != null)
                            {
                                

                                if (item.formatting.UnderlineStyle == UnderlineStyle.singleLine)
                                {
                                    birparagraftakiAltiCizililer += 1;

                                    string[] cumleler = item.text.Split(' ');

                                    foreach (var cumle in cumleler)
                                    {
                                        temp2 += " (i) " + cumle;
                                    }


                                    //temp2 += " (i)" + item.text;
                                }
                                else
                                {
                                    temp2 += item.text;
                                }
                            }
                            else
                            {
                                temp2 += item.text;
                            }
                        }


                        p.ReplaceText(temp, temp2);

                        p.ReplaceText(temp, tirnakCevirici(temp));
                        p.ReplaceText(temp, sayiCevirici(temp));
                        p.ReplaceText(temp, satirsonuCizgiAlgilayici(temp));
                        p.ReplaceText(temp, satirbasiAlintiCevirici(temp));
                        p.ReplaceText(temp, romenRakamCevirici(temp));
                        p.ReplaceText(temp, saatCevirici(temp));
                    }

                    acilanDosya.ReplaceText("- -", "--");
                    acilanDosya.SaveAs(kaydedilenDosya);
                    MessageBox.Show("Kayıt başarılı.");
                }
            }
        }
    }
}
