using App.Forms.Config;
using App.Forms.Services;
using App.WindowsForms.Repository;
using Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Configuration;

namespace App.WindowsForms.BackgroundServices
{
    public class FillInInformationBackgroundService : BackgroundService
    {
        private readonly ILogger<FillInInformationBackgroundService> _logger;
        public event EventHandler DataProcessed;
        private BillToPayRegistrationRepository _billToPayRegistrationRepository;

        public FillInInformationBackgroundService()
        {
            _billToPayRegistrationRepository = BillToPayRegistrationRepository.Instance;
        }

        public FillInInformationBackgroundService(ILogger<FillInInformationBackgroundService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _billToPayRegistrationRepository = BillToPayRegistrationRepository.Instance;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (IsRoutineEnabled())
            {
                try
                {
                    _ = Task.Run(() => RoutineFromTimeToTime(stoppingToken), stoppingToken);

                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro");
                }
            }
            else
            {
               
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        private static bool IsRoutineEnabled()
        {
            return bool
                .TryParse(ConfigurationManager.AppSettings["routine-worker-enable"], out bool isEnabled) && isEnabled;
        }

        private static TimeSpan IsRoutineNextTime()
        {
            if (TimeSpan.TryParse(ConfigurationManager.AppSettings["routine-worker-start-time"], out TimeSpan time))
            {
                return time;
            }
            return TimeSpan.FromMinutes(5); // Default to 5 minutes if not set
        }

        private async Task RoutineFromTimeToTime(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    BillToPayServices.Environment = UrlConfig.GetEnviromentInitialize();
                    var output = await BillToPayServices.SearchRecordsAwaitingCompleteRegistration(new ViewModel.RecordsAwaitingCompleteRegistrationViewModel());

                    IList<BillToPayRegistration> billToPayRegistration = new List<BillToPayRegistration>();

                    if (output.Output == null || output.Output.Data == null)
                    {
                        continue;
                    }

                    var dados = output.Output.Data;

                    var json = JsonConvert.SerializeObject(dados);

                    var conversion = JsonConvert.DeserializeObject<IList<BillToPayRegistration>>(json);

                    foreach (var item in conversion!)
                    {
                        billToPayRegistration.Add(item);
                    }

                    // Problema de Thread, não é chamado novamente o while depois da primeira vez. :(
                    _billToPayRegistrationRepository.AddRangeOnMemory(billToPayRegistration);

                    var totalMilliseconds = int.Parse(IsRoutineNextTime().TotalMilliseconds.ToString());

                    Thread.Sleep(totalMilliseconds);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro");
                }
            }
        }
    }
}
