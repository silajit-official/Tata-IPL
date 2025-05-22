import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Team } from '../Interfaces/AllTeam';

@Injectable({
  providedIn: 'root'
})
export class TeamServiceService {

  constructor(private httlp:HttpClient) { }

  public GetAllTeams():Observable<Team[]>
  {
    return this.httlp.get<Team[]>('https://localhost:44392/team/GetTeams')
  }

  public AddTeam(team:Team):Observable<any>
  {
    return this.httlp.post<any>('https://localhost:44392/team/AddTeam',team)
  }

  public GetTeamByID(id:number):Observable<Team>{
    return this.httlp.get<Team>('https://localhost:44392/team/GetTeamByID?tid='+id)
  }
}
