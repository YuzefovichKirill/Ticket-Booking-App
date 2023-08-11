import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar/navbar";
import Home from "./pages/home";
import NotFound from "./pages/not-found";
import SigninCallback from './pages/auth/signin-callback'
import SignoutCallback from './pages/auth/signout-callback'

function App() {

  return (
    <Router>
      <Navbar />

      <Routes>
        <Route path="/" exact element={<Home />}/>
        {/* <Route path="/concerts/concert-list" element={<ConcertList />}/>
        <Route path="/tickets/ticket-list" element={<TicketList />}/> */}
        {/* <Route path="*" element={<NotFound />} /> */}
        <Route path="/signin-callback" Component={SigninCallback} />
        <Route path="/signout-callback" Component={SignoutCallback} />
        <Route path="*" Component={NotFound} />
      </Routes>
    </Router>
  );
}

export default App;
