import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';

export const routes:Routes =[
  {path:'',component:HomeComponent},
  {path:'navbar',component:NavbarComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class SharedRoutingModule { }
