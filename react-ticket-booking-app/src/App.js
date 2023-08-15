import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/navbar";
import Home from "./pages/home";
import NotFound from "./pages/not-found";
import SigninCallback from './pages/auth/signin-callback'
import SignoutCallback from './pages/auth/signout-callback'
import ConcertList from "./pages/concerts/concert-list";
import ConcertCreate from "./pages/concerts/concert-create";

function App() {

  return (
    <Router>
      <Navbar />

      <Routes>
        <Route path="/" exact element={<Home />}/>
        <Route path="/concerts/concert-list" Component={ConcertList}/>
        <Route path="/concerts/concert-create"  Component={ConcertCreate}/>
        {/* <Route path="/tickets/ticket-list" element={<TicketList />}/> */}
        <Route path="/signin-callback" Component={SigninCallback} />
        <Route path="/signout-callback" Component={SignoutCallback} />
        <Route path="*" Component={NotFound} />
      </Routes>
    </Router>
  );
}

export default App;
