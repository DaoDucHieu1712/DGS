"use client";
import ProductItiem from "@/components/product/ProductItiem";
import CategoryService from "@/services/categoryService";
import ProductService from "@/services/productService";
import { Button, Input } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import { useState } from "react";

const Shop = () => {
  const [name, setName] = useState<string>("");
  const [toPrice, setToPrice] = useState<string>("");
  const [fromPrice, setFromPrice] = useState<string>("");
  const [categoryId, setCategoryId] = useState<string | undefined>("");
  const [sortType, setSortType] = useState<string | undefined>("");

  const productsQuery = useQuery({
    queryKey: ["products-shop", name, toPrice, fromPrice, categoryId, sortType],
    queryFn: async (context) => {
      return ProductService.searchWithReactQuery(context);
    },
  });

  const categorysQuery = useQuery({
    queryKey: ["categorys-shop"],
    queryFn: async () => {
      return CategoryService.getAll();
    },
  });

  const onReset = () => {
    setName("");
    setToPrice("");
    setFromPrice("");
    setCategoryId("");
    setSortType("");
  };

  return (
    <>
      <div className="flex items-center justify-center gap-x-3">
        <div className="form-group">
          <select
            onChange={(e) => setCategoryId(e.target.value)}
            className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border "
          >
            <option value="">All</option>
            {categorysQuery.data?.map((item) => {
              return (
                <option key={item.id} value={item.id.toString()}>
                  {item.name}
                </option>
              );
            })}
          </select>
        </div>
        <div className="form-group">
          <Input
            color="blue"
            label="To Price"
            type="number"
            min={0}
            onChange={(e) => setToPrice(e.target.value)}
          />
        </div>
        <div className="form-group">
          <Input
            color="blue"
            label="From Price"
            type="number"
            min={0}
            onChange={(e) => setFromPrice(e.target.value)}
          />
        </div>
        <div className="form-group">
          <Input
            color="blue"
            label="Product Name"
            onChange={(e) => setName(e.target.value)}
          />
        </div>
        <div className="form-group">
          <select
            defaultValue={sortType}
            onChange={(e) => setSortType(e.target.value)}
            className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border "
          >
            <option value="name-asc">Name - A to Z</option>
            <option value="name-desc">Name - Z to A</option>
            <option value="price-asc">Price - Low to High</option>
            <option value="price-desc">Price - High to Low</option>
          </select>
        </div>
        <div className="form-group flex gap-x-2">
          <Button type="submit" color="red" onClick={onReset}>
            Reset
          </Button>
        </div>
      </div>
      <div className="my-6 grid grid-cols-5 gap-3">
        {productsQuery.data?.map((item) => {
          return <ProductItiem key={item.id} item={item}></ProductItiem>;
        })}
      </div>
    </>
  );
};

export default Shop;
