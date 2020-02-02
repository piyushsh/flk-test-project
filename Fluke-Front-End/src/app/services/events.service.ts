import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';
import { EventModel } from '../models/event.model';
import { EventStatus } from '../models/eventStatus.model';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  private EventsEndPoint : string = "https://localhost:5001/events";

  constructor(public httpClient: HttpClient) { }

  getEvents(
    date: string = undefined,
    status: string = undefined,
    categoryId: number = undefined,
    sortBy: string = undefined
  ) : Observable<EventModel[]> {
    const url = `${this.EventsEndPoint}?` +
      this.addValidQueryString('date', date) +
      this.addValidQueryString('categoryId', categoryId) +
      this.addValidQueryString('status', status) +
      this.addValidQueryString('sortBy', sortBy, false);
    return this.httpClient
      .get<EventModel[]>(url)
      .pipe(
        map(evt => {
          evt.forEach(this.mapEventStatus);
          return evt;
        }),
        catchError(this.handleError)
      );
  }

  getEvent(eventId: string) : Observable<EventModel>
  {
    return this.httpClient
      .get<EventModel>(`${this.EventsEndPoint}/${eventId}`)
      .pipe(
        map(this.mapEventStatus),
        catchError(this.handleError)
      );
  }

  private addValidQueryString(key: string, value: any, addAnotherQueryString : boolean = true){
    if(value !== undefined || value != null)
    {
      return `${key}=${value}${addAnotherQueryString ? '&' : ''}`;
    }
    return '';
  }
  
  private mapEventStatus(event){
    event.status = event.closed ? EventStatus.closed : EventStatus.open;
    return event;
  }

  private handleError(error) : Observable<never> {
    console.error(error);
    return throwError(error);
  }
}
