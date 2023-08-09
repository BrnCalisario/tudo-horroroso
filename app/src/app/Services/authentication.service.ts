import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';

@Injectable({
	providedIn: 'root'
})
class AuthenticationService {
	
	constructor(
		private http : HttpClient,
		private config : ConfigService) { }

	login(email: string, password : string) {
		return this.http.post<Jwt>
			(this.config.backendURL + "/user/login", { email, password })
	}
}

interface Jwt
{
	value : string
}


export { AuthenticationService, Jwt }