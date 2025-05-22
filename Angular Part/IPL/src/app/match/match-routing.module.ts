import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { MatchDetailsComponent } from './match-details/match-details.component';


export const routes:Routes=[
  {path:'',component:MatchDetailsComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class MatchRoutingModule { }
