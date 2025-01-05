import { FaRobot } from "react-icons/fa";

export const Bolha = ({ onClick, isActive }) => {
  return (
    <div
      onClick={onClick}
      className={`rounded-full ${isActive ? "bg-blue-600" : "bg-gray-400"} 
        animate-pulse bolha hover:scale-110 transition hover:animate-none 
        p-2 m-2 text-white cursor-pointer duration-300 
        flex items-center justify-center`}
    >
      <FaRobot className="text-6xl" />
    </div>
  );
};
