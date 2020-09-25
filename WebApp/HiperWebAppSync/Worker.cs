using HiperWebApp.Application.Interfaces;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace HiperWebAppSync
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IApplicationServiceSync _api;

        public Worker(ILogger<Worker> logger, IApplicationServiceSync api)
        {
            _logger = logger;
            _api = api;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    await _api.StartSync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro na syncronia");
                }

                await Task.Delay((int) TimeSpan.FromMinutes(30).TotalMilliseconds, stoppingToken);
            }
        }
    }
}
