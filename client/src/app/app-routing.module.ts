import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";

import AuthGuard from './auth/auth.guard'

import { AuctionListPageComponent } from './auction-list-page/auction-list-page.component';
import { LoginPageComponent } from './login-page/login-page.component';

const routes: Routes = [
  { path: 'login', component: LoginPageComponent },
  { path: 'auction', component: AuctionListPageComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: 'login' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }