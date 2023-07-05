"use client";
import {
  Button,
  Card,
  Checkbox,
  Input,
  Radio,
  Typography,
} from "@material-tailwind/react";
import Link from "next/link";
import React from "react";

const Register = () => {
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
        <form className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96">
          <div className="mb-4 flex flex-col gap-6">
            <Input size="md" label="Display Name" />
            <div className="flex gap-10">
              <Radio id="male" name="gender" label="Male" defaultChecked />
              <Radio id="female" name="gender" label="Female" />
            </div>
            <Input size="md" type="date" label="Date of birth" />
            <Input size="md" label="Email" />
            <Input type="password" size="md" label="Password" />
            <Input type="password" size="md" label="Confirm Password" />
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
          <Button className="mt-6" size="md" fullWidth>
            login
          </Button>
          <Typography color="gray" className="mt-4 text-center font-normal">
            Already have an account?{" "}
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
