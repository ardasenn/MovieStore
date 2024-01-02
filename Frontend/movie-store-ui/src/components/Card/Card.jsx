import React from "react";

export const Card = () => {
  return (
    <div className="h-[440px] w-[250px] hover:bg-secondary">
      <img src="/doga.jpg" className="w-[250px] h-[320px]" alt="" />
      <p className="text-primary mt-2">100 quantity sold</p>
      <p className="text-xl text-white font-bold">No Time To Die</p>
      <div className="flex justify-between  text-white">
        <div className="flex items-center ">
          <img
            src="/imdb-svgrepo-com.png"
            className="w-[30px] h-[20px]"
            alt="imdb"
          />
          <p className="ml-3">76.0/100</p>
        </div>
        <p className="font-bold">100 TL</p>
      </div>
      <p className="mt-1 text-primary">Action,Adeventure,Thriller</p>
    </div>
  );
};
