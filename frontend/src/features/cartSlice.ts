import { RootState } from "@/redux/store";
import { CartItem } from "./../models/Cart";
import { PayloadAction, createSlice } from "@reduxjs/toolkit";

interface CartState {
  cart: CartItem[];
  totalPrice: number;
  totalQuantity: number;
}

const initialState: CartState = {
  cart: [],
  totalPrice: 0,
  totalQuantity: 0,
};

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    addToCart: (state, action: PayloadAction<CartItem>) => {
      let find = state.cart.findIndex(
        (item: CartItem) => item.productId === action.payload.productId
      );
      if (find >= 0) {
        state.cart[find].quantity += 1;
      } else {
        state.cart.push(action.payload);
      }
    },

    getCartTotal: (state) => {
      let { totalQuantity, totalPrice } = state.cart.reduce(
        (cartTotal: any, cartItem: any) => {
          const { price, quantity } = cartItem;
          const itemTotal = price * quantity;
          cartTotal.totalPrice += itemTotal;
          cartTotal.totalQuantity += quantity;
          return cartTotal;
        },
        { totalPrice: 0, totalQuantity: 0 }
      );
      state.totalPrice = parseInt(totalPrice.toFixed(2));
      state.totalQuantity = totalQuantity;
    },

    removeItem: (state, action) => {
      state.cart = state.cart.filter(
        (item) => item.productId !== action.payload
      );
    },

    increaseItemQuantity: (state, action) => {
      state.cart = state.cart.map((item) => {
        if (item.productId === action.payload) {
          return { ...item, quantity: item.quantity + 1 };
        }
        return item;
      });
    },

    decreaseItemQuantity: (state, action) => {
      let isRemove = false;
      state.cart = state.cart.map((item) => {
        if (item.productId === action.payload) {
          if (item.quantity <= 1) {
            isRemove = true;
          }
          return { ...item, quantity: item.quantity - 1 };
        }
        return item;
      });

      if (isRemove) {
        state.cart = state.cart.filter(
          (item) => item.productId !== action.payload
        );
      }
    },
  },
});

export const cartActions = cartSlice.actions;
export const cartSelector = (state: RootState) => state.cart;
export const cartReducer = cartSlice.reducer;
export default cartReducer;
