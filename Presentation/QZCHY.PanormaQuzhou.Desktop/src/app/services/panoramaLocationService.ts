import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { PanoramaLocation } from '../viewModels/panoramaLocation';
import { ConfigService } from "./configService";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class PanoramaLocationService {
  private apiUrl = "";

  constructor(private http: HttpClient,
    private configService: ConfigService) {
    this.apiUrl += configService.getApiUrl() ;
  }

  /** GET heroes from the server */
  // getGeoPanoramaLocations (): Observable<PanoramaLocation[]> {
  //   return this.http.get<PanoramaLocation[]>(this.apiUrl+ "Panolocations/map")
  //   .pipe(
  //     tap(response =>{}),
  //     catchError(this.handleError('getGeoPanoramaLocations', {}))
  //   );
  // }  

  getGeoPanoramaLocations (): Observable<PanoramaLocation[]> {
    return this.http.get<PanoramaLocation[]>(this.apiUrl+ "Panolocations/map")
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<PanoramaLocation[]>('getGeoPanoramaLocations', []))
      );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }  

  /** Log a PropertyService message with the MessageService */
  private log(message: string) {
    //this.logService.add('PropertyService: ' + message);
  }    
}