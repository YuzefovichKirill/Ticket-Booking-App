import { useEffect } from "react"
import { finishLogout } from "../../services/auth-service"
import { useNavigate } from "react-router-dom"
import routes from "../../environments/routes"
function SignoutCallback() {
    const navigate = useNavigate()

    useEffect(() => {
        async function signoutAsync() {
            await finishLogout()
        }
        
        signoutAsync()
            .then(() => {})
            .catch(() => {})
        navigate(routes.CONCERT_LIST , { replace: true})
    }, [])

    return (
        <div>Redirecting...</div>
    )
}

export default SignoutCallback
