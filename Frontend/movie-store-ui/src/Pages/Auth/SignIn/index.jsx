import React from "react";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import { fetchLogin } from "../../../Api/ApiCall";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../../contexts/AuthContext";
import { Input } from "../../../components/Input";
import { Button } from "../../../components/Button";

export const SignIn = () => {
  const { register, handleSubmit } = useForm();
  const navigate = useNavigate();
  const { login } = useAuth();
  const onSubmit = async (data) => {
    const registerResponse = await fetchLogin(data);
    if (!registerResponse.isSuccess) {
      //todo
    } else {
      console.log(registerResponse);
      login(registerResponse.data);
      navigate("/");
    }
  };

  return (
    <>
      <form
        className=" flex flex-col items-center pt-5  gap-8"
        onSubmit={handleSubmit(onSubmit)}
      >
        <h3 className="font-bold text-4xl mb-5 text-white">Sign In</h3>
        <Input
          register={register}
          labelFor="email"
          type="email"
          labelText="Email *"
          placeholder="Email *"
        />
        <Input
          register={register}
          labelFor="password"
          type="password"
          labelText="Password *"
          placeholder="Password *"
        />
        <div className="w-[360px] flex justify-end">
          <Button backgroundColor="bg-secondary">Sign In</Button>
        </div>
        <p className="text-sm font-light text-gray-500 dark:text-gray-400">
          Don’t have an account yet?{" "}
          <Link to="/register">
            <button className="font-medium text-primary-600 hover:underline dark:text-primary-500">
              Sign up
            </button>
          </Link>
        </p>
      </form>
    </>
  );
};
