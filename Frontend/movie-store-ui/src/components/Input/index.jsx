import React from "react";

export const Input = ({
  labelFor,
  placeholder,
  labelText = "",
  type = "text",
  register,
  errorMessage = "",
}) => {
  return (
    <div className="w-[360px] h-[60px]">
      <label
        htmlFor={labelFor}
        className="font-medium font-sans block mb-2 text-white"
      >
        {labelText}
      </label>
      <input
        {...register(labelFor, { required: true })}
        placeholder={placeholder}
        type={type}
        className="h-10 w-full pl-4 font-sans placeholder:font-medium placeholder:text-white text-white rounded-md bg-primary"
      />
      <span className="text-secondary text-xs pl-3">{errorMessage}</span>
    </div>
  );
};
