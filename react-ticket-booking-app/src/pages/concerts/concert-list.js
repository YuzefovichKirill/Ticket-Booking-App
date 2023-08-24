import React, { useEffect, useRef, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Link } from "react-router-dom";
import { YMaps, Map, Placemark } from '@pbe/react-yandex-maps';
import "./concert-list.css"

export default function ConcertList() {
    var [concerts, setConcerts] = useState([])

    const concertName = useRef(null)
    const [concertType, setConcertType] = useState('')
    var concertService = new ConcertService();
    useEffect(() => {
        concertService.getConcertList(concertName?.current?.value, concertType)
            .then(data => setConcerts(data.data.concerts))
            .catch(error => console.log(error.toJSON()))
    }, [])

    function getConcertListWithFilters() {
        concertService.getConcertList(concertName?.current?.value, concertType)
        .then(data => setConcerts(data.data.concerts))
        .catch(error => console.log(error.toJSON()));
    }

    function deleteConcert(id) {
        concertService.deleteConcert(id)
        .then(() => setConcerts(concerts.filter(concert => concert.id !== id)))
        .catch((error) => console.log(error.toJSON()));
    }

    const changeType = (value) => {
        setConcertType(value);
    }

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

                {/* {(concerts && concerts.length > 0 ) 
                ?
                <div className="concert-list">
                    <p className="title"><strong>Concerts</strong></p>
                    <table>
                        <thead>
                            <tr>
                                <th>&nbsp;</th>
                                <th>Concert Name</th>
                                <th>Band name</th>
                                <th>Date and Time</th>
                                <th>Concert Type</th>
                                <th>&nbsp;</th>
                            </tr>
                        </thead>
                        <tbody>
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
                        </tbody>
                    </table>
                </div>
                : 
                <div className="title">There is no concerts</div>} */}

                {(concerts && concerts.length > 0 ) 
                ?
                <div className="concert-list">
                    <p className="title"><strong>Concerts</strong></p>
                    {concerts?.map(concert => {
                        return (
                        <div className="concert">
                            <div className="concert-payload">
                                <div className="info">
                                    <div>{concert.concertName}</div>
                                    <div>{concert.bandName}</div>
                                </div>    
                                <div className="info">
                                    <div>{new Date(Date.parse(concert.dateTime)).toLocaleDateString()}</div>
                                    <div>{new Date(Date.parse(concert.dateTime)).getHours() + ':' + new Date(Date.parse(concert.dateTime)).getMinutes()}</div>
                                </div> 
                                <div>{concert.concertType}</div>
                            </div>
                            <div className="buttons">
                                <Link to='/concerts/concert-info' state={{concertId: concert.id}}>Get concert info</Link>
                                <button onClick={() => deleteConcert(concert.id)}>Delete concert</button>
                            </div>
                        </div>
                        )   
                    })}
                </div>
                : 
                <div className="title">There is no concerts</div>}
                
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