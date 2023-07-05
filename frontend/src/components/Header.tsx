"use client";
import { cartActions, cartSelector } from "@/features/cartSlice";
import { useAppDispatch, useAppSelector } from "@/redux/hooks";
import Image from "next/image";
import Link from "next/link";
import Logo from "public/logo.png";
import { useEffect } from "react";
const Header = () => {
  const { totalQuantity, cart } = useAppSelector(cartSelector);
  const dispatch = useAppDispatch();
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
          <Link href="/shop" className="hover:text-orange-400">
            login
          </Link>
          <Link href="/shop" className="hover:text-orange-400">
            orders
          </Link>
          <Link href="/shop" className="hover:text-orange-400">
            wishlist
          </Link>
          <Link href="/cart" className="hover:text-orange-400">
            bag ({cart.length})
          </Link>
        </div>
      </nav>
    </header>
  );
};

export default Header;
