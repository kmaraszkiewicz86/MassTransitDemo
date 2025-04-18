import { createAction, props } from '@ngrx/store';
import { FileBody, Result, ResultWithValue, FileFromAzureResponse } from '../../models/mass-transit';

//Upload
export const uploadFile = createAction(
    '[MassTransit] Upload File',
    props<{body : FileBody}>()
)

export const uploadFileSuccess = createAction(
    '[MassTransit] Upload File Success',
    props<{body : Result}>()
)

export const uploadFileFailure = createAction(
    '[MassTransit] Upload File Failure',
    props<{error : any}>()
)

//Load list
export const getFiles = createAction(
    '[MassTransit] Get Files'
)

export const getFilesSuccess = createAction(
    '[MassTransit] Get Files Success',
    props<{body : ResultWithValue<FileFromAzureResponse[]>}>()
)

export const getFilesFailure = createAction(
    '[MassTransit] Get Files Failure',
    props<{error : any}>()
)