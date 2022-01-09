import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Category, CategoryForCreationDto, CategoryForUpdateDto } from "../models/category.model";


@Injectable({
    providedIn: 'root'
})
export class CategoryService {

    private apiUrl = environment.apiUrl + '/api/categories';
    formData: Category = new Category();
    list: Category[];
    
    constructor(private http: HttpClient) { }
    
    getAll(): Observable<Category[]> {
        return this.http.get<Category[]>(this.apiUrl);
    }

    getById(categoryId: number): Observable<Category> {
        return this.http.get<Category>(`${this.apiUrl}/${categoryId}`);
    }

    getByName(category: string): Observable<Category> {
        return this.http.get<Category>(`${this.apiUrl}/${category}`);
    }

    create(category: CategoryForCreationDto) {
        return this.http.post(this.apiUrl, category);
    }

    edit(categoryId: number, category: CategoryForUpdateDto) {
        return this.http.put(`${this.apiUrl}/${categoryId}`, category);
    }

    delete(categoryId: number) {
        return this.http.delete(`${this.apiUrl}/${categoryId}`);
    }

    refreshList() {
        this.http.get(this.apiUrl)
            .toPromise()
            .then(res => this.list = res as Category[]);
    }
}