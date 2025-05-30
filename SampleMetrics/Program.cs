using Prometheus;

Console.WriteLine("Starting Prometheus Metrics Collector...");

// Start metrics server (listen on http://localhost:1234/metrics)
var server = new KestrelMetricServer(port: 1234);
server.Start();

var collector = new MetricsCollector();

// Simulate metrics in loop
while (true)
{
    collector.SimulateMetrics();
    Console.WriteLine("Simulated metrics at " + DateTime.Now);
    Thread.Sleep(2000); // Every 2 seconds
}
