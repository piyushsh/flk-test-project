import { Category } from './category.model';
import { EventStatus } from './eventStatus.model';

export class EventModel{
    id : string;
    title: string;
    link: string;
    categories: Category[];
    closed: Date;
    status: string = EventStatus.unknown;
}