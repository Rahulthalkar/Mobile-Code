import { Routes } from '@angular/router';
import { ViewlistComponent } from './pages/viewlist/viewlist.component';
import { ViewDetailsComponent } from './pages/view-details/view-details.component';
import { AddPhoneComponent } from './pages/add-phone/add-phone.component';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.routes').then(m => m.WELCOME_ROUTES) },
  {path:'list',component:ViewlistComponent},
  {path:'view-detail/:id',component:ViewDetailsComponent},
  {path:'phone',component:AddPhoneComponent}
];
