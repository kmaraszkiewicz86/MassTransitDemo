import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { MassTransitEffects } from './state/mass-transit/mass-transit.effects';
import { fileReducer as filmassTransitReducer } from './state/mass-transit/mass-transit.reducer';
import { FilesComponent } from './components/files/files.component';
import { GenerateFileComponent } from './components/generate-file/generate-file.component';

@NgModule({
  declarations: [
    AppComponent,
    FilesComponent,
    GenerateFileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    StoreModule.forFeature('massTransit', filmassTransitReducer),
    EffectsModule.forRoot([ MassTransitEffects ]),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
