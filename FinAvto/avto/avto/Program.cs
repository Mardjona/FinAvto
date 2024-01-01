using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите информацию о машине 1");
        var avto1 = new Avto();
        avto1.EnterInfo();
        Console.WriteLine("Введите информацию  о машине 2 ");
        var avto2 = new Avto();
        avto2.EnterInfo();
        List<Avto> avtos = new List<Avto>() { avto1, avto2 };
        while (true)
        {
           Console.WriteLine("Выберите машину: 1 или 2 ");
            string g = Console.ReadLine();
            if (g == "1")
            {
                avto1.Menu();
            }
            else if (g == "2")
            {
                avto2.Menu();
            }
        }

    }
}



