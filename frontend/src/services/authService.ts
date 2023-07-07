import { ApplicationUser, Login, User } from "@/models/Auth";
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
  findbyEmail(email: string | undefined): Promise<ApplicationUser> {
    const url = `/Auth/FindByEmail?email=${email}`;
    return axiosConfig.get(url);
  },
};

export default AuthServices;
