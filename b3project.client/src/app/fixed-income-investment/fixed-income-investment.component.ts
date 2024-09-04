import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CdbServiceService } from '../services/cdb-service.service';
import { FixedIncomeInvestment } from '../models/FixedIncomeInvestment';

@Component({
  selector: 'app-fixed-income-investment',
  templateUrl: './fixed-income-investment.component.html',
  styleUrl: './fixed-income-investment.component.css'
})
export class FixedIncomeInvestmentComponent {

  investment: FixedIncomeInvestment = {
    InvestmentValue: 0,
    InvestmentRate: 0
  };

  calculationResult:number | null = null;
  
  constructor(private router: Router, private CdbServices :CdbServiceService ) { }

  async onSubmit(){
    var result = this.CdbServices.GetValuesCdb(this.investment)
    .subscribe(response => {
      this.calculationResult = response.data; // Armazena o resultado da API
    }, error => {
      console.error('Erro ao calcular investimento:', error);
    });
  }

}
