import { Component, Input, OnInit } from '@angular/core';
import { FlightService } from '../../flight.service';
import { FlightDetailDTO } from '../../flight.model';

@Component({
  selector: 'app-flight-detail',
  templateUrl: './flight-detail.component.html',
  styleUrls: ['./flight-detail.component.scss'],
})
export class FlightDetailComponent implements OnInit {
  @Input('flightId') flightId: number | null = null;

  flightDetail: FlightDetailDTO | null = null;

  constructor(private flightService: FlightService) {}

  ngOnInit(): void {
    this.flightService.getFlightDetails(this.flightId).subscribe((res) => {
      this.flightDetail = res;
    })
  }
}
