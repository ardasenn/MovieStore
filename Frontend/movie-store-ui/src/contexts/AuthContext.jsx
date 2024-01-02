import { createContext, useContext, useState } from "react";
import { useLocalStorageState } from "../Hooks/LocalStorage";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [loggedIn, setLoggedIn] = useLocalStorageState("moviestore-auth", []);

  const login = (data) => {
    setLoggedIn(data);
  };

  const values = { loggedIn, login, setLoggedIn };
  return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>;
};

const useAuth = () => useContext(AuthContext);

export { AuthProvider, useAuth };
