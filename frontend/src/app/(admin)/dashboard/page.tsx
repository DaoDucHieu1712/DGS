"use client";
import ChartVerticle from "@/components/widgets/ChartVerticle";
import Feature from "@/components/widgets/Feature";
import DashboardService from "@/services/dashboardService";
import { useQuery } from "@tanstack/react-query";
import React from "react";

const Dashboard = () => {
  const dashboard = useQuery({
    queryKey: ["dashboard-total"],
    queryFn: async () => {
      return DashboardService.getDashboard();
    },
  });

  return (
    <>
      <div className="grid grid-cols-4 gap-x-4">
        <Feature name="Product" total={dashboard.data?.products}></Feature>
        <Feature name="User" total={dashboard.data?.users}></Feature>
        <Feature name="Order" total={dashboard.data?.orders}></Feature>
        <Feature name="Categories" total={dashboard.data?.categories}></Feature>
      </div>
      <div className="p-5 mt-5">
        <ChartVerticle></ChartVerticle>
      </div>
    </>
  );
};

export default Dashboard;
