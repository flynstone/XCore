export class Rental {
  rentalId: number;
  dateOfRental: Date;
  dueDate: Date;
  customerId: number;
  customer: string;
  mediaId: number;
  itemTitle: string;
}

export interface RentalForCreationDto {
  dateOfRental: Date;
  dueDate: Date;
  customer: string;
  itemTitle: string;
}

export interface RentalForUpdateDto {
  dateOfRental: Date;
  dueDate: Date;
  customer: string;
  itemTitle: string;
}
