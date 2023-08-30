import { useEffect } from "react"
import { finishLogin, getAccessToken } from "../../services/auth-service"

function SigninCallback() {

    // finishLogin()
    //     .then(() => {
    //         console.log('signin result')  
    //         //window.location.href = '/';
    //     })
    //     .catch(() => {
    //         console.log('2signin result')  
    //         //window.location.href = '/';
    //     })
    useEffect(() => {
        async function signinAsync() {
            await finishLogin()
        }
        
        signinAsync()
            .then(() => {
                console.log('signin result')
                getAccessToken().then((str) => console.log(str))
                
            })
            .catch(() => {
                 console.log('2signin result')
            })

        //window.location.href = '/';
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
