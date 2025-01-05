export const PesquisaSatisfacao = ({ onSelect }) => {
  const emojis = ["😢", "😕", "😐", "🙂", "😄"];

  return (
    <div className="p-4 border-t">
      <p className="text-center mb-2">Como foi sua experiência?</p>
      <div className="flex justify-center gap-4">
        {emojis.map((emoji, index) => (
          <button
            key={index}
            onClick={() => onSelect(index + 1)}
            className="text-2xl hover:scale-110 transition"
          >
            {emoji}
          </button>
        ))}
      </div>
    </div>
  );
};
