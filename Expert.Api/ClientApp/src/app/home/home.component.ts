import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

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
export class HomeComponent {
  public data: any = {};

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get(baseUrl + 'api/Catalog').subscribe(
      (result) => {
        this.data = (result as ApiResult).data;
        console.log(this.data);
      },
      (error) => console.error(error)
    );
  }
}

interface ApiResult {
  data: any;
  errors: string[];
  message: string;
}
