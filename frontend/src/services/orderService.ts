import { getCookie } from "cookies-next";
import { Order } from "./../models/Order";
import axiosConfig from "./axiosConfig";

const OrderServices = {
  getAll(): Promise<Order[]> {
    const url = "/Order";
    return axiosConfig.get(url);
  },
  findById(id: string | number): Promise<Order> {
    const url = `/Order/${id}`;
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
      `sortType=${context.queryKey[4]}&` +
      `Status=${context.queryKey[5]}&` +
      `CustomerName=${context.queryKey[6]}`;
    return axiosConfig.get(url);
  },
  getMyOrder(context: any): Promise<any> {
    const email = getCookie("email")?.toString();
    const url =
      "/Order/MyOrder/" +
      `${email}?` +
      `PageIndex=${context.queryKey[1]}&` +
      `StartDate=${context.queryKey[2]}&` +
      `EndDate=${context.queryKey[3]}&` +
      `sortType=${context.queryKey[4]}&` +
      `Status=${context.queryKey[5]}&` +
      `CustomerName=${context.queryKey[6]}`;
    return axiosConfig.get(url);
  },
  getOrderDetail(id: any): Promise<any> {
    const url = `/Order/OrderDetail/${id}`;
    return axiosConfig.get(url);
  },
};

export default OrderServices;
