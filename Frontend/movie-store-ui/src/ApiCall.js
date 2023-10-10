import axios from "axios";

axios.interceptors.request.use(
  function (config) {
    const token = localStorage.getItem("access-token-moviestore");
    const { origin } = new URL(config.url);
    const allowedOrigins = [process.env.REACT_APP_BASE_ENDPOINT];

    if (allowedOrigins.includes(origin)) {
      config.headers.authorization = token;
    }

    return config;
  },
  function (error) {
    // Do something with request error
    return Promise.reject(error);
  }
);

export const fetchRegister = async (input) => {
  const { data } = await axios.post(
    `${process.env.REACT_APP_BASE_ENDPOINT}/Auth/Register`,
    input
  );
  return data;
};
