import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import userManager from "./services/auth-service";
import AuthProvider from "./contexts/auth-context";
import SigninCallback from './pages/auth/signin-callback'
import SignoutCallback from './pages/auth/signout-callback'

import Navbar from "./components/navbar";
import Home from "./pages/home";
import NotFound from "./pages/not-found";
import ConcertList from "./pages/concerts/concert-list";
import ConcertCreate from "./pages/concerts/concert-create";
import TicketList from "./pages/tickets/ticket-list";
import ConcertInfo from "./pages/concerts/concert-info";
import CouponCreate from "./pages/coupons/coupon-create";
import CouponList from "./pages/coupons/coupon-list";
import RequireAuth from "./RequireAuth";
import Cart from "./pages/cart";
import CartProvider from "./contexts/cart-context";


function App() {

  return (
    <CartProvider>
      <AuthProvider userManager={userManager}>
        <Router>
          <Navbar />
          <Routes>
            <Route path="*" element={<NotFound/>} />
            <Route path="/" exact element={<Home/>}/>
            <Route path="/signin-callback" element={<SigninCallback/>}/>
            <Route path="/signout-callback" element={<SignoutCallback/>}/>
            <Route path="/concerts/concert-list" element={<ConcertList/>}/>
            <Route path="/concerts/concert-info" element={<ConcertInfo/>}/>

            <Route  element={<RequireAuth/>}>
              <Route path="/tickets/ticket-list" element={<TicketList/>}/>
              <Route path="/cart" element={<Cart/>}/>
            </Route>     

            <Route  element={<RequireAuth role="Admin"/>}>
              <Route path="/concerts/concert-create" element={<ConcertCreate/>}/>
              <Route path="/coupon/coupon-create" element={<CouponCreate/>}/>
              <Route path="/coupon/coupon-list" element={<CouponList/>}/>
            </Route>
          </Routes>
        </Router>
      </AuthProvider>
    </CartProvider>
  );
}

export default App;
