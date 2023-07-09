import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { MatTableDataSource, MatTableDataSourcePageEvent } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { WeatherModel } from 'src/app/api/response-models/weather.model';
import { MonthModel } from 'src/app/models/month';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit, OnDestroy {
  private dataSubscription: Subscription | undefined;
  private staticDataSubscription: Subscription | undefined;

  displayedColumns: string[] = ['index', 'date', 'time', 'temp', 'air_hum', 'dtemp', 'atm_press', 'wind_direct', 'wind_speed', 'cloud', 'h', 'vv', 'cond'];
  dataSource: MatTableDataSource<WeatherModel> = new MatTableDataSource<WeatherModel>();
  years: number[] = [];
  currentYear: number = 0;
  currentMonth: number = 0;

  recordsCount: number = 0;
  currentPage: number = 0;
  currentRecordsPerPage: number = 15;

  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
    this.loadData(this.currentRecordsPerPage, 0);
    this.loadStaticData();
  }

  ngOnDestroy() {
    this.dataSubscription?.unsubscribe();
    this.staticDataSubscription?.unsubscribe();
  }

  onYearChange(event: MatSelectChange) {
    this.currentYear = event.value;
    this.currentPage = 0;
    this.loadData(this.currentRecordsPerPage, 0);
  }

  onMonthChange(event: MatSelectChange) {
    this.currentMonth = event.value;
    this.currentPage = 0;
    this.loadData(this.currentRecordsPerPage, 0);
  }
  
  handlePageEvent(event: MatTableDataSourcePageEvent) {
    this.currentRecordsPerPage = event.pageSize;
    this.currentPage = event.pageIndex;
    this.loadData(event.pageSize, event.pageSize * event.pageIndex);
  }

  loadData(take: number, offset: number) {
    this.dataSubscription = this.weatherService
      .getWeatherData(take, offset, this.currentYear, this.currentMonth)
      .subscribe(r => {
        this.dataSource = new MatTableDataSource<WeatherModel>(r.data);
        this.recordsCount = r.count;
      });  
  }

  loadStaticData() {
      this.staticDataSubscription = this.weatherService
      .getWeatherStaticData()
      .subscribe(r => {
        this.years = r.years;
      });   
  }

  

  months: MonthModel[] = [
    { number: 1, name: 'Январь' },
    { number: 2, name: 'Февраль' },
    { number: 3, name: 'Март' },
    { number: 4, name: 'Апрель' },
    { number: 5, name: 'Май' },
    { number: 6, name: 'Июнь' },
    { number: 7, name: 'Июль' },
    { number: 8, name: 'Август' },
    { number: 9, name: 'Сентябрь' },
    { number: 10, name: 'Октябрь' },
    { number: 11, name: 'Ноябрь' },
    { number: 12, name: 'Декабрь' },
  ];
}
