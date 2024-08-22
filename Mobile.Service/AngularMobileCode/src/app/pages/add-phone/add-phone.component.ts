import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {
  SearchCountryField,
  CountryISO,
  NgxIntlTelInputModule,
  PhoneNumberFormat,
} from "ngx-intl-tel-input";
import { NzSelectModule } from 'ng-zorro-antd/select';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-phone',
  standalone: true,
  imports: [NgxIntlTelInputModule, ReactiveFormsModule, FormsModule, NzSelectModule,CommonModule],
  templateUrl: './add-phone.component.html',
  styleUrls: ['./add-phone.component.css']
})
export class AddPhoneComponent implements OnInit {
  separateDialCode = true;
  SearchCountryField = SearchCountryField;
  CountryISO = CountryISO;
  PhoneNumberFormat = PhoneNumberFormat;
  selectedCountry = CountryISO.Afghanistan;
  contryCodeOptions: { label: string; value: CountryISO }[] = [];

  phoneForm:FormGroup;
 
  constructor(private fb:FormBuilder,private cdr: ChangeDetectorRef) {
    this.phoneForm=this.fb.group({
      phone:[ ,[Validators.required]],
      contryCodeId: [this.selectedCountry],
    });
  }
 

  ngOnInit(): void {
    // Populate contryCodeOptions with country names and ISO codes
    this.contryCodeOptions = Object.keys(CountryISO).map((key) => ({
      label: key.replace('_', ' '), // Example: Convert "United_States" to "United States"
      value: CountryISO[key as keyof typeof CountryISO],
    }));

    // Listen for changes in the country selection
    this.phoneForm.get('contryCodeId')?.valueChanges.subscribe((value) => {
       if (value !== null) { // Ensure the value is not null before calling changeCountry
       this.changeCountry(value);
      }
    });
  }
  changeCountry(country: CountryISO) {

    this.selectedCountry = country;
    this.phoneForm.get('phone')?.updateValueAndValidity();
    this.cdr.detectChanges();
  }
  submitForm():void{
    if(this.phoneForm.valid){
      console.log('formdata==========>',this.phoneForm.value);
      
    }
  }
}
