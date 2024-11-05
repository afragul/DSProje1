using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Name
{
    internal class Program
    {
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
            return mesafeler[hedef] ; 
        }

        public static List<Tuple<int,int,double>> MesafeHesaplama(double[][] orjinalJagged,double[][] mesafeJagged,string[] sehirler){

            var farkListesi=new List<Tuple<int, int, double>>();
            var hesaplananCiftler = new HashSet<(int, int)>();

            for (int i=0;i<81;i++){
                for (int j = 0; j < 81; j++)
                {
                    if (mesafeJagged[i][j]==Double.PositiveInfinity && i!=j)
                    {
                        var sehirCifti = (Math.Min(i, j), Math.Max(i, j));

                        // Eğer çift daha önce işlendiyse gecsin
                        if (hesaplananCiftler.Contains(sehirCifti))
                            continue;

                        hesaplananCiftler.Add(sehirCifti);

                        double hesaplananMesafe=Dijkstra(i,j,mesafeJagged); //dijkstra algosuna esit olacak
                        double orjinalMesafe=orjinalJagged[i][j];
                        double fark=hesaplananMesafe-orjinalMesafe;
                        if (fark<0)
                        {
                            double yeniFark=fark*(-1);
                            fark=yeniFark;
                            
                        }

                        farkListesi.Add(new Tuple<int, int, double>(i,j,fark));
                        Console.WriteLine(sehirler[i+1] +" ile "+ sehirler[j+1] +" arasındaki karayolları cetvelindeki uzaklık değeri: " + orjinalMesafe + "\n" 
                        +"Dijkstra algoritması ile hesaplanan değer: " + hesaplananMesafe + "\n" 
                        +"Iki hesap arasındaki mesafe farkı : " + fark);
                    }
                }
            }

            return farkListesi;
        }

        
        public static string[] MesafeArrayFonk()
        { 
            string projeDizini = Directory.GetCurrentDirectory();
            string dosyaAdi = "mesafeler.txt";

            string dosyaYolu = Path.Combine(projeDizini, dosyaAdi);

            try
            {
                string file = File.ReadAllText(dosyaYolu);
                string[] mesafeArray = file.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return mesafeArray;
            }
            catch (Exception e)
            {
                Console.WriteLine("Dosya okunurken bir hata oluştu: " + e.Message);
                return Array.Empty<string>();
            }
        }

        public static string[] ilceMesafeArrayFonk()
        { 
            string projeDizini = Directory.GetCurrentDirectory();
            string dosyaAdi = "ilceler.txt";

            string dosyaYolu = Path.Combine(projeDizini, dosyaAdi);

            try
            {
                string file = File.ReadAllText(dosyaYolu);
                string[] ilcemesafeArray = file.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return ilcemesafeArray;
            }
            catch (Exception e)
            {
                Console.WriteLine("Dosya okunurken bir hata oluştu: " + e.Message);
                return Array.Empty<string>();
            }
        }
        public static List<int>[] KomsuIlcelerFonk(){
            
            List<int>[] komsuIlceler = new List<int>[30];
            for (int i = 0; i< komsuIlceler.Length;i++)
            {
                komsuIlceler[i] = new List<int>();
            }
            komsuIlceler[0].AddRange(new int[] { 22, 11, 4}); //Aliağanın komşuları
            komsuIlceler[1].AddRange(new int[] { 20,23,13}); // Balçova'nın komşuları
            komsuIlceler[2].AddRange(new int[] { 28, 24, 27, 17 }); // Bayındır'ın komşuları
            komsuIlceler[3].AddRange(new int[] { 6, 16 }); // Bayraklı'ın komşuları
            komsuIlceler[4].AddRange(new int[] { 0, 10, 18 }); // Bergama'ın komşuları
            komsuIlceler[5].AddRange(new int[] { 19, 24, 27 }); // Beydağ'ın komşuları
            komsuIlceler[6].AddRange(new int[] { 16, 20, 3, 17, 7 }); // Bornova'ın komşuları
            komsuIlceler[7].AddRange(new int[] { 20, 6, 14 }); // Buca'ın komşuları
            komsuIlceler[8].AddRange(new int[] { 29, 15}); // Çeşme'ın komşuları
            komsuIlceler[9].AddRange(new int[] { 16, 22}); // Çiğli'ın komşuları
            komsuIlceler[10].AddRange(new int[] { 4 }); // Dikili'ın komşuları
            komsuIlceler[11].AddRange(new int[] {22, 0}); // Foça'ın komşuları
            komsuIlceler[12].AddRange(new int[] { 14, 21); // Gaziemir'ın komşuları
            komsuIlceler[13].AddRange(new int[] { 1 , 23, 29, 25 }); // Güzelbahçe'ın komşuları
            komsuIlceler[14].AddRange(new int[] { 20, 7, 12, 21}); // Karabağlar'ın komşuları
            komsuIlceler[15].AddRange(new int[] { 29, 8}); // Karaburun'ın komşuları
            komsuIlceler[16].AddRange(new int[] {20, 9, 6, 3}); // Karşıyaka'ın komşuları
            komsuIlceler[17].AddRange(new int[] { 6, 2, 28}); // Kemalpaşa'ın komşuları
            komsuIlceler[18].AddRange(new int[] {4}); // Kınık'ın komşuları
            komsuIlceler[19].AddRange(new int[] { 5, 24 }); // Kiraz'ın komşuları
            komsuIlceler[20].AddRange(new int[] { 16, 6, 1, 7, 14 }); // Konak'ın komşuları
            komsuIlceler[21].AddRange(new int[] { 12, 14, 25, 28, 26 }); // Menderes'ın komşuları
            komsuIlceler[22].AddRange(new int[] { 9, 11, 0 }); // Menemen'ın komşuları
            komsuIlceler[23].AddRange(new int[] { 1, 13 }); // Narlıdere'ın komşuları
            komsuIlceler[24].AddRange(new int[] { 5, 19, 27, 2 }); // Ödemiş'ın komşuları
            komsuIlceler[25].AddRange(new int[] { 13, 29, 21 }); // Seferihisar'ın komşuları
            komsuIlceler[26].AddRange(new int[] { 21, 28 }); // Selçuk'ın komşuları
            komsuIlceler[27].AddRange(new int[] { 2, 24, 5 }); // Tire'ın komşuları
            komsuIlceler[28].AddRange(new int[] { 17, 21, 26, 2 }); // Torbalı'ın komşuları
            komsuIlceler[29].AddRange(new int[] { 13, 15, 8, 15 }); // Urla'ın komşuları
            return komsuIlceler;
        }
                                      
            
        public static List<int>[] KomsuIllerFonk(){

            List<int>[] komsuIller = new List<int>[81];
            for (int i = 0; i < komsuIller.Length; i++)
            {
                komsuIller[i] = new List<int>();
            }

            komsuIller[0].AddRange(new int[] { 32, 79, 30, 45, 37, 50}); // Adana'nın komşuları
            komsuIller[1].AddRange(new int[] { 43, 45, 26, 62, 20 }); // Adıyaman'ın komşuları
            komsuIller[2].AddRange(new int[] {  63, 19, 14, 31, 41, 25, 42 }); // Afyonkarahisar'ın 
            komsuIller[3].AddRange(new int[] { 75, 35, 24, 48, 12, 64 }); // agri'ın komşuları
            komsuIller[4].AddRange(new int[] { 54, 59, 18, 65 }); // amasya'ın komşuları
            komsuIller[5].AddRange(new int[] { 25, 13, 17, 70, 39, 67, 41}); // ankara'ın komşuları
            komsuIller[6].AddRange(new int[] { 47, 14, 31, 41, 69, 32}); // antalya'ın komşuları
            komsuIller[7].AddRange(new int[] {74,52,24}); // Artvin
            komsuIller[8].AddRange(new int[] { 34, 44, 19, 47}); // Aydın'ın komşuları
            komsuIller[9].AddRange(new int[] {16, 34, 44, 42, 15 }); // Balıkesir'ın komşuları
            komsuIller[10].AddRange(new int[] { 15, 42, 25, 53, 13}); // Bilecik'ın komşuları
            komsuIller[11].AddRange(new int[] { 23, 24, 48, 20, 22, 61}); // Bingöl'ın komşuları
            komsuIller[12].AddRange(new int[] { 48, 55, 71, 64, 3}); // Bitlis'ın komşuları
            komsuIller[13].AddRange(new int[] {  66, 80, 53, 10, 25, 5, 17, 77 }); // Bolu: Düzce, 
            komsuIller[14].AddRange(new int[] { 19, 2, 31, 6, 47}); // Burdur'ın komşuları
            komsuIller[15].AddRange(new int[] { 9, 42, 10, 53, 40, 76}); // Bursa'ın komşuları
            komsuIller[16].AddRange(new int[] { 9,58,21 }); // Çanakkale'ın komşuları
            komsuIller[17].AddRange(new int[] { 13, 5, 70, 65, 18, 36, 77 }); // Çankırı'ın komşuları
            komsuIller[18].AddRange(new int[] { 36, 17, 65, 4, 54, 59}); // Çorum'ın komşuları
            komsuIller[19].AddRange(new int[] { 8, 47, 14, 31, 02, 63, 44 }); // Denizli'ın komşuları
            komsuIller[20].AddRange(new int[] { 22, 11, 48, 71, 46, 62, 1, 43}); // Diyarbakır'ın 
            komsuIller[21].AddRange(new int[] {58, 38, 16 }); // Edirne: Kırklareli, Tekirdağ
            komsuIller[22].AddRange(new int[] { 43, 23, 61, 11, 20}); // Elazığ'ın komşuları
            komsuIller[23].AddRange(new int[] { 24, 61, 11, 22, 57, 28, 68}); // Erzincan'ın komşuları
            komsuIller[24].AddRange(new int[] { 52, 7, 74, 35, 3, 48, 11, 23, 68}); // Erzurum'ın 
            komsuIller[25].AddRange(new int[] { 10, 42, 2, 41, 5, 13}); // Eskişehir'ın komşuları
            komsuIller[26].AddRange(new int[] {  78, 30, 79, 45, 1, 62}); // Gaziantep'ın komşuları
            komsuIller[27].AddRange(new int[] { 51, 57, 23, 28, 60}); // Giresun'ın komşuları
            komsuIller[28].AddRange(new int[] { 60, 27, 23, 68}); // Gümüşhane'ın komşuları
            komsuIller[29].AddRange(new int[] { 72, 55, 64}); // Hakkari'ın komşuları
            komsuIller[30].AddRange(new int[] { 0, 79, 26, 78 }); // Hatay'ın komşuları
            komsuIller[31].AddRange(new int[] {14, 6, 41, 2}); // isparta'ın komşuları
            komsuIller[32].AddRange(new int[] { 6, 69, 41, 50, 0}); // mersin'ın komşuları
            komsuIller[33].AddRange(new int[] {40,58}); // istanbul'ın komşuları
            komsuIller[34].AddRange(new int[] {8,44,9}); // izmir'ın komşuları
            komsuIller[35].AddRange(new int[] {3, 75, 74, 24}); // kars'ın komşuları
            komsuIller[36].AddRange(new int[] { 56, 18, 17, 77, 73}); // kastamonu'ın komşuları
            komsuIller[37].AddRange(new int[] { 57, 45, 0, 50, 49, 65}); // kayseri'ın komşuları
            komsuIller[38].AddRange(new int[] {58,21}); // kirklareli'ın komşuları
            komsuIller[39].AddRange(new int[] {65, 49, 67, 5, 70}); // kirsehir'ın komşuları
            komsuIller[40].AddRange(new int[] { 33, 53, 15, 76}); // kocaeli'ın komşuları
            komsuIller[41].AddRange(new int[] { 67, 5, 25, 2, 31, 6, 69, 50}); // konya'ın komşuları
            komsuIller[42].AddRange(new int[] { 44, 9, 15, 10, 25, 2, 63}); // kutahya'ın komşuları
            komsuIller[43].AddRange(new int[] { 22, 1, 45, 57, 23, 20}); // malatya'ın komşuları
            komsuIller[44].AddRange(new int[] { 34, 8, 19, 63, 42, 9}); // manisa'ın komşuları
            komsuIller[45].AddRange(new int[] { 0, 79, 26, 1, 43, 57, 37}); // maras'ın komşuları
            komsuIller[46].AddRange(new int[] { 71, 20, 62, 72, 55}); // mardin'ın komşuları
            komsuIller[47].AddRange(new int[] { 8, 19, 14, 6}); // mugla'ın komşuları
            komsuIller[48].AddRange(new int[] { 24, 3, 12, 71, 20, 11}); // mus'ın komşuları
            komsuIller[49].AddRange(new int[] { 39, 67, 50, 37, 65}); // nevsehir'ın komşuları
            komsuIller[50].AddRange(new int[] { 37, 49, 67, 41, 0, 32}); // nigde'ın komşuları
            komsuIller[51].AddRange(new int[] { 54, 57, 27, 59}); // ordu'ın komşuları
            komsuIller[52].AddRange(new int[] { 60, 7, 24}); // rize'ın komşuları
            komsuIller[53].AddRange(new int[] {80, 40, 15, 10, 13 }); // sakarya'ın komşuları
            komsuIller[54].AddRange(new int[] {51, 4, 18, 59, 56 }); // samsun'ın komşuları
            komsuIller[55].AddRange(new int[] {71, 72, 46, 12, 64 }); // siirt'ın komşuları
            komsuIller[56].AddRange(new int[] {36, 18, 54 }); // sinop'ın komşuları
            komsuIller[57].AddRange(new int[] {27, 51, 59, 65, 37, 45, 43, 23 }); // sivas'ın komşuları
            komsuIller[58].AddRange(new int[] {38, 21, 33, 16 }); // tekirdag'ın komşuları
            komsuIller[59].AddRange(new int[] {4, 54, 51, 57, 65, 18 }); // tokat'ın komşuları
            komsuIller[60].AddRange(new int[] {52, 27, 28, 68 }); // trabzon'ın komşuları
            komsuIller[61].AddRange(new int[] {23, 11, 22}); // tunceli'ın komşuları
            komsuIller[62].AddRange(new int[] {20, 46, 26, 1}); // urfa'ın komşuları
            komsuIller[63].AddRange(new int[] { 44, 42, 2, 19}); // usak'ın komşuları
            komsuIller[64].AddRange(new int[] {12, 29, 3, 72, 55}); // van'ın komşuları
            komsuIller[65].AddRange(new int[] {18, 70, 39, 49, 37, 57, 59}); // yozgat'ın komşuları
            komsuIller[66].AddRange(new int[] {73, 77, 80, 13}); // zonguldak'ın komşuları
            komsuIller[67].AddRange(new int[] {39, 70, 5, 41, 50, 49}); // aksaray'ın komşuları
            komsuIller[68].AddRange(new int[] {24, 28, 23, 60}); // bayburt'ın komşuları
            komsuIller[69].AddRange(new int[] {41, 32, 6}); // karaman'ın komşuları
            komsuIller[70].AddRange(new int[] {17, 18, 65, 39, 5, 67}); // kirikkale'ın komşuları
            komsuIller[71].AddRange(new int[] { 55, 20, 48, 12, 46}); // batman'ın komşuları
            komsuIller[72].AddRange(new int[] {46, 55, 29, 64}); // sirnak'ın komşuları
            komsuIller[73].AddRange(new int[] {66, 77, 36}); // bartin'ın komşuları
            komsuIller[74].AddRange(new int[] {7, 35, 24}); // ardahan'ın komşuları
            komsuIller[75].AddRange(new int[] {3,35}); // igdir'ın komşuları
            komsuIller[76].AddRange(new int[] {40,15}); // yalova'ın komşuları
            komsuIller[77].AddRange(new int[] {73, 66, 36, 17, 13}); // karabuk'ın komşuları
            komsuIller[78].AddRange(new int[] {26,30}); // kilis'ın komşuları
            komsuIller[79].AddRange(new int[] {0, 30, 45, 26}); // osmaniye'ın komşuları
            komsuIller[80].AddRange(new int[] {66, 13, 53}); // duzce'ın komşuları

            return komsuIller;
        }
        static void Main(string[] args)
        {
            string[] sehirler = {
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
            
            String[] mesafe = MesafeArrayFonk();
            double[][] mesafeJaggedArray = new double[81][]; //sonsuz degeler olacak
            double[][] orjinalJaggedArray = new double[81][]; //cetveldeki versiyonlar kalacak 

            for (int i = 0; i < 81; ++i)
            {
                mesafeJaggedArray[i] = new double[81];
                orjinalJaggedArray[i] = new double[81];
                for (int j = 0; j < 81; j++)
                {
                    mesafeJaggedArray[i][j] = double.Parse(mesafe[i * 81 + j]);
                    orjinalJaggedArray[i][j] = int.Parse(mesafe[i * 81 + j]);

                }
            }

            //madde a 
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int sehir1 = random.Next(1,82);
                int sehir2 = random.Next(1,82);
                while (sehir1 == sehir2)
                {
                    sehir2 = random.Next(82);
                }
                Console.WriteLine(sehirler[sehir1] + " (plaka: " + sehir1 +") - "+ sehirler[sehir2] + " (plaka: "+ sehir2 + ") uzaklık: " + mesafeJaggedArray[sehir1 - 1][sehir2-1] );

            }

            //madde b
            List<int>[] komsuIller=KomsuIllerFonk(); //komsuilleri cagir

            //sonsuz yaptik
            for (int i = 0; i < mesafeJaggedArray.Length; i++)
            {
                for (int j = 0; j < mesafeJaggedArray[i].Length; j++)
                {
                    if (i != j && !komsuIller[i].Contains(j))
                    {
                        mesafeJaggedArray[i][j] = Double.PositiveInfinity;
                    }
                }
            }

            // //madde c 
            var farkListesi= MesafeHesaplama(orjinalJaggedArray,mesafeJaggedArray,sehirler);
            double minValue = farkListesi.Min(item => item.Item3);
            double maxValue = farkListesi.Max(item => item.Item3);
            var minItems = farkListesi.Where(item => item.Item3 == minValue).ToList();
            var maxItems = farkListesi.Where(item => item.Item3 == maxValue).ToList();

            Console.WriteLine("\nEn kısa mesafe farkına sahip şehirler: ");
            foreach (var item in minItems)
            {
                Console.WriteLine($"({sehirler[item.Item1+1]}, {sehirler[item.Item2+1]}, {item.Item3})");
            }

            Console.WriteLine("\nEn fazla mesafe farkına sahip şehirler: ");
            foreach (var item in maxItems)
            {
                Console.WriteLine($"({sehirler[item.Item1+1]}, {sehirler[item.Item2+1]}, {item.Item3})");
            }

            // //madde d
            String[] ilceler = {"Aliağa", "Balçova","Bayındır","Bayraklı","Bergama","Beydağ","Bornova","Buca","Çeşme","Çiğli","Dikili","Foça","Gaziemir","Güzelbahçe","Karabağlar","Karaburun","Karşıyaka","Kemalpaşa","Kınık","Kiraz","Konak","Menderes","Menemen","Narlıdere","Ödemiş","Seferihisar","Selçuk","Tire","Torbalı","Urla"}
            String[] mesafe = ilceMesafeArrayFonk();
            double[,] ilceMesafeMatris = new double[30,30]; //sonsuz degeler olacak
            double[,] ilceOrjinalMatris = new double[30,30]; //cetveldeki versiyonlar kalacak 
            for (int i = 0; i < 30; ++i)
            {
                for (int j = 0; j <30; j++)
                {
                    mesafeJaggedArray[i,j] = double.Parse(mesafe[i * 30 + j]);
                    orjinalJaggedArray[i,j] = int.Parse(mesafe[i * 30 + j]);

                }
            }
        }
    }
}
