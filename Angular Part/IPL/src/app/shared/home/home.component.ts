import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { AddTeamComponent } from '../../teams/add-team/add-team.component';

@Component({
  selector: 'app-home',
  imports: [NavbarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
