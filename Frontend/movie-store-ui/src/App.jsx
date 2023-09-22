import logo from "./logo.svg";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { NavbarDefault } from "./components/Navbar";

function App() {
  return (
    <>
      <NavbarDefault></NavbarDefault>
      <Routes>
        <Route path="/"> </Route>
      </Routes>
    </>
  );
}

export default App;
