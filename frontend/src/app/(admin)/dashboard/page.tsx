import ChartVerticle from "@/components/widgets/ChartVerticle";
import Feature from "@/components/widgets/Feature";
import React from "react";

const Dashboard = () => {
  return (
    <>
      <div className="grid grid-cols-4 gap-x-4">
        <Feature name="Product" total={43}></Feature>
        <Feature name="User" total={43}></Feature>
        <Feature name="Order" total={43}></Feature>
        <Feature name="Total" total={43}></Feature>
      </div>
      <div className="p-5 mt-5">
        <ChartVerticle></ChartVerticle>
      </div>
    </>
  );
};

export default Dashboard;
