import ProductService from "@/services/productService";
import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
} from "@material-tailwind/react";
import React, { useState } from "react";

interface DeleteModalConfirmProps {
  id: number;
  reload: any;
}

const DeleteModalCofirm = ({ id, reload }: DeleteModalConfirmProps) => {
  const [open, setOpen] = useState(false);

  const handleOpen = () => setOpen(!open);

  const handleDeleteProduct = async () => {
    await ProductService.deleteProduct(id).then((res) => {
      setOpen(false);
      reload();
    });
  };
  return (
    <>
      <Button
        size="sm"
        color="red"
        className="text-white lowercase"
        onClick={handleOpen}
      >
        delete
      </Button>
      <Dialog open={open} handler={handleOpen}>
        <DialogHeader>Remove Product</DialogHeader>
        <DialogBody divider>Do you want to delete ?????</DialogBody>
        <DialogFooter>
          <Button
            variant="text"
            color="red"
            onClick={handleOpen}
            className="mr-1"
          >
            <span>Cancel</span>
          </Button>
          <Button
            variant="gradient"
            color="green"
            onClick={handleDeleteProduct}
          >
            <span>Confirm</span>
          </Button>
        </DialogFooter>
      </Dialog>
    </>
  );
};

export default DeleteModalCofirm;
