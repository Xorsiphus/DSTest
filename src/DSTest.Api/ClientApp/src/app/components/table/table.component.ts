import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatTableDataSourcePageEvent } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { WeatherModel } from 'src/app/api/request-models/weather.model';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit, OnDestroy  {
  private dataSubscription: Subscription | undefined;
  displayedColumns: string[] = ['index', 'date', 'time', 'temp', 'air_hum', 'dtemp', 'atm_press', 'wind_direct', 'wind_speed', 'cloud', 'h', 'vv', 'cond'];
  dataSource: WeatherModel[] = [];
  recordsCount: number = 0;
  currentRecordsPerPage: number = 15;

  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
    this.loadData(this.currentRecordsPerPage, 0);
  }

  ngOnDestroy() {
    this.dataSubscription?.unsubscribe();
  }

  handlePageEvent(event: MatTableDataSourcePageEvent) {
    this.currentRecordsPerPage = event.pageSize;
    this.loadData(event.pageSize, event.pageSize * event.pageIndex);
  }

  loadData(take: number, offset: number) {
    this.dataSubscription = this.weatherService
      .getWeatherData(take, offset)
      .subscribe(r => {
        this.dataSource = r.data;
        this.recordsCount = r.count;
      });
  }
}
