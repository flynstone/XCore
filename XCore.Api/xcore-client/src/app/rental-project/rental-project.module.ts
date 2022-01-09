import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryCreateComponent } from './categories/category-create/category-create.component';
import { CategoryUpdateComponent } from './categories/category-update/category-update.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerCreateComponent } from './customers/customer-create/customer-create.component';
import { CustomerUpdateComponent } from './customers/customer-update/customer-update.component';
import { MediasComponent } from './medias/medias.component';
import { MediaCreateComponent } from './medias/media-create/media-create.component';
import { MediaUpdateComponent } from './medias/media-update/media-update.component';
import { RentalProjectLayoutComponent } from './rental-project-layout/rental-project-layout.component';
import { RentalsComponent } from './rentals/rentals.component';
import { RentalCreateComponent } from './rentals/rental-create/rental-create.component';
import { RentalUpdateComponent } from './rentals/rental-update/rental-update.component';
import { RentalProjectRoutingModule } from './rental-project-routing.module';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    CategoriesComponent,
    CategoryCreateComponent,
    CategoryUpdateComponent,
    CustomersComponent,
    CustomerCreateComponent,
    CustomerUpdateComponent,
    MediasComponent,
    MediaCreateComponent,
    MediaUpdateComponent,
    RentalProjectLayoutComponent,
    RentalsComponent,
    RentalCreateComponent,
    RentalUpdateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    RentalProjectRoutingModule
  ], 
  exports: [
    CategoriesComponent,
    CategoryCreateComponent,
    CategoryUpdateComponent,
    CustomersComponent,
    CustomerCreateComponent,
    CustomerUpdateComponent,
    MediasComponent,
    MediaCreateComponent,
    MediaUpdateComponent,
    RentalProjectLayoutComponent,
    RentalsComponent,
    RentalCreateComponent,
    RentalUpdateComponent
  ]
})
export class RentalProjectModule { }
