using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення потягів
            SchedulerOfTrain[] trains = new SchedulerOfTrain[]
            {
                new SchedulerOfTrain()
                {
                    Name = "Тарпан",
                    TypeOfTrain = "Вантажно-пасажирський",
                    DepartureTime = DateTime.UtcNow,
                    ArrivalTime = DateTime.Now,
                    PlaceOfArrival = "London",
                    PlaceOfDeparture = "Kyiv"
                },
                new SchedulerOfTrain()
                {
                    Name = "Дніпро",
                    TypeOfTrain = "Фірмовий-пасажирський",
                    DepartureTime = DateTime.UtcNow,
                    ArrivalTime = DateTime.Now,
                    PlaceOfArrival = "Paris",
                    PlaceOfDeparture = "Kyiv"
                },
                new SchedulerOfTrain()
                {
                    Name = "Hyperloop",
                    TypeOfTrain = "Пасажирський",
                    DepartureTime = DateTime.UtcNow,
                    ArrivalTime = DateTime.Now,
                    PlaceOfArrival = "Roma",
                    PlaceOfDeparture = "Kyiv"
                },
            };

            // створення станції
            RailwayStation station = new RailwayStation();


            for (int i = 0; i < trains.Length; i++)
            {
                station.SendingTrain(trains[i]);
                station.ArrivalTrain(trains[i]);
            }


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tТабличка на ЖД вокзалі:");
            Console.ResetColor();

            // Вивід таблички на станції
            for (int i = 0; i < trains.Length; i++)
            {
                Console.WriteLine(trains[i].ToString());
            }

            // delay
            Console.ReadKey(true);
        }
    }
}
