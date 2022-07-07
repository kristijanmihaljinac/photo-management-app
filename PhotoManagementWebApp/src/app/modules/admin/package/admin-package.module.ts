import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { BreadcrumbComponent } from 'app/shared/components/breadcrumb/breadcrumb.component';
import { SharedModule } from 'app/shared/shared.module';
import { AdminPackageOverview } from './overview/admin-package-overview.component';



const packageRoutes: Route[] = [
    {
        path     : '',
        component: AdminPackageOverview, 
        data: {
            breadcrumb: 'Paketići'
          },
    }
];

@NgModule({
    declarations: [
        AdminPackageOverview,
        BreadcrumbComponent
    ],
    imports     : [
        SharedModule,
        RouterModule.forChild(packageRoutes)        
    ]
})
export class AdminPackageModule
{
}
