import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType, HttpResponse } from '@angular/common/http';
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
        return this.PostFormData<WeatherFormDataUploadModel>(url, model).pipe(
            map(event => this.getUploadProgress(event)),
        );
    }

    private getUploadProgress(event: any): number {
        if (event.type === HttpEventType.UploadProgress) {
            return Math.round((100 * event.loaded) / event.total);
        } else if (event instanceof HttpResponse) {
            return 100;
        }
        return 0;
    }
}