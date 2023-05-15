using System;

class Program {
    static void Main(string[] args) {
        Console.Write("ใส่ความจุของถังน้ำ : ");
        double Vmax = double.Parse(Console.ReadLine());
        Console.Write("ปริมาณน้ำเฉลี่ยที่ดื่ม : ");
        double Vdrink = double.Parse(Console.ReadLine());
        Console.Write("ปริมาณน้ำที่เติม : ");
        double Vfill = double.Parse(Console.ReadLine());
        Console.Write("ระยะเวลาคั่นระหว่างช่วงพัก : ");
        double tdrink = double.Parse(Console.ReadLine());
        Console.Write("ระยะเวลาคั่นระหว่างรอบเติมน้ำ : ");
        double tfill = double.Parse(Console.ReadLine());
        Console.Write("ระยะเวลารวมของกิจกรรม : ");
        double tday = double.Parse(Console.ReadLine());

        double V = 0; 
        double time = 0; 
        bool enoughWater = true;

        while (time < tday) {
        
            if (time > 0 && time % tdrink == 0) {
                V -= Vdrink;
                if (V < 0) {
                    enoughWater = false;
                    break;
                }
            }

            
            if (time > 0 && time % tfill == 0) {
                V += Vfill;
                if (V > Vmax) {
                    enoughWater = false;
                    Console.WriteLine("Overflow Water");
                    break;
                }
            }

            time += 1; 
        }

        if (enoughWater && V <= Vmax) {
            Console.WriteLine("Enough Water, {0} left", V);
        } else {
            Console.WriteLine("Not Enough Water");
        }
    }
}
