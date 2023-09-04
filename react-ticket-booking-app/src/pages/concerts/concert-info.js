import React, { useEffect, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { TicketService } from "../../services/ticket-service";
import { Button } from "style-components";
import { useLocation } from "react-router-dom";
import PaypalPayment from "../../components/paypal-buttons"

export default function ConcertInfo() {
    var location = useLocation()
    var id = location.state.concertId
    var [concert, setConcert] = useState();
    var concertService = new ConcertService();
    var ticketService = new TicketService();
    
    useEffect(() => {
        if (!id) return;

        concertService.getConcert(id).then(data => {
            setConcert(data.data)
        })
    }, [id])

    function bookTicket() {
        ticketService.createTicket(id)
    }

    function buyTicket() {

    }

    return (
        <>
            <div>
                <div>Concert name: {concert?.concertName}</div>
                <div>Band name: {concert?.bandName}</div>
                <div>Amount of Tickets: {concert?.amountOfTickets}</div>
                <div>Amount of available tickets: {concert?.amountOfAvailableTickets}</div>
                <div>Concert Date: {concert?.dateTime}</div>
                <div>Place: {concert?.place}</div>
                <div>Concert type: {concert?.concertType}</div>
                <div>Ticket price: {concert?.price} $</div>
                {(concert?.concertType === 'ClassicalConcert') &&
                <>
                    <div>Voice type: {concert?.voiceType}</div>
                    <div>Composer: {concert?.composer}</div>
                </>}
                {(concert?.concertType === 'OpenAir') &&
                <>
                    <div>Getting Here: {concert?.gettingHere}</div>
                    <div>Headliner: {concert?.headliner}</div>
                </>}
                {(concert?.concertType === 'Party') &&
                <div>Age limit: {concert?.ageLimit}</div>}
            </div>
            <Button onClick={() => bookTicket()}>Book Ticket</Button>
            {concert &&
            <PaypalPayment price={concert?.price} concertName={concert?.concertName}/>}
        </>
    )
}
