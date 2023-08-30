import React, { useEffect, useState } from "react";
import { TicketService } from "../../services/ticket-service";

export default function TicketList() {
    var [tickets, setTickets] = useState();
    var ticketService = new TicketService();
    useEffect(() => {
        ticketService.getTicketList().then(data => {
            setTickets(data.data.tickets);
    })}, [])

    function deleteTicket(id) {
        ticketService.deleteTicket(id).then(() => {
            setTickets(tickets.filter(ticket => ticket.id !== id))
        });
    }

    if (!tickets) return <div>There is no tickets</div>

    return (
        <>
            <strong>Tickets</strong>
            <ul>{
                tickets?.map(ticket => {
                    return (
                        <li>
                            {ticket.id} {ticket.concertName} {ticket.concertTime}
                            <button onClick={() => deleteTicket(ticket.id)}>Delete ticket</button>
                        </li>
                    )
                })
            }</ul>
        </>
    )
} 