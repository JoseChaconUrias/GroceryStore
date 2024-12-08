import { BackgroundBeamsWithCollision } from "@/components/ui/BackgroundBeams";
import { FlipWords } from "../../components/ui/FlipWords";

const layout = ({ children }: { children: React.ReactNode }) => {
  return (
    <BackgroundBeamsWithCollision>
      <main className="flex flex-row bg-black">
        <div className="flex items-center justify-center w-1/2">
          <h2 className="text-center relative z-20 text-6xl font-bold text-white font-sans tracking-tight">
            A new way to think about{" "}
            <div className="relative mx-auto inline-block w-max [filter:drop-shadow(0px_1px_3px_rgba(27,_37,_80,_0.14))]">
              <div className="absolute left-0 top-[1px] bg-clip-text bg-no-repeat text-transparent bg-gradient-to-r py-4 from-purple-500 via-violet-500 to-pink-500 [text-shadow:0_0_rgba(0,0,0,0.1)]">
                <span className="">Online Shopping.</span>
              </div>
              <div className="relative bg-clip-text text-transparent bg-no-repeat bg-gradient-to-r from-purple-500 via-violet-500 to-pink-500 py-4">
                <span className="">Online Shopping.</span>
              </div>
            </div>
          </h2>
        </div>
        <section className="relative flex w-1/2">{children}</section>
      </main>      
    </BackgroundBeamsWithCollision>

  );
};

export default layout;
