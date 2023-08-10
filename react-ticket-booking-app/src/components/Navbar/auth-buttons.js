import React from "react"
import { NavLink } from "react-router-dom";

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

function AuthButtons() {
    return (
    <>
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink} to='/sign-up'>Sign Up</NavLink>
        </nav>
        <nav style={styles.navBtn}>
            <NavLink style={styles.navBtnLink} to='/sign-in'>Sign In</NavLink>
        </nav>
    </>
    )
}

export default AuthButtons