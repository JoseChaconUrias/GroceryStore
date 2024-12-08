"use client";
import Link from "next/link";
import { useState } from "react";
import { useRouter } from "next/navigation";

const LoginForm = () => {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [error, setError] = useState<string | null>(null);

  const router = useRouter();

  const handleLogIn = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      setError(null);

      const response = await fetch("API_URL", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password }),
      });

      if (!response.ok) {
        throw new Error("Invalid username or password");
      }

      router.push("/");
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
        console.error("Login failed:", error);
      } else {
        console.error(error);
      }
    }
  };

  return (
    <form
      className="w-[35rem] p-14 text-center rounded-xl text-white"
      onSubmit={handleLogIn}
    >
      <h1 className="font-bold text-3xl mb-5">Welcome Back!</h1>
        {error && <p className="text-red-500 font-medium">{error}</p>}
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
          <h3 className="text-zinc-200 text-sm text-left">Password</h3>
          <input
            className="bg-zinc-100 outline p-2 rounded-xl w-full text-zinc-900"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
      <button
        className="bg-violet-500 rounded-3xl w-32 p-2 font-bold mt-4 mb-6"
        type="submit"
      >
        Log In
      </button>
      <div className="flex flex-row justify-center gap-1">
        <p>Don't have an account?</p>
        <Link href="/signup" className="text-blue-500 font-semibold">
          Sign Up
        </Link>
      </div>
    </form>
  );
};

export default LoginForm;
