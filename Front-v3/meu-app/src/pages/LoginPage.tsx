import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { getToken, loginWithToken } from "../services/authService";
import LoginForm from "../components/LoginForm";

export default function LoginPage() {
  const navigate = useNavigate();
  const [error, setError] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(false);

  const handleLogin = async (email: string, password: string) => {
    setError("");
    setLoading(true);

    try {
      const token = await getToken();
      await loginWithToken(token, email, password);
      navigate("/welcome");
    } catch (err) {
      if (err instanceof Error) {
        setError(err.message);
      } else {
        setError("Erro inesperado.");
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <LoginForm onSubmit={handleLogin} error={error} loading={loading} />
    </div>
  );
}
