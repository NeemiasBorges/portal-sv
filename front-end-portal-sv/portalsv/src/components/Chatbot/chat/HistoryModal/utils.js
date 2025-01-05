export const parseMessages = (data) => {
  try {
    const cleanData = data.replace(/^"|"$/g, "");
    return JSON.parse(cleanData);
  } catch (error) {
    console.error("Erro ao fazer parse do JSON:", error);
    return [];
  }
};

export const formatTimestamp = (timestamp) => {
  try {
    return new Date(timestamp).toLocaleTimeString();
  } catch (error) {
    return timestamp;
  }
};
