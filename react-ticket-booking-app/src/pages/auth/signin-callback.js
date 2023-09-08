import { useEffect } from "react"
import { finishLogin } from "../../services/auth-service"
import { useNavigate } from 'react-router-dom';

function SigninCallback() {
    const navigate = useNavigate();

    useEffect(() => {
        async function signinAsync() {
            await finishLogin()
        }
        
        signinAsync()
            .then(() => {
                console.log('signin result')
            })
            .catch(() => {
                 console.log('2signin result')
            })

        navigate('../' , { replace: true})
        //navigate('/concerts/concert-list' , { replace: true})
    }, [])

    return (
        <div>Redirecting...</div>
    )
    
}

export default SigninCallback
