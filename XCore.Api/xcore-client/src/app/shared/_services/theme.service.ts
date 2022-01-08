import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private darkTheme: Subject<boolean> = new Subject<boolean>();
  isThemeDark = this.darkTheme.asObservable();

  setDarkTheme(isThemeDark: boolean) {
    this.darkTheme.next(isThemeDark);
  }
}

