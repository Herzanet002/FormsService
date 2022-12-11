import { Dish } from "./Dish";

export interface CategoryResponse {
  dishes: Dish[],
  id: number,
  title: string
}
