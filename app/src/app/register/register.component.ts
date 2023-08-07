import { Component } from '@angular/core';
import { User } from '../interfaces/Usuario';
import { UserService } from '../Services/UserService.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
 
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
