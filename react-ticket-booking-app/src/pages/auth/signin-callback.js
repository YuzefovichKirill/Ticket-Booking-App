import { useEffect } from "react"
import { finishLogin } from "../../services/auth-service"
import { useNavigate } from 'react-router-dom';
import routes from "../../environments/routes";

function SigninCallback() {
    const navigate = useNavigate();

    useEffect(() => {
        async function signinAsync() {
            await finishLogin()
        }
        
        signinAsync()
            .then(() => {})
            .catch(() => {})
        navigate(routes.CONCERT_LIST , { replace: true})
    }, [])

    return (
        <div>Redirecting...</div>
    )
}

export default SigninCallback
