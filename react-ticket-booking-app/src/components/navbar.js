import React, { useContext } from "react";
import AuthButtons from "./auth-buttons.js"
import { NavLink } from "react-router-dom";
import "./navbar.css"
import cart from "../assets/cart.png"
import { CartContext } from "../contexts/cart-context.js";

const Navbar = () => {
    const { amount } = useContext(CartContext) 

    return (
    <nav>
        <div className="link-group">
            <NavLink className="nav-link" to='/'>
                Home page
            </NavLink>
            <NavLink className="nav-link" to='concerts/concert-list'>
                Concerts
            </NavLink>
            <NavLink className="nav-link" to='tickets/ticket-list'>
                Tickets
            </NavLink>
            <NavLink className="nav-link" to='concerts/concert-create'>
                Create Concert
            </NavLink>
            <NavLink className="nav-link" to='coupon/coupon-list'>
                Coupons
            </NavLink>
        </div>
        
        <div className="link-group">
            <NavLink className="cart-link" to='cart'>
                <img className="cart-img" src={cart}/>
                <div className="cart-amount">{amount > 0 ? amount : ''}</div>    
            </NavLink>
            <AuthButtons/>
        </div>
    </nav>
    )
}

export default Navbar
