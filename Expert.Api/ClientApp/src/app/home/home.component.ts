import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import {
  ActivatedRoute,
  NavigationStart,
  ParamMap,
  Router,
  RouterEvent,
} from '@angular/router';
import { AddProductComponent } from './components/addProductComponent/add-product.component';
import { MatDialog } from '@angular/material/dialog';
import { filter, take } from 'rxjs';
import { eventNames } from 'process';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  styles: [
    `
      :host {
        width: 100%;
      }
    `,
  ],
})
export class HomeComponent implements OnInit {
  public data: any = {};
  public currentCatalogId: number = 0;
  public displayActions: boolean = true;

  constructor(
    public dialog: MatDialog,
    private router: Router,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    http.get(baseUrl + 'api/Catalog').subscribe(
      (result) => {
        this.data = (result as ApiResult).data;
      },
      (error) => console.error(error)
    );
  }

  ngOnInit() {
    this.currentCatalogId = Number.parseFloat(
      this.router.url.split('/').at(-1) ?? ''
    );

    this.router.events.pipe().subscribe((event) => {
      this.currentCatalogId = Number.parseFloat(
        this.router.url.split('/').at(-1) ?? ''
      );
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddProductComponent, {
      data: { catalogId: this.currentCatalogId },
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      console.log(result);
      if (result?.reload) this.reloadCurrentRoute();
    });
  }

  reloadCurrentRoute() {
    const currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
}

interface ApiResult {
  data: any;
  errors: string[];
  message: string;
}
