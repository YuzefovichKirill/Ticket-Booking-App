import { useEffect } from "react"
import { login } from "../../services/auth-service"
import { useNavigate } from 'react-router-dom'

function SigninCallback() {
    const navigate = useNavigate()
    useEffect(() => {
        async function signinAsync() {
            await login()
            navigate('/')
        }
        signinAsync()
    }, [navigate])

    window.location.href = "/";
    return (
        <div>Redirecting...</div>
    )
}

export default SigninCallback
