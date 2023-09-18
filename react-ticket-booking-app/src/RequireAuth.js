import React, { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { AuthContext } from "./contexts/auth-context";

const RequireAuth = ({role}) => {
  const {isAuth, userRole} = useContext(AuthContext);

  if (role) {
    return isAuth ?
    (userRole === role  ? <Outlet/> : <Navigate to="/restricted"/>) :
    <Navigate to="/unauthorized"/>
  }
  else {
    return isAuth ? <Outlet/> : <Navigate to="/unauthorized"/>
  }
}

export default RequireAuth