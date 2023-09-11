export interface FlightSearchRequestDTO {
  departureAirportId: number;
  arrivalAirportId: number;
  departureDate: string;
  arrivalDate: string;
}

export interface FlightListDTO {
  id: number;
  departureAirportName: string;
  arrivalAirportName: string;
  departureDate: string;
  arrivalDate: string;
  apron: string;
}

export interface FlightDetailDTO {
  departureAirportName: string;
  arrivalAirportName: string;
  departureDate: string;
  arrivalDate: string;
  aircraftType: string;
  apron: string;
  pilotName: string;
  coPilotName: string;
}
