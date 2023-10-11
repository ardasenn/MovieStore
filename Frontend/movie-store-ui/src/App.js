import logo from "./logo.svg";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { Navbar } from "./components/Navbar";
import { Register } from "./Pages/Auth/Register";
import { SignIn } from "./Pages/Auth/SignIn";

function App() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/"> </Route>
        <Route path="/register" element={<Register />} />
        <Route path="/signin" element={<SignIn />} />
      </Routes>
    </>
  );
}

export default App;
