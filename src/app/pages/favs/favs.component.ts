import { Component, OnInit } from '@angular/core';
import { AnimalService } from 'src/app/services/animal.service';

@Component({
  selector: 'app-favs',
  templateUrl: './favs.component.html',
  styleUrls: ['./favs.component.scss']
})
export class FavsComponent implements OnInit {

  constructor(private animalService:AnimalService) { }

  ngOnInit(): void {
  }
  get nrFavs()
  {
    return this.animalService.favs.size;
  }

}
