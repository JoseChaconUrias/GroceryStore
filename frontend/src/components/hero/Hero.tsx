"use client";
import { motion } from "framer-motion";
import React from "react";
import { ImagesSlider } from "../ui/ImagesSlider";

const Hero = () => {
  const images = [
    "/img/dummy_img/steak.jpg",
    "/img/dummy_img/chicken.jpg",
    "/img/dummy_img/pie.jpg",
  ];

  const handleScroll = () => {
    const storeElement = document.getElementById("store");
    if (storeElement) {
      storeElement.scrollIntoView({ behavior: "smooth" });
    }
  };

  return (
    <ImagesSlider className="mt-[5rem] h-[45rem]" images={images}>
      <motion.div
        initial={{
          opacity: 0,
          y: -80,
        }}
        animate={{
          opacity: 1,
          y: 0,
        }}
        transition={{
          duration: 0.6,
        }}
        className="z-50 flex flex-col justify-center items-center"
      >
        <motion.p className="font-bold text-xl md:text-6xl text-center bg-clip-text text-transparent bg-gradient-to-b from-neutral-50 to-neutral-400 py-4">
         Simplify Your Shopping, <br /> Maximize Your Time.
        </motion.p>
        <button onClick={handleScroll} className="px-4 py-2 backdrop-blur-sm border bg-pink-300/10 border-pink-500/20 text-white mx-auto text-center rounded-full relative mt-4">
          <span>Start Shopping ↓</span>
          <div className="absolute inset-x-0  h-px -bottom-px bg-gradient-to-r w-3/4 mx-auto from-transparent via-pink-500 to-transparent" />
        </button>
      </motion.div>
    </ImagesSlider>
  );
};

export default Hero;
