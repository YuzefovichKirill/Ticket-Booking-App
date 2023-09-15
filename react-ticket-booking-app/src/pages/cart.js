import React, { useContext, useRef } from "react";
import { CartContext } from "../contexts/cart-context";
import "./cart.css"
import PaypalPayment from "../components/paypal-buttons";

export default function Cart() {
  const { cartItems, appliedCoupons, addToCart, removeFromCart, clearCart, getCartTotal, applyCoupon } = useContext(CartContext)
  var promocode = useRef(null)

  const handleApplyCoupon = (event) => {
    event.preventDefault()
    var promo = promocode?.current?.value
    if (promo) applyCoupon(promo)
  }

  return (
    <>
      <p className="title">Your Cart</p>
      <div className="cart-container">
        <div className="cart-left-column">
          <div className="cart">
          {cartItems.map(item => {
            return (
              <div className="cart-item">
                <div className="concert-name">{item.concertName}</div>
                <div className="date-time">{item.dateTime}</div>
                <div className="cart-buttons">
                  <button onClick={() => addToCart(item)}>Add</button>
                  <div>{item.quantity}</div>
                  <button onClick={() => removeFromCart(item)}>Remove</button>
                </div>
                <div className="cart-price">{item.price * item.quantity}$</div>

              </div>
            );
          })}
          </div>
          <button className="clear-cart-button" onClick={() => clearCart()}>Clear cart</button>
        </div>

        <div className="cart-right-column">
          <div className="payment-block">
            <div><p>Payment</p></div>
            <div><p>Total: {getCartTotal()}$</p></div>
            <div className="paypal-buttons">
              <PaypalPayment items={cartItems} coupons={appliedCoupons} price={getCartTotal()} />
            </div>
          </div>
          <div className="promo-container">
            <form onSubmit={handleApplyCoupon}>
              <input className="promo-input" type="text" maxLength="20" placeholder="Enter the promocode" ref={promocode} />
              <button className="promo-submit" type="submit">Submit</button>
            </form>
          </div>
        </div>
      </div>
    </>
  )
}

