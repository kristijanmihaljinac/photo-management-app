import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { AuthModule } from 'app/core/auth/auth.module';
import { IconsModule } from 'app/core/icons/icons.module';
import { TranslocoCoreModule } from 'app/core/transloco/transloco.module';
import { ApiPrefixInterceptor } from './service/api-prefix.interceptor';
import { ApiService } from './service/api.service';


@NgModule({
    imports: [
        AuthModule,
        IconsModule,
        TranslocoCoreModule
    ], 
    providers: [
        ApiService,
        { provide: HTTP_INTERCEPTORS, useClass: ApiPrefixInterceptor, multi: true }
    ]
})
export class CoreModule
{
    /**
     * Constructor
     */
    constructor(
        @Optional() @SkipSelf() parentModule?: CoreModule
    )
    {
        // Do not allow multiple injections
        if ( parentModule )
        {
            throw new Error('CoreModule has already been loaded. Import this module in the AppModule only.');
        }
    }
}
