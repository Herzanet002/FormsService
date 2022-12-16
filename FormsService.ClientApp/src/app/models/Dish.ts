import {DishCategory} from "./DishCategory";
import {NamedEntity} from "./NamedEntity";

export interface Dish extends NamedEntity {
  id: number,
  dishPrice: number
  dishCategoryId?: number,
  category?: DishCategory

}
