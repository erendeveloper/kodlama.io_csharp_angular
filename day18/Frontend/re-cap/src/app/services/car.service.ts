import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { CarDetailDto } from '../models/carDetailDto';
import { Car } from '../models/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiUrl = 'https://localhost:44327/api/cars/';

  constructor(private httpClient: HttpClient) { }

  getCars():Observable<ListResponseModel<Car>>{
    return this.httpClient.get<ListResponseModel<Car>>(this.apiUrl+"getall");    
  }
  getCarDetails():Observable<ListResponseModel<CarDetailDto>>{
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(this.apiUrl+"getcardetails");    
  }
  getCarDetailsByBrand(brandId:number):Observable<ListResponseModel<CarDetailDto>>{
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(this.apiUrl+"getcardetailsbybrandid?id="+brandId);    
  }
  getCarDetailsByColor(colorId:number):Observable<ListResponseModel<CarDetailDto>>{
    return this.httpClient.get<ListResponseModel<CarDetailDto>>(this.apiUrl+"getcardetailsbycolorid?id="+colorId);    
  }

}
