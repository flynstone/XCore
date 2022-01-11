import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../_core/models/customer.model';
import { Media } from '../../_core/models/media.model';
import { Rental } from '../../_core/models/rental.model';
import { RentalService } from '../../_core/services/rentals.service';

@Component({
  selector: 'app-rental-update',
  templateUrl: './rental-update.component.html',
  styleUrls: ['./rental-update.component.scss']
})
export class RentalUpdateComponent implements OnInit {

  form: FormGroup;
  rentals: Rental;
  rentalId: number;
  category: string;
  medias: Media[];
  customers: Customer[];
  loading = false;

  constructor(
    private rentalService: RentalService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.form = this.formBuilder.group({
      rentalId: ['', [Validators.required]],
      dateOfRental: ['', [Validators.required]],
      dueDate: ['', [Validators.required]],
      customerId: ['', [Validators.required]],
      customer: [''],
      mediaId: ['', [Validators.required]],
      itemTitle: ['']
    });
  }

  ngOnInit(): void {
    this.rentalId = this.route.snapshot.params["rentalId"];

    this.getAllMedias();

    this.rentalService.getById(this.rentalId).subscribe((data: Rental) => {
      this.rentals = data;
      this.form.patchValue(data);
    });
  }

  onSubmit() {
    this.updateRental();
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

  private updateRental() {

    this.rentalService
      .edit(this.rentalId, this.form.value)
      .pipe(first())
      .subscribe({
        next: () => {
          this.router.navigate(["/rental-project/rentals"], { relativeTo: this.route });
        },
        error: (error) => {
          this.loading = false;
        },
      });
  }

  public hasError = (controlName: string, errorName: string) => {
    if (this.form.controls[controlName].hasError(errorName))
      return true;
    
    return false;
  }

  public redirectToRentalList() {
    this.router.navigate(['/rental-project/rentals'])
  }
}
function first(): any {
  throw new Error('Function not implemented.');
}

