import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import { Dish } from 'src/app/models/Dish';
import {DataDishesService} from "../../../../../services/data-dishes.service";
import {ToastrService} from "ngx-toastr";
import {DishCategory} from "../../../../../models/DishCategory";
import {DataCategoriesService} from "../../../../../services/data-categories.service";

@Component({
  selector: 'app-administrate-dishes',
  templateUrl: './administrate-dishes.component.html',
  styleUrls: ['./administrate-dishes.component.css']
})
export class AdministrateDishesComponent implements OnInit{
  dishes: Dish[];
  filteredItems: Dish[];
  categories: DishCategory[];
  @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;
  editedDish: Dish|null = null;
  isNewRecord: boolean = false;
  constructor(private dataDishesService: DataDishesService, private toast: ToastrService, private dataCategoriesService: DataCategoriesService) {
    this.dishes = new Array<Dish>();
    this.categories = new Array<DishCategory>();
  }

  private assignCopy(){
    this.filteredItems = Object.assign([], this.dishes);
  }
  private getDishes(){
    this.dataDishesService.getDishes().subscribe((data:Dish[]) => {
      this.dishes = data;
      this.assignCopy();
    });
  }

  public filterItem(value){
    if(!value){
      this.assignCopy();
    } // when nothing has typed
    this.filteredItems = Object.assign([], this.dishes).filter(
      item => item.name.toLowerCase().indexOf(value.toLowerCase()) > -1
    )
  }
  private getCategories(){
    this.dataCategoriesService.getCategories().subscribe((data:DishCategory[])=>{
      this.categories = data;
    });
  }

  public loadTemplate(dish: Dish) {
    return this.editedDish && this.editedDish.id === dish.id? this.editTemplate: this.readOnlyTemplate;
  }

  public saveDish() {
    if (this.isNewRecord) {
      this.dataDishesService.createDish(this.editedDish as Dish).subscribe(_ => {
        this.toast.success('???????????? ?????????????? ??????????????????')
          this.getDishes();
      });
      this.isNewRecord = false;
      this.editedDish = null;
    } else {
      this.dataDishesService.updateDish(this.editedDish.id, this.editedDish as Dish).subscribe(_ => {
        this.toast.success('???????????? ?????????????? ??????????????????')
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
      dishPrice : 0
    };
    this.dishes.push(this.editedDish);
    this.isNewRecord = true;
  }
  public editDish(dish: Dish) {
    this.editedDish = {
      id: dish.id,
      name: dish.name,
      dishCategoryId: dish.dishCategoryId,
      dishPrice: dish.dishPrice
    }
  }

  public deleteDish(dish: Dish) {
    if(confirm(`?????????????????????????? ?????????????? ?????????? ${dish.name} ?`))
    this.dataDishesService.deleteDish(dish.id).subscribe(_ => {
      this.toast.info('???????????? ?????????????? ??????????????')
        this.getDishes();
    });
  }
  public cancel() {
    if (this.isNewRecord) {
      this.dishes.pop();
      this.isNewRecord = false;
    }
    this.editedDish = null;
  }
  ngOnInit(): void {
    this.getCategories();
    this.getDishes();
  }
}
