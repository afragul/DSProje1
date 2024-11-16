using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace proje11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MakeCityDistanceJagged();
            RandomCityCouple();
            CityInfinity();
            PrintMinDifference();
            CountyMatris();
            countyInfinite();
            MinDifCunty();
            
        }
        static string[] cities = { //city names array
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
        static string[] countyNames = { "Aliağa", "Balçova", "Bayındır", "Bayraklı", "Bergama", "Beydağ", "Bornova", "Buca", "Çeşme", "Çiğli", "Dikili", "Foça", "Gaziemir", "Güzelbahçe", "Karabağlar", "Karaburun", "Karşıyaka", "Kemalpaşa", "Kınık", "Kiraz", "Konak", "Menderes", "Menemen", "Narlıdere", "Ödemiş", "Seferihisar", "Selçuk", "Tire", "Torbalı", "Urla" };
        static double[][] cityOriginalDistanceJagged = new double[81][]; //for original values
        static double[][] cityInfinityDistanceJagged = new double[81][]; //for infinite values
        static Dictionary<int, List<int>> neighborCities = new Dictionary<int, List<int>>(); //dict for neighbor cities
        static double[,] countyOriginalDistance = new double[30, 30]; //for original values
        static double[,] countyInfinityDistance = new double[30, 30]; //for infinite values
        static Dictionary<int, List<int>> neighborCounties = new Dictionary<int, List<int>>(); //dict for neighbor counties

        // madde a
        static void MakeCityDistanceJagged() 
        {
            string projectPath = Directory.GetCurrentDirectory(); //get project path for dinamic file path
            string fileName = "mesafeler.txt";
            string FilePath = Path.Combine(projectPath, fileName); 
            string[] distanceArray;
            try
            {
                string file = File.ReadAllText(FilePath); //read file
                distanceArray = file.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            }
            catch (Exception e)
            {
                Console.WriteLine("an error occurred while reading the file" + e.Message);
                distanceArray = Array.Empty<string>();
            }

            for (int i = 0; i < 81; i++) //create jagged array
            {
                cityOriginalDistanceJagged[i] = new double[81];
                cityInfinityDistanceJagged[i] = new double[81];
                for (int j = 0; j < 81; j++)
                {
                    cityOriginalDistanceJagged[i][j] = double.Parse(distanceArray[i * 81 + j]);
                    cityInfinityDistanceJagged[i][j] = double.Parse(distanceArray[i * 81 + j]);

                }
            }
        }
        static void RandomCityCouple() 
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int firstCity = random.Next(0, 81);
                int secondCity = random.Next(0, 81);
                while (firstCity == secondCity)
                {
                    secondCity = random.Next(0, 81);
                }
                ++firstCity;
                ++secondCity;
                Console.WriteLine(cities[firstCity] + " (" + firstCity + ") " + "- " + cities[secondCity] + 
                    " (" + secondCity + ") " + " :" + cityOriginalDistanceJagged[firstCity - 1][secondCity - 1]);
            }
            Console.ReadKey();
        }
        // madde b
        static void CityInfinity()
        {
            neighborCities = new Dictionary<int, List<int>> //dictionary for neighbor cities 
            {
                { 1, new List<int> { 33, 80, 31, 46, 38, 51 } }, // Adana
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
                { 21, new List<int> {23, 12, 49, 72, 47, 63, 02, 44} }, //Diyarbakır
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
                { 41, new List<int> { 34, 54, 16, 77} }, //Kocaeli
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
            int counter = 0;
            for (int i = 0; i < 81; i++)
            {
                for (int j = 0; j < 81; j++)
                {   
                    if (i != j && (!neighborCities.ContainsKey(i + 1) || !neighborCities[i + 1].Contains(j + 1)))
                    {
                        cityInfinityDistanceJagged[i][j] = Double.PositiveInfinity;
                        counter++;
                    }
                }
            }            
        }

        //madde c
        public static double Dijkstra(int first, int target, double[][] distanceJagged)
        {
            int numOfCity = 81;
            double[] distance = new double[numOfCity];
            bool[] isVisited = new bool[numOfCity];

            //Set all initial distances to infinite
            for (int i = 0; i < numOfCity; i++)
                distance[i] = double.PositiveInfinity;

            //start from first city
            distance[first] = 0;

            while (true)
            {
                int minDistanceIndex = -1;
                double minDistance = double.PositiveInfinity;

                // This is the city that has not yet been visited and has the smallest distance
                for (int i = 0; i < numOfCity; i++)
                {
                    if (!isVisited[i] && distance[i] < minDistance)
                    {
                        minDistance = distance[i];
                        minDistanceIndex = i;
                    }
                }

                // If it is unreachable or there are no other cities to visit
                if (minDistanceIndex == -1 || minDistanceIndex == target)
                    break;

                // Mark the city as visited
                isVisited[minDistanceIndex] = true;

                // Check neighboring cities and update distances
                for (int j = 0; j < numOfCity; j++)
                {
                    if (!isVisited[j] && distanceJagged[minDistanceIndex][j] != double.PositiveInfinity)
                    {
                        double newDistance = distance[minDistanceIndex] + distanceJagged[minDistanceIndex][j];
                        if (newDistance < distance[j])
                        {
                            distance[j] = newDistance;
                        }
                    }
                }
            }
            return distance[target];
        }

        public static List<Tuple<int, int, double>> CalculateDistance(double[][] originalJagged, double[][] distanceJagged, string[] cities)
        {
            var difList = new List<Tuple<int, int, double>>();
            var calculatedCouples = new HashSet<(int, int)>();

            for (int i = 0; i < 81; i++)
            {
                for (int j = 0; j < 81; j++)
                {
                    if (distanceJagged[i][j] == Double.PositiveInfinity && i != j)
                    {
                        var cityCouple = (Math.Min(i, j), Math.Max(i, j)); 

                        //Continue if the pair has already been saved
                        if (calculatedCouples.Contains(cityCouple))
                            continue;

                        calculatedCouples.Add(cityCouple);

                        double calculatedDistance = Dijkstra(i, j, distanceJagged); //it is equal to dijkstra's result
                        double originalDistance = originalJagged[i][j]; //equal to original distance
                        double difference = calculatedDistance - originalDistance;

                        if (difference < 0) //turning negative distance into positive
                        {
                            double newDif = difference * (-1);
                            difference = newDif;
                        }

                        difList.Add(new Tuple<int, int, double>(i, j, difference));
                        Console.WriteLine("Distance between  " + cities[i + 1] + " and " + cities[j + 1] + " in the highway chart: " + originalDistance + "\n"
                        + " Value calculated with Dijkstra algorithm: " + calculatedDistance + "\n"
                        + " Distance difference between two accounts : " + difference);
                    }
                }
            }
            return difList;
        }

        public static void PrintMinDifference()
        {
            var difList = CalculateDistance(cityOriginalDistanceJagged, cityInfinityDistanceJagged, cities);
            double minValue = difList.Min(item => item.Item3); 
            double maxValue = difList.Max(item => item.Item3); 
            var minItems = difList.Where(item => item.Item3 == minValue).ToList();//cities with minimum difference
            var maxItems = difList.Where(item => item.Item3 == maxValue).ToList();//cities witf maximum differnce

            Console.WriteLine("\n Cities with the shortest distance difference ");
            foreach (var item in minItems)
            {
                Console.WriteLine($"({cities[item.Item1 + 1]}, {cities[item.Item2 + 1]}, {item.Item3})");
            }

            Console.WriteLine("\n Cities with the longest distance difference ");
            foreach (var item in maxItems)
            {
                Console.WriteLine($"({cities[item.Item1 + 1]}, {cities[item.Item2 + 1]}, {item.Item3})");

            }
            Console.ReadKey();
        }

        // madde d
        public static void CountyMatris() //read file and create county distance matris
        {
            string projectpath = Directory.GetCurrentDirectory();
            string fileName = "ilceler.txt";
            string filePath = Path.Combine(projectpath, fileName);
            string[] countyDistanceArray;

            try
            {
                string file = File.ReadAllText(filePath);
                countyDistanceArray = file.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
                countyDistanceArray = Array.Empty<string>();
            }

            for (int i = 0; i < 30; i++)
            {

                for (int j = 0; j < 30; j++)
                {
                    countyOriginalDistance[i, j] = double.Parse(countyDistanceArray[i * 30 + j]); //for original values
                    countyInfinityDistance[i,j] = double.Parse(countyDistanceArray[i*30 + j]); //for infinite values
                }
            }

        }

        public static void countyInfinite() 
        {
            neighborCounties = new Dictionary<int, List<int>> //dict for neighbor counties
            {
                { 1, new List<int> { 23,12,5 } }, // Aliağa
                { 2, new List<int> { 21,24,15 } }, //Balçova
                { 3, new List<int> { 29,25,28,18 } }, //Bayındır
                { 4, new List<int> { 7,17,21} }, //Bayraklı
                { 5, new List<int> { 1, 11,19 } }, //Bergama
                { 6, new List<int> { 20,25 } }, //Beydağ
                { 7, new List<int> { 17,21,4,18,8,23 } }, //Bornova
                { 8, new List<int> { 21, 7, 15,13,22,29,18 } }, //Buca
                { 9, new List<int> { 30 } }, //Çeşme
                { 10, new List<int> {17,23 } }, //Çiğli
                { 11, new List<int> {5} }, //Dikili
                { 12, new List<int> {23,1 } }, //Foça
                { 13, new List<int> {15,22,8} }, //Gaziemir
                { 14, new List<int> {24,30,26,15} }, //Güzelbahçe
                { 15, new List<int> { 14,21,8,13,22,2,24 } }, //Karabağlar
                { 16, new List<int> { 30} }, //Karaburun
                { 17, new List<int> { 10, 7, 4, 23 } }, //Karşıyaka
                { 18, new List<int> { 7,3,29,8 } }, //Kemalpaşa
                { 19, new List<int> { 5 } }, //Kınık
                { 20, new List<int> {6,25} }, //Kiraz
                { 21, new List<int> {7,2,8,15,4} }, //Konak
                { 22, new List<int> { 13,15,26,29,27,8} }, //Menderes
                { 23, new List<int> {10,12,1,17,7} }, //Menemen
                { 24, new List<int> {2,14,15} }, //Narlıdere
                { 25, new List<int> { 6,20,28,3} }, //Ödemiş
                { 26, new List<int> { 14,30,22} }, //Seferihisar
                { 27, new List<int> {22,29,28} }, //Selçuk
                { 28, new List<int> {3,25,29,30} }, //Tire
                { 29, new List<int> {18,22,27,3,28,8} }, //Torbalı
                { 30, new List<int> { 14,16,9,26} }//urla
            };
           
            for (int i = 0; i < 30; i++) 
            {
                for (int j = 0; j < 30; j++)
                {
                    if (i != j && (!neighborCounties.ContainsKey(i + 1) || !neighborCounties[i + 1].Contains(j + 1)))
                    {

                        countyInfinityDistance[i, j] = Double.PositiveInfinity; //make infinite value
                        
                    }
                }
            }

        }
        public static double CountyDijkstra(int first, int target, double[,] countyInfinityDistance) //dijkstra algorithm for counties
        {
            int numOfCounty = 30;
            double[] distance = new double[numOfCounty];
            bool[] isVisited = new bool[numOfCounty];

            //Set all initial distances to infinite
            for (int i = 0; i < numOfCounty; i++)
                distance[i] = double.PositiveInfinity;

            //start from first city
            distance[first] = 0;

            while (true)
            {
                int minDistanceIndex = -1;
                double minDistance = double.PositiveInfinity;

                // This is the city that has not yet been visited and has the smallest distance
                for (int i = 0; i < numOfCounty; i++)
                {
                    if (!isVisited[i] && distance[i] < minDistance)
                    {
                        minDistance = distance[i];
                        minDistanceIndex = i;
                    }
                }      
                if (minDistanceIndex == -1 || minDistanceIndex == target)
                    break;

                isVisited[minDistanceIndex] = true;

                for (int j = 0; j < numOfCounty; j++)
                {
                    if (!isVisited[j] && countyInfinityDistance[minDistanceIndex, j] != double.PositiveInfinity)
                    {
                        double newDistance = distance[minDistanceIndex] + countyInfinityDistance[minDistanceIndex, j];
                        if (newDistance < distance[j])
                        {
                            distance[j] = newDistance;
                        }
                    }
                }
            }
            return distance[target];
        }

        public static List<Tuple<int, int, double>> CalculateDistCounty(double[,] orjinalMatris, double[,] matris, string[] counties)
        {
            var difList = new List<Tuple<int, int, double>>();
            var calculatedCouples = new HashSet<(int, int)>();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (matris[i, j] == Double.PositiveInfinity && i != j)
                    {
                        var couples = (Math.Min(i, j), Math.Max(i, j));

                        if (calculatedCouples.Contains(couples)) 
                            continue;

                        calculatedCouples.Add(couples);

                        double calculatedDistance = CountyDijkstra(i, j, matris); //equal to dijkstra's result
                        double originalDistance = orjinalMatris[i, j]; //equal to highway chart's value
                        double difference = calculatedDistance - originalDistance;
                        if (difference < 0)
                        {
                            double newDif = difference * (-1);
                            difference = newDif;
                        }
                        difList.Add(new Tuple<int, int, double>(i, j, difference));
                        Console.WriteLine("Distance between  " + counties[i] + " and " + counties[j] + " in the highway chart: " + originalDistance + "\n"
                        + "Value calculated with Dijkstra algorithm: " + calculatedDistance + "\n"
                        + "Distance difference between two accounts : " + difference);
                    }
                }
                
            }

            return difList;
        }

        public static void MinDifCunty()
        {
            var difList = CalculateDistCounty(countyOriginalDistance, countyInfinityDistance, countyNames);
            double minValue = difList.Min(item => item.Item3);
            double maxValue = difList.Max(item => item.Item3);
            var minItems = difList.Where(item => item.Item3 == minValue).ToList(); //counties with minimum difference
            var maxItems = difList.Where(item => item.Item3 == maxValue).ToList(); //counties with max difference

            Console.WriteLine("\n Counties with the shortest distance difference ");
            foreach (var item in minItems)
            {
                Console.WriteLine($"({countyNames[item.Item1]}, {countyNames[item.Item2]}, {item.Item3})");
            }

            Console.WriteLine("\n Counties with the longest distance difference ");
            foreach (var item in maxItems)
            {
                Console.WriteLine($"({countyNames[item.Item1 + 1]}, {countyNames[item.Item2 + 1]}, {item.Item3})");

            }
            Console.ReadKey();

        }
    }
}