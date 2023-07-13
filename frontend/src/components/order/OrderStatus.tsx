import React from "react";

interface OrderStatusProps {
  status: number | undefined;
}

let classes = "";
let statusName = "";

const OrderStatus = ({ status }: OrderStatusProps) => {
  if (status === 0) {
    classes = "bg-blue-500";
    statusName = "Wait";
  }
  if (status === 1) {
    classes = "bg-yellow-900";
    statusName = "Pending";
  }
  if (status === 2) {
    classes = "bg-red-500";
    statusName = "Reject";
  }
  if (status === 3) {
    classes = "bg-green-600";
    statusName = "Complete";
  }

  return (
    <span
      className={`font-semibold text-white rounded-lg px-3 py-1 ${classes}`}
    >
      {statusName}
    </span>
  );
};

export default OrderStatus;
