"use client";
import AuthServices from "@/services/authService";
import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Card,
  Checkbox,
  Input,
  Radio,
  Typography,
} from "@material-tailwind/react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";

const schema = yup
  .object({
    displayName: yup.string().required(),
    gender: yup.boolean().required(),
    birthDay: yup.date().required(),
    email: yup.string().email().required(),
    password: yup.string().min(6).max(15).required(),
    confirmPassword: yup.string().required(),
  })
  .required();
type FormData = yup.InferType<typeof schema>;

const Register = () => {
  const { push } = useRouter();

  const [errorMsg, setErrorMsg] = useState<string>("");

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = async (data: FormData) => {
    const NewUser = {
      displayName: data.displayName,
      imageURL: "",
      gender: data.gender,
      birtday: data.birthDay,
      email: data.email,
      password: data.password,
      confirmPassword: data.confirmPassword,
    };

    await AuthServices.register(NewUser)
      .then((res) => {
        push("/login");
      })
      .catch((err: Error) => {
        setErrorMsg((err as any).response.data);
      });
  };

  return (
    <div className="container mx-auto my-auto flex items-center justify-center">
      <Card color="transparent" shadow={false} className="p-2">
        <Typography
          variant="h4"
          color="blue-gray"
          className="uppercase text-xl font-bold"
        >
          Register with Customer
        </Typography>
        <Typography color="gray" className="mt-3 font-normal">
          Lorem ipsum dolor sit amet consectetur !
        </Typography>
        {errorMsg.length > 0 && (
          <div className="pt-4">
            <p className="text-red-500 text-sm font-medium">{errorMsg}</p>
          </div>
        )}
        <form
          className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96"
          onSubmit={handleSubmit(onSubmitHandler)}
        >
          <Input size="md" label="Display Name" {...register("displayName")} />
          <div className="mb-4 flex flex-col gap-6">
            <div className="flex gap-10">
              <Radio
                id="male"
                label="Male"
                value="true"
                defaultChecked
                {...register("gender")}
              />
              <Radio
                id="female"
                label="Female"
                value="false"
                {...register("gender")}
              />
            </div>
            <Input
              size="md"
              type="date"
              label="Date of birth"
              {...register("birthDay")}
            />
            <Input size="md" label="Email" {...register("email")} />
            <Input
              type="password"
              size="md"
              label="Password"
              {...register("password")}
            />
            <Input
              type="password"
              size="md"
              label="Confirm Password"
              {...register("confirmPassword")}
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
            Register
          </Button>
          <Typography color="gray" className="mt-4 text-center font-normal">
            You have an account?{" "}
            <Link
              href="/login"
              className="font-medium text-blue-500 transition-colors hover:text-blue-700"
            >
              login
            </Link>
          </Typography>
        </form>
      </Card>
    </div>
  );
};

export default Register;
