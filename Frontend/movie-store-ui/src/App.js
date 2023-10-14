import logo from "./logo.svg";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { Navbar } from "./components/Navbar";
import { Register } from "./Pages/Auth/Register";
import { SignIn } from "./Pages/Auth/SignIn";

function App() {
  return (
    <div className=" bg-gradient-to-r from-myBlue to-myPurple h-screen">
      <Navbar />
      <Routes>
        <Route path="/"> </Route>
        <Route path="/register" element={<Register />} />
        <Route path="/signin" element={<SignIn />} />
      </Routes>
    </div>
  );
}

export default App;
