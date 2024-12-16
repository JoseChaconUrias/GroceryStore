import Image from "next/image";
import { IoIosAdd } from "react-icons/io";

interface ProductType {
  productID: number;
  name: string;
  description: string;
  price: number;
  images: string;
  manufacturer: string;
  dimensions: string;
  weight: number;
  rating: number;
  sku: string;
  categoryID: number;
  stock: number;
  saleID: number;
  discountedPrice: number;
}

const Cards = async (categoryId: { categoryId: number }) => {
  console.log(categoryId)
  const response = await fetch(
    `http://localhost:5058/api/product/category/${categoryId.categoryId}`
  );
  const products = await response.json();

  return (
    <div className="flex gap-5">
      {products.map((product: ProductType) => (
        <div
          key={product.productID}
          className="bg-zinc-950 p-5 rounded-xl min-w-[250px] flex-shrink-0 transition-transform transform hover:scale-105"
        >
          <Image
            src={product.images === "image.jpg" ?  "/img/thedog2.jpeg" : product.images || "/img/thedog2.jpeg"}
            alt="Honeycrisp Apple"
            width={300}
            height={300}
            className="h-[16rem] w-[20rem] object-cover rounded-md"
          />
          <div className="flex flex-row items-center justify-between mt-3">
            <h2 className="font-bold">{product.name}</h2>
            <button className="rounded-full p-1 bg-pink-500 hover:bg-pink-600">
              <IoIosAdd className="text-white text-3xl" />
            </button>
          </div>
          <div className="flex flex-col gap-2 mt-6">
            <p>${product.price}</p>
            <p className="text-zinc-400 text-sm">{product.description}</p>
          </div>
        </div>
      ))}
    </div>
  );
};

export default Cards;
