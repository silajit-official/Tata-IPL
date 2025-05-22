import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { TeamsModuleBaseComponent } from './teams/teams-module-base.component';
import { HomeComponent } from './shared/home/home.component';

export const routes: Routes = [
    {path:'',
        loadChildren:()=>import('./shared/shared.module').then(m=>m.SharedModule)
    },
    {path:'teams',
        loadChildren:()=>import('./teams/teams.module').then(m=>m.TeamsModule)
    },
    {path:'player',
        loadChildren:()=>import('./players/players.module').then(m=>m.PlayersModule)
    },
    {path:'match',
        loadChildren:()=>import('./match/match.module').then(m=>m.MatchModule)
    }
    
];
