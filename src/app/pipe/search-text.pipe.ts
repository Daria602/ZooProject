import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchText'
})
export class SearchTextPipe implements PipeTransform {

  transform(users:any[], searchInput:string): any {
    if (!searchInput)
    {
      return users;
    }

    return users.filter((user)=>{
      return user.userName.toLowerCase().indexOf(searchInput.toLowerCase()) !== -1;
    });
  }

}
