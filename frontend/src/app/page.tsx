"use client";
import Navbar from "../components/header/Navbar";
import Hero from "../components/hero/Hero";
import ProductCards from "@/components/products/ProductCards";
import Footer from "@/components/footer/Footer";


const Home = () => {
  return (
    <main className="min-h-screen text-white">
      <Navbar />
      <Hero />

      <section id="store" className="p-28 flex flex-col gap-10">
        {[...Array(6)].map((_, i) => (
          <div key={i}>
            <ProductCards />
          </div>
        ))}
      </section>
      <Footer />
    </main>
  );
};

export default Home;
