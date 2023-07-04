import { Category } from "./Category";

export interface Product {
  id: number;
  name: string;
  image: string;
  description: string;
  price: number;
  categoryId: number;
  isActive: boolean;
  category: Category;
}
