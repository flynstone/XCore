import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Customer, CustomerForCreationDto, CustomerForUpdateDto } from "../models/customer.model";


@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    private apiUrl = environment.apiUrl + '/api/customers';
    formData: Customer = new Customer();
    list: Customer[];
    
    constructor(private http: HttpClient) { }
    
    getAll(): Observable<Customer[]> {
        return this.http.get<Customer[]>(this.apiUrl);
    }

    getById(customerId: number): Observable<Customer> {
        return this.http.get<Customer>(`${this.apiUrl}/${customerId}`);
    }

    create(customer: CustomerForCreationDto) {
        return this.http.post(this.apiUrl, customer);
    }

    edit(customerId: number, customer: CustomerForUpdateDto) {
        return this.http.put(`${this.apiUrl}/${customerId}`, customer);
    }

    delete(customerId: number) {
        return this.http.delete(`${this.apiUrl}/${customerId}`);
    }

    refreshList() {
        this.http.get(this.apiUrl)
            .toPromise()
            .then(res => this.list = res as Customer[]);
    }
}