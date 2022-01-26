import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginData } from '../interfaces/login-data';
import { RegisterData } from '../interfaces/register-data';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string= environment.API_URL;
  

  constructor(private http:HttpClient) { }

  login(data:LoginData){
    //"api"
    return this.http.post(this.baseUrl + "/Auth/LogIn", data);
  }
  register(data:RegisterData)
  {
    return this.http.post(this.baseUrl + "/Auth/Register", data);
  }

  isAdmin()
  {
    
    let token = localStorage.getItem("token");
    let role = JSON.parse(atob(token?.split(".")[1]!)).role;
    return role === "Admin";

  }
}
