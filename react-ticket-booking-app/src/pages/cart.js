import React, { useContext, useRef } from "react";
import { CartContext } from "../contexts/cart-context";
import "./cart.css"
import PaypalPayment from "../components/paypal-buttons";
import { CouponService } from "../services/coupon-service";

export default function Cart() {
  const { cartItems, appliedCoupons, addToCart, removeFromCart, clearCart, getCartTotal, applyCoupon } = useContext(CartContext)
  const couponService = new CouponService()
  var promocode = useRef(null)

  const handleApplyCoupon = (event) => {
    event.preventDefault()
    var promo = promocode?.current?.value
    if (promo) applyCoupon(promo)
  }

  return (
    <div className="cart-container">
      <div className="cart-left-column">
        <p>Your Cart</p>
        {cartItems.map(item => {
          return (
            <div>{JSON.stringify(item)}</div>
          )
        })}
        <hr/>
        {appliedCoupons.map(coupon => {
          return (
            <div>{JSON.stringify(coupon)}</div>
          )
        })}
      </div>

      <div className="cart-right-column">
        <p style={{visibility: "hidden"}}>hidden</p>
        <div className="payment-block">
          <p>Payment</p>
          <p>Total: {getCartTotal()}</p>
          {/* <PaypalPayment concertId={cartItems[0]?.id} price={getCartTotal()} concertName={cartItems[0]?.concertName}/> */}
        </div>
        <div>
          <form onSubmit={handleApplyCoupon}>
            <input type="text" maxLength="20" placeholder="Enter the promocode" ref={promocode}/>
            <button type="submit">Submit</button>
          </form>
        </div>
      </div>
    </div>
  )
}

