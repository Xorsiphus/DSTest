import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class BaseService {
    constructor(protected httpClient: HttpClient) { }

    protected get GetOriginUrl(): string { return 'http://localhost:5001'; };
}