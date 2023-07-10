export interface Order {
  id: number;
  userId: number;
  customerName: string;
  createAt: Date;
  totalPrice: number;
  shipAddress: string;
  status: number;
}
