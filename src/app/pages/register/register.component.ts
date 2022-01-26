import { registerLocaleData } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public myForm!:FormGroup;
  constructor(private formBuilder:FormBuilder, private authService:AuthService, private router:Router) { }

  ngOnInit(): void {
    this.myForm = this.formBuilder.group(
      {
        email:['',[Validators.required, Validators.email]],
        password: ['',[Validators.required, Validators.minLength(5),Validators.maxLength(20)]],
        role:'Student'
      }
    )
  }

  doRegister()
  {
    if (this.myForm.valid)
    {
      this.authService.register(this.myForm.value).subscribe((response:any) => {
        this.router.navigateByUrl("/login");
      });
    }
  }


}
