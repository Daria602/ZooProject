import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginData } from 'src/app/interfaces/login-data';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public isDisabled:boolean = false;
  public user: LoginData = 
  {
    email:"",
    password:""
  }
  public error:string | boolean = false;

  constructor(private authService:AuthService, private router:Router) { }

  ngOnInit(): void {
    
  }
  validateEmail(email: string) {
    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

  doLogin()
  {
    
    this.error = false;

    if(this.validateEmail(this.user.email) == true)
    {
      this.authService.login(this.user).subscribe((response:any) => {
        console.log(response);
        if (response && response.token)
        {
          let permission:any = {};
          localStorage.setItem("token", response.token.accessToken);
          let role = JSON.parse(atob(response.token.accessToken.split(".")[1]!)).role;
          if (role.toLowerCase() === "admin")
          {
            permission.dashboard = true;
          }
          else
          {
            permission.dashboard = false;
          }
          localStorage.setItem("permissions", JSON.stringify(permission));
          this.router.navigate(["/zoo"]);
        }
      });
    }
    else
    {
      this.error = "Email is not valid!";
    }
  }

  

}
