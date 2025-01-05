import { useState } from "react";
import { PesquisaSatisfacao } from "../pesquisaSatisfacao";

export const CompletionButtons = ({
  chatSession,
  onComplete,
  onSatisfaction,
}) => {
  const [loading, setLoading] = useState(false);

  const handleComplete = (isCompleted) => {
    if (isCompleted) {
      setLoading(true);
      onComplete(true);
      setTimeout(() => {
        setLoading(false);
      }, 2000);
    } else {
      onComplete(false);
    }
  };

  return (
    <>
      {!chatSession.isCompleted && chatSession.messages.length > 0 && (
        <div className="p-4 border-t">
          <p>A solicitação foi concluída?</p>
          <div className="flex gap-2">
            <button
              onClick={() => handleComplete(true)}
              className={`bg-green-500 text-white p-2 rounded hover:bg-green-700 flex items-center justify-center`}
              disabled={loading}
            >
              {loading ? (
                // Apenas um teste, verificar se ficara ate o fim
                <svg
                  className="animate-spin h-5 w-5 text-white"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                >
                  <circle
                    className="opacity-25"
                    cx="12"
                    cy="12"
                    r="10"
                    stroke="currentColor"
                    strokeWidth="4"
                  ></circle>
                  <path
                    className="opacity-75"
                    fill="currentColor"
                    d="M4 12a8 8 0 018-8v8H4z"
                  ></path>
                </svg>
              ) : (
                "Sim"
              )}
            </button>
            <button
              onClick={() => handleComplete(false)}
              className="bg-blue-500 text-white p-2 rounded hover:bg-blue-700"
              disabled={loading}
            >
              Não
            </button>
          </div>
        </div>
      )}

      {chatSession.isCompleted && !chatSession.satisfaction && (
        <PesquisaSatisfacao onSelect={onSatisfaction} />
      )}
    </>
  );
};
