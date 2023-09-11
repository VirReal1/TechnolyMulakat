import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FlightComponent } from './flight/flight.component';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { FlightService } from './flight/flight.service';
import { ApiPrefixInterceptor } from 'src/common/api-prefix.interceptor';
import { CommonService } from 'src/common/common.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlightDetailComponent } from './flight/components/flight-detail/flight-detail.component';

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent, FlightComponent, FlightDetailComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', title: 'Home' },
      { path: 'flight', component: FlightComponent, title: 'Flights' },
    ]),
    CommonModule,
    ReactiveFormsModule,
    NgSelectModule,
    BrowserAnimationsModule,
  ],
  providers: [
    FlightService,
    CommonService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiPrefixInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
