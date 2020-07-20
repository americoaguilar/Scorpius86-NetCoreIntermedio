import { Component, OnInit, ViewChild } from '@angular/core';
import {  ChartComponent} from "ng-apexcharts";
import { ChartOptions } from '../../shared/apex-chart/chart-options';
import { MatCardContent } from '@angular/material/card';

@Component({
  selector: 'app-sales-progress',
  templateUrl: './sales-progress.component.html',
  styleUrls: ['./sales-progress.component.scss']
})
export class SalesProgressComponent implements OnInit {
  @ViewChild("chart") chartComponent: ChartComponent;
  @ViewChild("chartContainer") chartContainer: MatCardContent;
  public chartOptions: Partial<ChartOptions>;

  constructor() {
    this.createChart();
  }

  ngOnInit(): void {
    
  }

  createChart() {
    this.chartOptions = {
      series: [{
        name: 'Net Profit',
        data: [35, 65, 75, 55, 45, 60, 55]
      }, {
        name: 'Revenue',
        data: [40, 70, 80, 60, 50, 65, 60]
      }],
      chart: {
        type: 'bar',
        height: 192,
        toolbar: {
          show: false
        },
        sparkline: {
          enabled: true
        },
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '30%',
          endingShape: 'rounded'
        },
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      stroke: {
        show: true,
        width: 1,
        colors: ['transparent']
      },
      xaxis: {
        categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            //colors: KTApp.getSettings()['colors']['gray']['gray-500'],
            colors:'#B5B5C3',
            fontSize: '12px'
            //fontFamily: KTApp.getSettings()['font-family']
          }
        }
      },
      yaxis: {
        min: 0,
        max: 100,
        labels: {
          style: {
            colors: '#B5B5C3',
            fontSize: '12px'
            //fontFamily: KTApp.getSettings()['font-family']
          }
        }
      },
      fill: {
        type: ['solid', 'solid'],
        opacity: [0.25, 1]
      },
      states: {
        normal: {
          filter: {
            type: 'none',
            value: 0
          }
        },
        hover: {
          filter: {
            type: 'none',
            value: 0
          }
        },
        active: {
          allowMultipleDataPointsSelection: false,
          filter: {
            type: 'none',
            value: 0
          }
        }
      },
      tooltip: {
        style: {
          fontSize: '12px',
         // fontFamily: KTApp.getSettings()['font-family']
        },
        y: {
          formatter: function (val) {
            return "$" + val + " thousands"
          }
        },
        marker: {
          show: false
        }
      },
      colors: ['#ffffff', '#ffffff'],
      grid: {
        borderColor: '#ECF0F3',
        strokeDashArray: 4,
        yaxis: {
          lines: {
            show: true
          }
        },
        padding: {
          left: 20,
          right: 20
        }
      }
    };
  }
}
