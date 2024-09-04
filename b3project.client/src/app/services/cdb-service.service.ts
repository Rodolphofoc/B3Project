import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CdbServiceService {
  private readonly baseUrl = "https://localhost:7142/api/b3/fixedincome";;

  
  constructor(private http:HttpClient) {}

    GetValuesCdb(request: any) : Observable<any> {
     let params = new HttpParams().set('InvestmentValue', request.InvestmentValue).set('InvestmentRate', request.InvestmentRate);

     return this.http.get<any>(this.baseUrl, { params });
  }
    

}
