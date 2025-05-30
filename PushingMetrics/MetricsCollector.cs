using Prometheus;

public class MetricsCollector
{
    private readonly Counter _counter;
    private readonly Gauge _gauge;
    private readonly Histogram _histogram;

    public MetricsCollector(CollectorRegistry registry)
    {
        _counter = Metrics.WithCustomRegistry(registry).CreateCounter("demo_requests_total", "Total number of requests.");
        _gauge = Metrics.WithCustomRegistry(registry).CreateGauge("demo_in_progress_gauge", "Current number of in-progress tasks.");
        _histogram = Metrics.WithCustomRegistry(registry).CreateHistogram("demo_request_duration_seconds", "Histogram of request durations.");
    }

    public async Task SimulateMetrics(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _counter.Inc();

            _gauge.Inc();

            Random rand = new Random();
            double simulatedDuration = rand.NextDouble();
            using (_histogram.NewTimer())
            {
                await Task.Delay((int)(simulatedDuration * 1000), cancellationToken);
            }

            _gauge.Dec();

            Console.WriteLine("Simulated metrics at " + DateTime.Now);
            await Task.Delay(2000); // Every 2 seconds
        }
    }
}
