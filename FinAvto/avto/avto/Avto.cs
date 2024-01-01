using System.Net;
using System.Collections.Generic;

class Avto
{
    string NamberCar; //номер машины
    double MaxBak;   // максимально вместимость  топлива в бензобаке
    double AmountFuel;  // количество топлива 
    double FuelConsum; // расход топлива на 100 км 
    double Dist; // дистанция
    double top; // топливо
    double mileage; // пробег
    private List<int> corA = new List<int>() { 0, 0 }; //начальная координата
    private List<int> corB;     //конечная координата
    // ввод информации
    public void EnterInfo()
    {
        Console.Write("Введите номер машины: ");
        NamberCar = Console.ReadLine();
        Console.Write("Введите максимальную вместимость топлива в бензобаке: ");
          MaxBak = Convert.ToDouble(Console.ReadLine());
        Console.Write("текущее количество топлива в бензобаке: ");
        AmountFuel = Convert.ToDouble(Console.ReadLine());
       /// AmountFuel = MaxBak;
        Console.Write("Введите расход топлива на 100км: ");
        FuelConsum = Convert.ToDouble(Console.ReadLine());
        if (AmountFuel > MaxBak) { Console.WriteLine("Ошибка. Текущее значение не может превышать максимальное"); return; }
    }
    // вывод информации
    void OutInfo()
    {
        Console.WriteLine($"Номер машины: {NamberCar}" +
            $"\nМаксимальная вместимость топлива в бензобаке: {MaxBak} л." +
            $"\nРасход топлива на 100км: {FuelConsum} л." +
            $"\nТекущее количество топлива в бензобаке: {AmountFuel} л. ");
        
    }
    // метод заправки
    void Zapravka()
    {
             Console.Write("Сколько литров топлива вам понадобиться? Введите значение: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a > MaxBak)
            {
                Console.WriteLine("Вы превысили лимит доступного значения, пожалуйста измените ваш выбор");
                Zapravka();
            }
            else if (a + AmountFuel <= MaxBak && a > 0)
            {
                AmountFuel += a;
                Console.Write($"\nБак полный");
            }
            else if (a + AmountFuel > MaxBak)
            {
                Console.WriteLine("\nКоличество топлива не может превысить максимальную вместимость");
                Zapravka();
            }
            else if (AmountFuel > MaxBak)
            {
                Console.WriteLine("Ошибка");
                Zapravka();
            }
            else
            {
                Console.WriteLine("\nОшибка введения значения, повторите попытку");
                Zapravka();
            }
    }
    // метод езды
    void Move()
    {
       Dist = Distation();
        //double ost = MaxBak - AmountFuel; // остаток топлива
        double ost = AmountFuel - top;
        if (AmountFuel < top)
        {
            double currendD = AmountFuel / (FuelConsum / 100); // сколько км  проехал 
            double cur = currendD; // временная переменная для хранения currendD
            while (AmountFuel < top)
            {
              
                double Distt = Dist - currendD; // сколько км осталось проехать
                Console.WriteLine($" \nВы проехали {currendD} км, вам осталось {Distt} км. Нужно {top - AmountFuel}" +
                    $"\nЧтобы продолжить поездку заправьте машину ");
                AmountFuel = 0;
                Console.WriteLine("\nХотите заполнить бак? Да/ Нет?: ");
                string ans = Console.ReadLine();
                if (ans == "Да" || ans == "ДА" || ans == "да" || ans == "lf" || ans == "LF" || ans == "LF")
                {
                    Zapravka();
                    currendD += cur;
                    Distt = Dist - currendD;
                    top -= AmountFuel;

                }
                else if (ans == "Нет" || ans == "НЕТ" || ans == "нет" || ans == "ytn" || ans == "Ytn" || ans == "YTN")
                {
                    Console.WriteLine("\nВы заглохли");
                    return;
                }
            }
            while (AmountFuel > top)
            {
                ost = AmountFuel - top;
                Console.WriteLine($"\nВы проехали {Dist} км, в баке осталось: {ost} л");
                break;
            }

        }
      else if (MaxBak > top)
      {
           Console.WriteLine($"\nВы проехали {Dist} км, в баке осталось: {ost} л");
      }
         mileage = Math.Round(top * 100, 2) / FuelConsum; // формула пробега 
         Console.WriteLine("\nПробег Машины: км");
         Console.WriteLine(Math.Round(mileage, 2));
    }
     //координаты
    double Distation()
    {
        corB = new List<int>();
        Console.Write("Введите координаты: ");
        string[] s = Console.ReadLine().Split(',', ' ', ';');
        foreach (string s2 in s) { corB.Add(Int32.Parse(s2)); }
        Dist = Math.Sqrt(
            Math.Pow(corB[0] - corA[0], 2) +
            Math.Pow(corB[1] - corA[1], 2)
        );
        top = (FuelConsum / 100) * Dist; // сколько топлива потребуется, чтобы прооехать дистанцию, которую задал пользователь

        Console.Write("Дистанция равна: " + Dist + 
            $" Чтобы проехать такую дистанцию вам понадобится {top} л. топлива"); ;
        return Dist;
    }
    public void Menu()
    {
        Console.WriteLine("Выберите действие: \n1-Узнать данные \n2-Заправитть машину \n3-Передвижение \n4- Выход");
        string ans = Console.ReadLine();
        if (ans == "1")
        {
            OutInfo();
        }
        else if (ans == "2")
        {
            Zapravka();

        }
        else if (ans == "3")
        {
            Move();
        }
        else if (ans == "4")
        {
            return;
        }
    }
}







    


