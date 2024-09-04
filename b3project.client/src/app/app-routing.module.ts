import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FixedIncomeInvestmentComponent } from './fixed-income-investment/fixed-income-investment.component';

const routes: Routes = [
  {
    path:"",
    pathMatch:"full",
    redirectTo:"home"
  },
  {
    path:"home",component:FixedIncomeInvestmentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
