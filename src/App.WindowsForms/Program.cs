using App.Forms.Config;
using App.Forms.Forms;
using Serilog;

namespace App.Forms
{
    public static class Program
    {
        public static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                ApplicationConfiguration
                    .Initialize();

                Application.Run(new Initial(GetInfoHeader()));
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static InfoHeader? GetInfoHeader()
        {
            var enviroment = UrlConfig.GetEnviromentInitialize();
            var urlAPI = UrlConfig.GetFinanceOrganizationApiUrl(enviroment);

            if (string.IsNullOrWhiteSpace(urlAPI))
            {
                return null;
            }

            bool productionEnviroment = false;

            if (urlAPI.StartsWith("http://api.financeiro.arielgiacomini.com.br"))
            {
                productionEnviroment = true;
            }

            var infoHeader = new InfoHeader
            {
                IsProductionEnvironment = productionEnviroment,
                Url = urlAPI,
                Version = Info.GetVersionString(),
                Environment = enviroment
            };

            return infoHeader;
        }
    }
}