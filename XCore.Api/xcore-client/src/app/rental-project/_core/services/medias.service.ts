import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Media, MediaForCreationDto, MediaForUpdateDto } from "../models/media.model";


@Injectable({
    providedIn: 'root'
})
export class MediaService {

    private apiUrl = environment.apiUrl + '/api/medias';
    formData: Media = new Media();
    list: Media[];
    
    constructor(private http: HttpClient) { }
    
    getAll(): Observable<Media[]> {
        return this.http.get<Media[]>(this.apiUrl);
    }

    getById(mediaId: number): Observable<Media> {
        return this.http.get<Media>(`${this.apiUrl}/${mediaId}`);
    }

    create(media: MediaForCreationDto) {
        return this.http.post(this.apiUrl, media);
    }

    edit(mediaId: number, media: MediaForUpdateDto) {
        return this.http.put(`${this.apiUrl}/${mediaId}`, media);
    }

    delete(mediaId: number) {
        return this.http.delete(`${this.apiUrl}/${mediaId}`);
    }

    getCategories<Category>(): Observable<Category[]> {
        return this.http.get<Category[]>(`${this.apiUrl}/categories`);
    }

    refreshList() {
        this.http.get(this.apiUrl)
            .toPromise()
            .then(res => this.list = res as Media[]);
    }
}