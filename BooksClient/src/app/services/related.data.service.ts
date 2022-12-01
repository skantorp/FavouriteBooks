import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { KeyValue } from "../models/keyvalue";

@Injectable()
export class RelatedDataService {
    relatedDataUrl = environment.apiUrl + '/relateddata'

    constructor(private http: HttpClient) {
    }

    getAuthors(): Observable<KeyValue[]> {
        const url = this.relatedDataUrl+'/authors';
        return this.http.get<KeyValue[]>(url);
    }

    getGenres(): Observable<KeyValue[]> {
        const url = this.relatedDataUrl+'/genres';
        return this.http.get<KeyValue[]>(url);
    }
    
    getStatuses(): Observable<KeyValue[]> {
        const url = this.relatedDataUrl+'/statuses';
        return this.http.get<KeyValue[]>(url);
    }
}