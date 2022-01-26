import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HasPermissionsGuard } from './guards/has-permissions.guard';
import { AnimalComponent } from './pages/animal/animal.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/login/login.component';
import { MainpageComponent } from './pages/mainpage/mainpage.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RegisterComponent } from './pages/register/register.component';
import { ZooComponent } from './pages/zoo/zoo.component';

const routes: Routes = [
  {
    path:"",
    component:MainpageComponent,
    pathMatch: 'full'
  },
  {
    path:"login",
    component:LoginComponent
  },
  {
    path:"register",
    component:RegisterComponent
  },
  {
    path: "zoo",
    component:ZooComponent
  },
  {
    path:"dashboard",
    component:DashboardComponent,
    canActivate: [HasPermissionsGuard]
  },
  {
    path:"profile/:id",
    component:ProfileComponent
  },
  {
    path:"animal/:id",
    component:AnimalComponent
  },
  {
    path:"**",
    redirectTo:""
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
