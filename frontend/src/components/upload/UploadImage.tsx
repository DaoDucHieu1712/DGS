import axios from "axios";
import React, { useState } from "react";
import { toast } from "react-toastify";

interface UploadImageProps {
  onChange: any;
  name: any;
}

const UploadImage = ({ onChange, name }: UploadImageProps) => {
  const [imageURL, setImageURL] = useState<string>("");

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
      <label className="flex items-center justify-center w-full cursor-pointer h-[206px] border boder-gray-200 border-dashed rounded-lg mb-3">
        {imageURL.length === 0 ? (
          <>
            <input type="file" onChange={handleUploadImage} hidden />
            <span>Choose file image</span>
          </>
        ) : (
          <img
            src={imageURL}
            alt="anh upload"
            className="w-full w-[230px] h-[206px] object-cover"
          />
        )}
      </label>
    </>
  );
};

export default UploadImage;
