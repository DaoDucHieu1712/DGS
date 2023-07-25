import axios from "axios";
import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";

interface ChangeImageProps {
  onChange: any;
  name: any;
  urlImage: string | undefined;
}

const ChangeImage = ({ onChange, name, urlImage = "" }: ChangeImageProps) => {
  const [imageURL, setImageURL] = useState<string>("");

  useEffect(() => {
    setImageURL(urlImage);
  }, []);

  const handleUploadImage = async (e: any) => {
    const file = e.target.files;
    if (!file) return;
    const bodyFormData = new FormData();
    bodyFormData.append("image", file[0]);
    const response = await axios({
      method: "post",
      url: process.env.NEXT_PUBLIC_API_BASE_URL_UPLOAD_IMAGE,
      data: bodyFormData,
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    const imageData = response.data.data;
    if (!imageData) {
      toast.error("Can not upload image to imgbbAPI");
      return;
    }
    const imageObj = {
      thumb: imageData.thumb.url,
      url: imageData.url,
    };
    onChange(name, imageObj.thumb);
    setImageURL(imageObj.thumb);
  };

  return (
    <>
      <div className="image">
        <img src={imageURL} alt="" className="object-cover h-[210px]" />
      </div>
      <input
        type="file"
        onChange={handleUploadImage}
        className="mt-3 px-6 py-2"
      />
    </>
  );
};

export default ChangeImage;
