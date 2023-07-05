"use client";
import CartItem from "@/components/cart/CartItem";
import { cartSelector } from "@/features/cartSlice";
import { useAppSelector } from "@/redux/hooks";
import { Button } from "@material-tailwind/react";

const Cart = () => {
  const { cart, totalPrice, totalQuantity } = useAppSelector(cartSelector);

  return (
    <div className="container mx-auto grid grid-cols-3 gap-x-12">
      <div className="col-span-2">
        <h1 className="font-bold text-2xl mb-3">My Cart</h1>
        <p>You have {cart.length} product with Cart</p>
        {cart.length === 0 ? (
          <p>Your Bag is Empty !!!!!</p>
        ) : (
          <div className="flex flex-col gap-y-5 cart mt-8 border-1 rounded-md border-gray-400">
            {cart.map((item) => {
              return <CartItem key={item.productId} item={item}></CartItem>;
            })}
          </div>
        )}
      </div>
      <div className="flex flex-col gap-y-4">
        <h1 className="pb-3 border-b font-bold text-2xl border-gray-200">
          Infomation Order
        </h1>
        <div className="flex justify-between items-center border-b pb-3 border-gray-200">
          <p className="font-bold text-lg">Total Price :</p>
          <p className="text-red-500  font-bold text-lg">{totalPrice} $</p>
        </div>
        <ul className="info">
          <li>
            Lorem ipsum dolor sit amet. Qui sapiente at, ipsum fuga nobis eaque!
            Consequatur, autem!
          </li>
          <li>
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sequi ea
            culpa sint, fugiat dolor necessitatibus
          </li>
        </ul>
        <div className="mt-3">
          <Button size="md" color="red" className="w-full">
            Checkout
          </Button>
        </div>
        <div className="mt-3 bg-blue-300 p-6 text-white rounded-md">
          <p>
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Asperiores
            id earum corrupti voluptatem tempora fugit itaque
          </p>
        </div>
      </div>
    </div>
  );
};

export default Cart;
