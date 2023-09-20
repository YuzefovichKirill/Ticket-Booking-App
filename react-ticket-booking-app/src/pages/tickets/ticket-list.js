import React, { useEffect, useState } from "react";
import { TicketService } from "../../services/ticket-service";
import "./ticket-list.css"
import Datetime from "../../components/date-time";

export default function TicketList() {
    var [tickets, setTickets] = useState();
    var ticketService = new TicketService();
    useEffect(() => {
        ticketService.getTicketList()
            .then(data => setTickets(data.data.tickets))
            .catch(error => alert('Server is not responding. Try later'))
    }, [])

    if (!tickets) return <div>There is no tickets</div>

    return (
        <>
            <p className="title">Your tickets</p>
            <div className="tickets-list">
                {tickets?.map(ticket => {
                    return (
                        <div className="ticket">
                            <div className="concert-name">{ticket.concertName}</div>
                            <Datetime datetime={ticket.concertTime}/>
                        </div>
                    )
                })}
            </div>
        </>
    )
} 