import { Product } from "@/models/Product";
import CategoryService from "@/services/categoryService";
import ProductService from "@/services/productService";
import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
  Input,
  Textarea,
} from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";

const schema = yup
  .object({
    name: yup.string().required(),
    image: yup.string().required(),
    description: yup.string().required(),
    price: yup.number().required(),
    categoryId: yup.string().required(),
  })
  .required();
type FormData = yup.InferType<typeof schema>;

interface UpdateProductModalFormProps {
  id: number;
  reload: any;
}

const UpdateProductModalForm = ({
  id,
  reload,
}: UpdateProductModalFormProps) => {
  const [open, setOpen] = useState(false);
  const [errMsg, setErrMsg] = useState("");
  const [product, setProduct] = useState<Product>();
  const handleOpen = () => setOpen(!open);

  const categorysQuery = useQuery({
    queryKey: ["categorys-update-product"],
    queryFn: async () => {
      return CategoryService.getAll();
    },
  });

  const getProduct = async () => {
    ProductService.getSingle(id).then((res) => {
      setProduct(res);
    });
  };

  useEffect(() => {
    getProduct();
  }, []);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = async (data: FormData) => {
    await ProductService.updateProduct(id, data)
      .then((res) => {
        reload();
        setOpen(false);
      })
      .catch((err: Error) => {
        setErrMsg((err as any)?.response?.data);
      });
  };

  return (
    <>
      <Button
        size="sm"
        color="yellow"
        className="text-white lowercase"
        onClick={handleOpen}
      >
        update
      </Button>
      <Dialog open={open} handler={handleOpen} size="md">
        <DialogHeader>update</DialogHeader>
        <form onSubmit={handleSubmit(onSubmitHandler)}>
          <DialogBody divider className="flex flex-col gap-y-6 py-10">
            <p className="text-sm text-red-500 font-medium">{errMsg}</p>
            <Input
              size="md"
              label="Product Name"
              defaultValue={product?.name}
              {...register("name")}
            />
            <Input
              size="md"
              label="Image Url"
              defaultValue={product?.image}
              {...register("image")}
            />
            <Textarea
              label="Description"
              {...register("description")}
              defaultValue={product?.description}
            />
            <Input
              size="md"
              type="number"
              label="Price"
              defaultValue={product?.price}
              {...register("price")}
            />
            <select
              {...register("categoryId")}
              defaultValue={product?.categoryId}
              className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border "
            >
              {categorysQuery.data?.map((item) => {
                return (
                  <option
                    key={item.id}
                    value={item.id.toString()}
                    selected={item.id === product?.categoryId}
                  >
                    {item.name}
                  </option>
                );
              })}
            </select>
          </DialogBody>
          <DialogFooter>
            <Button
              variant="text"
              color="red"
              onClick={handleOpen}
              className="mr-1"
            >
              <span>Cancel</span>
            </Button>
            <Button variant="gradient" color="green" type="submit">
              <span>Confirm</span>
            </Button>
          </DialogFooter>
        </form>
      </Dialog>
    </>
  );
};

export default UpdateProductModalForm;
