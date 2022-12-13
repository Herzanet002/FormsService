import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import { Dish } from 'src/app/models/Dish';
import {Person} from "../../../models/Person";
import {DataService} from "../../../services/data.service";
import {DishCategory} from "../../../models/DishCategory";

@Component({
  selector: 'app-administrate-dishes',
  templateUrl: './administrate-dishes.component.html',
  styleUrls: ['./administrate-dishes.component.css']
})
export class AdministrateDishesComponent implements OnInit{
  dishes: Dish[];
  categories: DishCategory[];
  @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;
  editedDish: Dish|null = null;
  isNewRecord: boolean = false;
  statusMessage: string = "";
  constructor(private dataService: DataService) {
    this.dishes = new Array<Dish>();
    this.categories = new Array<DishCategory>();
  }

  private getDishes(){
    this.dataService.getDishes().subscribe((data:Dish[]) => {
      this.dishes = data;
      this.dishes.forEach((x) => {
        if(!this.categories.find(el => el.id === x.category.id))
        this.categories.push(x.category);
      });
    });
  }

  public loadTemplate(dish: Dish) {
    return this.editedDish && this.editedDish.id === dish.id? this.editTemplate: this.readOnlyTemplate;
  }

  public saveDish() {
    if (this.isNewRecord) {
      // добавляем пользователя
      this.dataService.createDish(this.editedDish as Dish).subscribe(_ => {
        this.statusMessage = 'Данные успешно добавлены'
          this.getDishes();
      });
      this.isNewRecord = false;
      this.editedDish = null;
    } else {
      // изменяем пользователя
      this.dataService.updateDish(this.editedDish as Dish).subscribe(_ => {
        this.statusMessage = 'Данные успешно обновлены'
          this.getDishes();
      });
      this.editedDish = null;
    }
  }

  public addDish() {
    this.editedDish = {
      id:0,
      name:"",
      dishCategoryId:0,
      category:null
    };
    this.dishes.push(this.editedDish);
    this.isNewRecord = true;
  }
  public editDish(dish: Dish) {
    this.editedDish={
      id: dish.id,
      name: dish.name,
      dishCategoryId: dish.dishCategoryId,
      category: null
    }
  }

  public deleteDish(dish: Dish) {
    this.dataService.deleteDish(dish.id).subscribe(_ => {
      this.statusMessage = 'Данные успешно удалены',
        this.getDishes();
    });
  }
  cancel() {
    // если отмена при добавлении, удаляем последнюю запись
    if (this.isNewRecord) {
      this.dishes.pop();
      this.isNewRecord = false;
    }
    this.editedDish = null;
  }
  ngOnInit(): void {
    this.getDishes();
  }
}
