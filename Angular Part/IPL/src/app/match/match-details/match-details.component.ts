import { Component, EventEmitter, OnInit, Output, output } from '@angular/core';
import { NavbarComponent } from '../../shared/navbar/navbar.component';
import { MatchServiceService } from '../services/match-service.service';
import { TeamMatch } from '../interface/AllMatches';
import { CommonModule } from '@angular/common';
import { AddDetailsComponent } from '../add-details/add-details.component';
import { Team } from '../../teams/Interfaces/AllTeam';

@Component({
  selector: 'app-match-details',
  imports: [NavbarComponent,CommonModule,AddDetailsComponent],
  templateUrl: './match-details.component.html',
  styleUrl: './match-details.component.css'
})
export class MatchDetailsComponent implements OnInit {
  
  constructor(private matchservice:MatchServiceService) {}
  teamMatch:TeamMatch[]=[]
  temp:TeamMatch=new TeamMatch()
  counter:number=0
  addflag:boolean=false
  gridflag:boolean=true
  ngOnInit(): void {
    this.addflag=false
    this.counter=0
    this.matchservice.GetAllMatches().subscribe(
      res=>{
        this.teamMatch=res
        console.log(res)
      },
      err=>{console.log(err)}
    )
  }
   MatchDetail(tm:TeamMatch){
    this.addflag=true
    this.temp=tm
    this.gridflag=false
  }

  customevent($event:boolean)
  {
    this.gridflag=true
    this.addflag=false
  }


}
