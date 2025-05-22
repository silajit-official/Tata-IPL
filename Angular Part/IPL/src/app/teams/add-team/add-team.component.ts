import { Component, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from "../../shared/navbar/navbar.component";
import { Form, FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Team } from '../Interfaces/AllTeam';
import { TeamServiceService } from '../Services/team-service.service';

@Component({
  selector: 'app-add-team',
  imports: [NavbarComponent,FormsModule,CommonModule],
  templateUrl: './add-team.component.html',
  styleUrl: './add-team.component.css'
})


export class AddTeamComponent {

  /**
   *
   */
  constructor(private teamservice:TeamServiceService) {}
  team:Team=new Team();
  
  public formsubmit(Teamname:any):void{
    let values:string=Teamname.teamnames;
    this.team.teamName=values;
    console.log('Before calling- '+this.team.teamName+' '+this.team.points)
    this.teamservice.AddTeam(this.team).subscribe(
      (res)=>{
        console.log(res)
      },
      (err)=>{
        console.log(err)
      }
    )
  }

}
