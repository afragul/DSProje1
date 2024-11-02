using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Name
{
    internal class Program
    {
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
                "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya",
                "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik",
                "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
                "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne",
                "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun",
                "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul",
                "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu",
                "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Konya", "Kütahya",
                "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Nevşehir",
                "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun",
                "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon",
                "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yozgat", "Zonguldak"
            };
            
            String[] mesafe = MesafeArrayFonk();
            double[][] mesafeJaggedArray = new double[81][];

            for (int i = 0; i < 81; ++i)
            {
                mesafeJaggedArray[i] = new double[81];
                for (int j = 0; j < 81 - i; j++)
                {
                    mesafeJaggedArray[i][j] = int.Parse(mesafe[i * 81 + j]);
                }
            }

            //madde a 
            Random random = new Random();
            int sehir1 = random.Next(1,82);
            int sehir2 = random.Next(1,82);
            while (sehir1 == sehir2)
            {
                sehir2 = random.Next(82);
            }
            Console.WriteLine(sehirler[sehir1] + " (plaka: " + sehir1 +") - "+ sehirler[sehir2] + " (plaka: "+ sehir2 + ") uzaklık: " + mesafeJaggedArray[sehir1 - 1][sehir2-1] );
            Console.ReadKey();

            //madde b
            List<int>[] komsuIller=KomsuIllerFonk(); //komsuilleri cagir

            //sonsuz yaptik
            for (int i = 0; i < mesafeJaggedArray.Length; i++)
            {
                for (int j = 0; j < mesafeJaggedArray[i].Length; j++)
                {
                    // Eğer j, i'nin komşusu değilse sonsuz yap
                    if (i != j && !komsuIller[i].Contains(j))
                    {
                        mesafeJaggedArray[i][j] = Double.PositiveInfinity;
                    }
                }
            }

            // Sonuçları yazdırma
            Console.WriteLine("Mesafe Matrisi:");
            for (int i = 0; i < sehirler.Length; i++)
            {
                for (int j = 0; j < mesafeJaggedArray[i].Length; j++)
                {
                    Console.Write($"{mesafeJaggedArray[i][j]:0.##}\t");
                }
                Console.WriteLine();
            }

        }
    }
}