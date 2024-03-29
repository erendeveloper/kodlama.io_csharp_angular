import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';
import { RentalDetailDto } from '../models/rentalDetailDto';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiUrl = 'https://localhost:44327/api/rentals/';

  constructor(private httpClient: HttpClient) { }

  getRentals():Observable<ListResponseModel<Rental>>{
    return this.httpClient.get<ListResponseModel<Rental>>(this.apiUrl+"getall");    
  }
  getRentalDetails():Observable<ListResponseModel<RentalDetailDto>>{
    return this.httpClient.get<ListResponseModel<RentalDetailDto>>(this.apiUrl+"getrentaldetails");    
  }
}
