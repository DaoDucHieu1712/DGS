import Link from "next/link";
import React from "react";

const OtherInfomation = () => {
  return (
    <>
      <div className="mt-3">
        <h1 className="text-xl font-semibold mb-3">Infomation Orther</h1>
        <div className="mt-6 grid grid-cols-2 gap-4 ">
          <Link href="/change-password">
            <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md ">
              Change Password
            </div>
          </Link>
          <Link href="/my-order">
            <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
              My Order
            </div>
          </Link>
          <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
            Story
          </div>
          <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
            More Infomation
          </div>
          <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
            Address COD
          </div>
          <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
            Blog
          </div>
          <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
            SEO
          </div>
          <div className="px-8 py-3 bg-orange-400 flex items-center justify-center text-white font-semibold cursor-pointer text-sm rounded-md">
            Help me !
          </div>
        </div>
      </div>
    </>
  );
};

export default OtherInfomation;
