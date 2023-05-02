import { NgModule } from "@angular/core";
import { RouterModule, Route } from "@angular/router";
import { ListComponent } from "./employee/pages/list/list.component";

const routes: Route[] = [
    {
        path: '',
        component: ListComponent,
        pathMatch: 'full',
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