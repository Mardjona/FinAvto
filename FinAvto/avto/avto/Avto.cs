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
     void EnterInfo()
    {
        Console.Write("Введите номер машины: ");
        NamberCar = Console.ReadLine();
        Console.Write("Введите максимальную вместимость топлива в бензобаке: ");
        MaxBak = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите текущее количество топлива в бензобаке: ");
        AmountFuel = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите расход топлива на 100км: ");
        FuelConsum = Convert.ToDouble(Console.ReadLine());
    }
    // вывод информации
     void OutInfo()
    {
        Console.WriteLine($"Номер машины: {NamberCar}\nМаксимальная вместимость топлива в бензобаке: {MaxBak} л.\nРасход топлива на 100км: {FuelConsum} л.\nТекущее количество топлива в бензобаке: {AmountFuel} л. ");
    }
    // метод заправки
     void Zapravka()
    {
        Console.WriteLine("Хотите заправить машину? ДА / НЕТ");
        string ans = Console.ReadLine();
        if (ans == "Да" || ans == "ДА" || ans == "да" || ans == "lf" || ans == "LF" || ans == "Lf")
        {
            Console.Write("Сколько литров топлива вам понадобиться? Введите значение: ");
            top = Convert.ToInt32(Console.ReadLine());
            if (top > MaxBak)
            {
                Console.WriteLine("Вы превысили лимит доступного значения, пожалуйста измените ваш выбор");
                Zapravka();
            }
            else if (top + AmountFuel <= MaxBak && top > 0)
            {
                AmountFuel += top;

                Console.Write($"Вы заполнили бак на {top} литров, сейчас вам доступно {AmountFuel} литров бензина");
            }
            else if (top + AmountFuel > MaxBak)
            {
                Console.WriteLine("Количество топлива не может превысить максимальную вместимость");
                Zapravka();
                return;
            }
            else if (AmountFuel > MaxBak)
            {
                Console.WriteLine("Ошибка");
                Zapravka();
                return;

            }
            else
            {
                Console.WriteLine("Ошибка введения значения, повторите попытку");
                Zapravka();
                return;
            }

        }
        else if (ans == "Нет" || ans == "НЕТ" || ans == "нет" || ans == "ytn" || ans == "Ytn" || ans == "YTN")
        {
            Console.WriteLine("Изменений в баке нет");
        }

        else
        {
            Console.WriteLine("Ошибка! Повторите попытку, введите Да, если надо заправить бак или Нет, если не нужно");
            Zapravka();
        }
    }
   // метод езды
    void Move()
    {
        //mileage = Math.Round(MaxBak * 100, 2) / FuelConsum; // формула пробега 
        //Console.WriteLine("Пробег Машины: км");
       // Console.WriteLine(Math.Round(mileage, 2));
        Dist = Distation();
        double prob = Dist;
        top = (FuelConsum / 100) * Dist; // сколько топлива потребуется, чтобы прооехать дистанцию, которую задал пользователь
        double ost = AmountFuel - top; // остаток топлива 
        if (AmountFuel > top)

        {
            Console.WriteLine($"Вы проехали {Dist} км, в баке осталось: {ost} л");
        }
        else if (AmountFuel < top)
            while (true)
            {
                double currendD = AmountFuel / (FuelConsum / 100); // топлива хватило на определенную дистанцию
                Dist -= currendD; // сколько км осталось проехать
                top = Dist * (FuelConsum / 100); // сколько нужно топлива чтобы доехать до цели
                AmountFuel -= AmountFuel;
                Console.WriteLine($" Не достаточно топлива. Вы проехали {prob - Dist} км, вам осталось {Dist} км, для этого понадобится {top} л. топлива, вам доступно {AmountFuel} ");
                Console.WriteLine("Хотите заполнить бак? Да/ Нет?: ");
                string ans = Console.ReadLine();
                if (ans == "Да" || ans == "ДА" || ans == "да" || ans == "lf" || ans == "LF" || ans == "LF")
                {
                    Zapravka();
                    if (AmountFuel < top)
                    {
                        return;
                    }
                    else if (AmountFuel > top)
                    {
                        top = Dist * (FuelConsum / 100);
                        ost = AmountFuel - top;
                        Console.WriteLine($"!\nВы доехали до цели! топлива осталось {ost}");
                    }

                }
                else if (ans == "Нет" || ans == "НЕТ" || ans == "нет" || ans == "ytn" || ans == "Ytn" || ans == "YTN")
                {
                    Console.WriteLine("Вы заглохли");
                    return;
                }
                
            }
        mileage = Math.Round(top * 100, 2) / FuelConsum; // формула пробега 
        Console.WriteLine("Пробег Машины: км");
         Console.WriteLine(Math.Round(mileage, 2));

    }
    //координаты
    double Distation()
    {


        corB = new List<int>();
        Console.Write("Введите координаты: ");
        string[] s = Console.ReadLine().Split(',', ' ', ';');
        foreach (string s2 in s) { corB.Add(Int32.Parse(s2)); }
        double c = Math.Sqrt(
            Math.Pow(corB[0] - corA[0], 2) +
            Math.Pow(corB[1] - corA[1], 2)
        );
        return c;
    }
    public void Menu()
    {
        Console.WriteLine("Выберите действие: \n1-Ввести данные \n2-Узнать данные \n3-Заправитть машину \n4-Передвижение \n5- Выход");
        string ans = Console.ReadLine();
        if (ans == "1")
        {
            EnterInfo();
        }
        else if (ans =="2")
        {
            OutInfo();
        }
        else if (ans == "3")
        {
            Zapravka();

        }
        else if ( ans == "4")
        {
            Move();
        }
        else if ( ans == "5")
        {
            return;
        }

    }
    
 }


    


