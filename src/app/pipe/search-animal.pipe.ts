import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchAnimal'
})
export class SearchAnimalPipe implements PipeTransform {

  transform(animals:any[], searchInput:string): any {
    if (!searchInput)
    {
      return animals;
    }

    return animals.filter((animal)=>{
      return animal.name.toLowerCase().indexOf(searchInput.toLowerCase()) !== -1;
    });
  }
}
