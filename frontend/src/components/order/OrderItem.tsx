import { Product } from "@/models/Product";
import ProductService from "@/services/productService";
import { Button } from "@material-tailwind/react";
import { useEffect, useState } from "react";

interface OrderItemProps {
  item: any;
}

const OrderItem = ({ item }: OrderItemProps) => {
  const [product, setProduct] = useState<Product>();

  useEffect(() => {
    loadProduct();
  }, []);

  const loadProduct = async () => {
    await ProductService.getSingle(item.productId).then((res) => {
      setProduct(res);
    });
  };

  return (
    <div className="w-full cart-item flex justify-between rounded-lg gap-x-3 p-3 border border-gray-200">
      <div className="flex gap-x-3">
        <img src={product?.image} alt="" className="w-[100px] object-cover" />
        <div className="flex flex-col gap-y-1 text-sm">
          <p className="font-bold w-[300px]">{product?.name}</p>
          <p>{item.size}</p>
          <p>{product?.price} $</p>
        </div>
      </div>
      <div className="flex flex-col gap-y-3">
        <p className="text-sm">{product?.price} $</p>
        <div className="flex items-center justify-center gap-x-1">
          <button className="">x</button>
          <span>{item.quantity}</span>
        </div>
      </div>
      <div className="flex items-center justify-center">
        <Button size="sm" color="light-blue">
          detail
        </Button>
      </div>
    </div>
  );
};

export default OrderItem;
