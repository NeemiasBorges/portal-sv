import React from "react";
import { PesquisaSatisfacao } from "../pesquisaSatisfacao";

export const CompletionButtons = ({
  chatSession,
  onComplete,
  onSatisfaction,
}) => (
  <>
    {!chatSession.isCompleted && chatSession.messages.length > 0 && (
      <div className="p-4 border-t">
        <p>A solicitação foi concluída?</p>
        <div className="flex gap-2">
          <button
            onClick={() => onComplete(true)}
            className="bg-green-500 text-white p-2 rounded"
          >
            Sim
          </button>
          <button
            onClick={() => onComplete(false)}
            className="bg-blue-500 text-white p-2 rounded"
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
