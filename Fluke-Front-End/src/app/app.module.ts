import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './events/events.component';
import { EventComponent } from './event/event.component';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { CategoryComponent } from './category/category.component';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    EventComponent,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
