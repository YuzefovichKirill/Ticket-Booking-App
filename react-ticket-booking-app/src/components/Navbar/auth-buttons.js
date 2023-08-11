import React from "react"
import { NavLink } from "react-router-dom";
import { login, logout } from "../../services/auth-service";

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

function onRegister() {
    
}

function AuthButtons() {
    return (
    <>
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink}  onClick={onRegister.bind(null)}>Sign Up</NavLink>
        </nav>
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink} to='/auth/login' onClick={() => onLogin()}>Sign In</NavLink>
        </nav>
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink} to='/auth/logout' onClick={() => onLogout()}>Logout</NavLink>
        </nav>
    </>
    )
}

export default AuthButtons