import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileService } from './file.service';
import { WeatherFormDataUploadModel } from '../api/request-models/weather-form-data-request.model';
import { BaseService } from './base.service';
import { WeatherResponseModel } from '../api/response-models/weather.model';
import { WeatherStaticModel } from '../api/response-models/weather-static.model';

@Injectable({
    providedIn: 'root'
})
export class WeatherService extends BaseService {
    constructor(protected override httpClient: HttpClient, private fileService: FileService) {
        super(httpClient);
    }

    uploadFile(files: File[]): Observable<number> {
        const formData = new WeatherFormDataUploadModel();
        for (var i = 0; i < files.length; i++) {
            formData.AddFile(files[i]);
        }
        return this.fileService.uploadFile('/api/v1/Weather/UploadData', formData)
    }

    getWeatherData(take: number, offset: number, year: number, month: number): Observable<WeatherResponseModel> {
        let params = { take: take, offset: offset, year: year, month: month };
        return this.httpClient.get<WeatherResponseModel>(`${this.GetOriginUrl}/api/v1/Weather/GetData`, {
            params: new HttpParams({ fromObject: params }),
            responseType: 'json'
        });
    }

    getWeatherStaticData(): Observable<WeatherStaticModel> {
        return this.httpClient.get<WeatherStaticModel>(`${this.GetOriginUrl}/api/v1/Weather/GetStaticData`);
    }
}