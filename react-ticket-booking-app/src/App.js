import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar/navbar";
import Home from "./pages/home";
import NotFound from "./pages/not-found";

function App() {
  return (
    <Router>
      <Navbar />

      <Routes>
        <Route path="/" exact element={<Home />}/>
        {/* <Route path="/concerts/concert-list" element={<ConcertList />}/>
        <Route path="/tickets/ticket-list" element={<TicketList />}/> */}
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Router>
  );
}

export default App;
