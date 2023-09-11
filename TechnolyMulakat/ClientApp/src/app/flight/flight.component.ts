import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CodeListModel } from 'src/common/common.model';
import { FlightService } from './flight.service';
import { CommonService } from 'src/common/common.service';
import { FlightListDTO, FlightSearchRequestDTO } from './flight.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.scss'],
})
export class FlightComponent implements OnInit {
  @ViewChild('flightDetailModal') ngbmdFlightDetail: TemplateRef<any> | undefined;

  flightForm: FormGroup = this._fb.group({
    arrivalDate: [null],
    departureDate: [null],
    arrivalAirportId: [null],
    departureAirportId: [null],
  });

  airports: CodeListModel[] = [];
  flights: FlightListDTO[] = [];

  isSearched: boolean = false;
  modalVisibilityFlightDetail: boolean = false;

  flightId: number | null = null;

  constructor(private _fb: FormBuilder, private flightService: FlightService, private commonService: CommonService, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.getAirports();
  }

  get flightFormControls() {
    return this.flightForm.controls;
  }

  getAirports() {
    this.commonService.getAirports().subscribe((res) => {
      this.airports = res;
    });
  }

  submitForm() {
    if (this.anyInputProvided) {
      let formData: FlightSearchRequestDTO = this.flightForm.getRawValue();
      this.flightService.searchFlight(formData).subscribe((res) => {
        this.flights = res;
        if (res.length > 0) {
          this.isSearched = true;
        } else {
          this.isSearched = false;
        }
      });
    }
  }

  get anyInputProvided(): boolean {
    if (
      this.flightFormControls.arrivalAirportId.value ||
      this.flightFormControls.departureAirportId.value ||
      this.flightFormControls.arrivalDate.value ||
      this.flightFormControls.departureDate.value
    ) {
      return true;
    }

    return false;
  }

  getFlightDetails(flightId: number): void {
    this.modalVisibilityFlightDetail = true;
    this.modalService.open(this.ngbmdFlightDetail, { size: 'lg', centered: true });
    this.flightId = flightId;
  }
}
