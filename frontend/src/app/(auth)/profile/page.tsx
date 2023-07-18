"use client";
import OtherInfomation from "@/components/widgets/OtherInfomation";
import { ApplicationUser } from "@/models/Auth";
import AuthServices from "@/services/authService";
import { yupResolver } from "@hookform/resolvers/yup";
import { Button, Input, Radio } from "@material-tailwind/react";
import { getCookie } from "cookies-next";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";

const ProfilePage = () => {
  const [user, setUser] = useState<ApplicationUser>();
  const [displayName, setDisplayName] = useState("");
  const [gender, setGender] = useState("");
  const [dob, setDob] = useState("");
  const [msg, setMsg] = useState("");
  const [msgErr, setMsgErr] = useState<string>("");

  useEffect(() => {
    handleGetUser();
  }, []);

  const handleGetUser = async () => {
    let email = getCookie("email")?.toString();
    await AuthServices.findbyEmail(email).then((res) => {
      setUser(res);
      setDisplayName(res.displayName);
      setDob(res.birthDay.toString().slice(0, 10));
      setGender(res.gender ? "true" : "false");
    });
  };

  const onSubmitHandler = async () => {
    const userUpdate = {
      id: user?.id,
      displayName: displayName,
      gender: gender === "true" ? true : false,
      birthDay: dob,
      imageURL: "",
    };

    await AuthServices.ProfileSave(userUpdate)
      .then((res) => {
        setMsg("Update user successful !!!");
      })
      .catch((err: Error) => {
        setMsgErr((err as any).response.data);
      });
  };

  return (
    <>
      <div className="container mx-auto p-7">
        <div className="cap">
          <h1 className="text-2xl font-semibold">User Infomation</h1>
          <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit.</p>
        </div>
        <div className="mt-12 shadow-xl p-6 py-6">
          <div className="flex items-center justify-center gap-x-4 pb-5 border-b border-gray-300">
            <div className="avt w-full p-3 border-gray-900">
              <div className="flex items-center justify-center">
                <div className="border border-gray-700 w-[200px] h-[200px] rounded-full flex items-center justify-center text-md font-semibold">
                  {user?.displayName}
                </div>
              </div>
            </div>
            <div className="w-full p-4">
              <div className="mb-3">
                <p className="text-green-500">{msg}</p>
                <p className="text-red-500">{msgErr}</p>
              </div>
              <div className="flex justify-center items-center flex-col gap-y-4 w-full">
                <div className="form-group w-full">
                  <Input
                    size="md"
                    label="Display Name"
                    value={displayName}
                    onChange={(e) => setDisplayName(e.target.value)}
                  />
                </div>
                <div className="flex gap-10 w-full">
                  <Radio
                    id="male"
                    label="Male"
                    color="orange"
                    value="true"
                    checked={gender == "true" ? true : false}
                    onChange={(e) => setGender(e.target.value)}
                  />
                  <Radio
                    id="female"
                    label="Female"
                    color="orange"
                    value="false"
                    checked={gender == "false" ? true : false}
                    onChange={(e) => setGender(e.target.value)}
                  />
                </div>
                <div className="form-group w-full">
                  <Input
                    size="md"
                    type="date"
                    label="Date of birth"
                    value={dob}
                    onChange={(e) => setDob(e.target.value)}
                  />
                </div>
                <div className="form-group w-full">
                  <Button
                    className="mt-6"
                    size="md"
                    color="deep-orange"
                    type="submit"
                    fullWidth
                    onClick={onSubmitHandler}
                  >
                    Save
                  </Button>
                </div>
              </div>
            </div>
          </div>
          <OtherInfomation></OtherInfomation>
        </div>
      </div>
    </>
  );
};

export default ProfilePage;
