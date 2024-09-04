import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FixedIncomeInvestmentComponent } from './fixed-income-investment.component';

describe('FixedIncomeInvestmentComponent', () => {
  let component: FixedIncomeInvestmentComponent;
  let fixture: ComponentFixture<FixedIncomeInvestmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FixedIncomeInvestmentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FixedIncomeInvestmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
