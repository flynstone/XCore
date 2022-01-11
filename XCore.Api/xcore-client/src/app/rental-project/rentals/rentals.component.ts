import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Rental } from '../_core/models/rental.model';
import { RentalService } from '../_core/services/rentals.service';

@Component({
  selector: 'app-rentals',
  templateUrl: './rentals.component.html',
  styleUrls: ['./rentals.component.scss']
})
export class RentalsComponent implements OnInit {

  // Table Header
  columnsToDisplay: string[] = [
    'dateOfRental',
    'dueDate',
    'customer',
    'media',
    'update',
    'delete'
  ];
  // Get table data (from backend)
  dataSource = new MatTableDataSource<Rental>();

  // Angular Material Table sort and paginator  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private rentalService: RentalService,
  ) { }

  ngOnInit(): void {
    this.getAllRentals(); // initiate function
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  // Filter list
  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  // Get rentals function
  public getAllRentals = () => {
    this.rentalService.getAll().subscribe(res => {
      this.dataSource.data = res as Rental[];
    },
    (error) => {
      console.error(error);
    });
  }

  // Delete function
  delete(rentalId: number) {
    this.rentalService.delete(rentalId).subscribe(
      () => {
        this.getAllRentals();
      }
    )
  }
}
