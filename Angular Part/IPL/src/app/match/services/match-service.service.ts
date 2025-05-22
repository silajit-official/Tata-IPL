import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TeamMatch } from '../interface/AllMatches';
import { MatchDetail } from '../interface/MatchDetail';

@Injectable({
  providedIn: 'root'
})
export class MatchServiceService {

  constructor(private http:HttpClient) { }


  public GetAllMatches():Observable<TeamMatch[]>
  {
    return this.http.get<TeamMatch[]>('https://localhost:44392/match/GetAllMatches')
  }

  public AddMatchDetails(md:MatchDetail):Observable<any>{
    return this.http.post<any>('https://localhost:44392/match/AddMatchDetails',md)
  }
}
