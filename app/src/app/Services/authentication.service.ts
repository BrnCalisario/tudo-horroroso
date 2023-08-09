import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';

@Injectable({
	providedIn: 'root'
})
class AuthenticationService {

	constructor(
		private http: HttpClient,
		private config: ConfigService) {
	}

	login(email: string, password: string) {
		return this.http.post<Jwt>(this.config.backendURL + "/user/login", { email, password })
	}

	setSession(authResult : Jwt) {
		sessionStorage.setItem('id_token', authResult.value)
	}

	logout() {
		sessionStorage.removeItem('id_token')
	}
}

interface Jwt {
	value: string
}


export { AuthenticationService, Jwt }