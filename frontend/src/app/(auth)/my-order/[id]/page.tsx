"use client";
import OrderItem from "@/components/order/OrderItem";
import OrderStatus from "@/components/order/OrderStatus";
import OrderServices from "@/services/orderService";
import { Spinner } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React from "react";
interface ViewOrderDetailProps {
  params: { id: string };
}

const ViewOrderDetail = ({ params }: ViewOrderDetailProps) => {
  const orderQuery = useQuery({
    queryKey: ["order-view"],
    queryFn: async () => {
      return await OrderServices.findById(params.id);
    },
  });

  const orderdetailsQuery = useQuery({
    queryKey: ["orderdetail-list"],
    queryFn: async () => {
      return await OrderServices.getOrderDetail(params.id);
    },
  });

  return (
    <>
      <div className="container mx-auto grid grid-cols-3 gap-x-12">
        <div className="col-span-2">
          <h1 className="font-bold text-2xl mb-3">Order Detail</h1>
          <p>
            You have {orderdetailsQuery.data?.length} product with Order #
            {orderQuery.data?.id}
          </p>
          <>
            <div className="flex flex-col gap-y-5 cart mt-8 border-1 rounded-md border-gray-400">
              {orderdetailsQuery.isLoading ? (
                <Spinner />
              ) : (
                orderdetailsQuery.data?.map((item: any) => {
                  return <OrderItem key={item.id} item={item}></OrderItem>;
                })
              )}
            </div>
          </>
        </div>
        <div className="flex flex-col gap-y-4">
          <h1 className="pb-3 border-b font-bold text-2xl border-gray-200">
            Order : #{orderQuery.data?.id}
          </h1>
          <div className="flex justify-between items-center border-b pb-3 border-gray-200">
            <p className="font-bold text-lg">Customer Name :</p>
            <p className="text-red-500  font-bold text-lg">
              {orderQuery.data?.customerName}
            </p>
          </div>
          <div className="flex justify-between items-center border-b pb-3 border-gray-200">
            <p className="font-bold text-lg">Total Price :</p>
            <p className="text-red-500  font-bold text-lg">
              {orderQuery.data?.totalPrice} $
            </p>
          </div>
          <div className="flex justify-between items-center border-b pb-3 border-gray-200">
            <p className="font-bold text-lg">Created At :</p>
            <p className="text-red-500  font-bold text-lg">
              {orderQuery.data?.createdAt.toString().slice(0, 10)} $
            </p>
          </div>
          <div className="my-3 flex justify-between items-center gap-x-3">
            <p className="font-bold text-lg">Status : </p>
            <OrderStatus status={orderQuery.data?.status}></OrderStatus>
          </div>
          <ul className="info">
            <div className="flex justify-between gap-y-2 flex-col border-b pb-3 border-gray-200">
              <p className="font-bold text-lg">Ship Address :</p>
              <p className="font-medium text-sm">
                {orderQuery.data?.shipAddress}
              </p>
            </div>
          </ul>
          <div className="mt-3 bg-blue-300 p-6 text-white rounded-md">
            <p>
              Lorem ipsum dolor sit amet consectetur adipisicing elit.
              Asperiores id earum corrupti voluptatem tempora fugit itaque
            </p>
          </div>
        </div>
      </div>
    </>
  );
};

export default ViewOrderDetail;
