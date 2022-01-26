import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AnimalService } from 'src/app/services/animal.service';
import { AuthService } from 'src/app/services/auth.service';
import { ZookeeperService } from 'src/app/services/zookeeper.service';

@Component({
  selector: 'app-zoo',
  templateUrl: './zoo.component.html',
  styleUrls: ['./zoo.component.scss']
})
export class ZooComponent implements OnInit {
  public animals:any[] = [];
  public zookeepers:any[] = [];
  searchInput: string ='';
  myForm:any;
  volunteerForm:any;


  get isAdmin()
  {
    return this.authService.isAdmin();
  }

  constructor(private zookeeperService:ZookeeperService,private animalService:AnimalService, private fb: FormBuilder, private authService:AuthService, private router:Router) {
    this.myForm = this.fb.group({
      name: this.fb.control(''),
      yearBorn: this.fb.control(''),
      averageLongevity: this.fb.control(''),
      gender: this.fb.control(''),
    });

    this.volunteerForm = this.fb.group({
      name: ['',[Validators.required]],
      age: ['',[Validators.required,Validators.min(14)]],
      fanimal: this.fb.control(''),
      shpref: ['',[Validators.required, Validators.minLength(4)]],
    });
   }

  ngOnInit(): void {
    this.getAllAnimals();
    this.getAllZookeepers();
  }

  getAllAnimals()
  {
    this.animalService.getAll().subscribe((response:any)=>{
      this.animals = response;
    });
    
  }
  getAllZookeepers()
  {
    this.zookeeperService.getAll().subscribe((response:any)=>{
      this.zookeepers = response;
    });
  }

  addFav(event:Event,animalName:any)
  {
    event.stopPropagation();
      this.animalService.addFav(animalName);
  }

  createNewAnimal(data:any)
  {
    
    this.animalService.createNewAnimal(data).subscribe((response)=>{
      this.getAllAnimals();
    });
  }
  createNewZookeeper(data:any)
  {
    
    this.zookeeperService.createNewZookeeper(data).subscribe((response)=>{
      this.getAllZookeepers();
    });
  }

  goToAnimalPage(name:string)
  {
    let index = this.animals.findIndex(animal => animal.name === name);
    console.log();
    this.router.navigateByUrl("/animal/" + (index+1));
  }

}
