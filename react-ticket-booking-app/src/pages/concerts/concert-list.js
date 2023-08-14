import React, { useEffect, useState } from "react";
import { ConcertService } from "../../services/concert-service";

export default function ConcertList() {
    var [concerts, setConcerts] = useState()
    var concertService = new ConcertService();
    useEffect(() => {
        concertService.getConcertList().then(data => {
            setConcerts(data.data.concerts)
    })}, [])

    if (!concerts) return <div>There is no concerts</div>

    return (
        <>
            <strong>Concerts</strong>
            <ul>{
                concerts?.map(concert => {
                    return <li>{concert?.id} {concert?.concertName}</li>       
                })
            }</ul>
        </>
    )
}