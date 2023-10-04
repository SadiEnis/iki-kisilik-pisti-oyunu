using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace hafta4_odev1_ikiKisilikPistiOyunu
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Menü

            Menu menu = new Menu();
            menu.Olustur();

            Oyuncu oyuncu1 = new Oyuncu();
            Oyuncu oyuncu2 = new Oyuncu();

            Console.WriteLine("Birinci oyuncu bilgilerini giriniz.");
            oyuncu1.OyuncuEkle();
            Console.WriteLine();

            Console.WriteLine("İkinci oyuncu bilgilerini giriniz.");
            oyuncu2.OyuncuEkle();
            Console.WriteLine();

            #endregion

            #region Başlangıç

            Oyun pisti = new Oyun();
            pisti.DesteOlustur();

            Console.WriteLine("Desteyi birinci oyuncu doğum günü kadar karıyor...");
            for (int i = 0; i < oyuncu1.DogumGunu; i++)
                pisti.DesteKaristir();
            Thread.Sleep(2000);
            Console.WriteLine("Birinci oyuncu desteyi kardı. Oyuna ikinci oyuncu başlayacak.\n");

            for (int i = 0; i < 4; i++)
                pisti.YerdekiKartlar.Add(pisti.RastgeleKart());



            #endregion

            #region Oyun
            for (int a = 0; a < 6; a++)
            {
                for (int r = 0; r < 4; r++)
                {
                    oyuncu2.Kartlari.Add(pisti.RastgeleKart());
                    oyuncu1.Kartlari.Add(pisti.RastgeleKart());
                }
                Console.WriteLine("\n\nKartlar dağıtıldı.");

                for (int i = 0; i < 4; i++) // 52 bölü 4 13tür. 4ü yere konur. 12 dörtlü kalır geriye. 6 kez oynanır.
                {

                    YerdekiKartlar();
                    Oyuncu2Oyna();

                    YerdekiKartlar();
                    Oyuncu1Oyna();
                }
            }
            #endregion

            #region Puanlama

            if (oyuncu1.ToplananKartlar.Contains("♣ 2"))
                oyuncu1.sinek2++;
            if (oyuncu1.ToplananKartlar.Contains("♦ 10"))
                oyuncu1.karo10++;
            if (oyuncu2.ToplananKartlar.Contains("♣ 2"))
                oyuncu2.sinek2++;
            if (oyuncu2.ToplananKartlar.Contains("♦ 10"))
                oyuncu2.karo10++;

            oyuncu1.Puan = AsPuanlamaOyuncu1() * 1 + ValePuanlamaOyuncu1() * 1 + oyuncu1.sinek2 * 2 + oyuncu1.karo10 * 3 + oyuncu1.PistiSayisi * 10 + oyuncu1.ValePistiSayi * 20;
            oyuncu2.Puan = AsPuanlamaOyuncu2() * 1 + ValePuanlamaOyuncu2() * 1 + oyuncu2.sinek2 * 2 + oyuncu2.karo10 * 3 + oyuncu2.PistiSayisi * 10 + oyuncu2.ValePistiSayi * 20;

            if (oyuncu1.ToplananKartlar.Count > oyuncu2.ToplananKartlar.Count)
                oyuncu1.Puan += 3;
            else if (oyuncu1.ToplananKartlar.Count < oyuncu2.ToplananKartlar.Count)
                oyuncu2.Puan += 3;
            #endregion

            #region Sonuç


            Console.Clear();
            Console.WriteLine("OYUN SONU");
            Console.WriteLine();

            if (oyuncu1.Puan > oyuncu2.Puan)
            {
                Console.WriteLine(oyuncu1.Adi + " Kazandı.");
                Console.WriteLine(oyuncu1.Adi + " Toplam puanı: " + oyuncu1.Puan);
                Console.WriteLine(oyuncu2.Adi + " Toplam puanı: " + oyuncu2.Puan);
            }
            else if (oyuncu1.Puan < oyuncu2.Puan)
            {
                Console.WriteLine(oyuncu2.Adi + " Kazandı.");
                Console.WriteLine(oyuncu1.Adi + " Toplam puanı: " + oyuncu1.Puan);
                Console.WriteLine(oyuncu2.Adi + " Toplam puanı: " + oyuncu2.Puan);
            }
            else
            {
                Console.WriteLine("Berabere!");
                Console.WriteLine(oyuncu1.Adi + " Toplam puanı: " + oyuncu1.Puan);
                Console.WriteLine(oyuncu2.Adi + " Toplam puanı: " + oyuncu2.Puan);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write
                (oyuncu1.Adi + "Toplanan kartlar: ");
            foreach (var item1 in oyuncu1.ToplananKartlar)
            {
                Console.Write(" " + item1);
            }
            Console.WriteLine();
            Console.Write(oyuncu2.Adi + " Toplanan Kartları: ");
            foreach (var item2 in oyuncu2.ToplananKartlar)
            {
                Console.Write(" " + item2);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0} Pişti sayısı: {1}\t Vale Pişti sayısı: {2}", oyuncu1.Adi, oyuncu1.PistiSayisi, oyuncu1.ValePistiSayi);
            Console.WriteLine("{0} Pişti sayısı: {1}\t Vale Pişti sayısı: {2}", oyuncu2.Adi, oyuncu2.PistiSayisi, oyuncu2.ValePistiSayi);

            #endregion

            #region Metotlar

            int AsPuanlamaOyuncu1()
            {
                if (oyuncu1.ToplananKartlar.Contains("♥ A"))
                {
                    oyuncu1.A++;
                }
                if (oyuncu1.ToplananKartlar.Contains("♦ A"))
                {
                    oyuncu1.A++;
                }
                if (oyuncu1.ToplananKartlar.Contains("♣ A"))
                {
                    oyuncu1.A++;
                }
                if (oyuncu1.ToplananKartlar.Contains("♠ A"))
                {
                    oyuncu1.A++;
                }
                return oyuncu1.A;
            }
            int AsPuanlamaOyuncu2()
            {
                if (oyuncu2.ToplananKartlar.Contains("♥ A"))
                {
                    oyuncu2.A++;
                }
                if (oyuncu2.ToplananKartlar.Contains("♦ A"))
                {
                    oyuncu2.A++;
                }
                if (oyuncu2.ToplananKartlar.Contains("♣ A"))
                {
                    oyuncu2.A++;
                }
                if (oyuncu2.ToplananKartlar.Contains("♠ A"))
                {
                    oyuncu2.A++;
                }
                return oyuncu2.A;
            }

            int ValePuanlamaOyuncu1()
            {
                if (oyuncu1.ToplananKartlar.Contains("♥ J"))
                {
                    oyuncu1.J++;
                }
                if (oyuncu1.ToplananKartlar.Contains("♦ J"))
                {
                    oyuncu1.J++;
                }
                if (oyuncu1.ToplananKartlar.Contains("♣ J"))
                {
                    oyuncu1.J++;
                }
                if (oyuncu1.ToplananKartlar.Contains("♠ J"))
                {
                    oyuncu1.J++;
                }
                return oyuncu1.J;
            }
            int ValePuanlamaOyuncu2()
            {
                if (oyuncu2.ToplananKartlar.Contains("♥ J"))
                {
                    oyuncu2.J++;
                }
                if (oyuncu2.ToplananKartlar.Contains("♦ J"))
                {
                    oyuncu2.J++;
                }
                if (oyuncu2.ToplananKartlar.Contains("♣ J"))
                {
                    oyuncu2.J++;
                }
                if (oyuncu2.ToplananKartlar.Contains("♠ J"))
                {
                    oyuncu2.J++;
                }
                return oyuncu2.J;
            }

            int kartNo;
            void Oyuncu1KartTopla()
            {
                if (pisti.YerdekiKartlar.Count == 2 && (((string)pisti.YerdekiKartlar[0]).Split(' ')[1] == ((string)oyuncu1.Kartlari[kartNo]).Split(' ')[1]))
                {
                    if (((string)pisti.YerdekiKartlar[0]).Split(' ')[1] == ((string)oyuncu1.Kartlari[kartNo]).Split(' ')[1])
                    {
                        oyuncu1.PistiSayisi++;
                    }
                    else if (((string)pisti.YerdekiKartlar[0]).Split(' ')[1] == "J" && 
                            ((string)oyuncu1.Kartlari[kartNo]).Split(' ')[1] == "J")
                    {
                        oyuncu1.ValePistiSayi++;
                    }
                    for (int j = 0; j < pisti.YerdekiKartlar.Count; j++)
                        oyuncu1.ToplananKartlar.Add(pisti.YerdekiKartlar[j]);
                    pisti.YerdekiKartlar.Clear();
                }
                else if (pisti.YerdekiKartlar.Count > 1)
                {
                    if (((string)pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 1]).Split((' '))[1] == "J" ||
                        ((string)pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 2]).Split((' '))[1] ==
                        ((string)pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 1]).Split((' '))[1])
                    {      // Split kullan, kullanmak için değeri string yap
                        for (int j = 0; j < pisti.YerdekiKartlar.Count; j++)
                        {
                            oyuncu1.ToplananKartlar.Add(pisti.YerdekiKartlar[j]);
                        }
                        pisti.YerdekiKartlar.Clear();
                    }
                }
            }
            void Oyuncu1Oyna()
            {
                Console.Write("{0} Kartları: ", oyuncu1.Adi);
                for (int j = 0; j < oyuncu1.Kartlari.Count; j++)
                    Console.Write(j + ".kart " + oyuncu1.Kartlari[j] + " , ");
                Console.Write("\nKart no seç: ");
                kartNo = Convert.ToInt32(Console.ReadLine());
                pisti.YereEkle(oyuncu1.Kartlari[kartNo]);
                Oyuncu1KartTopla();
                oyuncu1.Kartlari.RemoveAt(kartNo);
            }
            void Oyuncu2KartTopla()
            {
                if (pisti.YerdekiKartlar.Count == 2 && (((string)pisti.YerdekiKartlar[0]).Split(' ')[1] == ((string)oyuncu2.Kartlari[kartNo]).Split(' ')[1]))
                {
                    if (((string)pisti.YerdekiKartlar[0]).Split(' ')[1] == ((string)oyuncu2.Kartlari[kartNo]).Split(' ')[1])
                    {
                        oyuncu2.PistiSayisi++;
                    }
                    else if (((string)pisti.YerdekiKartlar[0]).Split(' ')[1] == "J" &&
                            ((string)oyuncu2.Kartlari[kartNo]).Split(' ')[1] == "J")
                    {
                        oyuncu2.ValePistiSayi++;
                    }
                    for (int j = 0; j < pisti.YerdekiKartlar.Count; j++)
                        oyuncu2.ToplananKartlar.Add(pisti.YerdekiKartlar[j]);
                    pisti.YerdekiKartlar.Clear();
                }
                else if (pisti.YerdekiKartlar.Count > 1)
                {
                    if (((string)pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 1]).Split((' '))[1] == "J" ||
                        ((string)pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 2]).Split((' '))[1] ==
                        ((string)pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 1]).Split((' '))[1])
                    {      // Split kullan, kullanmak için değeri string yap
                        for (int j = 0; j < pisti.YerdekiKartlar.Count; j++)
                        {
                            oyuncu2.ToplananKartlar.Add(pisti.YerdekiKartlar[j]);
                        }
                        pisti.YerdekiKartlar.Clear();
                    }
                }
            }
            void Oyuncu2Oyna()
            {
                Console.Write("{0} Kartları: ", oyuncu2.Adi);
                for (int j = 0; j < oyuncu2.Kartlari.Count; j++)
                    Console.Write(j + ".kart " + oyuncu2.Kartlari[j] + " , ");
                Console.Write("\nKart no seç: ");
                kartNo = Convert.ToInt32(Console.ReadLine());
                pisti.YereEkle(oyuncu2.Kartlari[kartNo]);
                Oyuncu2KartTopla();
                oyuncu2.Kartlari.RemoveAt(kartNo);
            }
            void YerdekiKartlar()
            {
                Console.WriteLine();
                Console.Write("Yerdeki kartlar: ");
                if (pisti.YerdekiKartlar.Count == 0)
                    Console.WriteLine("Boş");
                else
                {
                    for (int k = 0; k < pisti.YerdekiKartlar.Count - 1; k++)
                        Console.Write("Kapalı - ");
                    Console.WriteLine(pisti.YerdekiKartlar[pisti.YerdekiKartlar.Count - 1]);
                }
            }

            #endregion


            Console.ReadKey();
        }

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
                int sayi = random.Next(0, Deste.Count);
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
}
