using System;

namespace hafta4_odev1_ikiKisilikPistiOyunu
{
    public class Menu
    {
        public void Olustur()
        {
            // Menü içerisinde oyun başında kurallar ve başlatma komutu bulunuyor. Bunları Program.cs içersinde yazmak istemedim.
            // Zaten Program.cs yeterince uzun bir kod. Hatta Oyun, Oyuncu ve Menu sınıflarını da Program.cs dışında oluşturdum kalabalık etmemek için.

            Console.WriteLine("Sadi Enis Güçlüer - \n\n ZarOyunu");

            Console.Write("\n\n\nMENU\n");

            Cizgi();

            Console.Write("PİŞTİYE HOŞ GELDİNİZ\n");
            Console.WriteLine("Oyunun kuralları kısaca şu şekilde: " +
                "İki kişiyle oynamaktayız. Deste oyuncunun doğum günü sayısınca karılır. Oyun başında oyunculara dörder kağıt dağıtılır. " +
                "Yere üç kapalı bir açık dört kart konur. Oyuncular sırasıyla kağıtlarından birini yere atarlar. " +
                "Oyuncuların elindeki kartlar bitince dörder tekrar dağıtılır. " +
                "Son atan oyuncunu attığı kağıt yerdeki kağıt ile aynı ise o oyunucu yerdeki tüm kağıtları alır ve hanesine ekler. " +
                "Aynı olma durumu desene göre olmaz sayısı(ya da J-Q-K-A) aynı olan kartlar aynı sayılır. " +
                "Aynı kartlar ile alma durumu dışında vale(J) kartı önceki kartın ne olduğunun bir önemi olmaksızın yerdeki tüm kartları toplar. ");


            Console.WriteLine("\n\n\nPUANLAMA ");
            Cizgi();
            Console.WriteLine("6 tür puan alma şekli vardır. " +
                "As kartları birer puan, " +
                "♣-2 iki puan, " +
                "♦-10 3 puan, " +
                "vale(J) kartları birer puan, " +
                "pişti 10 puan değerindedir. Vale ile pişti yaparsanız 20 puan kazanırsınız. " +
                "Ayrıca kart sayısı rakibin hanesindeki  kart sayısından fazla olan oyuncu 3 puan kazanır. " +
                "Deste bittiğinde puanı fazla olan oyuncu oyunu kazanır. ");
            Console.WriteLine("Pişti yapmak: Şayet yerde sadece bir kart varsa ve " +
                "siz de aynı kartı atmışsanız PİŞTİ yapmış olursunuz. ");


            Console.WriteLine("\n\n\nOyuna başlamak için ENTER\nİyi Şanslar... ");

            Cizgi();
            Console.ReadLine();
            Console.Clear();
        }
        private void Cizgi()
        {
            Console.WriteLine("------------------------------");
        }
    }
}
