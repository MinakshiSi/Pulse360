// src/app/credit-dashboard/credit-dashboard.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreditService } from '../services/credit.service';

@Component({
  selector: 'app-credit-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './credit-dashboard.component.html',
  styleUrls: ['./credit-dashboard.component.scss']
})
export class CreditDashboardComponent implements OnInit {
  creditData: any;

  constructor(private creditService: CreditService) {}

  ngOnInit(): void {
    this.creditService.getCreditSummary().subscribe({
      next: data => this.creditData = data,
      error: err => console.error('API error:', err)
    });
  }
}
