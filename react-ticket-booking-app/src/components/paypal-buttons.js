import React from "react";
import { PayPalButtons, PayPalScriptProvider } from "@paypal/react-paypal-js";

export default function PaypalPayment({concertName, price}) {
  
  const createOrder = async (data, actions) => {
    console.log('createOrder') 
    return actions.order.create({
      purchase_units: [
        {
          description: "Concert:" + concertName,
          amount: {
            value: price
          },
        },
      ],
    });
    
    try {
      //const responce = await  
      //return order.id
    }
    catch (error) {
      throw new Error(error)
    }
  }

  const onApprove = async (data, actions) => {
    console.log('onApprove')
    const order = await actions.order.capture();
    console.log(order)
    // const {orderID} = data;
    // const body = JSON.stringify({orderID})
    // let response

    try {
      //responce = await
      // const parsedBody = response ? await response.json() : {}
      // if (parsedBody) {
      // }
    }
    catch (error) {
      throw new Error(error)
    }
  }

  const onError = (error) => console.log(error)

  return (
    <PayPalScriptProvider options={{ clientId: "AQNSKnFHMKn3x0GvuApehmAWybUdcS1cZ59Kyxtk_I_l0VmUofn_yLQN54cSEdhzUgCJOXsDvIQSLiT8", currency: "USD", }}>
      <PayPalButtons createOrder={createOrder}
        onApprove={onApprove} onError={onError} />
    </PayPalScriptProvider>
  )
}
