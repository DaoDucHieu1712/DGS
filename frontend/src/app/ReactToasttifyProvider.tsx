"use client";
import React from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const ReactToasttifyProvider = ({
  children,
}: {
  children: React.ReactNode;
}) => {
  return (
    <div>
      {children}
      <ToastContainer></ToastContainer>
    </div>
  );
};

export default ReactToasttifyProvider;
