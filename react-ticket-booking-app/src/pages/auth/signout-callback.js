import { useEffect } from "react"
import { finishLogout } from "../../services/auth-service"

function SignoutCallback() {
    useEffect(() => {
        async function signoutAsync() {
            await finishLogout()
        }
        
        signoutAsync()
            .then(() => {
                console.log('signout result')
                //window.location.href = '/';
            })
            .catch(() => {
                console.log('2signout result')
            })
        //window.location.href = '/';
    }, [])


    return (
        <div>Redirecting...</div>
    )
}

export default SignoutCallback
