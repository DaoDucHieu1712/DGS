"use client";
import OrderStatus from "@/components/order/OrderStatus";
import OrderServices from "@/services/orderService";
import {
  Button,
  IconButton,
  Input,
  Typography,
} from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { getCookie } from "cookies-next";
import FileSaver from "file-saver";
import Link from "next/link";
import React, { useState } from "react";

const TABLE_HEAD = [
  "Id",
  "Customer",
  "CreateAt",
  "Total Price",
  "Ship Address",
  "Status",
  "Action",
];

const OrderPage = () => {
  const [page, setPage] = useState(1);
  const [startDate, setStartDate] = useState<string>("");
  const [endDate, setEndDate] = useState<string>("");
  const [sortType, setSortType] = useState<string>("");
  const [status, setStatus] = useState<string>("");
  const [customer, setCustomer] = useState<string>("");
  const ordersQuery = useQuery({
    queryKey: [
      "orders-list",
      page,
      startDate,
      endDate,
      sortType,
      status,
      customer,
    ],
    queryFn: async (context) => {
      return OrderServices.Filter(context);
    },
  });

  const handleExportExcel = () => {
    const token = getCookie("token");
    axios
      .get(`https://localhost:7280/api/Order/Export`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
        responseType: "blob",
      })
      .then((res) => {
        FileSaver.saveAs(res.data, "order-list.xlsx");
      });
  };

  return (
    <>
      <div className="flex justify-between p-2">
        <div className="">
          <h1 className="text-2xl text-orange-400 font-bold mb-3">
            order list
          </h1>
          <span className="text-sm">See infomation about all orders</span>
        </div>
        <div className="">
          <Button
            color="blue"
            size="md"
            className="mr-3 lowercase font-semibold"
            onClick={handleExportExcel}
          >
            Export Excel
          </Button>
        </div>
      </div>
      <div className="mt-5">
        <div className="flex items-center justify-end gap-x-3">
          <div className="form-group"></div>
          <div className="form-group">
            <Input
              color="blue"
              label="Customer Name"
              onChange={(e) => setCustomer(e.target.value)}
            />
          </div>
          <div className="form-group">
            <Input
              color="blue"
              label="Start Date"
              type="date"
              onChange={(e) => setStartDate(e.target.value)}
            />
          </div>
          <div className="form-group">
            <Input
              color="blue"
              label="End Date"
              type="date"
              onChange={(e) => setEndDate(e.target.value)}
            />
          </div>

          <div className="form-group">
            <select
              className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border"
              onChange={(e) => setStatus(e.target.value)}
            >
              <option value="">default</option>
              <option value="0">Wait</option>
              <option value="1">Pending</option>
              <option value="2">Reject</option>
              <option value="3">Complete</option>
            </select>
          </div>

          <div className="form-group">
            <select
              className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border"
              onChange={(e) => setSortType(e.target.value)}
            >
              <option value="">default</option>
              <option value="createdat-asc">Date - CreateAt Asc</option>
              <option value="createdat-desc">Date - CreateAt Desc</option>
            </select>
          </div>
        </div>
      </div>
      <div className="mt-12">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head) => (
                <th
                  key={head}
                  className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4"
                >
                  <Typography
                    variant="small"
                    color="blue-gray"
                    className="font-normal leading-none opacity-70"
                  >
                    {head}
                  </Typography>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {ordersQuery.data?.list?.map((item: any, index: number) => {
              const isLast = index === ordersQuery.data?.list?.length - 1;
              const classes = isLast
                ? "p-4 text-sm"
                : "p-4 border-b border-blue-gray-50 text-sm";
              return (
                <tr key={item.id}>
                  <td className={classes}>#{item.id}</td>
                  <td className={classes}>{item.customerName}</td>
                  <td className={classes}>
                    {item.createdAt.toString().slice(0, 10)}
                  </td>
                  <td className={classes}>{item.totalPrice} $</td>
                  <td className={classes}>{item.shipAddress}</td>
                  <td className={classes}>
                    <OrderStatus status={item.status}></OrderStatus>
                  </td>
                  <td className={classes}>
                    <div className="flex gap-x-3">
                      <Link
                        href={`/order/${item.id}`}
                        className="px-6 py-2 bg-light-blue-500 text-white font-medium rounded-lg cursor-pointer"
                      >
                        view
                      </Link>
                    </div>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <div className="flex items-center justify-between border-t border-blue-gray-50 p-4">
          <Button
            variant="outlined"
            color="blue-gray"
            size="sm"
            disabled={page === 1}
            onClick={() => setPage(page - 1)}
          >
            Previous
          </Button>
          <div className="flex items-center gap-2">
            {(() => {
              let rows = [];
              for (let i = 1; i <= ordersQuery.data?.total; i++) {
                rows.push(
                  <IconButton
                    key={i}
                    variant="outlined"
                    color="blue-gray"
                    size="sm"
                    className={page === i ? "bg-blue-gray-500 text-white" : ""}
                    onClick={() => setPage(i)}
                  >
                    {i}
                  </IconButton>
                );
              }
              return rows;
            })()}
          </div>
          <Button
            variant="outlined"
            color="blue-gray"
            size="sm"
            disabled={page >= ordersQuery.data?.total}
            onClick={() => setPage(page + 1)}
          >
            Next
          </Button>
        </div>
      </div>
    </>
  );
};

export default OrderPage;
