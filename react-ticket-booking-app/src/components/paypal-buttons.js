import React, { useCallback } from "react";
import { PayPalButtons, PayPalScriptProvider } from "@paypal/react-paypal-js";
import { OrderService } from "../services/order-service";

export default function PaypalPayment({items, coupons, price}) {
  const orderService = new OrderService()
 
  let body = {
    tickets: items.map((item) => ({...item, concertId: item.id})),
    coupons: coupons.map((coupon) => ({...coupon, couponId: coupon.id})) 
  };

  const createOrder = useCallback(async (data, actions) => {

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
    try {
      await orderService.createOrder(body)
    }
    catch (error) {
      throw new Error(error)
    }
    alert("Transaction funds captured");
  }

  const onError = (error) => {
    alert(error);
  }

  const deleteOrder = async (data, actions) => {}

  return (
    <PayPalScriptProvider options={{ clientId: "AQNSKnFHMKn3x0GvuApehmAWybUdcS1cZ59Kyxtk_I_l0VmUofn_yLQN54cSEdhzUgCJOXsDvIQSLiT8", currency: "USD", }}>
      <PayPalButtons createOrder={createOrder}
        onApprove={onApprove} onError={onError} onCancel={deleteOrder} forceReRender={[items, coupons, price]}/>
    </PayPalScriptProvider>
  )
}
