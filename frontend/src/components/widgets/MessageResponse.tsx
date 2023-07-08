import React from "react";

interface MessageResponseProps {
  message: string;
  status?: "success" | "error";
}

const MessageResponse = ({ message }: MessageResponseProps) => {
  return <p className="text-red-500 text-sm font-medium">{message}</p>;
};

export default MessageResponse;
