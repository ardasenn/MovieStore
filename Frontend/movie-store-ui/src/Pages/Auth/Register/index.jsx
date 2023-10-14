import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { customerSchema } from "./validation";
import { fetchRegister } from "../../../Api/ApiCall";
import Modal from "react-modal";
import { useNavigate } from "react-router-dom";
import { Input } from "../../../components/Input";
import { Button } from "../../../components/Button";

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
        className=" flex flex-col items-center pt-5 h-screen gap-8"
      >
        <h3 className="font-bold text-4xl mb-5 text-white">Sign Up</h3>

        <Input
          register={register}
          labelFor="firstName"
          type="text"
          labelText="First Name *"
          placeholder="First Name *"
          errorMessage={errors.firstName?.message}
        />
        <Input
          register={register}
          labelFor="lastName"
          type="text"
          labelText="Last Name *"
          placeholder="Last Name *"
          errorMessage={errors.lastName?.message}
        />
        <Input
          register={register}
          labelFor="email"
          type="email"
          labelText="Email *"
          placeholder="Email *"
          errorMessage={errors.email?.message}
        />
        <Input
          register={register}
          labelFor="userName"
          type="text"
          labelText="User Name *"
          placeholder="User Name *"
          errorMessage={errors.userName?.message}
        />
        <Input
          register={register}
          labelFor="password"
          type="password"
          labelText="Password *"
          placeholder="Password *"
          errorMessage={errors.password?.message}
        />
        <Input
          register={register}
          labelFor="passwordConfirm"
          type="password"
          labelText="Confirm Password*"
          placeholder="Password *"
          errorMessage={errors.passwordConfirm?.message}
        />
        <Input
          register={register}
          labelFor="phoneNumber"
          type="tel"
          labelText="Phone Number *"
          placeholder="Phone Number *"
          errorMessage={errors.phoneNumber?.message}
        />
        <div className="flex w-[360px] justify-end w-full">
          <Button backgroundColor="bg-secondary">Gönder</Button>
        </div>
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
