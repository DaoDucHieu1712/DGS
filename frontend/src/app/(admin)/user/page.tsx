"use client";
import AuthServices from "@/services/authService";
import { Button, IconButton, Typography } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React from "react";

const TABLE_HEAD = ["Id", "Display Name", "Gender", "BirthDay", "Action"];

const UserPage = () => {
  const usersQuery = useQuery({
    queryKey: ["products-list"],
    queryFn: async () => {
      return AuthServices.getUsers();
    },
  });
  return (
    <>
      <div className="flex justify-between p-2">
        <div className="">
          <h1 className="text-2xl text-orange-400 font-bold mb-3">user list</h1>
          <span className="text-sm">See infomation about all users</span>
        </div>
        <div className="">
          <Button
            color="blue"
            size="md"
            className="mr-3 lowercase font-semibold"
          >
            Export Excel
          </Button>
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
            {usersQuery.data?.map((item: any, index: number) => {
              const isLast = index === usersQuery.data?.length - 1;
              const classes = isLast
                ? "p-4 text-sm"
                : "p-4 border-b border-blue-gray-50 text-sm";
              return (
                <tr key={item.id}>
                  <td className={classes}>{item.id}</td>
                  <td className={classes}>{item.displayName}</td>
                  <td className={classes}>{item.gender ? "Male" : "Female"}</td>
                  <td className={classes}>
                    {item.birthDay.toString().slice(0, 10)}
                  </td>
                  <td className={classes}>
                    <div className="flex gap-x-3">
                      <Button size="sm">view</Button>
                    </div>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </>
  );
};

export default UserPage;
