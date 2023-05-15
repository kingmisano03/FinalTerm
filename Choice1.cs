using System;

namespace Covid19Simulation
{
    class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public int infected { get; set; }

        public City(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.infected = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("จำนวนเมืองที่แสดงในแบบจำลอง: ");
            int n = int.Parse(Console.ReadLine());

            City[] cities = new City[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("City {0}", i);
                Console.Write("ชื่อเมือง: ");
                string name = Console.ReadLine();
                Console.Write("จำนวนเมืองที่ติดต่อกับเมืองนี้: ");
                int m = int.Parse(Console.ReadLine());

                int[] connectedIds = new int[m];

                for (int j = 0; j < m; j++)
                {
                    bool validId = false;
                    do
                    {
                        Console.Write("หมายเลขประจำเมืองนี้ {0}: ", j + 1);
                        int id = int.Parse(Console.ReadLine());
                        if (id < i || id >= n || id == i || Array.IndexOf(connectedIds, id) != -1)
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        else
                        {
                            validId = true;
                            connectedIds[j] = id;
                        }
                    } while (!validId);
                }

                cities[i] = new City(i, name);
            }

            Console.WriteLine("\nCity ID\tName\tInfected");
            foreach (City city in cities)
            {
                Console.WriteLine("{0}\t{1}\t{2}", city.id, city.name, city.infected);
            }

            Console.Write("\nใส่เหตุการณ์ (Outbreak, Vaccinate, Lockdown): ");
            string eventType = Console.ReadLine();

            switch (eventType)
            {
                case "Outbreak":
                    Console.Write("เมืองที่เกิด outbreak : ");
                    int outbreakCityId = int.Parse(Console.ReadLine());
                    cities[outbreakCityId].infected++;
                    break;
                case "Vaccinate":
                    Console.Write("เมืองที่ได้รับ vaccination : ");
                    int vaccinateCityId = int.Parse(Console.ReadLine());
                    cities[vaccinateCityId].infected--;
                    break;
                case "Lockdown":
                    Console.Write("เมืองที่ lockdown : ");
                    int lockdownCityId = int.Parse(Console.ReadLine());
                    cities[lockdownCityId].infected++;
                    foreach (int connectedCityId in GetConnectedCityIds(cities, lockdownCityId))
                    {
                        cities[connectedCityId].infected--;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid event");
                    break;
            }

            Console.WriteLine("\nCity ID\tName\tInfected");
            foreach (City city in cities)
            {
                Console.WriteLine("{0}\t{1}\t{2}", city.id, city.name, city.infected);
            }
        }

        static int[] GetConnectedCityIds(City[] cities, int cityId)
        {
            int[] connectedCityIds = new int[0];

           
