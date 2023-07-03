"use client";
import ProductItiem from "@/components/product/ProductItiem";
import { Button, Input, Option, Select } from "@material-tailwind/react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { SelectContext } from "@material-tailwind/react/components/Select/SelectContext";

const schema = yup
  .object({
    categoryId: yup.string().required(),
    toPrice: yup.number().positive().integer().required(),
    fromPrice: yup.number().positive().integer().required(),
    name: yup.string().required(),
    sortType: yup.string().required(),
  })
  .required();

type FormData = yup.InferType<typeof schema>;

const Shop = () => {
  const {
    register,
    handleSubmit,
    formState: {
      errors,
      isValid,
      isSubmitted,
      isSubmitting,
      isSubmitSuccessful,
    },
  } = useForm<FormData>({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const onSubmit = (data: FormData) => {
    console.log(data);
  };

  return (
    <>
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="flex items-center justify-center gap-x-3"
      >
        <div className="form-group">
          <select
            {...register("categoryId")}
            placeholder="category"
            className="border py-2 rounded-lg outline-none w-[200px] border-gray-400"
          >
            <option value="1">Clothes</option>
            <option value="2">Pant</option>
            <option value="3">Bag</option>
            <option value="4">Sneaker</option>
          </select>
        </div>
        <div className="form-group">
          <Input
            color="blue"
            label="To Price"
            type="number"
            min={0}
            {...register("toPrice")}
          />
        </div>
        <div className="form-group">
          <Input
            color="blue"
            label="From Price"
            type="number"
            min={0}
            {...register("fromPrice")}
          />
        </div>
        <div className="form-group">
          <Input color="blue" label="Product Name" {...register("name")} />
        </div>
        <div className="form-group">
          <select
            placeholder="sort"
            {...register("sortType")}
            className="border py-2 rounded-lg outline-none border-gray-400 w-[200px]"
          >
            <option>Name - A to Z</option>
            <option>Name - Z to A</option>
            <option>Price - Low to High</option>
            <option>Price - High to Low</option>
          </select>
        </div>
        <div className="form-group flex gap-x-2">
          <Button type="submit" color="red">
            Filter
          </Button>
          <Button color="blue-gray">Reset</Button>
        </div>
      </form>
      <div className="my-6 grid grid-cols-5 gap-x-3">
        <ProductItiem></ProductItiem>
        <ProductItiem></ProductItiem>
        <ProductItiem></ProductItiem>
        <ProductItiem></ProductItiem>
        <ProductItiem></ProductItiem>
      </div>
    </>
  );
};

export default Shop;
