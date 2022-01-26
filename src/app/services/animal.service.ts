import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private baseUrl:string= environment.API_URL;
  public favs = new Set();
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem("token")
    })
  }
  constructor(private http:HttpClient) { }

  getAll()
  {
    return this.http.get(this.baseUrl + "/AnimalV2/GetAllAnimals");
  }

  addFav(animalName:string)
  {
    this.favs.add(animalName);
  }

  createNewAnimal(data:any)
  {
    return this.http.post(this.baseUrl + "/AnimalV2/CreateNewAnimal", data, this.privateHttpHeaders);
  }

  getAnimalById(id:string)
  {
    return this.http.get(this.baseUrl + "/AnimalV2/GetSpecificAnimal/" + id);
  }


}
