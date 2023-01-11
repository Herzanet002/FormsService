import {Location} from "./Location";

export interface Order{
  id: number,
  personId: number,
  location: Location,
  dateForming?: Date
}
