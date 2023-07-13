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
  changePassword(data: any): Promise<boolean> {
    const url = `/Auth/ChangePassword`;
    return axiosConfig.post(url, data);
  },
  getUsers(): Promise<any> {
    const url = "/Auth/User";
    return axiosConfig.get(url);
  },
  ProfileSave(data: any): Promise<boolean> {
    const url = "/Auth/ProfilePost";
    return axiosConfig.post(url, data);
  },
};

export default AuthServices;
