import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable()
export class ApiPrefixInterceptor implements HttpInterceptor {

  constructor(){}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!/^(http|https):/i.test(request.url)) {
      if(request.url.includes('api')){
        request = request.clone({ url: 'https://localhost:7004' + request.url });
      }
    }
    return next.handle(request);
  }
}