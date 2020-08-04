using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using CentralDeErros.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeErros.Services
{
    public class OccurrenceService : ServiceBase<Occurrence>
    {
        public OccurrenceService(CentralDeErrosDbContext context) : base(context)
        {
        }

        /// <summary>
        /// List values ​​based on pagination
        /// Can pass the start and end of occurences
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public ICollection<Occurrence> List(int? start, int? end)
        {
            var response = Context.Occurrences
                .Skip(start.HasValue ? start.Value : 0);

            if(end.HasValue)
            {
                response.Take(end.Value);
            }

            return response.ToList();
                
        }

        /// <summary>
        /// Search based on Environment Id
        /// </summary>
        /// <param name="enviromentId"></param>
        /// <returns></returns>
        public ICollection<Occurrence> SearchByEnviroment(int enviromentId)
        {
            return List(x => x.EnviromentId == enviromentId).ToList();
        }


        /// <summary>
        /// Search based on Error Level
        /// </summary>
        /// <param name="errorLevel"></param>
        /// <returns></returns>
        public ICollection<Occurrence> SearchByErrorLevel(string errorLevel)
        {
            return List(x => x.Error.Level.Name == errorLevel.ToLower())
                .ToList();
        }


        /// <summary>
        /// Search between a given DateTime
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public ICollection<Occurrence> SearchByDate(DateTime start, DateTime end)
        {
            return List(x => x.OccurrenceDate >= start && x.OccurrenceDate <= end).ToList();
        }
    }
}
