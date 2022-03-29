import { UserForRegistrationDto } from "src/app/authentication/_interfaces/user/userForRegistrationDto";
import { RegistrationResponseDto } from "src/app/authentication/_interfaces/response/registrationResponseDto";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }
  
  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}