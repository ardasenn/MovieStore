import React from "react";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import { fetchLogin } from "../../../Api/ApiCall";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../../contexts/AuthContext";
import { Input } from "../../../components/Input";

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
      <section className="bg-gray-50 dark:bg-gray-900">
        <div className="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0">
          <div className="w-full bg-white rounded-lg shadow dark:border md:mt-0 sm:max-w-md xl:p-0 dark:bg-gray-800 dark:border-gray-700">
            <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
              <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                Sign in to your account
              </h1>
              <form
                className="space-y-4 md:space-y-6"
                onSubmit={handleSubmit(onSubmit)}
              >
                {/* <Input
                  register={register}
                  labelFor={"email"}
                  className={
                    " dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                  }
                  placeholder={"test@test.com"}
                  labelText="Your Email"
                />
                <Input
                  register={register}
                  placeholder={"••••••••"}
                  className={` dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500`}
                  labelFor={"password"}
                  labelText="Password"
                  type="password"
                /> */}

                <div className="flex items-center justify-between">
                  <div className="flex items-start">
                    <div className="flex items-center h-5">
                      <input
                        id="remember"
                        aria-describedby="remember"
                        type="checkbox"
                        className="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-primary-600 dark:ring-offset-gray-800"
                      />
                    </div>
                    <div className="ml-3 text-sm">
                      <label
                        htmlFor="remember"
                        className="text-gray-500 dark:text-gray-300"
                      >
                        Remember me
                      </label>
                    </div>
                  </div>
                  {/* <a
                    href="#"
                    className="text-sm font-medium text-primary-600 hover:underline dark:text-primary-500"
                  >
                    Forgot password?
                  </a> */}
                </div>
                <button
                  type="submit"
                  className="w-full text-white  bg-yellow-500 hover:text-black focus:ring-4 focus:outline-none focus:ring-primary-300 font-extrabold rounded-lg text-m px-5 py-2.5 text-center dark:bg-primary-600 dark:focus:ring-primary-800"
                >
                  Sign in
                </button>
                <p className="text-sm font-light text-gray-500 dark:text-gray-400">
                  Don’t have an account yet?{" "}
                  <Link to="/register">
                    <button className="font-medium text-primary-600 hover:underline dark:text-primary-500">
                      Sign up
                    </button>
                  </Link>
                </p>
              </form>
            </div>
          </div>
        </div>
      </section>
    </>
  );
};
