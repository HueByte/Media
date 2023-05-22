import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { NewProductRequest } from 'src/api/models';

@Component({
  selector: 'add-product-component',
  templateUrl: 'add-product.component.html',
  styles: [
    `
      :host {
        display: block;
        text-align: center;
        padding: 20px;
      }
    `,
  ],
})
export class AddProductComponent {
  public newProduct = {} as NewProductRequest;
  public isError = false;
  public error = '';

  constructor(
    public dialogRef: MatDialogRef<AddProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CatalogDialogData,
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {}

  async addProduct(): Promise<void> {
    const newProductRequest: NewProductRequest = {
      catalogId: this.data.catalogId,
      name: this.newProduct.name,
      description: this.newProduct.description,
      price: this.newProduct.price,
      code: this.newProduct.code,
    };

    // Make the API request here
    this.http.post(this.baseUrl + 'api/Product', newProductRequest).subscribe(
      (response) => {
        console.log('API response:', response);
        this.dialogRef.close({ reload: true });
      },
      (error: any) => {
        console.error('API error:', error);
        this.isError = true;
        this.error = 'An error occurred. Please try again.';
      }
    );
  }

  onNoClick(): void {
    this.dialogRef.close({ reload: false });
  }
}

export interface CatalogDialogData {
  catalogId: number;
}
