"use client";
import { cartActions } from "@/features/cartSlice";
import { CartItem } from "@/models/Cart";
import { useAppDispatch } from "@/redux/hooks";
import ProductService from "@/services/productService";
import { Button } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import { useState } from "react";

interface ShopDetailProps {
  params: { id: string };
}

const ShopDetail = ({ params }: ShopDetailProps) => {
  const [size, setSize] = useState<string>("");

  const productQuery = useQuery({
    queryKey: ["product"],
    queryFn: async () => {
      return ProductService.getSingle(params.id);
    },
  });

  const dispatch = useAppDispatch();

  const handleAddToCart = () => {
    const CartItem: CartItem = {
      productId: productQuery.data?.id,
      name: productQuery.data?.name,
      img: productQuery.data?.image,
      price: productQuery.data?.price,
      quantity: 1,
      size: size,
    };
    dispatch(cartActions.addToCart(CartItem));
  };

  return (
    <div className="container mx-auto flex gap-x-3">
      <div className="flex items-center justify-center w-full">
        <img
          src={productQuery.data?.image}
          alt="image-ok"
          className="w-[650px] h-[500px] object-cover"
        />
      </div>
      <div className="flex flex-col mt-6 w-full">
        <div className="flex gap-y-4 flex-col border-b-gray-700">
          <h1 className="font-bold uppercase text-4xl">
            {productQuery.data?.name}
          </h1>
          <p className="text-2xl font-medium">{productQuery.data?.price} $</p>
          <div className="size">
            <p className="font-bold">please select size</p>
            <div className="flex gap-x-2 mt-3">
              <button
                className={`focus:bg-black focus:text-white px-4 py-1 border-2 rounded-lg border-black text-black bg-white hover:bg-white`}
                onClick={() => setSize("S")}
              >
                S
              </button>
              <button
                className="focus:bg-black focus:text-white  px-4 py-1 border-2 rounded-lg border-black text-black bg-white hover:bg-white"
                onClick={() => setSize("M")}
              >
                M
              </button>
              <button
                className="focus:bg-black focus:text-white  px-4 py-1 border-2 rounded-lg border-black text-black bg-white hover:bg-white"
                onClick={() => setSize("L")}
              >
                L
              </button>
              <button
                className="focus:bg-black focus:text-white  px-4 py-1 border-2 rounded-lg border-black text-black bg-white hover:bg-white"
                onClick={() => setSize("XL")}
              >
                XL
              </button>
            </div>
          </div>
        </div>
        <div className="flex gap-4 mt-6">
          <Button
            color="teal"
            onClick={handleAddToCart}
            disabled={size.length === 0}
          >
            add to bag
          </Button>
          <Button color="teal">help me !</Button>
        </div>
        <hr className="my-7" />
        <p className="w-full h-full">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus
          facilis vel minima atque consequuntur pariatur hic doloremque velit,
          assumenda reprehenderit culpa soluta tempore corporis porro ducimus
          inventore vitae reiciendis? Blanditiis. Lorem ipsum dolor sit amet,
          consectetur adipisicing elit. Placeat corrupti ipsa quasi harum
          dolorum similique sequi pariatur iusto quis doloribus ipsum
          temporibus, officiis aut ullam fuga? Adipisci laborum necessitatibus
          obcaecati.
        </p>
      </div>
    </div>
  );
};

export default ShopDetail;
