import React from "react";
import { PayPalButtons, PayPalScriptProvider } from "@paypal/react-paypal-js";
import { TicketService } from "../services/ticket-service";

export default function PaypalPayment({concertId, concertName, price}) {
  const ticketService = new TicketService()
  let ticketId;

  const createOrder = async (data, actions) => {
    try{
      const response = await ticketService.createTicket(concertId)
      ticketId = response.data
    }
    catch (error) {
      throw new Error(error)
    }

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
  }

  const onApprove = async (data, actions) => {
    await actions.order.capture();
    try {
      await ticketService.ApprovePaidTicket(ticketId) 
    }
    catch (error) {
      throw new Error(error)
    }

    alert("Transaction funds captured");
  }

  const onError = (error) => {
    alert(error);
  }

  const deleteOrder = async (data, actions) => {
    await ticketService.deleteTicket(ticketId)
  }

  return (
    <PayPalScriptProvider options={{ clientId: "AQNSKnFHMKn3x0GvuApehmAWybUdcS1cZ59Kyxtk_I_l0VmUofn_yLQN54cSEdhzUgCJOXsDvIQSLiT8", currency: "USD", }}>
      <PayPalButtons createOrder={createOrder}
        onApprove={onApprove} onError={onError} onCancel={deleteOrder} />
    </PayPalScriptProvider>
  )
}
