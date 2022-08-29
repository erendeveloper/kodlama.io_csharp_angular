import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarImage } from 'src/app/models/carImage';
import { CarImageService } from 'src/app/services/car-image.service';

@Component({
  selector: 'app-car-image',
  templateUrl: './car-image.component.html',
  styleUrls: ['./car-image.component.css']
})
export class CarImageComponent implements OnInit {

  carImages? : CarImage[] | null;
  carImagesSources? : string[] | null;

  constructor(private carImageService:CarImageService, private activatedroute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedroute.params.subscribe(params=>{
      if(params["carId"]){
        this.getCarImagesByCar(params["carId"]);
      }
      else{
        this.getCarImages();
      }
    });
  }
  getCarImages() {
    this.carImageService.getCarImages().subscribe(response=>{
      this.carImages=response.data;
    })
  }
  getCarImagesByCar(carId:number){
    this.carImageService.getCarImagesByCar(carId).subscribe(response=>{
      this.carImages=response.data;
    })
  }
  getCarImageSource(carImage:CarImage){
    this.carImageService.getCarImageSource(carImage);
  }
  getCarImageUrlRoot(){
    return this.carImageService.imageUrl;
  }
  setCarImages(carId:number){
    this.carImageService.getCarImagesByCar(carId).subscribe(response=>{
      this.carImages=response.data;
     })
  }
  resetImages(){
    this.carImages=[];
  }

}
