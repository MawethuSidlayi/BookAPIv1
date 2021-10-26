import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'Book';
/**
 *
 */
constructor(private authService: AuthService) {
  
}
  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }
}
