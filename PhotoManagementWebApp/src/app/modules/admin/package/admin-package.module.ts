import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { SharedModule } from 'app/shared/shared.module';
import { AdminPackageOverview } from './overview/admin-package-overview.component';



const packageRoutes: Route[] = [
    {
        path     : '',
        component: AdminPackageOverview
    }
];

@NgModule({
    declarations: [
        AdminPackageOverview
    ],
    imports     : [
        SharedModule,
        RouterModule.forChild(packageRoutes)        
    ]
})
export class AdminPackageModule
{
}
