import React, { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { AuthContext } from "./providers/auth-provider";

const RequireAuth = ({role}) => {
  const {isAuth, userRole} = useContext(AuthContext);

  if (role) {
    return isAuth ?
    (userRole === role  ? <Outlet/> : <Navigate to="/"/>) :
    <Navigate to="/"/>
  }
  else{
    return isAuth ? <Outlet/> : <Navigate to="/"/>
  }
}

export default RequireAuth