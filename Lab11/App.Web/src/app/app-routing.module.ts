import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ErrorComponent } from './pages/error/error.component';
import { authGuardFn } from '@auth0/auth0-angular';
import { FirstLabComponent } from './pages/first-lab/first-lab.component';
import { SecondLabComponent } from './pages/second-lab/second-lab.component';
import { ThirdLabComponent } from './pages/third-lab/third-lab.component';

export const routes: Routes = [
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [authGuardFn],
  },
  {
    path: 'error',
    component: ErrorComponent,
  },
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path: 'first',
    component: FirstLabComponent,
  },
  {
    path: 'second',
    component: SecondLabComponent,
  },
  {
    path: 'third',
    component: ThirdLabComponent,
  },
];
