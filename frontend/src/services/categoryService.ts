import { Category } from "@/models/Category";
import axiosConfig from "./axiosConfig";

const CategoryService = {
  getAll(): Promise<Category[]> {
    const url = "/Category";
    return axiosConfig.get(url);
  },
};

export default CategoryService;
