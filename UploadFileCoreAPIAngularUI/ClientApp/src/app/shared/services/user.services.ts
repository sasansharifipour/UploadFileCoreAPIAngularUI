import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserRegisterModel } from '../models/user.register.model';



@Injectable({
  providedIn: 'root',
})

export class UserService {
  
  constructor(private http: HttpClient) {
    
  }


  addUser(user: UserRegisterModel, image: File): any {

    const headers = new HttpHeaders().append('Content-Disposition', 'mulipart/form-data');

    let formData: FormData = new FormData();
    formData.append('data', JSON.stringify(user));
    formData.append('file', image, image.name);

    return this.http.post("https://localhost:44328/api/user", formData, { headers: headers });
  }

}
