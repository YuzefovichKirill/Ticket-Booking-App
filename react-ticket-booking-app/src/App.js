import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import userManager from "./services/auth-service";
import AuthProvider from "./contexts/auth-context";
import SigninCallback from './pages/auth/signin-callback'
import SignoutCallback from './pages/auth/signout-callback'

import Navbar from "./components/navbar";
import NotFound from "./pages/not-found";
import ConcertList from "./pages/concerts/concert-list";
import ConcertCreate from "./pages/concerts/concert-create";
import TicketList from "./pages/tickets/ticket-list";
import ConcertInfo from "./pages/concerts/concert-info";
import CouponCreate from "./pages/coupons/coupon-create";
import CouponList from "./pages/coupons/coupon-list";
import RequireAuth from "./RequireAuth";
import Cart from "./pages/cart/cart";
import CartProvider from "./contexts/cart-context";
import Unauthorized from "./pages/unauthorized";
import Restricted from "./pages/restricted";
import routes from "./environments/routes";


function App() {

  return (
    <CartProvider>
      <AuthProvider userManager={userManager}>
        <Router>
          <Navbar />
          <Routes>
            <Route path={routes.NOT_FOUND} element={<NotFound/>} />
            <Route path={routes.UNAUTHORIZED} element={<Unauthorized/>}/>
            <Route path={routes.RESTRICTED} element={<Restricted/>}/>
            <Route path={routes.SIGNIN_CALLBACK} element={<SigninCallback/>}/>
            <Route path={routes.SIGNOUT_CALLBACK} element={<SignoutCallback/>}/>
            <Route path={routes.CONCERT_LIST} element={<ConcertList/>}/>
            <Route path={routes.CONCERT_INFO} element={<ConcertInfo/>}/>

            <Route  element={<RequireAuth/>}>
              <Route path={routes.TICKET_LIST} element={<TicketList/>}/>
              <Route path={routes.CART} element={<Cart/>}/>
            </Route>     

            <Route  element={<RequireAuth role="Admin"/>}>
              <Route path={routes.CONCERT_CREATE} element={<ConcertCreate/>}/>
              <Route path={routes.COUPON_CREATE} element={<CouponCreate/>}/>
              <Route path={routes.COUPON_LIST} element={<CouponList/>}/>
            </Route>
          </Routes>
        </Router>
      </AuthProvider>
    </CartProvider>
  );
}

export default App;
