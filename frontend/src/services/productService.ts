import { Product } from "@/models/Product";
import axiosConfig from "./axiosConfig";

const ProductService = {
  getAll(): Promise<Product[]> {
    const url = "/Product";
    return axiosConfig.get(url);
  },
  getSingle(id: string): Promise<Product> {
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
    const url =
      "/Product/Search/?" +
      `Name=${data.name}&` +
      `ToPrice=${data.toPrice}&` +
      `FromPrice=${data.fromPrice}&` +
      `CategoryId=${data.categoryId}&` +
      `sortType=${data.sortType}&`;
    return axiosConfig.get(url);
  },
  searchWithReactQuery(context: any): Promise<Product[]> {
    const url =
      "/Product/Search?" +
      `Name=${context.queryKey[1]}&` +
      `ToPrice=${context.queryKey[2]}&` +
      `FromPrice=${context.queryKey[3]}&` +
      `CategoryId=${context.queryKey[4]}&` +
      `sortType=${context.queryKey[5]}&`;
    return axiosConfig.get(url);
  },
};

export default ProductService;
