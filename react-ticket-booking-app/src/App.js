import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/navbar";
import Home from "./pages/home";
import NotFound from "./pages/not-found";
import SigninCallback from './pages/auth/signin-callback'
import SignoutCallback from './pages/auth/signout-callback'
import ConcertList from "./pages/concerts/concert-list";
import ConcertCreate from "./pages/concerts/concert-create";
import TicketList from "./pages/tickets/ticket-list";
import ConcertInfo from "./pages/concerts/concert-info";

function App() {

  return (
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
      </Routes>
    </Router>
  );
}

export default App;
