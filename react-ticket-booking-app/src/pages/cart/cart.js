import React, { useContext, useRef } from "react";
import { CartContext } from "../../contexts/cart-context";
import "./cart.css"
import PaypalPayment from "../../components/paypal-buttons";
import Datetime from "../../components/date-time";

export default function Cart() {
  const { cartItems, appliedCoupons, addToCart, removeFromCart, clearCart, getCartTotal, applyCoupon } = useContext(CartContext)
  var promocode = useRef(null)

  const handleApplyCoupon = (event) => {
    event.preventDefault()
    var promo = promocode?.current?.value
    if (promo) {
      applyCoupon(promo)
      promocode.current.value = ''
    }
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
                <Datetime datetime={item.dateTime}/>
                <div className="cart-buttons">
                  <button onClick={() => addToCart(item)}>Add</button>
                  <div>{item.quantity}</div>
                  <button onClick={() => removeFromCart(item)}>Remove</button>
                </div>
                <div className="cart-price">
                  <div style={{textDecoration: (item.totalPrice < item.price) ? 'line-through' : ''}} >{item.price * item.quantity}$</div>
                  {(item.totalPrice < item.price) && <div>{item.totalPrice * item.quantity}$</div>}
                </div>

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
              {getCartTotal() > 0 && <PaypalPayment items={cartItems} coupons={appliedCoupons} price={getCartTotal()} />}
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

