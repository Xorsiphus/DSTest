import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileService } from './file.service';
import { WeatherFormDataModel } from '../api/request-models/weather-form-data.model';
import { BaseService } from './base.service';
import { WeatherResponseModel } from '../api/request-models/weather.model';

@Injectable({
    providedIn: 'root'
})
export class WeatherService extends BaseService {
    constructor(protected override httpClient: HttpClient, private fileService: FileService) {
        super(httpClient);
    }

    uploadFile(files: File[]): Observable<number> {
        const formData = new WeatherFormDataModel();
        for (var i = 0; i < files.length; i++) {
            formData.AddFile(files[i]);
        }
        return this.fileService.uploadFile('/api/v1/Weather/UploadData', formData)
    }

    getWeatherData(take: number, offset: number): Observable<WeatherResponseModel> {
        return this.httpClient.get<WeatherResponseModel>(`${this.GetOriginUrl}/api/v1/Weather/GetData`, {
            params: { take: take, offset: offset }
        });
    }
}