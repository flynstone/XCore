import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Rental, RentalForCreationDto, RentalForUpdateDto } from "../models/rental.model";


@Injectable({
    providedIn: 'root'
})
export class RentalService {

    private apiUrl = environment.apiUrl + '/api/rentals';
    formData: Rental = new Rental();
    list: Rental[];
    
    constructor(private http: HttpClient) { }
    
    getAll(): Observable<Rental[]> {
        return this.http.get<Rental[]>(this.apiUrl);
    }

    getById(rentalId: number): Observable<Rental> {
        return this.http.get<Rental>(`${this.apiUrl}/${rentalId}`);
    }

    create(rental: RentalForCreationDto) {
        return this.http.post(this.apiUrl, rental);
    }

    edit(rentalId: number, rental: RentalForUpdateDto) {
        return this.http.put(`${this.apiUrl}/${rentalId}`, rental);
    }

    delete(rentalId: number) {
        return this.http.delete(`${this.apiUrl}/${rentalId}`);
    }

    getCategories<Category>(): Observable<Category[]> {
        return this.http.get<Category[]>(`${this.apiUrl}/categories`);
    }

    getCustomers<Customer>(): Observable<Customer[]> {
        return this.http.get<Customer[]>(`${this.apiUrl}/customers`);
    }

    getMedias<Media>(): Observable<Media[]> {
        return this.http.get<Media[]>(`${this.apiUrl}/medias`);
    }

    refreshList() {
        this.http.get(this.apiUrl)
            .toPromise()
            .then(res => this.list = res as Rental[]);
    }
}