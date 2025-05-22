import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../shared/navbar/navbar.component';

@Component({
  selector: 'app-teams-module-base',
  imports: [RouterModule],
  templateUrl: './teams-module-base.component.html',
  styleUrl: './teams-module-base.component.css'
})
export class TeamsModuleBaseComponent {

}
