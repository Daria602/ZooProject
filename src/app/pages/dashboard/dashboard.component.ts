import { Component, OnInit } from '@angular/core';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public users:any[]=[];

  searchInput: string ='';
  constructor(private privateService:PrivateService) { }

  ngOnInit(): void {
    this.getAllUsers();
  
  }

  getAllUsers()
  {
    this.privateService.getAllUsers().subscribe((response:any)=>{
      this.users = response;
      console.log(this.users);
    });
    
  }

  removeUser(name:string)
  {
    this.users = this.users.filter((user)=>{
      return user.userName !== name;
    })
  }

  


}
