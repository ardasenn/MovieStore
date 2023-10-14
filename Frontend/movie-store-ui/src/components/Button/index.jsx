import React from "react";

export const Button = ({
  children,
  backgroundColor = "bg-primary",
  size = "normal",
  isBordered = false,
  onClick,
}) => {
  const largeSize = "w-[180px] h-[52px] rounded-[20px]";
  const normalSize = "w-[110px] h-[40px] rounded-[15px]";
  return (
    <>
      <button
        className={`${size === "normal" ? normalSize : largeSize} ${
          isBordered && "border-[1px] border-primary text-primary "
        } ${!isBordered && backgroundColor}  font-bold text-xl`}
        onClick={onClick}
      >
        {children}
      </button>
    </>
  );
};
