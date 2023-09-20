import React, { useCallback, useContext } from "react";
import { PayPalButtons, PayPalScriptProvider } from "@paypal/react-paypal-js";
import { OrderService } from "../services/order-service";
import { CartContext } from "../contexts/cart-context";

export default function PaypalPayment({items, coupons, price}) {
  const orderService = new OrderService()
  const {clearCart} = useContext(CartContext)
  let body = {
    tickets: items.map((item) => ({...item, concertId: item.id})),
    coupons: coupons.map((coupon) => ({...coupon, couponId: coupon.id}))
  };

  const createOrder = useCallback(async (data, actions) => {
    body = {
      tickets: items.map((item) => ({...item, concertId: item.id})),
      coupons: coupons.map((coupon) => ({...coupon, couponId: coupon.id}))
    };
    var res = await orderService.createPreOrder(body)
                      .then(_ => true)
                      .catch((error) => {
                        alert(error.response.data.error); 
                        return false
                      })
    if (!res) return
    return actions.order.create({
      purchase_units: [{
          description: "Buy cart items",
          amount: {
            value: price,
            currency_code: 'USD'
          }
      }]
    })
  }, [items, coupons, price]);

  const onApprove = async (data, actions) => {
    await actions.order.capture();
    await orderService.createOrder(body)
            .catch((error) => alert(error.response.data.error))
    clearCart()

    alert("Transaction funds captured");
  }

  const onCancel = async (data, actions) => {
    alert('Payment was canceled')
    await orderService.deletePreOrder(body)
            .catch((error) => alert(error.response.data.error))
  }

  const onError = (error) => {
    console.error('error from the onError callback', error);
  }

  return (
    <PayPalScriptProvider options={{ clientId: "AQNSKnFHMKn3x0GvuApehmAWybUdcS1cZ59Kyxtk_I_l0VmUofn_yLQN54cSEdhzUgCJOXsDvIQSLiT8", currency: "USD", }}>
      <PayPalButtons createOrder={createOrder} onApprove={onApprove} onError={onError}
                    onCancel={onCancel} forceReRender={[items, coupons, price]}/>
    </PayPalScriptProvider>
  )
}
