import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandComponent } from './components/brand/brand.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarImageComponent } from './components/car-image/car-image.component';
import { ColorComponent } from './components/color/color.component';

const routes: Routes = [
  {path:"", pathMatch:"full",component:CarDetailComponent},
  {path:"cardetails/brand/:brandId", component:CarDetailComponent},
  {path:"cardetails/color/:colorId", component:CarDetailComponent},
  {path:"cars/images/:carId", component:CarImageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
