import React, { useEffect, useState } from "react";

export const CartContext = React.createContext()

const CartProvider = ({children}) => {
  var items = localStorage.getItem('cartItems')
  const [cartItems, setCartItems] = useState(items ? JSON.parse(items) : [])
  const [amount, setAmount] = useState(cartItems ? cartItems.length : 0)
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
      setCartItems([...cartItems, {...item, quantity: 1}]);
    }

    setAmount(prev => prev + 1)
  }

  const removeFromCart = (item) => {
    const isItemInCart = cartItems.find((cartItem) => cartItem.id === item.id)

    if (isItemInCart.quantity === 1) {
      setCartItems(cartItems.filter((cartItem) => cartItem.id !== item.id))
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
    setAmount(0)
  }

  const getCartTotal = () => {
    return cartItems.reduce((total, item) => total + item.price * item.quantity, 0)
  }

  useEffect(() => {
    localStorage.setItem('cartItems', JSON.stringify(cartItems))
  }, [cartItems])

  return (
    <CartContext.Provider 
      value={{
        cartItems,
        amount,
        addToCart,
        removeFromCart,
        clearCart,
        getCartTotal
      }}>
      {children}
    </CartContext.Provider>
  )
}

export default CartProvider
