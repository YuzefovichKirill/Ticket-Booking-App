import React, { useEffect, useState, useRef } from "react";
import { ConcertService } from "../../services/concert-service";

export default function CouponCreate() {
	const [concertId, setConcertId] = useState('')
	var [concerts, setConcerts] = useState([])
	const couponName = useRef(null)
	const discountPercentage = useRef()
	const coupon = {
		concertId: '',
		name: '',
		discountPercentage: 0
	}

	useEffect(() => {
		var concertService = new ConcertService();
		concertService.getConcertList()
			.then(data => setConcerts(data.data.concerts))
			.catch(error => console.log(error.toJSON()));
	}, [])

	const createCoupon = (event) => {
		event.preventDefault()
		coupon.concertId = concertId
		coupon.name = couponName?.current?.value || ''
		coupon.discountPercentage = discountPercentage?.current?.value || 0
		
		console.log(coupon)
		//couponService.
	}

	return (
		<div className="container">
			<p className="title"><strong>Create coupon</strong></p>
			<form onSubmit={createCoupon}>
				<div className="form-row">
					<div className="input-data">
						<label>Concert name</label>
						<select onChange={(e) => setConcertId(e.target.value)} required>
							{concerts?.map(concert => {
								return (
									<option value={concert.Id}>{concert.concertName}</option>
								)
							})
							}
						</select>
				</div>
				</div>
				<div className="form-row">
					<div className="input-data">
						<label>Coupon value</label>
						<input type="text" ref={couponName} required/>
					</div>
				</div>
				<div className="form-row">
					<div className="input-data">
						<label>Discount percentage</label>
						<input type="number" step="any" min={1} ref={discountPercentage} required/>						
					</div>
				</div>

				<div className="submit-button">
          <input type="submit" value="Submit" />
				</div>
			</form>
		
		
		</div>
	)

}