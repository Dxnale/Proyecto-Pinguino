using Microsoft.Data.SqlClient;

namespace EVA2TI_BarPinguino.Data
{
    public class BackupService : BackgroundService
    {
        private readonly ILogger<BackupService> _logger;
        private readonly IConfiguration _configuration;

        public BackupService(ILogger<BackupService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Backup Service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await PerformBackupAsync();
                    _logger.LogInformation("Backup completed successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during backup.");
                }

                await Task.Delay(TimeSpan.FromHours(6), stoppingToken); 
            }

            _logger.LogInformation("Backup Service stopped.");
        }

        private async Task PerformBackupAsync()
        {
            string backupFolder = _configuration["BackupSettings:ConnectionStrings:BackupFolder"];
            string databaseName = _configuration["BackupSettings:ConnectionStrings:Database"];
            string connectionString = _configuration["BackupSettings:ConnectionStrings:SqlConnec"];
            string backupFileName = Path.Combine(backupFolder, $"{databaseName}_{DateTime.Now:yyyyMMddHHmmss}.bak");

            Directory.CreateDirectory(backupFolder);

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = $"BACKUP DATABASE [{databaseName}] TO DISK = '{backupFileName}' WITH INIT;";
                using (var command = new SqlCommand(query, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}
