import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class BaseService {
    constructor(protected httpClient: HttpClient) { }

    protected get GetOriginUrl(): string { return 'http://localhost:5001'; };
    protected static readonly GET_WEATHER_DATA = 'Weather/GetData';
    protected static readonly GET_WEATHER_STATIC_DATA = 'Weather/GetStaticData';
    protected static readonly POST_WEATHER_FORM_DATA = 'Weather/UploadData';

    protected Get<T>(url: string, params?: { [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean> }) {
        return this.httpClient.get<T>(`${this.GetOriginUrl}/api/v1/${url}`, { params: params });
    }

    protected PostFormData<T extends { formData: FormData }>(url: string, model: T) {
        return this.httpClient.post(`${this.GetOriginUrl}/api/v1/${url}`, model.formData, {
            reportProgress: true,
            observe: 'events',
            responseType: 'text'
        })
    }
}