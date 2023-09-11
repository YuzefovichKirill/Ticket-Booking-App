import React from "react"
import { NavLink } from "react-router-dom";
import { loginChanged , login, logout } from "../services/auth-service";
import { useState } from "react";
import "./auth-buttons.css"

function onLogin() {
    login();
}

function onLogout() {
    logout();
}

function AuthButtons() {
    
    var [isUserAuthenticated, setUserAuthenticated] = useState(false);
    loginChanged.subscribe(_isAuthenticated => {
        setUserAuthenticated(_isAuthenticated);
    })

    return (
    <>
        {
            isUserAuthenticated ? 
            <div className="nav-btn">
                <NavLink className="nav-btn-link" onClick={() => onLogout()}>Logout</NavLink>
            </div> :
            <div className="nav-btn">
                <NavLink className="nav-btn-link" onClick={() => onLogin()}>Login</NavLink>
            </div>
        }
    </>
    )
}

export default AuthButtons
