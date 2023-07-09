import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpEventType, HttpResponse } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { BaseService } from './base.service';
import { WeatherFormDataUploadModel } from '../api/request-models/weather-form-data-request.model';

@Injectable({
    providedIn: 'root'
})
export class FileService extends BaseService {
    constructor(protected override httpClient: HttpClient) {
        super(httpClient);
    }

    uploadFile(url: string, model: WeatherFormDataUploadModel): Observable<number> {
        return this.httpClient.post(this.GetOriginUrl + url, model.formData, {
            reportProgress: true,
            observe: 'events',
            responseType: 'text'
        })
        .pipe(
            map(event => this.getUploadProgress(event)),
        );
    }

    private getUploadProgress(event: any): number {
        if (event.type === HttpEventType.UploadProgress) {
            const progress = Math.round((100 * event.loaded) / event.total);
            return progress;
        } else if (event instanceof HttpResponse) {
            return 100;
        }

        return 0;
    }
}