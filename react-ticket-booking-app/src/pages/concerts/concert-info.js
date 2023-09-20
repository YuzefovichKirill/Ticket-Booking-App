import React, { useContext, useEffect, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Button } from "style-components";
import { useLocation } from "react-router-dom";
import { CartContext } from "../../contexts/cart-context";
import "./concert-info.css"
import Datetime from "../../components/date-time";

export default function ConcertInfo() {
    var location = useLocation()
    var id = location.state.concertId
    var [concert, setConcert] = useState()
    var concertService = new ConcertService()
    const {addToCart} = useContext(CartContext)
    useEffect(() => {
        if (!id) return;

        concertService.getConcert(id)
            .then(data => setConcert(data.data))
            .catch((error) => alert(error.response.data.error))	
    }, [id])

    const handleAddToCart = (item) => {
        addToCart(item)
    }

    return (
        <div className="concert-info">
            <div className="primary-container">
                <div className="main-info">
                    <div style={{fontSize: '24px',}}>{concert?.concertName}</div>
                    <div style={{fontSize: '20px'}}>Band: {concert?.bandName}</div>
                    <Datetime datetime={concert?.dateTime}/>
                    <div>Place: {concert?.place}</div>
                    <div>Concert type: {concert?.concertType}</div>
                </div>
                <div>
                    <div>Amount of tickets: {concert?.amountOfTickets}</div>
                    <div>Available tickets: {concert?.amountOfAvailableTickets}</div>
                </div>
            </div>

            <div className="secondary-container">
                <div className="additional-details">
                    <div>Additional details:</div>
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
                <div className="payment-info">
                    <div>Ticket price: {concert?.price} $</div>
                    <Button className="add-to-cart" onClick={() => handleAddToCart({id: concert.id, concertName: concert.concertName, 
                                                    dateTime: concert.dateTime, price: concert.price})}>Add to cart</Button>
                </div>
            </div>
        </div>
    )
}
