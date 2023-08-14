import React from "react";
import AuthButtons from "./auth-buttons.js"
import { NavLink } from "react-router-dom";

const styles = {
    nav: {
        background: '#63D471',
        height: '85px',
        display: 'flex',
        justifyContent: 'space-between',
        padding: '0.2rem calc((100vw - 1000px) / 2)',
        zIndex: '12'
    },
    navLink: {
        color: '#808080',
        display: 'flex',
        alignItems: 'center',
        textDecoration: 'none',
        padding: '0 1rem',
        height: '100%',
        cursor: 'pointer',
        active : {
        color: '#000000',
        }
    },
    navMenu: {
        color: 'blue',
        display: 'flex',
        alignItems: 'center',
        marginRight: '-24px',
    }
}

const Navbar = () => {
    return (
    <nav style={styles.nav}>
        <div style={styles.navMenu}>
            <NavLink style={styles.navLink} to='/'>
                Home page
            </NavLink>
            <NavLink style={styles.navLink} to='concerts/concert-list'>
                Concerts
            </NavLink>
            <NavLink style={styles.navLink} to='tickets/ticket-list'>
                Tickets
            </NavLink>
        </div>
        
        <div style={styles.navMenu}>
            <AuthButtons />
        </div>
    </nav>
    )
}

export default Navbar
