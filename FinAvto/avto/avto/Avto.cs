using System.Net;

class Avto
{
    string NamberCar; //номер машины
    double MaxBak;   // максимально вместимость  топлива в бензобаке
    double AmountFuel;  // количество топлива 
    double FuelConsum; // расход топлива на 100 км 
    double Dist; // дистанция
    double top; // топливо
    double mileage; // пробег

    public void EnterInfo()
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

    public void OutInfo()
    {
        Console.WriteLine($"Номер машины: {NamberCar}\nМаксимальная вместимость топлива в бензобаке: {MaxBak} л.\nРасход топлива на 100км: {FuelConsum} л.\nТекущее количество топлива в бензобаке: {AmountFuel} л. ");
    }
    public void Zapravka()
    {
        Console.WriteLine("Хотите заправить машину? ДА / НЕТ");
        string ans = Console.ReadLine();
        if (ans == "Да")
        {
            Console.Write("Сколько литров топлива вам понадобиться? Введите значение  ");
            top = Convert.ToInt32(Console.ReadLine());
            if (top > MaxBak)
            {
                Console.WriteLine("Вы превысили лимит доступного значения, пожалуйста измените ваш выбор");
                Zapravka();
            }
            else if (top <= MaxBak && top > 0)
            {
                AmountFuel += top;

                Console.Write($"Вы заполнили бак на {top} литров, сейчас вам доступно {AmountFuel} литров бензина");
            }
            else if (top + AmountFuel > MaxBak)
            {
                Console.WriteLine("Количество топлива не может превысить максимальную вместимость");
                Zapravka();
            }
            else
            {
                Console.WriteLine("Ошибка введения значения, повторите попытку");
                Zapravka();
            }

        }
        else if (ans == "Нет")
        {
            Console.WriteLine("Изменений в баке нет");
        }

        else
        {
            Console.WriteLine("Ошибка! Повторите попытку, введите Да, если надо заправить бак или Нет, если не нужно");
            Zapravka();
        }
    }
    public void Move()
    {
        mileage = Math.Round(MaxBak * 100, 2) / FuelConsum; // формула пробега 
        Console.WriteLine("Пробег Машины: км");
        Console.WriteLine(Math.Round(mileage, 2));

        Console.WriteLine("Введиет дистанцию, которую хотите проехать(сколько км?)");
        Dist = Convert.ToInt32(Console.ReadLine());
        top = (FuelConsum / 100) * Dist; // сколько топлива потребуется, чтобы прооехать дистанцию, которую задал пользователь
        double ost = AmountFuel - top; // остаток топлива 
        if (AmountFuel > top)
        {
            Console.WriteLine($"Вы проехали {Dist} км, в баке осталось: {ost} л");
        }
        else if (AmountFuel < top)
        {
            double currendD = AmountFuel / (FuelConsum / 100); // топлива хватило на определенную дистанцию
            double remaindis = Dist - currendD; // сколько км осталось проехать
            top = remaindis * (FuelConsum / 100); // сколько нужно топлива, чтобы доехать до цели

            AmountFuel -= AmountFuel;

            Console.WriteLine($"Не достаточно топлива. Вы проехали {currendD} км, вам осталось {remaindis} км для этого понадобится {top} л. топлива, вам доступно {AmountFuel} ");
            Console.WriteLine("Хотите заполнить бак? Да/ Нет?: ");
            string ans = Console.ReadLine();
            if (ans == "Да" || ans == "ДА" || ans == "да" || ans == "ls" || ans == "LS" || ans == "Ls")
            {

                Zapravka();
                top = remaindis * (FuelConsum / 100);
                ost = AmountFuel - top;
                Console.WriteLine($"!\nВы доехали до цели! топлива осталось {ost}");

            }
            else if (ans == "Нет" || ans == "НЕТ" || ans == "нет" || ans == "ytn" || ans == "Ytn" || ans == "YTN")
            {
                Console.WriteLine("Вы заглохли");
            }
            else
            {
                Console.WriteLine("Ошибка");
                return;
            }
        }
        else
        {
            return;
        }
    }


    
}


