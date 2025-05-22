import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Player } from '../Interface/AllPlayer';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlayerServiceService {

  constructor(private http:HttpClient) { }

  public AddPlayer(player:Player):Observable<any>{
    return this.http.post<any>('https://localhost:44392/PLAYER/AddPlayer',player)
  }

  public GetPlayer(tid:number):Observable<Player[]>
  {
    return this.http.get<Player[]>('https://localhost:44392/PLAYER/GetPlayer/'+tid)

  }
}
