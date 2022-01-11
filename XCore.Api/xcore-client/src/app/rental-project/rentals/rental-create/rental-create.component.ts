import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../_core/models/customer.model';
import { Media } from '../../_core/models/media.model';
import { Rental } from '../../_core/models/rental.model';
import { RentalService } from '../../_core/services/rentals.service';

@Component({
  selector: 'app-rental-create',
  templateUrl: './rental-create.component.html',
  styleUrls: ['./rental-create.component.scss']
})
export class RentalCreateComponent implements OnInit {

  rentals: Rental[] = [];
  form: FormGroup;
  medias: Media[];
  customers: Customer[];

  constructor(
    private rentalService: RentalService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      dateOfRental: ['', [Validators.required]],
      dueDate: ['', [Validators.required]],
      customerId: ['', [Validators.required]],
      customer: [''],
      mediaId: ['', Validators.required],
      media: ['']
    });

    this.getAllCustomers();
    this.getAllMedias();
  }

  public validateControl = (controlName: string) => {
    if (this.form.controls[controlName].invalid && this.form.controls[controlName].touched)
      return true;
    
    return false;
  }

   // Get Foreign Tables
   public getAllMedias = () => {
    this.rentalService.getMedias<Media>().subscribe((media) => {
      this.medias = media
    });
  }

  public getAllCustomers = () => {
    this.rentalService.getCustomers<Customer>().subscribe((customer) => {
      this.customers = customer
    });
  }


  onSubmit(formData) {
    this.rentalService.create(formData.value).subscribe(res => {
      this.router.navigateByUrl('/rental-project/rentals');
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    if (this.form.controls[controlName].hasError(errorName))
      return true;
    
    return false;
  }

}
