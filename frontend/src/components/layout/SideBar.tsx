"use client";

import React from "react";
import Logo from "public/logo.png";
import Image from "next/image";
import Link from "next/link";
import { usePathname } from "next/navigation";
import { deleteCookie } from "cookies-next";

const navigation = [
  { href: "/dashboard", name: "dashboard" },
  { href: "/user", name: "user" },
  { href: "/product", name: "product" },
  { href: "/order", name: "order" },
];

const SideBar = () => {
  const pathname = usePathname();
  return (
    <>
      <div className="p-3 flex flex-col gap-y-12 mt-7 h-[100vh] shadow-md w-[300px] fixed bg-white">
        <div className="flex items-center justify-center border-b pb-8 border-gray-300">
          <Link href="/dashboard">
            <Image src={Logo} alt="logo"></Image>
          </Link>
        </div>
        <div className="list flex flex-col justify-center items-center gap-y-10 text-lg font-medium">
          {navigation.map((item) => {
            return (
              <Link
                key={item.href}
                href={item.href}
                className={
                  pathname === item.href
                    ? `text-orange-400`
                    : "hover:text-orange-400"
                }
              >
                {item.name}
              </Link>
            );
          })}
          <button
            className="hover:text-orange-400"
            onClick={() => {
              deleteCookie("email");
              deleteCookie("token");
              deleteCookie("roles");
              window.location.href = "/login";
            }}
          >
            sign out
          </button>
        </div>
      </div>
    </>
  );
};

export default SideBar;
