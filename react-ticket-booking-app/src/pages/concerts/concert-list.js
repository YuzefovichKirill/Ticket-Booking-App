import React, { useEffect, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Link } from "react-router-dom";
import { YMaps, Map, Placemark } from '@pbe/react-yandex-maps';

export default function ConcertList() {
    var [concerts, setConcerts] = useState()
    var concertService = new ConcertService();
    useEffect(() => {
        concertService.getConcertList().then(data => {
            setConcerts(data.data.concerts)
    })}, [])

    function deleteConcert(id) {
        concertService.deleteConcert(id).then(() => {
            setConcerts(concerts.filter(concert => concert.id !== id))
        });
    }

    if (!concerts) return (
        <>
            <YMaps>
                <Map defaultState={{ center: [53.8839926266, 27.58253953370], zoom: 6 }} height={600} width={1000} />
            </YMaps>
            <div>There is no concerts</div>
        </>
    )
    return (
        <>
            <strong>Concerts</strong>
            <ul>
                {concerts?.map(concert => {
                    return (
                    <li>
                        <Link to='/concerts/concert-info' state={{concertId: concert.id}}>Get concert info</Link>
                        <> {concert.id} {concert.concertName} ... </>
                        <button onClick={() => deleteConcert(concert.id)}>Delete concert</button>
                    </li>
                    )   
                })}
            </ul>
            <div>
                <YMaps>
                    <Map defaultState={{ center: [53.8839926266, 27.58253953370], zoom: 6 }} height={600} width={1000}>
                        {concerts?.map(concert => {
                            return (
                                <Placemark
                                    modules={["geoObject.addon.balloon"]}
                                    defaultGeometry={[concert.geoLng, concert.geoLat]}
                                    properties={{ balloonContentBody: concert.concertName }}
                                />
                            )
                        })}
                    </Map>
                </YMaps>
            </div>
        </>
    )
}