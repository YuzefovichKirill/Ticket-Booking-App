import React, { useContext } from "react";
import AuthButtons from "./auth-buttons.js"
import { NavLink } from "react-router-dom";
import "./navbar.css"
import cart from "../assets/cart.png"
import { CartContext } from "../contexts/cart-context.js";
import { AuthContext } from "../contexts/auth-context.js";

const Navbar = () => {
    const { amount } = useContext(CartContext) 
    const { isAuth, userRole } = useContext(AuthContext)

    return (
    <nav>
        <div className="link-group">
            <NavLink className="nav-link" to='concerts/concert-list'>
                Concerts
            </NavLink>
            <NavLink className="nav-link" to='tickets/ticket-list'>
                Tickets
            </NavLink>
            
            {(userRole === "Admin") &&
            <>
            <NavLink className="nav-link" to='concerts/concert-create'>
                Create Concert
            </NavLink>
            <NavLink className="nav-link" to='coupons/coupon-list'>
                Coupons
            </NavLink>
            </>}
        </div>
        
        <div className="link-group end">
            <NavLink className="cart-link" to='cart'>
                <img className="cart-img" src={cart}/>
                {isAuth && (amount > 0) && <div className="cart-amount">{amount}</div>}     
            </NavLink>
            <AuthButtons/>
        </div>
    </nav>
    )
}

export default Navbar
