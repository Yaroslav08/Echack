import { User } from './user/user';
import { Receipt } from './receipt/receipt';
export class Comment {
    constructor(
        public id: number,
        public createdAt: Date,
        public text: string,
        public user: User,
        public receipt: Receipt,
        public updatedAt: Date
    ) { }
}