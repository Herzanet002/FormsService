import {Person} from "./Person";
import {Location} from "./Location";
import {Dish} from "./Dish";

export interface Order{
  person: Person;
  location: Location;
  dishes: Dish[]
}
