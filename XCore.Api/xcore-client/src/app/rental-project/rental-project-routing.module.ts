import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CategoriesComponent } from "./categories/categories.component";
import { CategoryCreateComponent } from "./categories/category-create/category-create.component";
import { CategoryUpdateComponent } from "./categories/category-update/category-update.component";
import { CustomerCreateComponent } from "./customers/customer-create/customer-create.component";
import { CustomerUpdateComponent } from "./customers/customer-update/customer-update.component";
import { CustomersComponent } from "./customers/customers.component";
import { MediaCreateComponent } from "./medias/media-create/media-create.component";
import { MediaUpdateComponent } from "./medias/media-update/media-update.component";
import { MediasComponent } from "./medias/medias.component";
import { RentalProjectLayoutComponent } from "./rental-project-layout/rental-project-layout.component";
import { RentalCreateComponent } from "./rentals/rental-create/rental-create.component";
import { RentalUpdateComponent } from "./rentals/rental-update/rental-update.component";
import { RentalsComponent } from "./rentals/rentals.component";


const routes: Routes = [
  {
    path: '', component: RentalProjectLayoutComponent,
    children: [
      { path: '', component: CustomersComponent },
      { path: 'customers/add', component: CustomerCreateComponent },
      { path: 'customers/edit/:customerId', component: CustomerUpdateComponent },
      { path: 'categories', component: CategoriesComponent },
      { path: 'categories/add', component: CategoryCreateComponent },
      { path: 'categories/edit/:categoryId', component: CategoryUpdateComponent },
      { path: 'medias', component: MediasComponent },
      { path: 'medias/add', component: MediaCreateComponent },
      { path: 'medias/edit/:mediaId', component: MediaUpdateComponent },
      { path: 'rentals', component: RentalsComponent },
      { path: 'rentals/add', component: RentalCreateComponent },
      { path: 'rentals/edit/:rentalId', component: RentalUpdateComponent }
    ]
  }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class RentalProjectRoutingModule { }