import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ZookeeperService {

  private baseUrl:string= environment.API_URL;

  constructor(private http:HttpClient) { }

  getAll()
  {
    return this.http.get(this.baseUrl + "/ZookeeperV2/GetAllZookeepers");
  }

  createNewZookeeper(data:any)
  {
    return this.http.post(this.baseUrl + "/ZookeeperV2/CreateNewZookeeper", data);
  }

}
