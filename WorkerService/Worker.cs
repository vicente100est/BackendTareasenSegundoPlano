namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string _path = Directory.GetCurrentDirectory() + @"\Files\";

        private IFliesData _fileData;

        private int _count = 0;

        public Worker(ILogger<Worker> logger, IFliesData fliesData)
        {
            _logger = logger;
            _fileData = fliesData;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _fileData.Create($"{_path}{_count++}.txt");
            }
        }
    }
}