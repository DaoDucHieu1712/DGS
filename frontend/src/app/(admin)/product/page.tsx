"use client";
import AddProductForm from "@/components/product/AddProductForm";
import DeleteModalCofirm from "@/components/product/DeleteModalCofirm";
import UpdateProductModalForm from "@/components/product/UpdateProductModalForm";
import CategoryService from "@/services/categoryService";
import ProductService from "@/services/productService";
import {
  Button,
  IconButton,
  Input,
  Typography,
} from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import { useState } from "react";
import * as FileSaver from "file-saver";
import axios from "axios";
import { getCookie } from "cookies-next";

const TABLE_HEAD = ["Id", "Image", "Product", "Price", "Category", "Action"];

const Product = () => {
  const [page, setPage] = useState(1);
  const [name, setName] = useState<string>("");
  const [toPrice, setToPrice] = useState<string>("");
  const [fromPrice, setFromPrice] = useState<string>("");
  const [categoryId, setCategoryId] = useState<string | undefined>("");
  const [sortType, setSortType] = useState<string | undefined>("");

  const productsQuery = useQuery({
    queryKey: [
      "products-list",
      page,
      name,
      toPrice,
      fromPrice,
      categoryId,
      sortType,
    ],
    queryFn: async (context) => {
      return ProductService.filterWithReactQuery(context);
    },
  });

  const categorysQuery = useQuery({
    queryKey: ["categorys-list"],
    queryFn: async () => {
      return CategoryService.getAll();
    },
  });

  const fetchPaging = () => {
    for (let i = 1; i <= productsQuery.data?.total; i++) {
      return (
        <IconButton variant="outlined" color="blue-gray" size="sm">
          {i}
        </IconButton>
      );
    }
  };

  const handleExportExcel = () => {
    const token = getCookie("token");
    axios
      .get(`https://localhost:7280/api/Product/Export`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
        responseType: "blob",
      })
      .then((res) => {
        FileSaver.saveAs(res.data, "product-list.xlsx");
      });
  };

  return (
    <>
      <div className="flex justify-between p-2">
        <div className="">
          <h1 className="text-2xl text-orange-400 font-bold mb-3">
            product list
          </h1>
          <span className="text-sm">See infomation about all products</span>
        </div>
        <div className="">
          <Button
            color="blue"
            size="md"
            className="mr-3 lowercase font-semibold"
            onClick={handleExportExcel}
          >
            Export Excel
          </Button>
          <AddProductForm reload={productsQuery.refetch}></AddProductForm>
        </div>
      </div>
      <div className="mt-5">
        <div className="flex items-center justify-end gap-x-3">
          <div className="form-group">
            <select
              onChange={(e) => {
                setCategoryId(e.target.value);
                setPage(1);
              }}
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
              onChange={(e) => {
                setToPrice(e.target.value);
                setPage(1);
              }}
            />
          </div>
          <div className="form-group">
            <Input
              color="blue"
              label="From Price"
              type="number"
              min={0}
              onChange={(e) => {
                setFromPrice(e.target.value);
                setPage(1);
              }}
            />
          </div>
          <div className="form-group">
            <Input
              color="blue"
              label="Product Name"
              onChange={(e) => {
                setName(e.target.value);
                setPage(1);
              }}
            />
          </div>
          <div className="form-group">
            <select
              defaultValue={sortType}
              onChange={(e) => {
                setSortType(e.target.value);
                setPage(1);
              }}
              className="peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal  px-3 py-2.5 rounded-[7px] border-blue-gray-200 focus:border-blue-500 border "
            >
              <option value="name-asc">Name - A to Z</option>
              <option value="name-desc">Name - Z to A</option>
              <option value="price-asc">Price - Low to High</option>
              <option value="price-desc">Price - High to Low</option>
            </select>
          </div>
        </div>
      </div>
      <div className="mt-12">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head) => (
                <th
                  key={head}
                  className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4"
                >
                  <Typography
                    variant="small"
                    color="blue-gray"
                    className="font-normal leading-none opacity-70"
                  >
                    {head}
                  </Typography>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {productsQuery.data?.products?.map((item: any, index: number) => {
              const isLast = index === productsQuery.data?.products?.length - 1;
              const classes = isLast
                ? "p-4 text-sm"
                : "p-4 border-b border-blue-gray-50 text-sm";
              return (
                <tr key={item.id}>
                  <td className={classes}>{item.id}</td>
                  <td className={classes}>
                    <img
                      src={item.image}
                      alt={item.name}
                      className="w-[50px] h-[50px] object-cover"
                    />
                  </td>
                  <td className={classes}>{item.name}</td>
                  <td className={classes}>{item.price} $</td>
                  <td className={classes}>{item.category.name}</td>
                  <td className={classes}>
                    <div className="flex gap-x-3">
                      <UpdateProductModalForm
                        id={item.id}
                        reload={productsQuery.refetch}
                      ></UpdateProductModalForm>
                      <DeleteModalCofirm
                        id={item.id}
                        reload={productsQuery.refetch}
                      ></DeleteModalCofirm>
                    </div>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <div className="flex items-center justify-between border-t border-blue-gray-50 p-4">
          <Button
            variant="outlined"
            color="blue-gray"
            size="sm"
            disabled={page === 1}
            onClick={() => setPage(page - 1)}
          >
            Previous
          </Button>
          <div className="flex items-center gap-2">
            {(() => {
              let rows = [];
              for (let i = 1; i <= productsQuery.data?.total; i++) {
                rows.push(
                  <IconButton
                    key={i}
                    variant="outlined"
                    color="blue-gray"
                    size="sm"
                    className={page === i ? "bg-blue-gray-500 text-white" : ""}
                    onClick={() => setPage(i)}
                  >
                    {i}
                  </IconButton>
                );
              }
              return rows;
            })()}
          </div>
          <Button
            variant="outlined"
            color="blue-gray"
            size="sm"
            disabled={page >= productsQuery.data?.total}
            onClick={() => setPage(page + 1)}
          >
            Next
          </Button>
        </div>
      </div>
    </>
  );
};

export default Product;
