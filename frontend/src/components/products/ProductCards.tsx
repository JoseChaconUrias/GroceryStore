import Cards from "./Cards";

const ProductCards = () => {
  return (
    <>
      <h1 className="text-4xl font-bold mb-10">Fresh Produce</h1>
      <div className="flex flex-row p-4 gap-10 overflow-x-scroll overscroll-x-auto scroll-smooth [scrollbar-width:none]">
        <Cards />
      </div>
    </>
  );
};

export default ProductCards;
