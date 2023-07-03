import { Login, User } from "@/models/Auth";
import axiosConfig from "./axiosConfig";

const AuthServices = {
  login(data: Login): Promise<User> {
    const url = "/Auth/Login";
    return axiosConfig.post(url, data);
  },
  register(data: any): Promise<void> {
    const url = "/Auth/Register";
    return axiosConfig.post(url, data);
  },
};

export default AuthServices;
