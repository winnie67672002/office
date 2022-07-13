import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({ name: 'localDate' })
export class MomentPipe implements PipeTransform {
  transform(value: Date | moment.Moment, dateFormat: string): any {
    if (value == null)
      return null;
    const date = moment(value).format(dateFormat);
    const stillUtc = moment.utc(date).toDate();
    return moment(stillUtc).local().format(dateFormat);
  }
}
