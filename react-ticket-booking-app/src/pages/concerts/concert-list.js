import React, { useEffect, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Link } from "react-router-dom";

export default function ConcertList() {
    var [concerts, setConcerts] = useState()
    var concertService = new ConcertService();
    useEffect(() => {
        concertService.getConcertList().then(data => {
            setConcerts(data.data.concerts)
    })}, [])

    function deleteConcert(id) {
        concertService.deleteConcert(id);
    }

    if (!concerts) return <div>There is no concerts</div>

    return (
        <>
            <strong>Concerts</strong>
            <ul>{
                concerts?.map(concert => {
                    return (
                    <li>
                        <Link to='/concerts/concert-info' state={{concertId: concert.id}}>Get concert info</Link>
                        <> {concert.id} {concert.concertName} ... </>
                        <button onClick={() => deleteConcert(concert.id)}>Delete concert</button>
                    </li>
                    )   
                })
            }</ul>
        </>
    )
}