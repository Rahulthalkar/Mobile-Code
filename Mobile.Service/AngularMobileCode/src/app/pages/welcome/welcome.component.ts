import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormGroup, NonNullableFormBuilder, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { UserService } from '../../service/user.service';
import { Router, RouterLink } from '@angular/router';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-welcome',
  standalone: true,
  imports:[ReactiveFormsModule,NzFormModule,NzButtonModule,NzDropDownModule,NzInputModule,NzSelectModule,RouterLink
    ,NzInputNumberModule,CommonModule
  ],
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  validateForm: FormGroup;
  contryCodeOptions:any;
  isSubmitted: boolean = false;

  constructor(private fb: NonNullableFormBuilder,
    private userService:UserService,
    private router:Router

  ) {
    this.validateForm = this.fb.group({
      name: ['', [ Validators.required]],
      countryCodeId:[null,[ Validators.required]],
      phone: ['', [Validators.required,Validators.maxLength(15)]],
    },{
    validators: this.phoneWithCountryCodeValidator()
    }
   )
   }

  phoneWithCountryCodeValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!this.isSubmitted) {
        return null; // Skip validation if the form hasn't been submitted
      }
      const countryCodeId = control.get('countryCodeId');
      const phone = control.get('phone');

      if (countryCodeId?.value && phone?.value) {
        return null; // No error
      } else {
        return { phoneWithCountryCode: true }; // Error if either is missing
      }
    };
  }
  ngOnInit() { 
    this.getDropDownOptions();
  }
  
  submitForm(): void {
    this.isSubmitted = true;
    if (this.validateForm.valid) {
      
      console.log('submit', this.validateForm.value);
      this.userService.Regiter(this.validateForm.value).subscribe({
        next:(response:any)=>{
          if(response.isSuccess){
            this.router.navigate(['list']);
          }else{
            alert("failed to register")
          }
          this.validateForm.reset();
        }
      })
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
  
  getDropDownOptions(): void {
    
    this.userService.getDropDownOptions('CountryPhoneCode').subscribe(options => {
     console.log(this.contryCodeOptions = options.value);
     const defaultOption = this.contryCodeOptions.find((option: { isDefault: any; }) => option.isDefault);
     if (defaultOption) {
         this.validateForm.patchValue({
             contryCodeId: defaultOption.id
         });
     }
    });
  }
  trackById(index: number, item: any): number {
    return item.id;
}
 

}
