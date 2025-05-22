import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { AddPlayerComponent } from './add-player/add-player.component';

export const routes:Routes=[
  {path:'',component:AddPlayerComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class PlayersRoutingModule { }
