import logo from "./logo.svg";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { Navbar } from "./components/Navbar";
import { Register } from "./Pages/Auth/Register";

function App() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/"> </Route>
        <Route path="/register" element={<Register />} />
      </Routes>
    </>
  );
}

export default App;
