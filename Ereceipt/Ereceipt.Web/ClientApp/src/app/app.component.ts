import { Component, OnInit } from '@angular/core';
import { UserService } from './user/user.service';
import { User } from './user/user';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [UserService]
})
export class AppComponent implements OnInit {

    user: User = new User();
    users: User[];
    tableMode: boolean = true;

    constructor(private dataService: UserService) { }

    ngOnInit() {
        this.loadUsers();
    }

    loadUsers() {
        this.dataService.getUsers()
            .subscribe((data: User[]) => this.users = data);
    }

    save() {
        if (this.user.id == null) {
            this.dataService.createUser(this.user)
                .subscribe((data: User) => this.users.push(data));
        } else {
            this.dataService.updateProduct(this.user)
                .subscribe(data => this.loadUsers());
        }
        this.cancel();
    }
    editProduct(p: User) {
        this.user = p;
    }
    cancel() {
        this.user = new User();
        this.tableMode = true;
    }
    delete(p: User) {
        this.dataService.deleteProduct(p.id)
            .subscribe(data => this.loadUsers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}