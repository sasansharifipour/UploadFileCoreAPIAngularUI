import { Component } from '@angular/core';
import { UserService } from '../shared/services/user.services';
import { UserRegisterModel } from '../shared/models/user.register.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public fileData: File = null;

  constructor(private userService: UserService) {

  }

  registerUser({ value, valid }: { value: UserRegisterModel, valid: boolean }) {

    this.userService.addUser(value, this.fileData).subscribe(res => {
      alert(res.value);
    }, error => {
      alert('ERROR Happened!!!');
    });
  }

  handleFileInput(files: FileList) {
    this.fileData = files.item(0);
  }

}
