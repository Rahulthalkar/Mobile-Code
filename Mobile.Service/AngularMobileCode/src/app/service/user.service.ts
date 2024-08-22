import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

 
  constructor(
    private http: HttpClient,
    private notification: NzNotificationService
  ) { }

  private getHttpOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Credentials': 'true',
        'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
        'Access-Control-Allow-Headers':
          'Origin, Content-Type, Accept, X-Custom-Header, Upgrade-Insecure-Requests',
      }),
      withCredentials: true,
    };
    
  }

  Regiter(formData: any): Observable<any> {
    var httpOptionsToUse = this.getHttpOptions();
    return this.http
      .post(environment.baseUrl + `api/User/Register`,formData, httpOptionsToUse)
      .pipe((response: any) => {
        return response;
      });
  }
  getDropDownOptions(dropDownFor: any): Observable<any> {
    var httpOptionsToUse = this.getHttpOptions();
    return this.http
      .post(environment.baseUrl + `api/User/GetDropDown?dropdownFor=${dropDownFor}`, httpOptionsToUse)
      .pipe((response: any) => {
        return response;
      });
  }
  ViewList(): Observable<any> {
    var httpOptionsToUse = this.getHttpOptions();
    return this.http
      .post(environment.baseUrl + `api/User/ViewList`, httpOptionsToUse)
      .pipe((response: any) => {
        return response;
      });
  }
  GetUserDetails(userId: any): Observable<any> {
    var httpOptionsToUse = this.getHttpOptions();
    return this.http
      .post(environment.baseUrl + `api/User/GetUserDetails?userId=${userId}`, httpOptionsToUse)
      .pipe((response: any) => {
        return response;
      });
  }
  UpdateProfile(formData: any): Observable<any> {
    var httpOptionsToUse = this.getHttpOptions();
    return this.http
      .post(environment.baseUrl + `api/User/GetDropDown?UpdateProfile`,formData, httpOptionsToUse)
      .pipe((response: any) => {
        return response;
      });
  }
}
