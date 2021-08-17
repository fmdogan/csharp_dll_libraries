using System;
using System.Reflection;
using System.Windows.Forms;

namespace _161213005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;

            int sayi;
            bool isSayi = int.TryParse(textBox1.Text, out sayi); // TextBox a girilen bir integer sayı ise true döndürür 
                                                                 // ve girilen sayıyı, sayi değişkenine atar

            if ((textBox1.Text.StartsWith("-") && (textBox1.Text.Length < 2)) || isSayi) // Negatif integer sayıların da girilebilmesi için
                                                  // - sonrasında sayıdan başka bir      // - işaretinden sonra 1 karakter daha girilmeden önce 
                                                  // karakter girilmesini önler          // textBoxları sıfırlamaz
            {
                Assembly hesapla_dll = Assembly.LoadFrom("hesapla.dll"); // dll'i yükler
                Type hesapla_type = hesapla_dll.GetType("hesapla.Hesapla");
                object hesapla_instance = Activator.CreateInstance(hesapla_type); // Hesapla sınıfının bir örneğini oluşturur
                MethodInfo[] hesapla_methods = hesapla_type.GetMethods(); // hesapla dll'indeki tüm metodları diziye atar

                object result = hesapla_methods[0].Invoke(hesapla_instance, new object[] { sayi }); // Girilen sayıyı dll e gönderir, 
                                                                                                    // işlemi yapar ve sonucu result'a atar
                textBox3.Text = result.ToString(); // Sonucu, sonuc textBox ına atar
            }
            else // Sayıdan başka bir şey girilmişse textBoxları sıfırlar
            {
                textBox1.Text = "";
                textBox3.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //
        {
            textBox1.Text = textBox2.Text;
        }
    }
}
