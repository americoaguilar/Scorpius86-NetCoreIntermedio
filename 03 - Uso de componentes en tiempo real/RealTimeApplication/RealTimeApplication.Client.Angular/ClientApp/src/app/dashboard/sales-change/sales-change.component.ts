import { Component, OnInit } from '@angular/core';
import { ChartOptions } from '../../shared/apex-chart/chart-options';

@Component({
  selector: 'app-sales-change',
  templateUrl: './sales-change.component.html',
  styleUrls: ['./sales-change.component.scss']
})
export class SalesChangeComponent implements OnInit {

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
        data: [40, 40, 30, 30, 35, 35, 50]
      }],
      chart: {
        type: 'area',
        height: 158,
        toolbar: {
          show: false
        },
        zoom: {
          enabled: false
        },
        sparkline: {
          enabled: true
        }
      },
      plotOptions: {},
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      fill: {
        type: 'solid',
        opacity: 1
      },
      stroke: {
        curve: 'smooth',
        show: true,
        width: 3,
        colors: ['#6993FF']
      },
      xaxis: {
        categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Aug', 'Sep'],
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false
        },
        labels: {
          show: false,
          style: {
            colors: '#B5B5C3',
            fontSize: '12px',
            // fontFamily: 'Poppins'
          }
        },
        crosshairs: {
          show: false,
          position: 'front',
          stroke: {
            color: '#E5EAEE',
            width: 1,
            dashArray: 3
          }
        },
        tooltip: {
          enabled: true,
          formatter: undefined,
          offsetY: 0,
          style: {
            fontSize: '12px',
            //fontFamily: 'Poppins'
          }
        }
      },
      yaxis: {
        min: 0,
        max: 55,
        labels: {
          show: false,
          style: {
            colors: '#B5B5C3',
            fontSize: '12px',
            //fontFamily: 'Poppins'
          }
        }
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
          //fontFamily: 'Poppins'
        },
        y: {
          formatter: function (val) {
            return "$" + val + " thousands"
          }
        }
      },
      colors: ['#E1E9FF'],
      markers: {
        colors: ['#E1E9FF', 'red'],
        strokeColors: ['#6993FF'],
        strokeWidth: 3
      }
    };
  }

}
