import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { SpinnerOverlayService } from './shared/_services/spinner-overlay.service';
import { ThemeService } from './shared/_services/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'xcore-client';

  // Toggle sidenav event
  @Output() public sidebarToggle = new EventEmitter;

  public opened!: boolean; // Will be used to toggle animated icon states
  public isDarkTheme: Observable<boolean>; // Will be used to toggle between dark and light modes
  public mobile: boolean; // Toggle mobile layout

  constructor(
    private breakpointObserver: BreakpointObserver,
    public themeService: ThemeService,
    private spinnerOverlayService: SpinnerOverlayService,
  ) { }
  
  get isMobile(): boolean {
    return this.breakpointObserver.isMatched(Breakpoints.Handset);
  }
  
  ngOnInit(): void {
    this.isDarkTheme = this.themeService.isThemeDark;

    // ~~~~~ Display Spinner ~~~~~ //
    this.spinnerOverlayService.show();
    setTimeout(() => {
      this.spinnerOverlayService.hide();
    }, 1000);
  }

  clicked() {
    this.opened = !this.opened;
    this.sidebarToggle.emit();
  }

  toggleDarkTheme(checked: boolean) {
    this.themeService.setDarkTheme(checked);
  }
}
