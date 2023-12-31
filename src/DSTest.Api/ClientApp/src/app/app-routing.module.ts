import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TableComponent } from './components/table/table.component';
import { UploadComponent } from './components/upload/upload.component';

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Table', component: TableComponent },
  { path: 'Upload', component: UploadComponent },
  { path: '**', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
