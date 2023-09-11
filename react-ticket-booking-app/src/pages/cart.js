import React, { useContext, useRef } from "react";
import { CartContext } from "../contexts/cart-context";
import "./cart.css"
import PaypalPayment from "../components/paypal-buttons";

export default function Cart() {
  const { cartItems, addToCart, removeFromCart, clearCart, getCartTotal } = useContext(CartContext)

  var promocode = useRef(null)
  const applyPromocode = () => {
    var promo = promocode?.current?.value
    
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
      </div>
      <div className="cart-right-column">
        <p style={{visibility: "hidden"}}>hidden</p>
        <div className="payment-block">
          <p>Total: {getCartTotal()}</p>
          <PaypalPayment concertId={cartItems[0]?.id} price={getCartTotal()} concertName={cartItems[0]?.concertName}/>
        </div>
        <div>
          <form onSubmit={() => {}}>
            <input type="text" maxLength="20" placeholder="Enter the promocode" ref={promocode}/>
            <button type="submit">Submit</button>
          </form>
        </div>

      </div>
    </div>
  )
}

