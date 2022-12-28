import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import { Dish } from 'src/app/models/Dish';
import {DataDishesService} from "../../../services/data-dishes.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-administrate-dishes',
  templateUrl: './administrate-dishes.component.html',
  styleUrls: ['./administrate-dishes.component.css']
})
export class AdministrateDishesComponent implements OnInit{
  dishes: Dish[];
  categories: string[];
  @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;
  editedDish: Dish|null = null;
  isNewRecord: boolean = false;
  constructor(private dataDishesService: DataDishesService, private toast: ToastrService) {
    this.dishes = new Array<Dish>();
    this.categories = new Array<string>();
  }

  private getDishes(){
    this.dataDishesService.getDishes().subscribe((data:Dish[]) => {
      this.dishes = data;
      this.dishes.forEach((x) => {
        if(!this.categories.find(el => el === x.dishCategoryName))
        this.categories.push(x.dishCategoryName);
      });
    });
  }

  public loadTemplate(dish: Dish) {
    return this.editedDish && this.editedDish.id === dish.id? this.editTemplate: this.readOnlyTemplate;
  }

  public saveDish() {
    if (this.isNewRecord) {
      // добавляем пользователя
      this.dataDishesService.createDish(this.editedDish as Dish).subscribe(_ => {
        this.toast.success('Данные успешно добавлены')
          this.getDishes();
      });
      this.isNewRecord = false;
      this.editedDish = null;
    } else {
      // изменяем пользователя
      this.dataDishesService.updateDish(this.editedDish as Dish).subscribe(_ => {
        this.toast.success('Данные успешно обновлены')
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
      dishCategoryName:"",
      dishPrice : 0
    };
    this.dishes.push(this.editedDish);
    this.isNewRecord = true;
  }
  public editDish(dish: Dish) {
    this.editedDish={
      id: dish.id,
      name: dish.name,
      dishCategoryName: dish.dishCategoryName,
      dishCategoryId: dish.dishCategoryId,
      dishPrice: dish.dishPrice
    }
  }

  public deleteDish(dish: Dish) {
    if(confirm(`Действительно удалить блюдо ${dish.name} ?`))
    this.dataDishesService.deleteDish(dish.id).subscribe(_ => {
      this.toast.info('Данные успешно удалены')
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
