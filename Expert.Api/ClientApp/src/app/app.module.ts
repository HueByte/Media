import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { AddProductComponent } from './home/components/addProductComponent/add-product.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductsComponent,
    AddProductComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    MatInputModule,
    MatDialogModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent,
        children: [
          { path: 'catalog/:catalogId', component: ProductsComponent },
        ],
      },
    ]),
  ],
  exports: [MatDialogModule],
  entryComponents: [AddProductComponent],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
