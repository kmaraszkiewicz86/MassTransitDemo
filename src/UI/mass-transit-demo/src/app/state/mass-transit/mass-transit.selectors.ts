import { createFeatureSelector, createSelector } from '@ngrx/store';
import { MassTransitState } from './mass-transit.reducer';

const selectFileState = createFeatureSelector<MassTransitState>('massTransit');

export const selectAllFiles = createSelector(
  selectFileState,
  state => state.files
);

export const selectUploadResult = createSelector(
  selectFileState,
  state => state.uploadResult
);

export const selectLoadResult = createSelector(
    selectFileState,
    state => state.uploadResult
  );

export const selectLoading = createSelector(
  selectFileState,
  state => state.loading
);

export const selectError = createSelector(
  selectFileState,
  state => state.error
);