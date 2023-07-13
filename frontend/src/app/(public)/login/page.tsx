"use client";
import { Login } from "@/models/Auth";
import AuthServices from "@/services/authService";
import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Card,
  Checkbox,
  Input,
  Typography,
} from "@material-tailwind/react";
import { setCookie } from "cookies-next";
import Link from "next/link";
import { useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";

const schema = yup
  .object({
    email: yup.string().email("example : abc@gmail.com").required(),
    password: yup.string().min(6).max(15).required(),
  })
  .required();
type FormData = yup.InferType<typeof schema>;

const LoginPage = () => {
  const [errorMessage, setErrorMessage] = useState<string>("");
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: FormData) => {
    const loginForm: Login = {
      email: data.email,
      password: data.password,
    };
    await AuthServices.login(loginForm)
      .then((res) => {
        const accessToken = res.accessToken;
        const email = res.email;
        const roles = res.roles;
        setCookie("token", accessToken, {
          maxAge: 60 * 60 * 25 * 60,
        });
        setCookie("email", email, {
          maxAge: 60 * 60 * 25 * 90,
        });
        setCookie("roles", roles[0], {
          maxAge: 60 * 60 * 25 * 90,
        });
        if (roles[0] === "Customer") {
          window.location.href = "/";
        } else {
          window.location.href = "/dashboard";
        }
      })
      .catch((error: Error) => {
        const error_response = (error as any).response;
        setErrorMessage(error_response.data);
      });
  };

  return (
    <div className="container mx-auto my-auto flex items-center justify-center ">
      <Card color="transparent" shadow={false} className="p-2">
        <Typography
          variant="h4"
          color="blue-gray"
          className="uppercase text-xl font-bold"
        >
          Sign In with Customer
        </Typography>
        <Typography color="gray" className="mt-3 font-normal">
          Welcome back !!
        </Typography>
        <div className="pt-4">
          <p className="text-red-500 text-sm font-medium">{errorMessage}</p>
        </div>
        <form
          className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96"
          onSubmit={handleSubmit(onSubmit)}
        >
          <div className="mb-4 flex flex-col gap-6">
            <Input size="md" label="Email" {...register("email")} />
            {/* <p className="mt-1 text-sm text-red-600 dark:text-red-500">
              {errors.email?.message}
            </p> */}
            <Input
              type="password"
              size="md"
              label="Password"
              {...register("password")}
            />
          </div>
          <Checkbox
            label={
              <Typography
                variant="small"
                color="gray"
                className="flex items-center font-normal"
              >
                I agree the
                <a
                  href="#"
                  className="font-medium transition-colors hover:text-blue-500"
                >
                  &nbsp;Terms and Conditions
                </a>
              </Typography>
            }
            containerProps={{ className: "-ml-2.5" }}
          />
          <Button className="mt-6" size="md" type="submit" fullWidth>
            login
          </Button>
          <Typography color="gray" className="mt-4 text-center font-normal">
            You have have an account?{" "}
            <Link
              href="/register"
              className="font-medium text-blue-500 transition-colors hover:text-blue-700"
            >
              Register
            </Link>
          </Typography>
        </form>
      </Card>
    </div>
  );
};

export default LoginPage;
