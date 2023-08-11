import { useEffect } from "react"
import { logout } from "../../services/auth-service"
import { useNavigate } from 'react-router-dom'

function SignoutCallback() {
    const navigate = useNavigate()
    useEffect(() => {
        async function signoutAsync() {
            await logout()
            navigate('/')
        }
        signoutAsync()
    }, [navigate])

    window.location.href = "/";
    return (
        <div>Redirecting...</div>
    )
}

export default SignoutCallback
