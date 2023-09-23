import React from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";

export const Navbar = () => {
  const { loggedIn } = useAuth();

  return (
    <div className="navbar-container flex h-16 justify-between items-center bg-slate-800 text-zinc-100 font-bold px-4">
      <div className="navbar-image ">
        <img className="h-8 mr-3" src="/movie.svg" alt="logo" />
      </div>
      <div className="navbar-content w-1/5 flex justify-evenly items-center">
        <Link to="/" className=" hover:text-zinc-500">
          Ana Sayfa
        </Link>
        {!loggedIn && (
          <>
            <Link to="/orders" className=" hover:text-zinc-500">
              Siparişlerim
            </Link>
            <Link>
              <button className=" hover:text-black bg-yellow-500 w-24 h-10 rounded-full">
                Çıkış yap
              </button>
            </Link>
          </>
        )}
        {loggedIn && (
          <>
            <Link>
              <button className=" hover:text-black bg-green-500 w-24 h-10 rounded-full">
                Kayıt ol
              </button>
            </Link>
            <Link>
              <button className=" hover:text-black bg-yellow-500 w-24 h-10 rounded-full">
                Giriş Yap
              </button>
            </Link>
          </>
        )}
      </div>
    </div>
  );
};
