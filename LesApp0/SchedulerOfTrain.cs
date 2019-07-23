using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Розклад потягів
    /// </summary>
    struct SchedulerOfTrain
    {
        /// <summary>
        /// Назва потяга
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Тип потяга
        /// </summary>
        public string TypeOfTrain { get; set; }
        /// <summary>
        /// Час відправлення
        /// </summary>
        public DateTime DepartureTime { get; set; }
        /// <summary>
        /// Час прибуття
        /// </summary>
        public DateTime ArrivalTime { get; set; }
        /// <summary>
        /// Місце відправлення
        /// </summary>
        public string PlaceOfDeparture { get; set; }
        /// <summary>
        /// Місце прибуття
        /// </summary>
        public string PlaceOfArrival { get; set; }

        public override string ToString()
        {
            string s = new StringBuilder()
                .Append($"\n\tНазва потяга - {Name} ")
                .Append($"\n| Тип потяга - {TypeOfTrain} ")
                .Append($"\n| Час відправлення потяга - {DepartureTime} ")
                .Append($"\n| Час прибуття потяга - {ArrivalTime} ")
                .Append($"\n| Місце відправлення потяга - {PlaceOfDeparture} ")
                .Append($"\n| Місце прибуття - {PlaceOfArrival} ")
                .ToString();

            return s; 
        }

    }
}
