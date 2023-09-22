import React from "react";

export const Navbar = () => {
  return (
    <div className="navbar-container flex h-16 justify-between items-center bg-slate-800 text-zinc-100 font-bold px-4">
      <div className="navbar-image ">
        <img className="h-8 mr-3" src="/movie.svg" alt="logo" />
      </div>
      <div className="navbar-content w-1/5 flex justify-evenly items-center">
        <p className=" hover:text-zinc-500">Ana Sayfa</p>
        <p className=" hover:text-zinc-500">Siparişlerim</p>
        <button className=" hover:text-black bg-yellow-500 w-24 h-10 rounded-full">
          Sign out
        </button>
      </div>
    </div>
  );
};
