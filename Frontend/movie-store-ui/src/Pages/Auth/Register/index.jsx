import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { customerSchema } from "./validation";
import { fetchRegister } from "../../../ApiCall";
import Modal from "react-modal";
import { useNavigate } from "react-router-dom";

export const Register = () => {
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({ resolver: yupResolver(customerSchema) });
  const customStyles = {
    content: {
      top: "50%",
      left: "50%",
      right: "auto",
      bottom: "auto",
      marginRight: "-50%",
      transform: "translate(-50%, -50%)",
    },
  };
  const [isModalOpen, setModalOpen] = useState(false);
  const onSubmit = async (data) => {
    try {
      data.phoneNumber = String(data.phoneNumber);
      const registerResponse = await fetchRegister(data);
      console.log("register", registerResponse);
      registerResponse.isSuccess && setModalOpen(true);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <>
      <form
        onSubmit={handleSubmit(onSubmit)}
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

      <Modal
        isOpen={isModalOpen}
        onRequestClose={() => setModalOpen(false)}
        contentLabel="Example Modal"
        style={customStyles}
      >
        <div className="relative h-16">
          <h2 className="font-bold">Kayıt başarıyla gerçekleşti</h2>
          <button
            className=" text-cyan-50 font-medium hover:text-black  bg-green-500 w-28 mt-2 absolute right-0  h-8 rounded-full"
            onClick={() => {
              setModalOpen(false);
              navigate("/signin");
            }}
          >
            Ekranı Kapat
          </button>
        </div>
      </Modal>
    </>
  );
};
