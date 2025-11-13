import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CreditDashboardComponent } from './credit-dashboard/credit-dashboard.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CreditDashboardComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('pulse360-ui');
}
