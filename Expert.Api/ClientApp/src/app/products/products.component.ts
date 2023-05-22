import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiResponse } from 'src/api/models';
import { Catalog } from 'src/api/models/Catalog';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  public catalogId: number = 0;
  public data: any = {};
  private httpClient: HttpClient | null = null;
  private baseUrl: string | null = null;

  constructor(
    private route: ActivatedRoute,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      this.catalogId = params['catalogId'];
      this.fetchProducts();
    });
  }

  fetchProducts() {
    this.httpClient
      ?.get(
        this.baseUrl + 'api/Catalog/WithProducts?catalogId=' + this.catalogId
      )
      .subscribe(
        (result) => {
          this.data = (result as ApiResponse<Catalog>).data;
        },
        (error) => console.error(error)
      );
  }
}
