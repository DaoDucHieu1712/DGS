export interface Order {
  id: number;
  userId: number;
  customerName: string;
  createdAt: Date;
  totalPrice: number;
  shipAddress: string;
  status: number;
}
