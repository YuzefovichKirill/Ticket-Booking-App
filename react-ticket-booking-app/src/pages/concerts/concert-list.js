import React, { useContext, useEffect, useRef, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import { Link } from "react-router-dom";
import { YMaps, Map, ObjectManager } from '@pbe/react-yandex-maps';
import "./concert-list.css"
import { CartContext } from "../../contexts/cart-context";
import Datetime from "../../components/date-time";
import { AuthContext } from "../../contexts/auth-context";
import routes from "../../environments/routes";

export default function ConcertList() {
    const [concerts, setConcerts] = useState([])
    const concertName = useRef(null)
    const [concertType, setConcertType] = useState('')
    var concertService = new ConcertService();
    const { addToCart } = useContext(CartContext)
    const { userRole } = useContext(AuthContext)
    var [points, setPoints] = useState([])
    useEffect(() => {
        concertService.getConcertList(concertName?.current?.value, concertType)
            .then(data => setConcerts(data.data.concerts))
            .catch((error) => alert('Server is not responding. Try later'))	
    }, [])

    useEffect(() => {
        setPoints(concerts.map((concert, id) => {
            return {
                id: id,
                type: "Feature",
                geometry: {
                    type: "Point",
                    coordinates: [concert.geoLat, concert.geoLng]
                },
                properties: {
                balloonContent: `<div>${concert.concertName}</div>`,
                //iconCaption: concert.concertName,
                clusterCaption: `Метка №${id + 1}`
                }
            };
        }))
    }, [concerts])

    function getConcertListWithFilters() {
        concertService.getConcertList(concertName?.current?.value, concertType)
            .then(data => setConcerts(data.data.concerts))
            .catch((error) => alert(error?.response?.data?.error))	
    }

    function deleteConcert(id) {
        concertService.deleteConcert(id)
        .then(() => {
            concertService.getConcertList(concertName?.current?.value, concertType)
                .then(data => setConcerts(data.data.concerts))
                .catch((error) => alert(alert('Server is not responding. Try later')))	
        })
        .catch((error) => alert(error.response.data.error))	
    }

    const changeType = (value) => {
        setConcertType(value);
    }

    const handleAddToCart = (item) => {
        addToCart(item)
    }

    return (
        <div className="concert-list-page">
            <div className="concert-list-left-column">
                {(concerts && concerts.length > 0 ) 
                ?
                <div className="concert-list">
                    <p className="title">Concerts</p>
                    {concerts?.map(concert => {
                        return (
                        <div className="concert">
                            <div className="concert-payload">
                                <div className="info concert-name">
                                    <div className="concert-name-text-list">{concert.concertName}</div>
                                    <div className="concert-band-text-list">{concert.bandName}</div>
                                </div>    
                                <div className="info date-time">
                                    <Datetime datetime={concert.dateTime}/>
                                </div>
                                <div className="info price">
                                    <div>{concert.price} $</div>
                                </div> 
                                <div className="info concert-type">
                                    <div>{concert.concertType}</div>
                                </div>
                            </div>
                            <div className="buttons">
                                <Link to={routes.CONCERT_INFO} state={{concertId: concert.id}}>Get info</Link>
                                <button onClick={() => handleAddToCart({id: concert.id, concertName: concert.concertName, 
                                                                        dateTime: concert.dateTime, price: concert.price})}>Add to cart</button>
                                {userRole === "Admin" &&<button onClick={() => deleteConcert(concert.id)}>Delete concert</button>}
                            </div>
                        </div>
                        )   
                    })}
                </div>
                : 
                <div className="title">There is no concerts</div>}
            </div>

            <div className="concert-list-right-column">
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
                <p className="title"><strong>Location on map</strong></p>
                <div className="map">
                    <YMaps>
                        <Map defaultState={{ center: [53.8839926266, 27.58253953370], zoom: 3, controls: ["zoomControl", "fullscreenControl"]}}
                                            modules={["control.ZoomControl", "control.FullscreenControl"]} >
                            <ObjectManager
                                objects={{

                                    preset: 'islands#blueDotIconWithCaption',
                                    iconColor: '#0096FF',
                                    controls: [],
                                }}
                                clusters={{}}
                                options={{
                                    clusterize: true,

                                    gridSize: 32,
                                }}
                                features={{ type: 'FeatureCollection', features: points }}
                                modules={[
                                    'objectManager.addon.objectsBalloon',
                                    'objectManager.addon.clustersBalloon',
                                ]}
                                />
                        </Map>
                    </YMaps>
                </div>
            </div>
        </div>
    )
}