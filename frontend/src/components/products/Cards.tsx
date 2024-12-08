import Image from "next/image";
import { IoIosAdd } from "react-icons/io";

const Cards = () => {
  return (
    <div className="flex gap-6">
      {[...Array(6)].map((_, i) => (
        <div
          key={i}
          className="bg-zinc-950 p-5 rounded-xl min-w-[250px] flex-shrink-0 transition-transform transform hover:scale-105"
        >
          <Image
            src="/img/dummy_img/apple.jpg"
            alt="Honeycrisp Apple"
            width={300}
            height={300}
            className="h-[16rem] w-[20rem] object-cover rounded-md"
          />
          <div className="flex flex-row items-center justify-between mt-3">
            <h2 className="font-bold">Honeycrisp Apple</h2>
            <button className="rounded-full p-1 bg-pink-500 hover:bg-pink-600">
              <IoIosAdd className="text-white text-3xl" />
            </button>
          </div>
          <div className="flex flex-col gap-2 mt-6">
            <p>89¢</p>
            <p className="text-zinc-400 text-sm">
              Popular variety known for its crisp texture,
              <br /> juicy flesh, and perfect balance of <br /> sweetness and
              tartness.
            </p>
          </div>
        </div>
      ))}
    </div>
  );
};

export default Cards;
