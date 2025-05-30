using Prometheus;

public class MetricsCollector
{
    private readonly Counter _counter;
    private readonly Gauge _gauge;
    private readonly Histogram _histogram;

    public MetricsCollector()
    {
        _counter = Metrics.CreateCounter("demo_requests_total", "Total number of requests.");
        _gauge = Metrics.CreateGauge("demo_in_progress_gauge", "Current number of in-progress tasks.");
        _histogram = Metrics.CreateHistogram("demo_request_duration_seconds", "Histogram of request durations.");
    }

    public void SimulateMetrics()
    {
        _counter.Inc();

        _gauge.Inc();

        Random rand = new Random();
        double simulatedDuration = rand.NextDouble();
        using (_histogram.NewTimer())
        {
            Thread.Sleep((int)(simulatedDuration * 1000));
        }

        _gauge.Dec();
    }
}
