﻿namespace NewsSystem.Application.Statistics.Queries.Current
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetCurrentStatisticsQuery : IRequest<GetCurrentStatisticsOutputModel>
    {
        public class GetCurrentStatisticsQueryHandler : IRequestHandler<GetCurrentStatisticsQuery, GetCurrentStatisticsOutputModel>
        {
            private readonly IStatisticsRepository statistics;

            public GetCurrentStatisticsQueryHandler(IStatisticsRepository statistics) 
                => this.statistics = statistics;

            public Task<GetCurrentStatisticsOutputModel> Handle(
                GetCurrentStatisticsQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetCurrent(cancellationToken);
        }
    }
}
