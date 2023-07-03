import { Product } from "@/models/Product";
import axiosConfig from "./axiosConfig";

const ProductService = {
  getAll(): Promise<Product[]> {
    const url = "/Product";
    return axiosConfig.get(url);
  },
  getSingle(id: number): Promise<Product> {
    const url = `/Product/${id}`;
    return axiosConfig.get(url);
  },
  addProduct(data: any): Promise<void> {
    const url = "/Product";
    return axiosConfig.post(url, data);
  },
  updateProduct(id: number, data: any): Promise<void> {
    const url = `/Product/${id}`;
    return axiosConfig.put(url, data);
  },
  deleteProduct(id: number) {
    const url = `/Product/${id}`;
    return axiosConfig.delete(url);
  },
  filter(data: any): Promise<Product[]> {
    const url = "/Product/Filter";
    return axiosConfig.post(url, data);
  },
  search(data: any): Promise<Product[]> {
    const url = "/Product/Search";
    return axiosConfig.post(url, data);
  },
};

export default ProductService;
