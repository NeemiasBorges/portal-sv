import { useEffect, useState } from "react";

const WithCustomProgressBar = ({ closeToast, toastProps, data }) => {
  const strokeDash = 2 * Math.PI * 90; // Comprimento total da circunferência do círculo
  const [dashOffset, setDashOffset] = useState(strokeDash); // Estado para animar o círculo

  useEffect(() => {
    // Atualiza o stroke-dashoffset conforme o progresso do toast
    const progress = toastProps.progress || 0; // Progresso varia entre 0 e 1
    setDashOffset((1 - progress) * strokeDash);
  }, [toastProps.progress]);

  return (
    <div className="flex justify-between items-center w-full">
      <p>{data.message}</p>
      <svg
        width="40"
        height="40"
        viewBox="-25 -25 250 250"
        version="1.1"
        xmlns="http://www.w3.org/2000/svg"
        className="-rotate-90"
      >
        {/* Círculo de fundo (base cinza) */}
        <circle
          r="90"
          cx="100"
          cy="100"
          fill="transparent"
          stroke="#e0e0e0"
          strokeWidth="6"
        />

        {/* Círculo de progresso animado */}
        <circle
          r="90"
          cx="100"
          cy="100"
          fill="transparent"
          stroke="#76e5b1"
          strokeWidth="16"
          strokeLinecap="round"
          strokeDasharray={strokeDash}
          strokeDashoffset={dashOffset} // Atualiza com base no progresso
          style={{
            transition: "stroke-dashoffset 0.2s ease-out", // Suaviza a animação
          }}
        />
      </svg>
    </div>
  );
};

export default WithCustomProgressBar;
