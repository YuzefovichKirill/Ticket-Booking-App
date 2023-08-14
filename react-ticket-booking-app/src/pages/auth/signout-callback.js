import { useEffect } from "react"
import { finishLogout } from "../../services/auth-service"

function SignoutCallback() {
    useEffect(() => {
        async function signoutAsync() {
            await finishLogout()
        }
        signoutAsync()
        window.location.href = '/';
    }, [])


    return (
        <div>Redirecting...</div>
    )
}

export default SignoutCallback
