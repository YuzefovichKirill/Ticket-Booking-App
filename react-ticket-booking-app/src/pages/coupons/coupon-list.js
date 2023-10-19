import React, { useEffect, useState } from "react";
import {CouponService} from "../../services/coupon-service"
import { Link } from "react-router-dom";
import "./coupon-list.css"
import routes from "../../environments/routes";

export default function CouponList() {
  var [coupons, setCoupons] = useState([])

  var couponService = new CouponService()
  useEffect(() => {
    couponService.getCouponList()
      .then(data => setCoupons(data.data.coupons))
      .catch((error) => alert('Server is not responding. Try later'))
  }, []) 

  function deleteCoupon(id) {
    couponService.deleteCoupon(id)
      .then(() => {
        couponService.getCouponList()
        .then(data => setCoupons(data.data.coupons))
        .catch((error) => alert('Server is not responding. Try later'))	
      })
      .catch((error) => alert(error.response.data.error))	
  }


  return (
    <div>
      <p className="title">Coupons</p>
      <Link to={routes.COUPON_CREATE}><div className="coupon-create-link">Create coupon</div></Link>
      <div className="coupon-list">
        {coupons?.map(coupon => {
          return (
            <div className="coupon">
              <div className="concert-name">{coupon.concertName}</div>
              <div className="coupon-name">{coupon.name} </div>
              <div className="discount">{coupon.discountPercentage}%</div>
              <button className="delete-coupon-button" onClick={() => deleteCoupon(coupon.id)}>Delete coupon</button>
            </div>
          )
        })}
      </div>

      <div>
      </div>   
    </div>
  )
}