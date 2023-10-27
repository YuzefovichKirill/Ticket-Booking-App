import React, { useContext } from "react";
import AuthButtons from "./auth-buttons.js"
import { NavLink } from "react-router-dom";
import "./navbar.css"
import cart from "../assets/cart.png"
import { CartContext } from "../contexts/cart-context.js";
import { AuthContext } from "../contexts/auth-context.js";
import routes from "../environments/routes.js";

const Navbar = () => {
    const { amount } = useContext(CartContext) 
    const { isAuth, userRole } = useContext(AuthContext)

    return (
    <nav>
        <div className="link-group">
            <NavLink className="nav-link" to={routes.CONCERT_LIST}>
                Concerts
            </NavLink>
            <NavLink className="nav-link" to={routes.TICKET_LIST}>
                Tickets
            </NavLink>
            
            {(userRole === "Admin") &&
            <>
            <NavLink className="nav-link" to={routes.CONCERT_CREATE}>
                Create Concert
            </NavLink>
            <NavLink className="nav-link" to={routes.COUPON_LIST}>
                Coupons
            </NavLink>
            </>}
        </div>
        
        <div className="link-group end">
            <NavLink className="cart-link" to={routes.CART}>
                <img className="cart-img" src={cart}/>
                {isAuth && (amount > 0) && <div className="cart-amount">{amount}</div>}     
            </NavLink>
            <AuthButtons/>
        </div>
    </nav>
    )
}

export default Navbar
