import { Component, OnInit } from '@angular/core';
import { NzTableModule } from 'ng-zorro-antd/table';
import { UserService } from '../../service/user.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-viewlist',
  standalone: true,
  imports: [NzTableModule],
  templateUrl: './viewlist.component.html',
  styleUrl: './viewlist.component.css'
})
export class ViewlistComponent implements OnInit {
  Viewlist: any[]=[];
  
  constructor(private userService:UserService,private route:Router){

  }
  ngOnInit(): void {
    this.userService.ViewList().subscribe({
      next:(response:any)=>{
        if(response.isSuccess){
            this.Viewlist=response.value;
        }
      }
    })
  }
  getId(id: number): void {
    this.route.navigateByUrl(`/view-detail/${id}`);
  }
}
