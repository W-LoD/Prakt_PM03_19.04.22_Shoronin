using System;
using System.IO;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = -1; //Для размера массива
            Console.WriteLine("Введите размер массива N= ");
            while (N < 1)
            {
                try
                {
                    N = int.Parse(Console.ReadLine()); // Считывание размера
                    if(N<=0)
                        Console.WriteLine("Размер массива должен быть целым числом больше 0!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Размер массива должен быть целым числом больше 0!");
                }
            }
            TouristicOperator touristicOperator = new TouristicOperator(); //Создание экземпляра класса TouristicOperator
            touristicOperator.Trips = new Trip[N]; //Создание массива указателей размера N
            Console.WriteLine("Введите элементы массива(Продолжительность поездки в днях, Цену поездки целой суммой в рублях, Размер туристической группы)");
            for (int i = 0; i < N; i++)
            {
                touristicOperator.Trips[i] = new Trip(); //Распределение памяти указателям
                try
                {
                    touristicOperator.Trips[i].Duration = int.Parse(Console.ReadLine()); //Заполнение поля Продолжительность поездки
                    touristicOperator.Trips[i].Price = int.Parse(Console.ReadLine()); //Заполнение поля Цена
                    touristicOperator.Trips[i].Size_of_the_tour_group = int.Parse(Console.ReadLine()); //Заполнение поля Размер туристической группы
                }
                catch (Exception)
                {
                    Console.WriteLine("Данные должны быть целыми числами!");
                    i--;
                }
            }
            touristicOperator.Sort_mas(touristicOperator.Trips); //Вызов метода сортировки массива
            touristicOperator.Write_to_file(touristicOperator, N); //Вызов метода записи в файл
        }  
    }
    public class Trip //Класс Trip с соответствующими полями
    {
        public int Duration;
        public int Price;
        public int Size_of_the_tour_group;
    }
    public class TouristicOperator //Класс TouristicOperator с соответствующими полями
    {
        public Trip[] Trips; //Хранение массива Trip

        public void Sort_mas(Trip[] Trips) //Сортировка массива по двум полям
        {
            Trip temp;
            for (int i = 0; i < Trips.Length - 1; i++)
            {
                for (int j = i + 1; j < Trips.Length; j++)
                {
                    if ((Trips[i].Price > Trips[j].Price) || (Trips[i].Size_of_the_tour_group > Trips[j].Size_of_the_tour_group))
                    {
                        temp = Trips[i];
                        Trips[i] = Trips[j];
                        Trips[j] = temp;
                    }
                }
            }
        }

        public void Write_to_file(TouristicOperator touristicOperator, int N) //Запись массива в файл
        {
            using (StreamWriter sr = new StreamWriter("Text.txt", true))
            {
                for (int i = 0; i < N; i++)
                {
                    sr.WriteLine("Продолжительность поездки: " + touristicOperator.Trips[i].Duration + " Цена поездки: " 
                        + touristicOperator.Trips[i].Price + " Размер туристической группы: " 
                        + touristicOperator.Trips[i].Size_of_the_tour_group);
                }
            }
        }
    }
}
