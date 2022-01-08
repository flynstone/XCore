import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { FooterComponent } from './layout/footer/footer.component';
import { MaterialModule } from './material/material.module';
import { HomeComponent } from './components/home/home.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { SpinnerOverlayComponent } from './components/spinner/spinner-overlay/spinner-overlay.component';
import { SpinnerOverlayWrapperComponent } from './components/spinner/spinner-overlay-wrapper/spinner-overlay-wrapper.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { CookiesPolicyComponent } from './components/cookies-policy/cookies-policy.component';
import { PrivacyPolicyComponent } from './components/privacy-policy/privacy-policy.component';
import { TermsAndConditionsComponent } from './components/terms-and-conditions/terms-and-conditions.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    SidenavComponent,
    FooterComponent,
    HomeComponent,
    SpinnerComponent,
    SpinnerOverlayComponent,
    SpinnerOverlayWrapperComponent,
    NotFoundComponent,
    CookiesPolicyComponent,
    PrivacyPolicyComponent,
    TermsAndConditionsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
  ],
  exports: [
    SidenavComponent,
    FooterComponent,
    MaterialModule,
    HomeComponent,
    SpinnerComponent,
    SpinnerOverlayComponent,
    SpinnerOverlayWrapperComponent,
    NotFoundComponent,
    CookiesPolicyComponent,
    PrivacyPolicyComponent,
    TermsAndConditionsComponent
  ]
})
export class SharedModule { }
