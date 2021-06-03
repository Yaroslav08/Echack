import { Component } from '@angular/core';

@Component({
    selector: 'app',
    template: `<label>Enter text:</label>
                 <input [(ngModel)]="text" placeholder="text">
                 <h2>Your text: {{text}}!</h2>`
})
export class AppComponent {
    text = '';
}