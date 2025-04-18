import { createReducer, on } from '@ngrx/store';
import * as MassTransit from './mass-transit.actions';
import { FileFromAzureResponse, Result, ResultWithValue } from '../../models/mass-transit';

export interface MassTransitState {
    files: FileFromAzureResponse[],
    uploadResult?: Result,
    getResult?: ResultWithValue<FileFromAzureResponse[]>,
    loading: boolean,
    error: any
}

export const initialState: MassTransitState = {
    files: [],
    loading: false,
    error: null
}

export const fileReducer = createReducer(
    initialState,

    on(MassTransit.uploadFile, (state: MassTransitState) => ({
        ...state,
        loading: true,
        error: null
    })),
    on(MassTransit.uploadFileSuccess, (state, { body }) => ({
        ...state,
        loading: false,
        uploadResult: body,
      })),
    on(MassTransit.uploadFileFailure, (state, { error }) => ({
        ...state,
        loading: false,
        error: error
    })),

    on(MassTransit.getFiles, (state: MassTransitState) => ({
        ...state,
        loading: true,
        error: null
    })),
    on(MassTransit.getFilesSuccess, (state, { body }) => ({
        ...state,
        loading: false,
        getResult: body,
      })),
    on(MassTransit.getFilesFailure, (state, { error }) => ({
        ...state,
        loading: false,
        error: error
    })),
)