import { Product } from './Product';

export interface Catalog {
  id: number;
  name: string;
  description: string;
  products: Product[] | null;
}
