import { useEffect } from "react"
import { finishLogout } from "../../services/auth-service"
import { useNavigate } from "react-router-dom"

function SignoutCallback() {
    const navigate = useNavigate()

    useEffect(() => {
        async function signoutAsync() {
            await finishLogout()
        }
        
        signoutAsync()
            .then(() => {})
            .catch(() => {})
        navigate('/concerts/concert-list' , { replace: true})
    }, [])


    return (
        <div>Redirecting...</div>
    )
}

export default SignoutCallback
