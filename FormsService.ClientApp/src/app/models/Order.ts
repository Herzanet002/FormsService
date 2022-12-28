import {Person} from "./Person";
import {Location} from "./Location";
import {Dish} from "./Dish";
import {LocationEnums} from "./LocationEnums";

export interface Order{
  id: number,
  personId: number,
  location: Location,
  dateForming?: Date
}
