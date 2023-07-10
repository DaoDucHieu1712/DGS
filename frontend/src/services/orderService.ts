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
  Update(id: string, status: string): Promise<void> {
    const url = `/Order/${id}?status=${status}`;
    return axiosConfig.put(url);
  },
  Filter(context: any): Promise<any> {
    const url =
      `/Order/Filter?` +
      `PageIndex=${context.queryKey[1]}&` +
      `StartDate=${context.queryKey[2]}&` +
      `EndDate=${context.queryKey[3]}&` +
      `sortType=${context.queryKey[4]}&`;
    return axiosConfig.get(url);
  },
  getMyOrder(context: any): Promise<any> {
    const url =
      "/Order/MyOrder/" +
      `${context.queryKey[1]}?` +
      `PageIndex=${context.queryKey[2]}` +
      `StartDate=${context.queryKey[3]}` +
      `EndDate=${context.queryKey[4]}` +
      `sortType=${context.queryKey[5]}`;
    return axiosConfig.get(url);
  },
};

export default OrderServices;
