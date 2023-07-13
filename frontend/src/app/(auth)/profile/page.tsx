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

const schema = yup
  .object({
    displayName: yup.string().required(),
    gender: yup.boolean().required(),
    birthDay: yup.date().required(),
  })
  .required();
type FormData = yup.InferType<typeof schema>;

interface ProfilePageProps {
  params: { id: string };
}

const ProfilePage = ({ params }: ProfilePageProps) => {
  const [user, setUser] = useState<ApplicationUser>();
  const [displayName, setDisplayName] = useState("");
  const [gender, setGender] = useState("");
  const [dob, setDob] = useState("");
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: yupResolver(schema),
  });

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

  const onSubmitHandler = async (data: FormData) => {
    const userUpdate = {
      id: user?.id,
      displayName: displayName,
      gender: gender === "true" ? true : false,
      birthDay: dob,
      imageURL: "",
    };

    await AuthServices.ProfileSave(userUpdate);
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
              <form
                onSubmit={handleSubmit(onSubmitHandler)}
                className="flex justify-center items-center flex-col gap-y-4 w-full"
              >
                <div className="form-group w-full">
                  <Input
                    size="md"
                    label="Display Name"
                    defaultValue={displayName}
                    {...register("displayName")}
                    onChange={(e) => setDisplayName(e.target.value)}
                  />
                </div>
                <div className="flex gap-10 w-full">
                  <Radio
                    id="male"
                    label="Male"
                    color="orange"
                    defaultValue="true"
                    checked={gender == "true" ? true : false}
                    {...register("gender")}
                    onChange={(e) => setGender(e.target.value)}
                  />
                  <Radio
                    id="female"
                    label="Female"
                    color="orange"
                    defaultValue="false"
                    checked={gender == "false" ? true : false}
                    {...register("gender")}
                    onChange={(e) => setGender(e.target.value)}
                  />
                </div>
                <div className="form-group w-full">
                  <Input
                    size="md"
                    type="date"
                    label="Date of birth"
                    defaultValue={dob}
                    {...register("birthDay")}
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
                  >
                    Save
                  </Button>
                </div>
              </form>
            </div>
          </div>
          <OtherInfomation></OtherInfomation>
        </div>
      </div>
    </>
  );
};

export default ProfilePage;
