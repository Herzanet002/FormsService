import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'groupByAsc'
})
export class GroupByAscPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
