namespace NewsSystem.Domain.Statistics.Models
{
    using NewsSystem.Domain.Common;
    using System;
    using System.Collections.Generic;
     
    public class StatisticsData : IInitialData
    {
        public Type EntityType => typeof(Statistics);

        public IEnumerable<object> GetData()
            => new List<Statistics>
            {
                new Statistics()
            };
    }
}
