import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ImoveisComponent } from './imoveis/imoveis.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HeadComponent } from './head/head.component';

@NgModule({
  declarations: [
    AppComponent,
    ImoveisComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent,
    HeadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
