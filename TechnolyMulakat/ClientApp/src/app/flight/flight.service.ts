import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CodeListModel } from 'src/common/common.model';
import { FlightDetailDTO, FlightListDTO, FlightSearchRequestDTO } from './flight.model';

@Injectable()
export class FlightService {
  constructor(private http: HttpClient) {}

  searchFlight(data: FlightSearchRequestDTO): Observable<FlightListDTO[]> {
    return this.http.post<FlightListDTO[]>('api/flight/searchFlight', data);
  }

  getFlightDetails(flightId: number | null): Observable<FlightDetailDTO> {
    return this.http.get<FlightDetailDTO>('api/flight/flightDetail/' + flightId);
  }
}
