import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currency } from './currency';

@Injectable()
export class CurrencyService {
    private url = "/api/v1/currencies";

    constructor(private http: HttpClient) {
    }

    getAllCurrencies() {
        return this.http.get(this.url);
    }
}