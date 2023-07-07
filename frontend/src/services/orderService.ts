import { Order } from "./../models/Order";
import axiosConfig from "./axiosConfig";

const OrderServices = {
  getAll(): Promise<Order[]> {
    const url = "/Order";
    return axiosConfig.get(url);
  },
  createAndGet(data: any): Promise<Order> {
    const url = "/Order/CreateAndGet";
    return axiosConfig.post(url, data);
  },
  AddOrderDetail(data: any): Promise<void> {
    const url = "/Order/OrderDetail";
    return axiosConfig.post(url, data);
  },
  GetMyOrder(id: string): Promise<Order[]> {
    const url = `/Order/GetByUser/${id}`;
    return axiosConfig.get(url);
  },
  Update(id: string, status: string): Promise<void> {
    const url = `/Order/${id}?status=${status}`;
    return axiosConfig.put(url);
  },
};

export default OrderServices;
