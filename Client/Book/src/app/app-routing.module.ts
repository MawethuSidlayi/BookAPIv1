import { AuthGuard } from './Guards/auth.guard';
import { SubscriptionsComponent } from './pages/subscriptions/subscriptions.component';
import { LoginComponent } from './pages/login/login.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BooksListComponent } from './pages/books-list/books-list.component';

const routes: Routes = [
  { path: '', component: BooksListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'subscriptions', component: SubscriptionsComponent, canActivate:[AuthGuard] }
];

@NgModule({
  imports: [  CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
