using System;
using System.Collections;

namespace hafta4_odev1_ikiKisilikPistiOyunu
{
    public class Oyun
    {
        public ArrayList Deste = new ArrayList();
        public ArrayList YerdekiKartlar = new ArrayList();
        public void DesteOlustur()
        {
            string[] desteArray = new string[] // Bir desteyi tek tek eklememek için diziye yazdım. Aşağıda foreach ile ekleme yaptım.
            {
                "♣ A", "♣ 2", "♣ 3", "♣ 4", "♣ 5", "♣ 6", "♣ 7", "♣ 8", "♣ 9", "♣ 10", "♣ J", "♣ Q", "♣ K",
                "♠ A", "♠ 2", "♠ 3", "♠ 4", "♠ 5", "♠ 6", "♠ 7", "♠ 8", "♠ 9", "♠ 10", "♠ J", "♠ Q", "♠ K",
                "♦ A", "♦ 2", "♦ 3", "♦ 4", "♦ 5", "♦ 6", "♦ 7", "♦ 8", "♦ 9", "♦ 10", "♦ J", "♦ Q", "♦ K",
                "♥ A", "♥ 2", "♥ 3", "♥ 4", "♥ 5", "♥ 6", "♥ 7", "♥ 8", "♥ 9", "♥ 10", "♥ J", "♥ Q", "♥ K"
            };

            foreach (var item in desteArray)
                Deste.Add(item);
        }
        public void DesteKaristir()
        {
            Random rndm = new Random();
            int count = Deste.Count;
            while (count > 1)  // Desteyi karmak için bir döngü kullandım.
                               // Önce rastgele sayıdan gelen Deste değerini tuttuk. Sonra da onu destenin random bir ögesine attık.
                               // İşlemi count kez yapınca deste karılmış oldu. Bir public metot yazptığım için kullanıcı istediği kez karabilir.
            {
                count--;
                int rndmSayi = rndm.Next(count + 1);
                object objDeger = Deste[rndmSayi];
                Deste[rndmSayi] = Deste[count];
                Deste[count] = objDeger;
            }
        }
        public object RastgeleKart()
        {
            Random random = new Random();
            int sayi = random.Next(0,Deste.Count);
            object Kart = Deste[sayi];
            Deste.RemoveAt(sayi);
            return Kart;
        }
        public void YereEkle(object value)
        {
            YerdekiKartlar.Add(value);
        }
    }
    public class Oyuncu
    {
        public string Adi;
        public DateTime DogumTarihi;
        public int DogumGunu;

        public int A; // 1 puan
        public int J; // 1 puan
        public int sinek2; // 2 puan
        public int karo10; // 3 puan
        public int PistiSayisi; // 10 puan
        public int ValePistiSayi; // 20 puan
        public int Puan;

        public ArrayList Kartlari = new ArrayList();
        public ArrayList ToplananKartlar = new ArrayList();
        public void OyuncuEkle()
        {
            Console.Write("Oyuncu adı: ");
            this.Adi = Console.ReadLine();

            Console.Write("Oyuncu doğum tarihi(örnek: {0}.{1}.{2}): ", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            this.DogumTarihi = Convert.ToDateTime(Console.ReadLine());
            DogumGunu = DogumTarihi.Day;
        }
    }
}
