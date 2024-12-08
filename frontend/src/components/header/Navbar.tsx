"use client";
import React, { useState, useEffect } from "react";
import Link from "next/link";
import { FaShoppingCart } from "react-icons/fa";
import { CgProfile } from "react-icons/cg";
import { IoMenuOutline } from "react-icons/io5";

const Navbar = () => {
  const [lastScrollY, setLastScrollY] = useState(0);
  const [showNavbar, setShowNavbar] = useState(true);
  const [scrollThreshold] = useState(5);

  const handleScroll = () => {
    if (typeof window !== "undefined") {
      if (window.scrollY > lastScrollY + scrollThreshold) {
        setShowNavbar(false);
      } else if (window.scrollY < lastScrollY - scrollThreshold) {
        setShowNavbar(true);
      }
      setLastScrollY(window.scrollY);
    }
  };

  useEffect(() => {
    window.addEventListener("scroll", handleScroll);
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, [lastScrollY]);

  return (
    <header
      className={`bg-black z-50 fixed top-0 left-0 right-0 flex flex-row justify-between items-center outline outline-1 outline-zinc-800 py-6 px-10 font-bold text-zinc-100 transition-transform duration-300 ${
        showNavbar ? "transform translate-y-0" : "transform -translate-y-full"
      }`}
    >
      {/* Search */}
      <div className="w-1/3">
        <button className="flex items-center justify-center p-1 rounded-md hover:bg-zinc-900">
          <IoMenuOutline className="size-6" />
          <p>Menu</p>
        </button>
      </div>

      {/* Home */}
      <div className="flex justify-center w-1/3">
        <Link href="/" className="text-2xl">
          Shop<span className="relative bg-clip-text text-transparent bg-no-repeat bg-gradient-to-r from-purple-500 via-violet-500 to-pink-500">Quik</span>
        </Link>
      </div>

      {/* Navigation */}
      <div className="flex flex-row gap-10 w-1/3 justify-end">
        <Link href="/cart" className="rounded-md hover:bg-zinc-900 p-1">
          <FaShoppingCart className="size-6" />
        </Link>
        <Link href="/profile" className="rounded-md hover:bg-zinc-900 p-1">
          <CgProfile className="size-6" />
        </Link>
      </div>
    </header>
  );
};

export default Navbar;
