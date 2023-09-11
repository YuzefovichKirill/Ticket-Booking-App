import React, { useEffect, useRef, useState } from "react";
import { getRole } from "../services/auth-service";

export const AuthContext = React.createContext()

const AuthProvider = ({userManager: manager, children}) => {
  let userManager = useRef(manager)

  var [isAuth, setIsAuth] = useState(false)
  var [userRole, setUserRole] = useState(null)

  useEffect(() => {
    const onUserLoaded = (user) => {
        console.log('User loaded: ', user);
        setIsAuth(true)
        setUserRole(getRole(user))
    };
    const onUserUnloaded = () => {
        console.log('User unloaded');
        setIsAuth(false)
        setUserRole(null)
    };
    const onAccessTokenExpiring = () => {
        console.log('User token expiring');
    };
    const onAccessTokenExpired = () => {
        console.log('User token expired');
        setIsAuth(false)
        setUserRole(null)
    };
    const onUserSignedOut = () => {
        console.log('User signed out');
        setIsAuth(false)
        setUserRole(null)
    };

    userManager.current.events.addUserLoaded(onUserLoaded);
    userManager.current.events.addUserUnloaded(onUserUnloaded);
    userManager.current.events.addAccessTokenExpiring(onAccessTokenExpiring);
    userManager.current.events.addAccessTokenExpired(onAccessTokenExpired);
    userManager.current.events.addUserSignedOut(onUserSignedOut);

    return function cleanup() {
        if (userManager && userManager.current) {
            userManager.current.events.removeUserLoaded(onUserLoaded);
            userManager.current.events.removeUserUnloaded(onUserUnloaded);
            userManager.current.events.removeAccessTokenExpiring(onAccessTokenExpiring);
            userManager.current.events.removeAccessTokenExpired(onAccessTokenExpired);
            userManager.current.events.removeUserSignedOut(onUserSignedOut);
        }
    };
  }, [manager]);

  return (
    <AuthContext.Provider 
      value={{
        isAuth,
        userRole}}>
      {children}
    </AuthContext.Provider>
  )
}

export default AuthProvider;
