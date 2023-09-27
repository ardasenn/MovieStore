import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { customerSchema } from "../SignIn/validation";
export const Register = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({ resolver: yupResolver(customerSchema) });

  return (
    <form
      onSubmit={handleSubmit((data) => {
        console.log(data);
      })}
      className="flex flex-col items-center pt-5 space-y-2 bg-slate-50  "
    >
      <h3 className="font-bold text-4xl mb-5">Sign Up</h3>
      <div className="mb-1">
        <input
          {...register("firstName")}
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
          placeholder="First Name"
        />
        {errors.firstName && (
          <span className="text-red-500 ml-2 block">
            {errors.firstName.message}
          </span>
        )}
      </div>
      <div className="mb-1">
        <input
          {...register("lastName")}
          placeholder="Last Name"
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        {errors.lastName && (
          <span className="text-red-500 ml-2 block">
            {errors.lastName.message}
          </span>
        )}
      </div>
      <div className="mb-1">
        <input
          {...register("email")}
          placeholder="Email"
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        {errors.email && (
          <span className="text-red-500 ml-2 block">
            {errors.email.message}
          </span>
        )}
      </div>
      <div className="mb-1">
        <input
          {...register("userName")}
          type="text"
          name="userName"
          placeholder="Username"
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        {errors.userName && (
          <span className="text-red-500 ml-2 block">
            {errors.userName.message}
          </span>
        )}
      </div>
      <div className="mb-1">
        <input
          {...register("password")}
          type="password"
          name="password"
          placeholder="Password"
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        {errors.password && (
          <span className="text-red-500 ml-2 block">
            {errors.password.message}
          </span>
        )}
      </div>
      <div className="mb-1">
        <input
          {...register("passwordConfirm")}
          type="password"
          name="passwordConfirm"
          placeholder="Confirm Password"
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        {errors.passwordConfirm && (
          <span className="text-red-500 ml-2 block">
            {errors.passwordConfirm.message}
          </span>
        )}
      </div>
      <div className="mb-1">
        <input
          {...register("phoneNumber")}
          type="tel"
          name="phoneNumber"
          placeholder="Phone Number"
          className="w-[400px] px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        {errors.phoneNumber && (
          <span className="text-red-500 ml-2 block">
            {errors.phoneNumber.message}
          </span>
        )}
      </div>
      <button className=" text-zinc-100 font-bold  hover:text-black bg-green-500 w-24 h-10 rounded-full">
        Kayıt ol
      </button>
    </form>
  );
};
