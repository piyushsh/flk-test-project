import { Component, OnInit } from '@angular/core';
import { EventsService } from '../services/events.service';
import { Observable } from 'rxjs';
import { EventModel } from '../models/event.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  events$ : Observable<EventModel[]>;
  dateFilter: string;
  statusFilter: string = '';
  categoryIdFilter: number;
  sortBy: string = '';

  constructor(
    public eventsService: EventsService, 
    public datePipe: DatePipe) { }

  ngOnInit() {
    this.events$ = this.eventsService.getEvents();
  }

  filterEvents(){
    this.events$ = this.eventsService.getEvents(
      this.datePipe.transform(this.dateFilter, 'MM-dd-yyyy'), 
      this.statusFilter, 
      this.categoryIdFilter, 
      this.sortBy);
  }

  sortEvents(){
    this.events$ = this.eventsService.getEvents(
      this.datePipe.transform(this.dateFilter, 'MM-dd-yyyy'), 
      this.statusFilter, 
      this.categoryIdFilter, 
      this.sortBy
    );
  }
}
