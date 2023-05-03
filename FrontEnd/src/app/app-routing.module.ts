import { NgModule } from "@angular/core";
import { RouterModule, Route } from "@angular/router";
import { ListComponent } from "./employee/pages/list/list.component";
import { AddComponent } from "./employee/pages/add/add.component";
import { EditComponent } from "./employee/pages/edit/edit.component";

const routes: Route[] = [
    {
        path: '',
        component: ListComponent,
        pathMatch: 'full',
    },
    {
        path: 'add',
        component: AddComponent,
    },
    {
        path: 'edit/:id',
        component: EditComponent,
    },
    {
        path: '**',
        redirectTo: ''
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }