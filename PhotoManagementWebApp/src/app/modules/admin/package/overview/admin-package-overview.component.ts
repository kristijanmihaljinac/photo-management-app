import { Component } from '@angular/core';
import { AdminPackageOverviewDto } from 'app/shared/models/package/adminPackageOverviewDto.interface';
import { AdminPackageService } from '../admin-package.service';
@Component({
    selector     : 'admin-package-overview',
    templateUrl  : './admin-package-overview.component.html',
    providers: [AdminPackageService]
})
export class AdminPackageOverview
{
    packages: AdminPackageOverviewDto[];

    /**
     * Constructor
     */
    constructor(
        private adminPackageService: AdminPackageService
    )
    {
        this.adminPackageService.getAll().subscribe(data => this.packages = data)
    }



}
