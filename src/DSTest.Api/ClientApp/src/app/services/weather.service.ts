import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileService } from './file.service';
import { WeatherFormDataUploadModel } from '../api/request-models/weather-form-data-request.model';
import { BaseService } from './base.service';
import { WeatherResponseModel } from '../api/response-models/weather.model';
import { WeatherStaticModel } from '../api/response-models/weather-static.model';
import { WeatherDataRequestModel } from '../api/request-models/weather-data-request.model';

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
        return this.fileService.uploadFile(BaseService.POST_WEATHER_FORM_DATA, formData);
    }

    getWeatherData({ take, offset, year, month }: WeatherDataRequestModel): Observable<WeatherResponseModel> {
        return this.Get<WeatherResponseModel>(BaseService.GET_WEATHER_DATA, {
            take,
            offset,
            ...(year !== undefined ? { year } : null),
            ...(month !== undefined ? { month } : null)
        });
    }

    getWeatherStaticData(): Observable<WeatherStaticModel> {
        return this.Get<WeatherStaticModel>(BaseService.GET_WEATHER_STATIC_DATA);
    }
}