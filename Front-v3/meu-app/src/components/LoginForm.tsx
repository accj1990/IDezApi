import { useState } from "react";

type LoginFormProps = {
  onSubmit: (email: string, password: string) => void;
  error?: string;
  loading?: boolean;
};

export default function LoginForm({ onSubmit, error, loading }: LoginFormProps) {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(email, password);
  };

  return (
    <form
      onSubmit={handleSubmit}
      className="flex flex-col gap-4 max-w-sm mx-auto p-6 shadow rounded-xl bg-white"
    >
      <h2 className="text-2xl font-bold text-center">Login</h2>

      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        className="p-2 border rounded-lg"
        required
      />

      <input
        type="password"
        placeholder="Senha"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        className="p-2 border rounded-lg"
        required
      />

      {error && <p className="text-red-600 text-center">{error}</p>}

      <button
        type="submit"
        disabled={loading}
        className="p-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 disabled:opacity-50"
      >
        {loading ? "Carregando..." : "Entrar"}
      </button>
    </form>
  );
}
