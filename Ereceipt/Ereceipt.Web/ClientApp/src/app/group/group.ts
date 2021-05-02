import { DatePipe } from '@angular/common';
import { Receipt } from './receipt/receipt';
export class Group {
    constructor(
        public id: string,
        public createdAt: Date,
        public name: string,
        public color: string,
        public desc: string,
        public updatedAt: Date,
        public receipts: Receipt[],
    ) { }
}