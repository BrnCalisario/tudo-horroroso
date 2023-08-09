import { User } from '../interfaces/Usuario';
import { UserService } from '../Services/UserService.service';
import { Router } from '@angular/router';
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
 
  @Output() public onUploadFinished = new EventEmitter<any>();

    @Input() public value: FormData | undefined = new FormData();
    @Input() public title: string = '';
    @Input() public imgUrl: string = '';

    ngOnInit(): void {}

    uploadFile = (files: any) => {
        if (files.length == 0) {
            return;
        }

        let fileToUpload = <File>files[0];

        this.value = new FormData();
        this.value.append('file', fileToUpload, fileToUpload.name);
        this.imgUrl = URL.createObjectURL(fileToUpload);

        this.onUploadFinished.emit(this.value);
    };

    getImgSrc() {
        if (this.imgUrl !== '') return this.imgUrl;

        return '../assets/usuario.png';
    }

  OnEmailOut(event: any){
    
    let email : string = event.target.value

    var result = email.match(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/)    
  }

  user : User = {
    userName: '',
    email: '',
    password: ''
  }

  constructor(private service : UserService, private router : Router) { }

  cadastrar()
  {
    this.service.add(this.user)
      .subscribe((res) => {
        this.router.navigate(["/login"])
      })
  }
}
