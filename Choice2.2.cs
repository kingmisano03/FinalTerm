using System;

class MainClass {
  public static void Main (string[] args) {
    double B1, B2, B3, payment, remainingBalance;
    B1 = Convert.ToDouble(Console.ReadLine());
    B2 = Convert.ToDouble(Console.ReadLine());
    B3 = Convert.ToDouble(Console.ReadLine());

    while (true) {
      payment = Convert.ToDouble(Console.ReadLine());
      if (payment <= 0) {
        break;
      }
      if (B1 >= payment) {
        B1 -= payment;
      } else if (B2 >= payment - B1) {
        B2 -= payment - B1;
        B1 = 0;
      } else if (B3 >= payment - B1 - B2) {
        B3 -= payment - B1 - B2;
        B2 = B1 = 0;
      } else {
        remainingBalance = payment - B1 - B2 - B3;
        B1 = B2 = B3 = 0;
        Console.WriteLine("Remaining Balance: {0}", remainingBalance);
        break;
      }
    }
    Console.WriteLine("Balance 1: {0}, Balance 2: {1}, Balance 3: {2}", B1, B2, B3);
  }
}
