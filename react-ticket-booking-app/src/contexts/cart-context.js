import React, { useEffect, useState } from "react";
import { CouponService } from "../services/coupon-service";

export const CartContext = React.createContext()

const CartProvider = ({children}) => {
  var items = localStorage.getItem('cartItems')
  const [cartItems, setCartItems] = useState(items ? JSON.parse(items) : [])
  var coupons = localStorage.getItem('appliedCoupons')
  const [appliedCoupons, setAppliedCoupons] = useState(coupons ? JSON.parse(coupons): [])
  const [amount, setAmount] = useState(cartItems ? cartItems.reduce((total, item) => total + item.quantity, 0) : 0)
  const couponService = new CouponService()

  const addToCart = (item) => {
    const isItemInCart = cartItems.find((cartItem) => cartItem.id === item.id)
    
    if (isItemInCart) {
      setCartItems(
        cartItems.map((cartItem) => 
          cartItem.id === item.id
            ? { ...cartItem, quantity: cartItem.quantity + 1}
            : cartItem
        )
      );
    }
    else {
      setCartItems([...cartItems, {...item, quantity: 1, totalPrice: item.price, couponName: ""}]);
    }

    setAmount(prev => prev + 1)
  }

  const removeFromCart = (item) => {
    const isItemInCart = cartItems.find((cartItem) => cartItem.id === item.id)

    if (isItemInCart.quantity === 1) {
      setCartItems(cartItems.filter((cartItem) => cartItem.id !== item.id))
      setAppliedCoupons(appliedCoupons.filter((coupon) => coupon.name !== item.couponName))
    }
    else {
      setCartItems(
        cartItems.map((cartItem) => 
          cartItem.id === item.id
            ? { ...cartItem, quantity: cartItem.quantity - 1}
            : cartItem
        )
      );
    }

    setAmount(prev => prev - 1)
  }

  const clearCart = () => {
    setCartItems([])
    setAppliedCoupons([])
    setAmount(0)
  }

  const getCartTotal = () => {
    return cartItems.reduce((total, item) => total + item.totalPrice * item.quantity, 0)
  }

  const applyCoupon = async (name) => {
    var data = await couponService.getCoupon(name)
    var coupon = data.data
    const isCouponUsed = appliedCoupons.find((coupon) => coupon.name === name)
    if (isCouponUsed) {
      alert("This coupon is already used")
      return
    }
    const isItemInCart = cartItems.find((cartItem) => cartItem.id === coupon.concertId)
    if (!isItemInCart)  {
      alert("Cart has no concert for this coupon")
      return
    }

    const isWithoutCoupon = isItemInCart.couponName === ""
    if (!isWithoutCoupon) {
      alert("Concert already have applied coupon")
      return
    }
    else {
      setCartItems(
        cartItems.map((cartItem) => 
          cartItem.id === coupon.concertId
            ? { ...cartItem, totalPrice: cartItem.price * (1 - coupon.discountPercentage/100), couponName: coupon.name}
            : cartItem
        ) 
      );
      setAppliedCoupons([...appliedCoupons, coupon])
    }
  }

  useEffect(() => {
    localStorage.setItem('cartItems', JSON.stringify(cartItems))
  }, [cartItems])

  useEffect(() => {
    localStorage.setItem('appliedCoupons', JSON.stringify(appliedCoupons))
  }, [appliedCoupons])

  return (
    <CartContext.Provider 
      value={{
        cartItems,
        appliedCoupons,
        amount,
        addToCart,
        removeFromCart,
        clearCart,
        getCartTotal,
        applyCoupon
      }}>
      {children}
    </CartContext.Provider>
  )
}

export default CartProvider
