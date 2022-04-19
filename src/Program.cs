using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
    }
}
