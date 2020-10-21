import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './components/employees/employees.component';


const routes: Routes = [
  {path: 'employees', component: EmployeesComponent},
  {path: '**', pathMatch: 'full', redirectTo: 'employees'},
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
