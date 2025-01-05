export interface ChatSession {
  id: string;
  email: string | null;
  messages: ChatMessage[];
  isCompleted: boolean;
  satisfaction: number | null;
}
