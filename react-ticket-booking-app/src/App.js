import { BrowserRouter as Router, AuthorizeRoute, Routes, Route } from "react-router-dom";

import userManager from "./services/auth-service";
import AuthProvider from "./services/auth-provider";
import SigninCallback from './pages/auth/signin-callback'
import SignoutCallback from './pages/auth/signout-callback'

import Navbar from "./components/navbar";
import Home from "./pages/home";
import NotFound from "./pages/not-found";
import ConcertList from "./pages/concerts/concert-list";
import ConcertCreate from "./pages/concerts/concert-create";
import TicketList from "./pages/tickets/ticket-list";
import ConcertInfo from "./pages/concerts/concert-info";


function App() {

  return (
    <AuthProvider userManager={userManager}>
      <Router>
        <Navbar />

        <Routes>
          <Route path="/" exact element={<Home/>}/>
          <Route path="/concerts/concert-list" element={<ConcertList/>}/>
          <Route path="/concerts/concert-info" element={<ConcertInfo/>}/>
          <Route path="/concerts/concert-create"  element={<ConcertCreate/>}/>
          <Route path="/tickets/ticket-list" element={<TicketList/>}/>
          <Route path="/signin-callback" element={<SigninCallback/>} />
          <Route path="/signout-callback" element={<SignoutCallback/>} />
          <Route path="*" element={<NotFound/>} />
        
          {/* <AuthorizeRoute path="/tickets/ticket-list" element={<TicketList/>}/> */}
        </Routes>
      </Router>    
    </AuthProvider>
  );
}

export default App;
