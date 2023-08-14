import React from "react"
import { NavLink } from "react-router-dom";
import { loginChanged , login, logout, isAuthenticated, getAccessToken } from "../services/auth-service";
import { useState } from "react";

const styles = {
    navBtn: {
        display: 'flex',
        alignItems: 'center',
        marginRight: '24px'
    },
    navBtnLink: {
        borderRadius: '4px',
        background: '#808080',
        padding: '10px 22px',
        color: '#000000',
        outline: 'none',
        border: 'none',
        cursor: 'pointer',
        transition: 'all 0.2s ease-in-out',
        textDecoration: 'none',
        marginLeft: '24px'
    }
}

function onLogin() {
    login();
}

function onLogout() {
    logout();
}

function AuthButtons() {
    
    var [isUserAuthenticated, setUserAuthenticated] = useState(false);
    loginChanged.subscribe(_ => {
    })

    return (
    <>
        {
            isUserAuthenticated ? 
            <nav style={styles.navBtn}>
                <NavLink style={styles.navBtnLink} onClick={() => onLogout()}>Logout</NavLink>
            </nav> :
            <nav style={styles.navBtn}>
                <NavLink style={styles.navBtnLink} onClick={() => onLogin()}>Login</NavLink>
            </nav>
        }
        { isUserAuthenticated.toString() }
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink} onClick={() => onLogout()}>Logout</NavLink>
        </nav>
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink} onClick={() => onLogin()}>Login</NavLink>
        </nav>
    </>
    )
}

export default AuthButtons
