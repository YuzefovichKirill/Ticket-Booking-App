import React, { useEffect, useState, useRef } from "react";
import { ConcertService } from "../../services/concert-service";
import { CouponService } from "../../services/coupon-service";

export default function CouponCreate() {
	const couponService = new CouponService()
	var [concerts, setConcerts] = useState([])

	const concertId = useRef(null)
	const couponName = useRef(null)
	const discountPercentage = useRef(null)
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
		coupon.concertId = concertId?.current?.value || ''
		coupon.name = couponName?.current?.value || ''
		coupon.discountPercentage = discountPercentage?.current?.value || 0

		couponService.createCoupon(coupon)
	}

	return (
		<div className="container">
			<p className="title"><strong>Create coupon</strong></p>
			<form onSubmit={createCoupon}>
				<div className="form-row">
					<div className="input-data">
						<label>Concert name</label>
						<select ref={concertId} required>
							{concerts?.map(concert => {
								return (
									<option value={concert.Id}>{concert.concertName}</option>
								)
							})}
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
						<input type="number" step="any" min={1} max={99} ref={discountPercentage} required/>						
					</div>
				</div>

				<div className="submit-button">
          <input type="submit" value="Submit" />
				</div>
			</form>
		
		
		</div>
	)

}