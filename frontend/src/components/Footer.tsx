import Link from "next/link";
import React from "react";

const Footer = () => {
  return (
    <footer className="p-7 grid grid-cols-3">
      <div className="font-medium flex gap-x-4">
        <Link href="facebook.com">facebook</Link>
        <Link href="instagram.com">instagram</Link>
      </div>
      <div className="flex items-center justify-center">
        <p className="text-center">
          DESIGN BY <span className="font-bold">Hieuddhe151352@fpt.edu.vn</span>
        </p>
      </div>
      <div className="font-medium flex gap-x-4 justify-end">
        <Link href="facebook.com">about us</Link>
        <Link href="instagram.com">store location</Link>
        <Link href="instagram.com">return policy</Link>
      </div>
    </footer>
  );
};

export default Footer;
