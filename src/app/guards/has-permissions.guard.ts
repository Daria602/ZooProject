import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HasPermissionsGuard implements CanActivate {
  constructor(private router:Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if (localStorage.getItem('permissions'))
      {
        const permissions = JSON.parse(localStorage.getItem('permissions')!);
        if(!permissions[route.routeConfig?.path!])
        {
          this.router.navigate(['/login']);
          return false;
        }
        
      }
      
    return true;
  }
  
}
