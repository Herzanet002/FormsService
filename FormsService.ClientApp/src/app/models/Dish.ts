import {DishCategory} from "./DishCategory";
import {NamedEntity} from "./NamedEntity";

export interface Dish extends NamedEntity {
  id: number,
  dishCategoryId: number,
  category: DishCategory


}
