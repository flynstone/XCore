import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CookiesPolicyComponent } from './shared/components/cookies-policy/cookies-policy.component';
import { HomeComponent } from './shared/components/home/home.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { PrivacyPolicyComponent } from './shared/components/privacy-policy/privacy-policy.component';
import { TermsAndConditionsComponent } from './shared/components/terms-and-conditions/terms-and-conditions.component';

const routes: Routes = [
  { path: "home", component: HomeComponent, pathMatch: "full" },
  { path: 'privacy-policy', component: PrivacyPolicyComponent },
  { path: 'terms-and-conditions', component: TermsAndConditionsComponent },
  { path: 'cookies-policy', component: CookiesPolicyComponent },
  { path: '404', component: NotFoundComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },  
  { path: '**', redirectTo: '/404', pathMatch: 'full' } // Redirect if path unknown
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
