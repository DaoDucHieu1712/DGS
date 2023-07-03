"use client";

import Image from "next/image";

export default function Home() {
  return (
    <main className="flex items-center justify-between gap-x-3">
      <img
        src="https://theme.hstatic.net/1000344185/1001008743/14/new_index_item_1.jpg"
        alt="banner"
        className="w-[50%]"
      ></img>
      <img
        src="https://theme.hstatic.net/1000344185/1001008743/14/new_index_item_2.jpg"
        alt="banner"
        className="w-[50%]"
      ></img>
    </main>
  );
}
