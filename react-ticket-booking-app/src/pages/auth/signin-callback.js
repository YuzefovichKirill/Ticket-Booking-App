import { useEffect } from "react"
import { finishLogin, userManager } from "../../services/auth-service"

function SigninCallback() {
    useEffect(() => {
        async function signinAsync() {
            await finishLogin()
        }

        signinAsync().then(() => {
            userManager.getUser().then((user) => {
                console.log(user)
            })
            window.location.href = '/';
        })
        //window.location.href = '/';
    }, [])

    return (
        <div>Redirecting...</div>
    )
}

export default SigninCallback
