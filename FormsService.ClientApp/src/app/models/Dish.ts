import {NamedEntity} from "./NamedEntity";

export interface Dish extends NamedEntity {
  id: number,
  dishPrice: number
  dishCategoryId: number
  dishCategoryName?: string
}
