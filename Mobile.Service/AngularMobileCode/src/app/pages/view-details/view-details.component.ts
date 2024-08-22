import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormGroup, NonNullableFormBuilder, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { UserService } from '../../service/user.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
@Component({
  selector: 'app-view-details',
  standalone: true,
  imports:[ReactiveFormsModule,NzFormModule,NzButtonModule,NzDropDownModule,NzInputModule,NzSelectModule,RouterLink],

  templateUrl: './view-details.component.html',
  styleUrl: './view-details.component.css'
})
export class ViewDetailsComponent {

  Viewlist: any;
  
  constructor(private userService:UserService,private route:ActivatedRoute){
    
  }
  ngOnInit(): void {
   const  id = Number(this.route.snapshot.paramMap.get('id'));
    this.userService.GetUserDetails(id).subscribe({
      next:(response:any)=>{
        if(response.isSuccess){
            this.Viewlist=response.value;
        }
      }
    })
  }
}
