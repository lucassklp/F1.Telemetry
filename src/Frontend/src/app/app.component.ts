import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ChartComponent, NgApexchartsModule, ApexAxisChartSeries, ApexChart, ApexXAxis, ApexStroke, ApexDataLabels } from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
  legend: ApexLegend;
};

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgApexchartsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  
  public speedChart?: Partial<ChartOptions>;
  public steerChart?: Partial<ChartOptions>;
  public throttleChart?: Partial<ChartOptions>;

  constructor(private httpClient: HttpClient, private cdr: ChangeDetectorRef){

    this.speedChart = this.createChart("Speed");
    this.steerChart = this.createChart("Steer");
    this.throttleChart = this.createChart("Throttle");

    this.httpClient.get<any>('/api/telemetry?name=Norris&name=Leclerc&name=Verstappen')
      .subscribe(response => {

        const drivers = Object.keys(response)

        const speedSeries = drivers.map(driver => {
          const data = response[driver].map((telemetry: any) => {
            return {
              x: telemetry.timestamp,
              y: telemetry.speed
            }
          });
          return {
            name: driver,
            data: data
          }
        })
        console.log(speedSeries)
        this.speedChart!.series = speedSeries
        //this.speedChart!.xaxis!.categories = categories;


        const steerSeries = drivers.map(driver => {
          const data = response[driver].map((telemetry: any) => {
            return {
              x: telemetry.timestamp,
              y: telemetry.steer
            }
          });
          return {
            name: driver,
            data: data
          }
        })

        this.steerChart!.series = steerSeries

        const throttleSeries = drivers.map(driver => {
          const data = response[driver].map((telemetry: any) => {
            return {
              x: telemetry.timestamp,
              y: telemetry.throttle
            }
          });

          return {
            name: driver,
            data: data
          }
        })

        this.throttleChart!.series = throttleSeries

        console.log("this.chartOptions", this.speedChart)

        this.cdr.detectChanges();
      });
  }

  private createChart(name: string): ChartOptions{
    return {
      series: [],
      chart: {
        height: 350,
        type: "line",
        zoom: {
          enabled: true
        }
      },
      dataLabels: {
        enabled: false
      },
      stroke: {
        curve: "smooth",
        width: 1.5 
      },
      title: {
        text: name,
        align: "left"
      },
      legend: {
        position: 'top'
      },
      grid: {
        row: {
          colors: ["#f3f3f3", "transparent"], // takes an array which will be repeated on columns
          opacity: 0.5
        }
      },
      xaxis: {
        type: 'numeric',
        // labels: {
        //   formatter: function(val) {
        //     return (parseFloat(val) / 60).toFixed(3) + " min";
        //   }
        // }
      }
    };
  }
}
