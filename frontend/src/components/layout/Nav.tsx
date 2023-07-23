"use client";
import { getCookie } from "cookies-next";
import React, { useEffect, useState } from "react";

const Nav = () => {
  const [email, setEmail] = useState<any>();
  useEffect(() => {
    setEmail(getCookie("email"));
  }, []);
  return (
    <div className="flex items-center justify-end bg-white p-2">
      <p className="hover:text-orange-400 font-medium cursor-pointer">
        {email}
      </p>
    </div>
  );
};

export default Nav;
