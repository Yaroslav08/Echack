import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Receipt } from './receipt';

@Injectable()
export class ReceiptService {

    private url = "/api/v1/receipts";

    constructor(private http: HttpClient) {
    }

    getMyReceipts(offset: number = 0) {
        return this.http.get(this.url + '/my?skip=' + offset);
    }

    getReceipt(id: string) {
        return this.http.get(this.url + '/' + id);
    }

    createReceipt(receipt: Receipt) {
        return this.http.post(this.url, receipt);
    }
    updateReceipt(receipt: Receipt) {

        return this.http.put(this.url, receipt);
    }
    deleteReceipt(id: string) {
        return this.http.delete(this.url + '/' + id);
    }
    getCommentsByReceiptId(id: string) {
        return this.http.get(this.url + '/' + id + '/comments');
    }
}