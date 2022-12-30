import { Dish } from "./Dish";

export interface CategoryResponse {
  dishes: Dish[],
  id: number,
  categoryTitle: string
}
