import React, { useContext } from "react"
import { NavLink } from "react-router-dom";
import { login, logout } from "../services/auth-service";
import "./auth-buttons.css"
import { AuthContext } from "../contexts/auth-context";

function onLogin() {
    login();
}

function onLogout() {
    logout();
}

function AuthButtons() {
    const {isAuth} = useContext(AuthContext)

    return (
    <>
        {
            isAuth ? 
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
