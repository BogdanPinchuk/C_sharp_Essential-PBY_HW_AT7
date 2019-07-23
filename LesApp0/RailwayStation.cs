using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Залізнична станція
    /// </summary>
    class RailwayStation
    {
        /// <summary>
        /// Відправлення потяга
        /// </summary>
        public void SendingTrain(SchedulerOfTrain train)
        {
            string temp = $"\nПотяг \"{train.Name}\" " +
                $"типу \"{train.TypeOfTrain}\" " +
                $"відправлається із {train.PlaceOfDeparture} о " +
                $"{train.DepartureTime} ";

            Console.WriteLine(temp);
        }

        /// <summary>
        /// Прибуття потяга
        /// </summary>
        /// <param name="train"></param>
        public void ArrivalTrain(SchedulerOfTrain train)
        {
            string temp = $"\nПотяг \"{train.Name}\" " +
                $"типу \"{train.TypeOfTrain}\" " +
                $"прибуває в {train.PlaceOfArrival} о " +
                $"{train.ArrivalTime} ";

            Console.WriteLine(temp);
        }
    }
}
