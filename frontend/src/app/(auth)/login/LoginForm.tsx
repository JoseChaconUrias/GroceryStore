import Link from "next/link";

const LoginForm = () => {
  return (
    <form className="outline w-[27.5rem] p-14 text-center rounded-xl">
      <h1 className="font-bold text-3xl mb-5">Welcome Back!</h1>
      <div className="flex flex-col gap-3 justify-center items-center">
        <input className="outline p-2 rounded-xl w-full mb-2" placeholder="Username" type="text" required />
        <input className="outline p-2 rounded-xl w-full mb-2" placeholder="Password" type="password" required />

        <button className="bg-emerald-400 rounded-3xl w-32 p-2">Log In</button>
        <div className=" flex flex-row justify-center gap-1">
            <p>Don't have an account?</p>
            <Link href="/signup" className="text-blue-500 font-bold">Sign Up</Link>       
        </div>
      </div>
    </form>
  );
};

export default LoginForm;
