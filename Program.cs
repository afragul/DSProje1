using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace proje11
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IlUzaklıkMatrisiOluşturma();
            RastgeleSehirCifti();
            KomsuIllerDısındaSonsuzYap();
            EnKisaYazdir();
            ilceMatris();
            ilceKomsularSonsuz();
            EnKisaYazdirIlce();
            

        }


        static string[] sehirAdlari = {
                " " , "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya",
                "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik",
                "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
                "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne",
                "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun",
                "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul",
                "İzmir", "Kars", "Kastamonu",
                "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli" ,"Konya", "Kütahya",
                "Malatya", "Manisa", "Kahramanmaraş" ,"Mardin", "Muğla", "Muş" ,"Nevşehir",
                "Niğde", "Ordu" , "Rize", "Sakarya", "Samsun",
                "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon",
                "Tunceli", "Şanlıurfa" , "Uşak", "Van", "Yozgat", "Zonguldak" ,
                "Aksaray" , "Bayburt" , "Karaman" , "Kırıkkale" , "Batman" ,
                "Şırnak" , "Bartın" , "Ardahan" , "Iğdır" , "Yalova" , "Karabük" ,
                "Kilis" , "Osmaniye" , "Düzce"
            };
        static string[] ilceAdlari = { "Aliağa", "Balçova", "Bayındır", "Bayraklı", "Bergama", "Beydağ", "Bornova", "Buca", "Çeşme", "Çiğli", "Dikili", "Foça", "Gaziemir", "Güzelbahçe", "Karabağlar", "Karaburun", "Karşıyaka", "Kemalpaşa", "Kınık", "Kiraz", "Konak", "Menderes", "Menemen", "Narlıdere", "Ödemiş", "Seferihisar", "Selçuk", "Tire", "Torbalı", "Urla" };
        static double[][] ilMesafeMatrisi = new double[81][]; //cetveldeki veriler kalacak
        static double[][] ilMesafeMatrisiSonsuz = new double[81][]; //sonsuz değerler olarak
        static Dictionary<int, List<int>> komsuIller = new Dictionary<int, List<int>>();
        static double[,] ilceMesafeMatris = new double[30, 30];
        static double[,] ilceMesafeMatrisSonsuz = new double[30, 30];
        static Dictionary<int, List<int>> komsuIlceler = new Dictionary<int, List<int>>();

        // madde a
        static void IlUzaklıkMatrisiOluşturma()
        {

            string projeDizini = Directory.GetCurrentDirectory();
            string dosyaAdi = "mesafeler.txt";
            string dosyaYolu = Path.Combine(projeDizini, dosyaAdi);
            string[] mesafeArray;

            try
            {
                string file = File.ReadAllText(dosyaYolu);
                mesafeArray = file.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            }
            catch (Exception e)
            {
                Console.WriteLine("Dosya okunurken bir hata oluştu: " + e.Message);
                mesafeArray = Array.Empty<string>();
            }

            for (int i = 0; i < 81; i++)
            {
                ilMesafeMatrisi[i] = new double[81];
                ilMesafeMatrisiSonsuz[i] = new double[81];
                for (int j = 0; j < 81; j++)
                {
                    ilMesafeMatrisi[i][j] = double.Parse(mesafeArray[i * 81 + j]);
                    ilMesafeMatrisiSonsuz[i][j] = double.Parse(mesafeArray[i * 81 + j]);

                }
            }


        }
        static void RastgeleSehirCifti()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int sehir1 = random.Next(0, 81);
                int sehir2 = random.Next(0, 81);
                while (sehir1 == sehir2)
                {
                    sehir2 = random.Next(0, 81);
                }
                ++sehir1;
                ++sehir2;


                Console.WriteLine(sehirAdlari[sehir1] + " (" + sehir1 + ") " + "- " + sehirAdlari[sehir2] + " (" + sehir2 + ") " + "- :" + ilMesafeMatrisi[sehir1 - 1][sehir2 - 1]);
            }
            Console.ReadKey();
        }
        // madde b
        static void KomsuIllerDısındaSonsuzYap()
        {
            komsuIller = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 33, 80, 31, 46, 38, 51 } }, // Adana'nın komşuları (örnek)
                { 2, new List<int> { 44, 46, 27, 63, 21 } }, //Adıyaman
                { 3, new List<int> { 64, 20, 15, 32, 42, 26, 43 } }, //Afyonkarahisar
                { 4, new List<int> { 76, 36, 25, 49, 13, 65} }, //Ağrı
                { 5, new List<int> { 55, 60, 19, 66 } }, //Amasya
                { 6, new List<int> { 26, 14, 18, 71, 40, 68, 42 } }, //Ankara
                { 7, new List<int> { 48, 15, 32, 42, 70, 33 } }, //Antalya
                { 8, new List<int> { 75, 25, 53 } }, //Artvin
                { 9, new List<int> { 35, 45, 20, 48 } }, //Aydın
                { 10, new List<int> {17, 35, 45, 43, 16 } }, //Balıkesir
                { 11, new List<int> {16, 43, 26, 54, 14 } }, //Bilecik
                { 12, new List<int> {24, 25, 49, 21, 23, 62 } }, //Bingöl
                { 13, new List<int> {49, 56, 72, 65, 04} }, //Bitlis
                { 14, new List<int> { 67, 81, 54, 11, 26, 06, 18, 78} }, //Bolu
                { 15, new List<int> { 20, 03, 32, 07, 48 } }, //Burdur
                { 16, new List<int> { 10, 43, 11, 54, 41, 77} }, //Bursa
                { 17, new List<int> { 10, 59, 22 } }, //Çanakkale
                { 18, new List<int> { 14, 06, 71, 66, 19, 37, 78 } }, //Çankırı
                { 19, new List<int> { 37, 18, 66, 05, 55, 60 } }, //Çorum
                { 20, new List<int> {09, 48, 15, 32, 03, 64, 45} }, //Denizli
                { 21, new List<int> {23, 12, 49, 72, 47, 63, 02, 44} },
                { 22, new List<int> { 59, 39, 17} }, //Edirne
                { 23, new List<int> {44, 24, 62, 12, 21} }, //Elazığ
                { 24, new List<int> {25, 62, 12, 23, 58, 29, 69} }, //Erzincan
                { 25, new List<int> { 53, 08, 75, 36, 04, 49, 12, 24, 69} }, //Erzurum
                { 26, new List<int> { 11, 43, 03, 42, 06, 14} }, //Eskişehir
                { 27, new List<int> {79, 31, 80, 46, 02, 63} }, //Gaziantep
                { 28, new List<int> {52, 58, 24, 29, 61} }, //Giresun
                { 29, new List<int> { 61, 28, 24, 69} }, //Gümüşhane
                { 30, new List<int> { 73, 56, 65} }, //Hakkari
                { 31, new List<int> {01, 80, 27, 79} }, //Hatay
                { 32, new List<int> {15, 07, 42, 03} }, //Isparta
                { 33, new List<int> { 07, 70, 42, 51, 01 } }, //Mersin(içel)
                { 34, new List<int> { 41, 59 } }, //İstanbul
                { 35, new List<int> { 09, 45, 10 } }, //İzmir
                { 36, new List<int> { 04, 76, 75, 25} }, //Kars
                { 37, new List<int> { 57, 19, 18, 78, 74} }, //Kastamonu
                { 38, new List<int> { 58, 46, 01, 51, 50, 66} }, //Kayseri
                { 39, new List<int> { 59, 22} }, //Kırklareli
                { 40, new List<int> { 66, 50, 68, 06, 71} }, //Kırşehir
                { 41, new List<int> { 66, 50, 68, 06, 71} }, //Kocaeli
                { 42, new List<int> { 68, 06, 26, 03, 32, 07, 70, 51 } }, //Konya
                { 43, new List<int> {45, 10, 16, 11, 26, 03, 64} }, //Kütahya
                { 44, new List<int> { 23, 02, 46, 58, 24, 21} }, //Malatya
                { 45, new List<int> {35, 09, 20, 64, 43, 10} }, //Manisa
                { 46, new List<int> {01, 80, 27, 02, 44, 58, 38} }, //Kahramanmaraş
                { 47, new List<int> { 72, 21, 63, 73, 56} }, //Mardin
                { 48, new List<int> {09, 20, 15, 07} }, //Muğla
                { 49, new List<int> { 25, 04, 13, 72, 21, 12} }, //Muş
                { 50, new List<int> {40, 68, 51, 38, 66} }, //Nevşehir
                { 51, new List<int> { 38, 50, 68, 42, 01, 33} }, //Niğde
                { 52, new List<int> { 55, 58, 28, 60} }, //Ordu
                { 53, new List<int> {61, 08, 25} }, //Rize
                { 54, new List<int> { 81, 41, 16, 11, 14} }, //Sakarya
                { 55, new List<int> {52, 05, 19, 60, 57} }, //Samsun
                { 56, new List<int> {72, 73, 47, 13, 65} }, //Siirt
                { 57, new List<int> { 37, 19, 55} }, //Sinop
                { 58, new List<int> {28, 52, 60, 66, 38, 46, 44, 24} }, //Sivas
                { 59, new List<int> { 39, 22, 34, 17} }, //Tekirdağ
                { 60, new List<int>  {05, 55, 52, 58, 66, 19} }, //Tokat
                { 61, new List<int>  { 53, 28, 29, 69} }, //Trabzon
                { 62, new List<int>  { 24, 12, 23} }, //Tunceli
                { 63, new List<int>  { 21, 47, 27, 02} }, //Şanlıurfa
                { 64, new List<int>  { 45, 43, 03, 20} }, //Uşak
                { 65, new List<int>  { 13, 30, 04, 73, 56} }, //Van
                { 66, new List<int>  { 19, 71, 40, 50, 38, 58, 60 } }, //Yozgat
                { 67, new List<int>  { 74, 78, 81, 14} }, //Zonguldak
                { 68, new List<int>  { 40, 71, 06, 42, 51, 50} }, //Aksaray
                { 69, new List<int>  { 25, 29, 24, 61} }, //Bayburt
                { 70, new List<int>  {42, 33, 07} }, //Karaman
                { 71, new List<int>  {18, 19, 66, 40, 06, 68} }, //Kırıkkale
                { 72, new List<int>  { 56, 21, 49, 13, 47} }, //Batöam
                { 73, new List<int>  { 47, 56, 30, 65} }, //Şırnak
                { 74, new List<int>  { 67, 78, 37} }, //Bartın
                { 75, new List<int>  { 08, 36, 25} }, //Ardahan
                { 76, new List<int>  { 04, 36} }, //Iğdır
                { 77, new List<int>  { 41, 16} }, //Yalova
                { 78, new List<int>  { 74, 67, 37, 18, 14} }, //Karabük
                { 79, new List<int>  { 27, 31} }, //Kilis
                { 80, new List<int>  {01, 31, 46, 27} }, //Osmaniye
                { 81, new List<int>  { 67, 14, 54} }, //Düzce
                

            };
            for (int i = 0; i < 81; i++)
            {
                for (int j = 0; j < 81; j++)
                {
                    if (i != j && (!komsuIller.ContainsKey(i + 1) || !komsuIller[i + 1].Contains(j + 1)))
                    {
                        ilMesafeMatrisiSonsuz[i][j] = Double.PositiveInfinity;
                    }
                }


            }
        }


        public static double Dijkstra(int baslangic, int hedef, double[][] mesafeJaggedArray)
        {
            int sehirSayisi = 81;
            double[] mesafeler = new double[sehirSayisi];
            bool[] ziyaretEdildi = new bool[sehirSayisi];

            // Başlangıçtaki tüm mesafeleri sonsuz olarak ayarla.
            for (int i = 0; i < sehirSayisi; i++)
                mesafeler[i] = double.PositiveInfinity;

            // Başlangıç şehrinden başla
            mesafeler[baslangic] = 0;

            while (true)
            {
                int enKucukMesafeIndeksi = -1;
                double enKucukMesafe = double.PositiveInfinity;

                // Henüz ziyaret edilmemiş ve en küçük mesafeye sahip şehri bul
                for (int i = 0; i < sehirSayisi; i++)
                {
                    if (!ziyaretEdildi[i] && mesafeler[i] < enKucukMesafe)
                    {
                        enKucukMesafe = mesafeler[i];
                        enKucukMesafeIndeksi = i;
                    }
                }

                // Eğer ulaşılamaz veya ziyaret edilecek başka şehir yoksa
                if (enKucukMesafeIndeksi == -1 || enKucukMesafeIndeksi == hedef)
                    break;

                // Şehri ziyaret edilmiş olarak işaretle
                ziyaretEdildi[enKucukMesafeIndeksi] = true;

                // Komşu şehirleri kontrol et ve mesafeleri güncelle
                for (int j = 0; j < sehirSayisi; j++)
                {
                    if (!ziyaretEdildi[j] && mesafeJaggedArray[enKucukMesafeIndeksi][j] != double.PositiveInfinity)
                    {
                        double yeniMesafe = mesafeler[enKucukMesafeIndeksi] + mesafeJaggedArray[enKucukMesafeIndeksi][j];
                        if (yeniMesafe < mesafeler[j])
                        {
                            mesafeler[j] = yeniMesafe;
                        }
                    }
                }
            }
            return mesafeler[hedef];
        }

        public static List<Tuple<int, int, double>> MesafeHesaplama(double[][] orjinalJagged, double[][] mesafeJagged, string[] sehirAdlari)
        {

            
            var farkListesi = new List<Tuple<int, int, double>>();
            var hesaplananCiftler = new HashSet<(int, int)>();

            for (int i = 0; i < 81; i++)
            {
                for (int j = 0; j < 81; j++)
                {
                    if (mesafeJagged[i][j] == Double.PositiveInfinity && i != j)
                    {
                        var sehirCifti = (Math.Min(i, j), Math.Max(i, j));

                        // Eğer çift daha önce işlendiyse gecsin
                        if (hesaplananCiftler.Contains(sehirCifti))
                            continue;

                        hesaplananCiftler.Add(sehirCifti);

                        double hesaplananMesafe = Dijkstra(i, j, mesafeJagged); //dijkstra algosuna esit olacak
                        double orjinalMesafe = orjinalJagged[i][j];
                        double fark = hesaplananMesafe - orjinalMesafe;
                        if (fark < 0)
                        {
                            double yeniFark = fark * (-1);
                            fark = yeniFark;

                        }

                        farkListesi.Add(new Tuple<int, int, double>(i, j, fark));
                        Console.WriteLine(sehirAdlari[i + 1] + " ile " + sehirAdlari[j + 1] + " arasındaki karayolları cetvelindeki uzaklık değeri: " + orjinalMesafe + "\n"
                        + "Dijkstra algoritması ile hesaplanan değer: " + hesaplananMesafe + "\n"
                        + "Iki hesap arasındaki mesafe farkı : " + fark);
                    }
                }
            }

            return farkListesi;
        }

        public static void EnKisaYazdir()
        {
            var farkListesi = MesafeHesaplama(ilMesafeMatrisi, ilMesafeMatrisiSonsuz, sehirAdlari);
            double minValue = farkListesi.Min(item => item.Item3);
            double maxValue = farkListesi.Max(item => item.Item3);
            var minItems = farkListesi.Where(item => item.Item3 == minValue).ToList();
            var maxItems = farkListesi.Where(item => item.Item3 == maxValue).ToList();

            Console.WriteLine("\nEn kısa mesafe farkına sahip şehirler: ");
            foreach (var item in minItems)
            {
                Console.WriteLine($"({sehirAdlari[item.Item1 + 1]}, {sehirAdlari[item.Item2 + 1]}, {item.Item3})");
            }

            Console.WriteLine("\nEn fazla mesafe farkına sahip şehirler: ");
            foreach (var item in maxItems)
            {
                Console.WriteLine($"({sehirAdlari[item.Item1 + 1]}, {sehirAdlari[item.Item2 + 1]}, {item.Item3})");

            }
            Console.ReadKey();



        }

        // madde d
        public static void ilceMatris()
        {
            string projeDizini = Directory.GetCurrentDirectory();
            string dosyaAdi = "ilceler.txt";
            string dosyaYolu = Path.Combine(projeDizini, dosyaAdi);
            string[] ilceMesafeArray;

            try
            {
                string file = File.ReadAllText(dosyaYolu);
                ilceMesafeArray = file.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            }
            catch (Exception e)
            {
                Console.WriteLine("Dosya okunurken bir hata oluştu: " + e.Message);
                ilceMesafeArray = Array.Empty<string>();
            }

            for (int i = 0; i < 30; i++)
            {

                for (int j = 0; j < 30; j++)
                {
                    ilceMesafeMatris[i, j] = double.Parse(ilceMesafeArray[i * 30 + j]);
                }
            }

        }

        public static void ilceKomsularSonsuz()
        {

            komsuIlceler = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 23,12,5} }, // Aliağa
                { 2, new List<int> { 21,24,14 } }, //Balçova
                { 3, new List<int> { 29,25,28,18 } }, //Bayındır
                { 4, new List<int> { 7,17} }, //Bayraklı
                { 5, new List<int> { 1, 11,19 } }, //Bergama
                { 6, new List<int> { 20,25,28 } }, //Beydağ
                { 7, new List<int> { 17,21,4,18,8 } }, //Bornova
                { 8, new List<int> { 21, 7, 15 } }, //Buca
                { 9, new List<int> { 30,16 } }, //Çeşme
                { 10, new List<int> {17,23 } }, //Çiğli
                { 11, new List<int> {5 } }, //Dikili
                { 12, new List<int> {23,1 } }, //Foça
                { 13, new List<int> {15,22} }, //Gaziemir
                { 14, new List<int> {2,24,30,26} }, //Güzelbahçe
                { 15, new List<int> { 21,8,13,22 } }, //Karabağlar
                { 16, new List<int> { 30,9} }, //Karaburun
                { 17, new List<int> { 21, 10, 7, 4 } }, //Karşıyaka
                { 18, new List<int> { 7,3,29 } }, //Kemalpaşa
                { 19, new List<int> { 5 } }, //Kınık
                { 20, new List<int> {6,25} }, //Kiraz
                { 21, new List<int> {17,7,2,8,15} }, //Konak
                { 22, new List<int> { 13,15,26,29,27} }, //Menderes
                { 23, new List<int> {10,12,1} }, //Menemen
                { 24, new List<int> {2,14} }, //Narlıdere
                { 25, new List<int> { 6,20,28,3} }, //Ödemiş
                { 26, new List<int> { 14,30,22} }, //Seferihisar
                { 27, new List<int> {22,29} }, //Selçuk
                { 28, new List<int> {3,25,6} }, //Tire
                { 29, new List<int> {18,22,27,3} }, //Torbalı
                { 30, new List<int> { 14,16,9,26} }//Hakkari
            };

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (i != j && (!komsuIlceler.ContainsKey(i + 1) || !komsuIlceler[i + 1].Contains(j + 1)))
                    {
                        ilceMesafeMatrisSonsuz[i, j] = Double.PositiveInfinity;
                    }
                }
            }

        }
        public static double IlceDijkstra(int baslangic, int hedef, double[,] ilceMesafeMatrisSonsuz)
        {
            int ilceSayisi = 30;
            double[] mesafeler = new double[ilceSayisi];
            bool[] ziyaretEdildi = new bool[ilceSayisi];

            // Başlangıçtaki tüm mesafeleri sonsuz olarak ayarla.
            for (int i = 0; i < ilceSayisi; i++)
                mesafeler[i] = double.PositiveInfinity;

            // Başlangıç şehrinden başla
            mesafeler[baslangic] = 0;

            while (true)
            {
                int enKucukMesafeIndeksi = -1;
                double enKucukMesafe = double.PositiveInfinity;

                // Henüz ziyaret edilmemiş ve en küçük mesafeye sahip ilçeyi bul
                for (int i = 0; i < ilceSayisi; i++)
                {
                    if (!ziyaretEdildi[i] && mesafeler[i] < enKucukMesafe)
                    {
                        enKucukMesafe = mesafeler[i];
                        enKucukMesafeIndeksi = i;
                    }
                }

                // Eğer ulaşılamaz veya ziyaret edilecek başka şehir yoksa
                if (enKucukMesafeIndeksi == -1 || enKucukMesafeIndeksi == hedef)
                    break;

                // Şehri ziyaret edilmiş olarak işaretle
                ziyaretEdildi[enKucukMesafeIndeksi] = true;

                // Komşu şehirleri kontrol et ve mesafeleri güncelle
                for (int j = 0; j < ilceSayisi; j++)
                {
                    if (!ziyaretEdildi[j] && ilceMesafeMatrisSonsuz[enKucukMesafeIndeksi, j] != double.PositiveInfinity)
                    {
                        double yeniMesafe = mesafeler[enKucukMesafeIndeksi] + ilceMesafeMatrisSonsuz[enKucukMesafeIndeksi, j];
                        if (yeniMesafe < mesafeler[j])
                        {
                            mesafeler[j] = yeniMesafe;
                        }
                    }
                }
            }
            return mesafeler[hedef];
        }

        public static List<Tuple<int, int, double>> MesafeHesaplamaIlce(double[,] orjinalMatris, double[,] matris, string[] İlceAdlari)
        {
            var farkListesiIlce = new List<Tuple<int, int, double>>();
            var hesaplananCiftlerIlce = new HashSet<(int, int)>();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (matris[i, j] == Double.PositiveInfinity && i != j)
                    {
                        var ilceCifti = (Math.Min(i, j), Math.Max(i, j));

                        if (hesaplananCiftlerIlce.Contains(ilceCifti))
                            continue;

                        hesaplananCiftlerIlce.Add(ilceCifti);

                        double hesaplananMesafe = IlceDijkstra(i, j, matris); //dijkstra algosuna esit olacak
                        double orjinalMesafe = orjinalMatris[i, j];
                        double fark = hesaplananMesafe - orjinalMesafe;
                        if (fark < 0)
                        {
                            double yeniFark = fark * (-1);
                            fark = yeniFark;

                        }


                        farkListesiIlce.Add(new Tuple<int, int, double>(i, j, fark));
                        Console.WriteLine(ilceAdlari[i] + " ile " + ilceAdlari[j] + " arasındaki karayolları cetvelindeki uzaklık değeri: " + orjinalMesafe + "\n"
                        + "Dijkstra algoritması ile hesaplanan değer: " + hesaplananMesafe + "\n"
                        + "Iki hesap arasındaki mesafe farkı : " + fark);
                    }
                }
            }

            return farkListesiIlce;
        }

        public static void EnKisaYazdirIlce()
        {
            var farkListesiIlce = MesafeHesaplamaIlce(ilceMesafeMatris, ilceMesafeMatrisSonsuz, ilceAdlari);
            double minValue = farkListesiIlce.Min(item => item.Item3);
            double maxValue = farkListesiIlce.Max(item => item.Item3);
            var minItems = farkListesiIlce.Where(item => item.Item3 == minValue).ToList();
            var maxItems = farkListesiIlce.Where(item => item.Item3 == maxValue).ToList();

            Console.WriteLine("\nEn kısa mesafe farkına sahip ilçeler: ");
            foreach (var item in minItems)
            {
                Console.WriteLine($"({ilceAdlari[item.Item1]}, {ilceAdlari[item.Item2]}, {item.Item3})");
            }

            Console.WriteLine("\nEn fazla mesafe farkına sahip ilçeler: ");
            foreach (var item in maxItems)
            {
                Console.WriteLine($"({ilceAdlari[item.Item1]}, {ilceAdlari[item.Item2]}, {item.Item3})");

            }
            Console.ReadKey();

        }
    }
}



