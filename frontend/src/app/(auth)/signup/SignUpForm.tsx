"use client";
import Link from "next/link";
import { useState } from "react";
import { useRouter } from "next/navigation";

const SignUpForm = () => {
  const [email, setEmail] = useState<string>("");
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [comfirmPassword, setComfirmPassword] = useState<string>("");
  const [error, setError] = useState<string | null>(null);

  const router = useRouter();

  const hanldeSignUp = async (e: React.FormEvent) => {
    e.preventDefault();

    setError(null);

    const specialCharacterRegex = /[!@#$%^&*(),.?":{}|<>]/;

    if (password.length < 7 || !specialCharacterRegex.test(password)) {
      setError(
        "Password must be at least 7 characters long and include at least one special character."
      );
      return;
    }

    if (password !== comfirmPassword) {
      setError("Passwords do not match.");
      return;
    }

    try {
      setError(null);
      const response = await fetch("API_URL", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, username, password }),
      });

      if (!response.ok) {
        throw new Error("Faild to sign up. Please try again.");
      }

      console.log("Sign in successful");
      router.push("/");
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      } else {
        setError("An unexpected error occurred.");
      }
    }
  };

  return (
    <form
      className="w-[35rem] p-14 text-center rounded-xl text-white"
      onSubmit={hanldeSignUp}
    >
      <h1 className="font-bold text-3xl mb-5">Welcome to ShopQuik!</h1>
      {error && <p className="text-red-500 mb-3 text-sm">{error}</p>}
      <div className="mb-2">
        <h3 className="text-zinc-200 text-sm text-left">Username</h3>
        <input
          className="bg-zinc-100 outline p-2 rounded-xl w-full text-zinc-900"
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </div>
      <div className="mb-2">
        <h3 className="text-zinc-200 text-sm text-left">Email</h3>
        <input
          className="bg-zinc-100 outline p-2 rounded-xl w-full text-zinc-900"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>
      <div className="mb-2">
        <h3 className="text-zinc-200 text-sm text-left">Password</h3>
        <input
          className="bg-zinc-100 outline p-2 rounded-xl w-full text-zinc-900"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>
      <div className="mb-2">
        <h3 className="text-zinc-200 text-sm text-left">Comfirm Password</h3>
        <input
          className="bg-zinc-100 outline p-2 rounded-xl w-full text-zinc-900"
          type="password"
          value={comfirmPassword}
          onChange={(e) => setComfirmPassword(e.target.value)}
          required
        />
      </div>

      <button
        className="bg-violet-500 rounded-3xl font-bold w-32 p-2 mt-4 mb-6"
        type="submit"
      >
        Sign Up
      </button>
      <div className=" flex flex-row justify-center gap-1">
        <p>Already have an account?</p>
        <Link href="/login" className="text-blue-500 font-semibold">
          Log In
        </Link>
      </div>
    </form>
  );
};

export default SignUpForm;
