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
            .then(() => {
                console.log('signout result')
            })
            .catch(() => {
                console.log('2signout result')
            })

        navigate('../' , { replace: true})
        navigate('/concerts/concert-list' , { replace: true})
    }, [])


    return (
        <div>Redirecting...</div>
    )
}

export default SignoutCallback
