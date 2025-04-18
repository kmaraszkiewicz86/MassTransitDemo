import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { MassTransitHttpClientService } from "../../services/mass-transit-http-client.service";
import * as MassTransitActions from './mass-transit.actions';
import { catchError, map, mergeMap, of } from "rxjs";

@Injectable()
export class MassTransitEffects {

    constructor(
        private action$: Actions,
        private http: MassTransitHttpClientService
    ) { }

    uploadFile$ = createEffect(() => 
        this.action$.pipe(
            ofType(MassTransitActions.uploadFile),
            mergeMap(({ body }) => 
                this.http.uploadFileToAzure(body).pipe(
                    map(result => MassTransitActions.uploadFileSuccess({ body: result })),
                    catchError(error => 
                        of(MassTransitActions.uploadFileFailure({ error: error }))
                    )
                ))
        )
    )


    getFiles$ = createEffect(() => 
        this.action$.pipe(
            ofType(MassTransitActions.getFiles),
            mergeMap(() => 
                this.http.getFiles().pipe(
                    map(result => MassTransitActions.getFilesSuccess({ body: result })),
                    catchError(error => 
                        of(MassTransitActions.getFilesFailure({ error: error }))
                    )
                ))
        )
    )
}