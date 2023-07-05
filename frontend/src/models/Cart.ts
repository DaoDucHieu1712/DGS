export interface CartItem {
  productId: number | undefined;
  name: string | undefined;
  img: string | undefined;
  price: number | undefined;
  size: string;
  quantity: number;
  orderId?: number;
}
