import { useEffect } from "react"
import { finishLogin } from "../../services/auth-service"

function SigninCallback() {

    // finishLogin()
    //     .then(() => {
    //         window.location.href = '/';
    //     })
    //     .catch(() => {
    //         window.location.href = '/';
    //     })
    useEffect(() => {
        async function signinAsync() {
            await finishLogin()
        }
        
        signinAsync().then(() => {
            console.log('signin result')
            window.location.href = '/';
        })
    })
        
    //     // signinAsync().then(() => {
    //     //     //window.location.href = '/';
    //     // })
    //     //window.location.href = '/';
    // }, [])

    return (
        <div>Redirecting...</div>
    )
}

export default SigninCallback
