import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../../shared/navbar/navbar.component";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Team } from '../../teams/Interfaces/AllTeam';
import { TeamServiceService } from '../../teams/Services/team-service.service';
import { Player } from '../Interface/AllPlayer';
import { PlayerServiceService } from '../services/player-service.service';

@Component({
  selector: 'app-add-player',
  imports: [NavbarComponent, FormsModule, CommonModule],
  templateUrl: './add-player.component.html',
  styleUrl: './add-player.component.css'
})


export class AddPlayerComponent implements OnInit {



  constructor(private teamservice: TeamServiceService, private playerService:PlayerServiceService) { }
  public team: Team[] = []
  public addflag:boolean=false

  ngOnInit(): void {
    this.teamservice.GetAllTeams().subscribe(
      res => {
        this.team = res
      },
      err => { console.log(err) }
    )
  }

  formsubmit(data: any): void {
    var val1: string = data.playername, val2: number = data.teamid
    
    let player:Player=new Player();
    player.name=val1;
    player.ptid=val2

    this.playerService.AddPlayer(player).subscribe(
      res=>{
        console.log('The res value is '+res)
        this.addflag=true
      },
      err=>{console.log(err)}
    )
  }




}
