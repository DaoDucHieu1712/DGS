"use client";
import CartItem from "@/components/cart/CartItem";
import { cartSelector } from "@/features/cartSlice";
import { useAppSelector } from "@/redux/hooks";
import AuthServices from "@/services/authService";
import OrderServices from "@/services/orderService";
import { Button, Textarea } from "@material-tailwind/react";
import { getCookie } from "cookies-next";
import { useState } from "react";
import { toast } from "react-toastify";

const Cart = () => {
  const [address, setAddress] = useState<string>("");
  const { cart, totalPrice } = useAppSelector(cartSelector);

  const handleCheckout = async () => {
    var email = getCookie("email")?.toString();
    var user = await AuthServices.findbyEmail(email);

    var NewOrder = await OrderServices.createAndGet({
      userId: user.id,
      customerName: user.displayName,
      totalPrice: totalPrice,
      shipAddress: address,
      status: 0,
    });

    var orderdetails = cart.map((item) => {
      return {
        orderId: NewOrder.id,
        productId: item.productId,
        size: item.size,
        unitPrice: item.price,
        quantity: item.quantity,
      };
    });

    await OrderServices.AddOrderDetail(orderdetails)
      .then((res) => {
        window.location.href = "/";
        toast.success("order successful !!!");
      })
      .catch((error) => {
        console.log("Loi roi anh ban oi");
      });
  };

  return (
    <div className="container mx-auto grid grid-cols-3 gap-x-12">
      <div className="col-span-2">
        <h1 className="font-bold text-2xl mb-3">My Cart</h1>
        <p>You have {cart.length} product with Cart</p>
        {cart.length === 0 ? (
          <p>Your Bag is Empty !!!!!</p>
        ) : (
          <>
            <div className="flex flex-col gap-y-5 cart mt-8 border-1 rounded-md border-gray-400">
              {cart.map((item) => {
                return <CartItem key={item.productId} item={item}></CartItem>;
              })}
            </div>
            <div className="mt-12">
              <Textarea
                label="Ship Adress"
                onChange={(e) => setAddress(e.target.value)}
              />
            </div>
          </>
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
          <Button
            size="md"
            color="red"
            className="w-full"
            disabled={address.length === 0}
            onClick={handleCheckout}
          >
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
