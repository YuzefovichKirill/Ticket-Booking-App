import React, { useEffect, useState } from "react";
import {CouponService} from "../../services/coupon-service"
import { Link } from "react-router-dom";


export default function CouponList() {
  var [coupons, setCoupons] = useState([])

  var couponService = new CouponService()
  useEffect(() => {
    couponService.getCouponList()
      .then(data => setCoupons(data.data.coupons))
      .catch(error => console.log(error.toJSON()))
  }, []) 

  function deleteCoupon(id) {
    couponService.deleteCoupon(id)
      .then(() => {
        couponService.getCouponList()
        .then(data => setCoupons(data.data.coupons))
        .catch(error => console.log(error.toJSON()))
      })
      .catch(error => console.log(error.toJSON()))
  }


  return (
    <div>
      <p><strong>Coupons</strong></p>
      <Link to='/coupon/coupon-create'>Create coupon</Link>
      {coupons?.map(coupon => {
        return (
          <div>
            {coupon.id} {coupon.concertId} {coupon.name} {coupon.discountPercentage}
            <button onClick={() => deleteCoupon(coupon.id)}>Delete coupon</button>
          </div>
        )
      })}
      <div>
      </div>   
    </div>
  )
}