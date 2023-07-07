"use client";
import { cartActions, cartSelector } from "@/features/cartSlice";
import { useAppDispatch, useAppSelector } from "@/redux/hooks";
import { deleteCookie, getCookie } from "cookies-next";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/navigation";
import Logo from "public/logo.png";
import { useEffect, useState } from "react";

const Header = () => {
  const { cart } = useAppSelector(cartSelector);
  const [email, setEmail] = useState<any>();
  const { push } = useRouter();

  const dispatch = useAppDispatch();
  const emailCurrent = getCookie("email");

  useEffect(() => {
    setEmail(getCookie("email"));
  }, [emailCurrent]);

  useEffect(() => {
    dispatch(cartActions.getCartTotal());
  }, [cart]);

  return (
    <header className="p-7">
      <nav className="grid grid-cols-3 text-lg">
        <div className="flex gap-x-5 font-medium">
          <Link href="/shop" className="hover:text-orange-400">
            shop
          </Link>
          <Link href="/shop" className="hover:text-orange-400">
            new arrivals
          </Link>
          <Link href="/shop" className="hover:text-orange-400">
            bestsellers
          </Link>
          <Link href="/shop" className="hover:text-orange-400">
            sale
          </Link>
        </div>
        <div className="flex items-center justify-center">
          <Link href="/">
            <Image src={Logo} alt="logo"></Image>
          </Link>
        </div>
        <div className="flex items-center justify-end gap-x-5 font-medium">
          {email ? (
            <Link href="/my-profile" className="hover:text-orange-400">
              {email}
            </Link>
          ) : (
            <Link href="/login" className="hover:text-orange-400">
              login
            </Link>
          )}
          <Link href="/myOrder" className="hover:text-orange-400">
            orders
          </Link>
          <Link href="/shop" className="hover:text-orange-400">
            wishlist
          </Link>
          <Link href="/cart" className="hover:text-orange-400">
            bag ({cart.length})
          </Link>
          {email && (
            <button
              className="hover:text-orange-400"
              onClick={() => {
                deleteCookie("token");
                deleteCookie("roles");
                deleteCookie("email");
                window.location.href = "/login";
              }}
            >
              logout
            </button>
          )}
        </div>
      </nav>
    </header>
  );
};

export default Header;
