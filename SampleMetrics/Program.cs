using Prometheus;

Console.WriteLine("Starting Prometheus Metrics Collector...");

// Start metrics server (listen on http://localhost:1234/metrics)
var server = new KestrelMetricServer(port: 1234);
server.Start();

var collector = new MetricsCollector();
var cts = new CancellationTokenSource();

AppDomain.CurrentDomain.ProcessExit += (s, e) =>
{
    Console.WriteLine("Shutting down...");
    cts.Cancel();
};

// Simulate metrics in loop
await collector.SimulateMetrics(cts.Token);
