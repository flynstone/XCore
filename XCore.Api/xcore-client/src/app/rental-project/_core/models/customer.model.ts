export class Customer {
    customerId: number;
    lastName: string;
    firstName: string;
    address: string;
}

export interface SaveCustomer {
    customerId: number;
    firstName: string;
    lastName: string;
    address: string;
}

export interface CustomerForCreationDto {
    lastName: string;
    firstName: string;
    address: string;
}

export interface CustomerForUpdateDto {
    lastName: string;
    firstName: string;
    address: string;
}