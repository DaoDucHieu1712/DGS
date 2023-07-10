"use client";
import { Input } from "@material-tailwind/react";
import React, { useState } from "react";

const OrderPage = () => {
  const [page, setPage] = useState(1);
  const [startDate, setStartDate] = useState<Date>();
  const [endDate, setEndDate] = useState<Date>();
  const [sortType, setSortType] = useState("");
  return (
    <>
      <div className="flex justify-between p-2">
        <div className="">
          <h1 className="text-2xl text-orange-400 font-bold mb-3">
            order list
          </h1>
          <span className="text-sm">See infomation about all orders</span>
        </div>
      </div>
      <div className="mt-5">
        <div className="flex items-center justify-end gap-x-3">
          <div className="form-group"></div>
          <div className="form-group">
            <Input color="blue" label="Start Date" type="date" />
          </div>
          <div className="form-group">
            <Input color="blue" label="End Date" type="date" />
          </div>

          <div className="form-group">
            <select className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border ">
              <option value="createdat-asc">Date - CreateAt Asc</option>
              <option value="createdat-desc">Date - CreateAt Desc</option>
            </select>
          </div>
        </div>
      </div>
    </>
  );
};

export default OrderPage;
