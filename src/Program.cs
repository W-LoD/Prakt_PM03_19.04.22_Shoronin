﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            Console.WriteLine("Введите размер массива N= ");
            try
            {
                N = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Размер массива должен быть числом больше 0!");
            }
            TouristicOperator touristicOperator = new TouristicOperator();
            touristicOperator.Trips = new Trip[N];
            Console.WriteLine("Введите элементы массива(Продолжительность поездки в днях, Цену поездки, Размер туристической группы)");
            for (int i = 0; i < N; i++)
            {
                touristicOperator.Trips[i] = new Trip();
                touristicOperator.Trips[i].Duration = int.Parse(Console.ReadLine());
                touristicOperator.Trips[i].Price = int.Parse(Console.ReadLine());
                touristicOperator.Trips[i].Size_of_the_tour_group = int.Parse(Console.ReadLine());
            }
            touristicOperator.Sort_mas(touristicOperator.Trips);
            touristicOperator.Write_to_file(touristicOperator, N);
        }  
    }
    public class Trip
    {
        public int Duration;
        public int Price;
        public int Size_of_the_tour_group;
    }
    public class TouristicOperator
    {
        public Trip[] Trips;

        public void Sort_mas(Trip[] Trips)
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

        public void Write_to_file(TouristicOperator touristicOperator, int N)
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
