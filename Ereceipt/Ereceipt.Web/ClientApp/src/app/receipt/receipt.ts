import { User } from './user/user';
import { Group } from './group/group';
import { Currency } from './currency/currency';
import { Product } from './product/product';

export class Receipt {
    constructor(
        public id: string,
        public createdAt: Date,
        public shopName: string,
        public totalPrice: number,
        public IsImportant: boolean,
        public canEdit: boolean,
        public receiptType: ReceiptType,
        public user: User,
        public group: Group,
        public currency: Currency,
        public products: Product[]
    ) { }
}
enum ReceiptType {
    Paymant,
    Internal
}