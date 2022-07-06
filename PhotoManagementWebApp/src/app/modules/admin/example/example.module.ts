import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { ExampleComponent } from 'app/modules/admin/example/example.component';
import { SharedModule } from 'app/shared/shared.module';



const exampleRoutes: Route[] = [
    {
        path     : 'example45',
        component: ExampleComponent
    }
];

@NgModule({
    declarations: [
        ExampleComponent
    ],
    imports     : [
        SharedModule,
        RouterModule.forChild(exampleRoutes)        
    ]
})
export class ExampleModule
{
}
