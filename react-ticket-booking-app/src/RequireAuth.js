import React, { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { AuthContext } from "./contexts/auth-context";
import routes from "./environments/routes";

const RequireAuth = ({role}) => {
  const {isAuth, userRole} = useContext(AuthContext);

  if (role) {
    return isAuth ?
    (userRole === role  ? <Outlet/> : <Navigate to={routes.RESTRICTED}/>) :
    <Navigate to={routes.UNAUTHORIZED}/>
  }
  else {
    return isAuth ? <Outlet/> : <Navigate to={routes.UNAUTHORIZED}/>
  }
}

export default RequireAuth