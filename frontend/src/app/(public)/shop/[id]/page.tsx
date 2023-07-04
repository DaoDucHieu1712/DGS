import React from "react";

const ShopDetail = ({ params }: { params: { id: string } }) => {
  return <div>{params.id}</div>;
};

export default ShopDetail;
