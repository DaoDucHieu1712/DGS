export interface Order {
  id: number;
  userId: number;
  createAt: Date;
  totalPrice: number;
  shipAddress: string;
  status: number;
}
