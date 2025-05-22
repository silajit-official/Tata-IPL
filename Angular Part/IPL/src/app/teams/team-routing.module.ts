import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { AddTeamComponent } from './add-team/add-team.component';
import { PointsTableComponent } from './points-table/points-table.component';

export const routes: Routes = [
  {path:'add-team',component:AddTeamComponent},
  {path:'',component:AddTeamComponent},
  {path:'points-table',component:PointsTableComponent}
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class TeamRoutingModule { }
