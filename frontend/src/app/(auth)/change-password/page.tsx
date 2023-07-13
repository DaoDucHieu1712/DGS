"use client";
import OtherInfomation from "@/components/widgets/OtherInfomation";
import AuthServices from "@/services/authService";
import { yupResolver } from "@hookform/resolvers/yup";
import { Button, Input } from "@material-tailwind/react";
import { getCookie } from "cookies-next";
import { useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";

const schema = yup
  .object({
    oldPassword: yup.string().required(),
    newPassword: yup.string().required(),
    confirmPassword: yup.string().required(),
  })
  .required();
type FormData = yup.InferType<typeof schema>;

const ChangePasswordPage = () => {
  const [msgSuccesss, setMsgSuccesss] = useState("");
  const [msgErr, setMsgErr] = useState("");
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = async (data: FormData) => {
    const changePassword = {
      email: getCookie("email")?.toString(),
      oldPassword: data.oldPassword,
      newPassword: data.newPassword,
      confirmPassword: data.confirmPassword,
    };
    await AuthServices.changePassword(changePassword)
      .then((res) => {
        setMsgSuccesss("change password successful !");
      })
      .catch((err: Error) => {
        setMsgErr((err as any).response.data);
      });
  };

  return (
    <>
      <div className="container mx-auto p-7">
        <div className="cap">
          <h1 className="text-2xl font-semibold">Change Password</h1>
          <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit.</p>
        </div>
        <section className="mt-12 shadow-xl p-6 py-6">
          <div className="flex items-center justify-center gap-x-4 pb-5 border-b border-gray-300">
            <div className="flex items-center justify-center avt w-full p-3 border-gray-900">
              <div className="border border-gray-700 w-[200px] h-[200px] rounded-full flex items-center justify-center text-md font-semibold">
                Avartar User
              </div>
            </div>
            <div className="w-full p-4">
              <div className="mb-3">
                <p className="text-green-500">{msgSuccesss}</p>
                <p className="text-red-500">{msgErr}</p>
              </div>
              <form
                onSubmit={handleSubmit(onSubmitHandler)}
                className="flex justify-center items-center flex-col gap-y-4 w-full"
              >
                <div className="form-group w-full">
                  <Input
                    size="md"
                    type="password"
                    label="Old Password"
                    {...register("oldPassword")}
                  />
                </div>
                <div className="form-group w-full">
                  <Input
                    size="md"
                    type="password"
                    label="New Password"
                    {...register("newPassword")}
                  />
                </div>
                <div className="form-group w-full">
                  <Input
                    size="md"
                    type="password"
                    label="Confirm Password"
                    {...register("confirmPassword")}
                  />
                </div>
                <div className="form-group w-full">
                  <Button
                    className="mt-6"
                    size="md"
                    color="orange"
                    type="submit"
                    fullWidth
                  >
                    Change Password
                  </Button>
                </div>
              </form>
            </div>
          </div>
          <OtherInfomation></OtherInfomation>
        </section>
      </div>
    </>
  );
};

export default ChangePasswordPage;
