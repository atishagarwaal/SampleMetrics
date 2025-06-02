This solution contains two projects :-
  1. PullingMetrics
  2. PusingMetrcis

PullingMetrics is a .NET console application designed to expose application metrics in a format compatible with Prometheus, a popular open-source monitoring and alerting toolkit. The project uses the prometheus-net.AspNetCore library to provide an HTTP endpoint (usually /metrics) that Prometheus servers can "pull" (scrape) at regular intervals.

The application hosts a minimal web server (using ASP.NET Core) that exposes metrics endpoints. Prometheus scrapes these endpoints to collect real-time metrics about the application (e.g., counters, gauges,   histograms).

**Steps to test PullingMetrics locally**

  1. Install Prometheus
  2. Edit prometheus.yml to include PullingMetrics app

     ![image](https://github.com/user-attachments/assets/ceb94771-a2c2-4696-95c0-1428c356f975)
  4. Run Application

     ![image](https://github.com/user-attachments/assets/544b7fef-f39c-41b0-bab7-4a8b495c2a29)
  6. Run Prometheus
   
     ![image](https://github.com/user-attachments/assets/0a6f6be8-ad6d-41cf-8b40-9ab511560082)
  7. Open Prometheus http://localhost:9090

     ![image](https://github.com/user-attachments/assets/408e4a18-80f3-4e8d-9036-0047cec78194)
  9. Install Grafana
  10. Open Grafana at http://localhost:3000
  11. Add data source - http://localhost:9090

      ![image](https://github.com/user-attachments/assets/ce9050ef-ba89-49a1-89a6-9048f4aa6756)
  12. Explore metrics with Drilldown

      ![image](https://github.com/user-attachments/assets/fa1412ac-eac9-44de-8bfe-1fbdc3fcdfc4)

  14.  Create dashboard

        ![Screenshot 2025-06-02 130646](https://github.com/user-attachments/assets/e159e893-8bbe-4418-8425-0f7e11e92fa4)
       

PushingMetrics is a .NET console application that collects metrics and "pushes" them to a Prometheus Pushgateway. This is useful for short-lived jobs or batch processes that can't be scraped by Prometheus directly. Instead of exposing an HTTP endpoint for Prometheus to scrape, this app uses the prometheus-net library to send (push) metrics to a Prometheus Pushgateway at the end of a job or at regular intervals.

**Steps to test PushingMetrics locally**

