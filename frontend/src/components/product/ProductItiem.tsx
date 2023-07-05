import { CartItem } from "@/models/Cart";
import { Product } from "@/models/Product";
import { useAppDispatch } from "@/redux/hooks";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Typography,
} from "@material-tailwind/react";
import Link from "next/link";

interface ProductItemProps {
  item: Product;
}

const ProductItiem = ({ item }: ProductItemProps) => {
  return (
    <>
      <Card>
        <CardHeader shadow={false} floated={false} className="h-96">
          <img
            src={item.image}
            alt={item.name}
            className="w-full h-full object-cover"
          />
        </CardHeader>
        <CardBody>
          <div className="flex items-center justify-between mb-2">
            <Typography color="blue-gray" className="font-medium">
              {item.name}
            </Typography>
            <Typography color="blue-gray" className="font-medium">
              {item.price} $
            </Typography>
          </div>
          <Typography
            variant="small"
            color="gray"
            className="font-normal opacity-75"
          >
            With plenty of talk and listen time, voice-activated Siri access,
            and an available wireless charging case.
          </Typography>
        </CardBody>
        <CardFooter className="pt-0 flex items-center justify-center gap-x-3">
          <Link
            href={`/shop/${item.id}`}
            className="w-full text-center font-medium bg-blue-gray-900/10 px-6 py-2 rounded-lg text-blue-gray-900 shadow-none hover:shadow-none hover:scale-105 focus:shadow-none focus:scale-105 active:scale-100"
          >
            Detail
          </Link>
        </CardFooter>
      </Card>
    </>
  );
};

export default ProductItiem;
