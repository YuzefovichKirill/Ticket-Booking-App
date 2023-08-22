import React, { useEffect, useRef, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Link } from "react-router-dom";
import { YMaps, Map, Placemark } from '@pbe/react-yandex-maps';

export default function ConcertList() {
    var [concerts, setConcerts] = useState()

    const concertName = useRef(null)
    const [concertType, setConcertType] = useState('')
    var concertService = new ConcertService();
    useEffect(() => {
        concertService.getConcertList(concertName?.current?.value, concertType).then(data => {
            setConcerts(data.data.concerts)
    })}, [])

    function getConcertListWithFilters() {
        concertService.getConcertList(concertName?.current?.value, concertType).then(data => {
            setConcerts(data.data.concerts)
        });
    }

    function deleteConcert(id) {
        concertService.deleteConcert(id).then(() => {
            setConcerts(concerts.filter(concert => concert.id !== id))
        });
    }

    const changeType = (value) => {
        setConcertType(value);
    }

    if (!concerts) return <div>There is no concerts</div>

    return (
        <>
            <div>
                <label>Name of concert</label>
                <input type="text" ref={concertName}/>
                <label >Type of Concert</label>
                <select onChange={(e) => changeType(e.target.value)}>
                    <option value=''/>
                    <option value='ClassicalConcert'>Classical concert</option>
                    <option value='OpenAir'>Open air</option>
                    <option value='Party'>Party</option>
                </select>
                <button onClick={getConcertListWithFilters.bind(null, concertName, concertType)}>Find concerts</button>
            </div>

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