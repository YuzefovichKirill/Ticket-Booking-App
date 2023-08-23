import React, { useEffect, useRef, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Link } from "react-router-dom";
import { YMaps, Map, Placemark } from '@pbe/react-yandex-maps';
import "./concert-list.css"

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
            <div className="wrapper">
                <div className="concert-search">
                    <label>Name of concert</label>
                    <input type="text" ref={concertName}/>
                    <label >Type of Concert</label>
                    <select className="select-type" onChange={(e) => changeType(e.target.value)}>
                        <option value=''/>
                        <option value='ClassicalConcert'>Classical concert</option>
                        <option value='OpenAir'>Open air</option>
                        <option value='Party'>Party</option>
                    </select>
                    <button onClick={getConcertListWithFilters.bind(null, concertName, concertType)}>Find concerts</button>
                </div>

                <div className="concert-list">
                    <p className="title"><strong>Concerts</strong></p>
                    <table>
                        <tr>
                            <th>&nbsp;</th>
                            <th>Concert Name</th>
                            <th>Band name</th>
                            <th>Date and Time</th>
                            <th>Concert Type</th>
                            <th>&nbsp;</th>
                        </tr>
                        {concerts?.map(concert => {
                            return (
                                <tr className="concert">
                                    <td><Link to='/concerts/concert-info' state={{concertId: concert.id}}>Get concert info</Link></td>
                                    <td>{concert.concertName}</td>
                                    <td>{concert.bandName}</td>
                                    <td>{concert.dateTime}</td>
                                    <td>{concert.concertType}</td>
                                    <td><button onClick={() => deleteConcert(concert.id)}>Delete concert</button></td>
                                </tr>
                            )   
                        })}
                    </table>
                </div>

                {/* <div className="concert-list">
                    <p className="title"><strong>Concerts</strong></p>
                    <ul>
                        {concerts?.map(concert => {
                            return (
                            <li className="concert">
                                <Link to='/concerts/concert-info' state={{concertId: concert.id}}>Get concert info</Link>
                                <> {concert.id} {concert.concertName} ... </>
                                <button onClick={() => deleteConcert(concert.id)}>Delete concert</button>
                            </li>
                            )   
                        })}
                    </ul>
                </div> */}

                <div className="map">
                    <p className="title"><strong>Location on map</strong></p>
                    <YMaps>
                        <Map defaultState={{ center: [53.8839926266, 27.58253953370], zoom: 6 }} >
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
            </div>
        </>
    )
}