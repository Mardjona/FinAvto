using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
      var avto1 = new Avto();
        var avto2 = new Avto();
        
        List<Avto> avtos = new List<Avto>() {avto1, avto2};
        //while (true)

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




