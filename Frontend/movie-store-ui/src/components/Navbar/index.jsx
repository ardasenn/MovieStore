import React from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import { Button } from "../Button";

export const Navbar = () => {
  const { loggedIn, setLoggedIn } = useAuth();

  return (
    <div
      className="navbar-container w-full flex  justify-between
     items-center  text-zinc-100 font-bold px-4"
    >
      <div className="mt-2 flex items-center">
        <Link to="/">
          <img
            className="h-[80px] w-[125px] mr-3 text-primary"
            src="/movie2.svg"
            alt="logo"
          />
        </Link>
        <p className="text-2xl">
          Movie<span className="text-primary">Store</span>
        </p>
      </div>
      <div className="flex justify-between items-center">
        {loggedIn && (
          <>
            <Link to="/orders" className=" hover:text-zinc-500 mr-2">
              Siparişlerim
            </Link>
            <Link>
              <Button
                onClick={() => setLoggedIn(null)}
                backgroundColor="bg-secondary"
              >
                Çıkış yap
              </Button>
            </Link>
          </>
        )}
        {!loggedIn && (
          <>
            <Link to="register">
              <Button backgroundColor="bg-myPurple">Sign Up</Button>
            </Link>
            <Link to="signin">
              <Button isBordered={true}>Sign In</Button>
            </Link>
          </>
        )}
      </div>
    </div>
  );
};
