import { User } from './user/user';
import { Group } from './group/group';

export class GroupMember {
    constructor(
        public id: string,
        public createdAt: Date,
        public title: string,
        public user: User,
        public group: Group,
        public updatedAt: Date,
    ) { }
}