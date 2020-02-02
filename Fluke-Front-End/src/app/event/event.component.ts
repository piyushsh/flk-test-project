import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { EventModel } from '../models/event.model';
import { EventsService } from '../services/events.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

  event$ : Observable<EventModel>;

  constructor(public route : ActivatedRoute, public eventService: EventsService) { }

  ngOnInit() {
    const eventId = this.route.snapshot.paramMap.get('eventId');
    this.event$ = this.eventService.getEvent(eventId);
  }
}
