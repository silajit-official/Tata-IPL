import { Component,OnInit } from '@angular/core';
import { NavbarComponent } from '../../shared/navbar/navbar.component';
import { TeamServiceService } from '../Services/team-service.service';
import { Team } from '../Interfaces/AllTeam';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-points-table',
  imports: [NavbarComponent,CommonModule],
  templateUrl: './points-table.component.html',
  styleUrl: './points-table.component.css'
})
export class PointsTableComponent {

  /**
   *
   */
  public team:Team[]=[]
  constructor(private teamservice:TeamServiceService) {}
  ngOnInit():void{
    this.GetAllTeams();
  }
  
  public GetAllTeams():void{
    this.teamservice.GetAllTeams().subscribe(
      (res)=>{
        console.log(res)
        this.team=res;
      },
      (err)=>{
        console.log(err)
      }
    )
  }
}
