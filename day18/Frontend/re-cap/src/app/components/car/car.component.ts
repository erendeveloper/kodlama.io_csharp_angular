import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  cars : Car[] = [];
  currentCar? : Car | null;

  constructor(private carService:CarService) { }

  ngOnInit(): void {
    this.getCars();
  }

  getCars() {
    this.carService.getCars().subscribe(response=>{
      this.cars=response.data
    })
  }
  setCurrentCar(car:Car){
    this.currentCar=car;
  }
  resetCurrentCar(){
    this.currentCar=null;
  }
  getCurrentCarClass(car:Car){
    if(car==this.currentCar){
      return "list-group-item active"
    }
    else{
      return "list-group-item"
    }
  }

  getAllCarClass(){
    if(!this.currentCar){
      return "list-group-item active"
    }
    else{
      return "list-group-item"
    }
  }

}
