import { CartItem } from "@/models/Cart";
import { useAppDispatch } from "@/redux/hooks";
import { Button } from "@material-tailwind/react";
import React from "react";

interface CartItemProps {
  item: CartItem;
}

const CartItem = ({ item }: CartItemProps) => {
  const dispatch = useAppDispatch();

  return (
    <div className="w-full cart-item flex justify-between rounded-lg gap-x-3 p-3 border border-gray-200">
      <div className="flex gap-x-3">
        <img src={item.img} alt="" className="w-[100px] object-cover" />
        <div className="flex flex-col gap-y-1 text-sm">
          <p className="font-bold w-[300px]">{item.name}</p>
          <p>{item.size}</p>
          <p>{item.price} $</p>
        </div>
      </div>
      <div className="flex flex-col gap-y-3">
        <p className="text-sm">{item.price} $</p>
        <div className="flex items-center justify-center gap-x-2">
          <button className="py-1 px-2 border border-gray-400">-</button>
          <span>{item.quantity}</span>
          <button className="py-1 px-2 border border-gray-400">+</button>
        </div>
      </div>
      <div className="flex items-center justify-center">
        <Button size="sm" color="red">
          Delete
        </Button>
      </div>
    </div>
  );
};

export default CartItem;
