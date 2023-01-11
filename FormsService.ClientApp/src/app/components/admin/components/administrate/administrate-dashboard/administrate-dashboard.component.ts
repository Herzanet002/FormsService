import {Component, Inject, LOCALE_ID, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {formatDate} from "@angular/common";
import {DataOrdersService} from "../../../../../services/data-orders.service";
import {DatesRange} from "../../../../../models/DatesRange";
import {Person} from "../../../../../models/Person";

@Component({
  selector: 'app-administrate-dashboard',
  templateUrl: './administrate-dashboard.component.html',
  styleUrls: ['./administrate-dashboard.component.css']
})
export class AdministrateDashboardComponent implements OnInit{
  adminForm: FormGroup
  dates: DatesRange;

  constructor(@Inject(LOCALE_ID) public locale: string,
              private formBuilder: FormBuilder,
              private ordersDataService: DataOrdersService) {
  }
  ngOnInit(): void {
    this.createForm();
    this.ordersDataService.getDatesRange()
      .subscribe((data:DatesRange) => {
        this.patchDates(data);
        return this.dates = data;
      });
  }

  public onSubmitForm(adminForm: FormGroup){
    console.log(adminForm.value);
  }
  private createForm(){
    this.adminForm = this.formBuilder.group(
      {
        startPicker: [''],
        endPicker: [''],
        price:['']
      });
  }

  private patchDates(dates: DatesRange) {
    this.adminForm.patchValue({
      startPicker: formatDate(dates.startDate, 'yyyy-MM-dd', this.locale),
      endPicker: formatDate(dates.endDate, 'yyyy-MM-dd', this.locale)
    });
  }
}
