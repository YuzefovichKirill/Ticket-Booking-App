import React, { useRef, useState } from "react";
import { ConcertService } from "../../services/concert-service";
import "./concert-create.css"

export default function ConcertCreate() {
    const [concertType, setConcertType] = useState('ClassicalConcert')
    const concertName = useRef(null)
    const bandName = useRef(null)
    const amountOfTickets = useRef(null)
    const amountOfAvailableTickets = useRef(null)
    const dateTime = useRef(null)
    const place = useRef(null)
    const geoLng = useRef(null)
    const geoLat = useRef(null)
    const concert = {
        concertName: '',
        bandName: '',
        amountOfTickets: 0,
        amountOfAvailableTickets: 0,
        dateTime: Date.now(),
        place: '',
        geoLng: 0,
        geoLat: 0,
        concertType: ''
    }

    const voiceType = useRef(null)
    const composer = useRef(null)

    const gettingHere = useRef(null)
    const headliner = useRef(null)

    const ageLimit = useRef(null)

    const changeType = (value) => {
        setConcertType(value);
    }
    var concertService = new ConcertService();

    const createConcert = (event) => {
        event.preventDefault();
        concert.concertName = concertName?.current?.value || ''
        concert.bandName = bandName?.current?.value || ''
        concert.amountOfTickets = amountOfTickets?.current?.value || 0
        concert.amountOfAvailableTickets = amountOfAvailableTickets?.current?.value || 0
        concert.dateTime = dateTime?.current?.value || Date.now()
        concert.place = place?.current?.value || ''
        concert.geoLng = geoLng?.current?.value || 0
        concert.geoLat = geoLat?.current?.value || 0
        concert.concertType = concertType

        switch (concert.concertType) {
            case 'ClassicalConcert':
                concert.voiceType = voiceType?.current?.value || ''
                concert.composer = composer?.current?.value || ''
                break;
            case 'OpenAir':
                concert.gettingHere = gettingHere?.current?.value || ''
                concert.headliner = headliner?.current?.value || ''
                break;
            case 'Party':
                concert.ageLimit = ageLimit?.current?.value || 0
                break;
        }
        concertService.createConcert(concert).then((data) => () => {
            console.log(Date.now() + ' ' + data.data)
        })
    } 

    return (
        <div className="container">
            <p className="title"><strong>Create concert</strong></p>
            <form onSubmit={createConcert}>
                <div className="form-row">
					<div className="input-data">
						<label>Concert name</label>
						<input type="text" ref={concertName}/>
					</div>
					<div className="input-data">
						<label>Band name</label>
						<input type="text" ref={bandName}/>						
					</div>
                </div>
				<div className="form-row">
					<div className="input-data">
						<label>Amount of tickets</label>
						<input type="number" ref={amountOfTickets}/>
					</div>
					<div className="input-data">
						<label>Amount of available tickets</label>
						<input type="number" ref={amountOfAvailableTickets}/>
					</div>
                </div>
				<div className="form-row">
					<div className="input-data">
						<label>Geo longitude</label>
						<input type="number" step='any' min={-180} max={180} ref={geoLng}/>
					</div>
					<div className="input-data">
						<label>Geo latitude</label>
						<input type="number" step='any' min={-90} max={90} ref={geoLat}/>
					</div>
                </div>
				<div className="form-row">
					<div className="input-data">
						<label>Date and Time</label>
						<input type="datetime-local" ref={dateTime}/>
					</div>
					<div className="input-data">
						<label>Place</label>
						<input type="text" ref={place}/>
					</div>
                </div>
                <div className="form-row">
					<div className="input-data">
						<label>Concert type</label>
						<select  onChange={(e) => changeType(e.target.value)}>
							<option value='ClassicalConcert'>Classical concert</option>
							<option value='OpenAir'>Open air</option>
							<option value='Party'>Party</option>
						</select>
					</div>
                </div>
                {(concertType === 'ClassicalConcert') &&
				<div className="form-row">
					<div className="input-data">
						<label>Voice type</label>
						<input type="text" ref={voiceType}/>
					</div>
					<div className="input-data">
						<label>Composer</label>
						<input type="text" ref={composer}/>
					</div>
                </div>}
                {(concertType === 'OpenAir') &&
				<div className="form-row">
					<div className="input-data">
						<label>Getting Here</label>
						<input type="text" ref={gettingHere}/>
					</div>
					<div className="input-data">
						<label>Headliner</label>
						<input type="text" ref={headliner}/>
					</div>
				</div>}	
                {(concertType === 'Party') &&
				<div className="form-row">
					<div className="input-data">
						<label>Age limit</label>
						<input type="number" ref={ageLimit}/>
					</div>
				</div>}

				<div className="submit-button">
                	<input type="submit" value="Submit" />
				</div>
            </form>
        </div>
    )
}