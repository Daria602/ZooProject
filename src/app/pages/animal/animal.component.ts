import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AnimalService } from 'src/app/services/animal.service';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.scss']
})
export class AnimalComponent implements OnInit {

  public id:string='';
  public animal:any;
  constructor(private activatedRoute:ActivatedRoute, private animalService:AnimalService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params:any) => {
      this.id = params['id'];
      
      this.animalService.getAnimalById(this.id).subscribe((repsonse)=>{
        this.animal = repsonse;
      });
    });
    
  }

}
