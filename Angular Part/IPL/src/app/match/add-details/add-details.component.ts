import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { TeamMatch } from '../interface/AllMatches';
import { MatchDetailsComponent } from '../match-details/match-details.component';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Team } from '../../teams/Interfaces/AllTeam';
import { TeamServiceService } from '../../teams/Services/team-service.service';
import { PlayerServiceService } from '../../players/services/player-service.service';
import { Player } from '../../players/Interface/AllPlayer';
import { MatchServiceService } from '../services/match-service.service';
import { MatchDetail } from '../interface/MatchDetail';

@Component({
  selector: 'app-add-details',
  imports: [RouterModule,CommonModule,FormsModule],
  templateUrl: './add-details.component.html',
  styleUrl: './add-details.component.css'
})
export class AddDetailsComponent implements OnInit{
  
  @Output() clicks=new EventEmitter<boolean>()
  flag:boolean=false
  @Input() teammatchs:any
  t:TeamMatch=new TeamMatch()
  team: Team[] = []
  player:Player[]=[]

  constructor(private teamservice: TeamServiceService,private playerservice:PlayerServiceService,private matchservice:MatchServiceService,private router:Router) {
    

  }
  ngOnInit(): void {
    let p1:Player[]
    let p2:Player[]
    this.t=this.teammatchs
    console.log(this.teammatchs)
    console.log(this.teammatchs.team1_Name)

    this.teamservice.GetTeamByID(this.teammatchs.team1).subscribe(
      res => {
        this.team.push(res)
      },
      err => { console.log(err) }
    )
    this.teamservice.GetTeamByID(this.teammatchs.team2).subscribe(
      res => {
        this.team.push(res)
      },
      err => { console.log(err) }
    )
    
    this.playerservice.GetPlayer(this.teammatchs.team1).subscribe(
      res=>{
        p1=res
        this.player=p1
        this.playerservice.GetPlayer(this.teammatchs.team2).subscribe(
      res=>{
        p2=res
        this.player=[...this.player,...p2]

      }
    )
      }
    )
    
    console.log(this.player)
  }


  
  

  myevent(){
    this.flag=true
    this.clicks.emit(this.flag)
  }


  formsubmit(val:any)
  {
    let matchD:MatchDetail=new MatchDetail()
    matchD.playerOfTheMatch=val.play
    matchD.firstTeamBat=val.teamid
    matchD.mdTmId=this.teammatchs.tmid
    matchD.winByRuns=val.run
    matchD.winByWickets=val.wicket
    console.log(matchD)
    this.matchservice.AddMatchDetails(matchD).subscribe(
      res=>{
        console.log(res)
        alert('Details updated successfully')
        this.ngOnInit()
        
      },
      err=>{
        console.log(err)
      }
    )
  }
 
}
