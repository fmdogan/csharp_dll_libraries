using System;
using System.Reflection;

namespace hesapla
{
    public class Hesapla
    {
        public int Hesaplama(int x)
        {
            Assembly topla_dll = Assembly.LoadFrom("topla.dll"); // Kendi bulunduğu dizinden dll'i bulup yükler
            Type topla_type = topla_dll.GetType("topla.Topla");
            object topla_instance = Activator.CreateInstance(topla_type); // Topla sınıfının bir örneğini oluşturur
            MethodInfo[] topla_methods = topla_type.GetMethods(); // topla dll'indeki tüm metodları diziye atar

            Assembly cikar_dll = Assembly.LoadFrom("cikar.dll"); 
            Type cikar_type = cikar_dll.GetType("cikar.Cikar");
            object cikar_instance = Activator.CreateInstance(cikar_type); 
            MethodInfo[] cikar_methods = cikar_type.GetMethods(); 

            Assembly carp_dll = Assembly.LoadFrom("carp.dll");
            Type carp_type = carp_dll.GetType("carp.Carp");
            object carp_instance = Activator.CreateInstance(carp_type);
            MethodInfo[] carp_methods = carp_type.GetMethods();

            Assembly bol_dll = Assembly.LoadFrom("bol.dll");
            Type bol_type = bol_dll.GetType("bol.Bol");
            object bol_instance = Activator.CreateInstance(bol_type);
            MethodInfo[] bol_methods = bol_type.GetMethods();

            // fonksiyon (2+x)*(x-3) ise sonuc = ifade1 + ifade2
            object ifade1 = topla_methods[0].Invoke(topla_instance, new object[] { 2, x }); // Dizideki ilk (ve tek) fonksiyona parametre gönderip çalıştırır
            object ifade2 = cikar_methods[0].Invoke(cikar_instance, new object[] { x, 3 });
            object sonuc = carp_methods[0].Invoke(carp_instance, new object[] { ifade1, ifade2 });

            return (int) sonuc;
        }
    }
}
