import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrivateService {
  private baseUrl:string= environment.API_URL;
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem("token")
    })
  }
  constructor(private http:HttpClient) { }

  getAllUsers()
  {
    
    return this.http.get(this.baseUrl+"/Users/GetAllUsers",this.privateHttpHeaders);
  }
}
