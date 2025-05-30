using Prometheus;

Console.WriteLine("Starting Prometheus Metrics Pusher...");

var registry = Metrics.NewCustomRegistry();

var pusher = new MetricPusher(
    endpoint: "http://localhost:9091/metrics",
    job: "dotnet_push_metrics",
    instance: Environment.MachineName,
    intervalMilliseconds: 5000,
    registry: registry
);

pusher.Start();

// Start metrics server (listen on http://localhost:1234/metrics)
////var server = new KestrelMetricServer(port: 1234);
////server.Start();

var collector = new MetricsCollector(registry);
var cts = new CancellationTokenSource();

AppDomain.CurrentDomain.ProcessExit += (s, e) =>
{
    Console.WriteLine("Shutting down...");
    cts.Cancel();
    pusher.Stop();
};

// Simulate metrics in loop
await collector.SimulateMetrics(cts.Token);
