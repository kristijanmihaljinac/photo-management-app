import { Injectable } from '@angular/core';
import { ApiService } from 'app/core/service/api.service';
import { AdminPackageOverviewDto } from 'app/shared/models/package/adminPackageOverviewDto.interface';
import { Observable } from 'rxjs';
 

@Injectable()
export class AdminPackageService {
	
	constructor(private apiService: ApiService) { }

	getAll() : Observable<AdminPackageOverviewDto[]> {
        return this.apiService.get<AdminPackageOverviewDto[]>("/packages");
	}
}