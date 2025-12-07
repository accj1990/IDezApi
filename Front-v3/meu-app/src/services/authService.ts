import GenericClientHttp from "./http/GenericClientHttp";

const client = new GenericClientHttp("https://fakeapi.com");

export async function getToken(): Promise<string> {
  // Simula chamada ao endpoint de token
  const response = await client.post<null, { token: string }>("/token", null);
  return response.token ?? "fake-token-123";
}

export async function loginWithToken(
  token: string,
  email: string,
  password: string
): Promise<{ success: boolean }> {
  const response = await client.post<{ email: string; password: string }, { success: boolean }>(
    "/login",
    { email, password }
  );

  console.log("Token usado:", response);

  // Mock da lógica de validação
  if (token && email === "admin@teste.com" && password === "123456") {
    return { success: true };
  }

  throw new Error("Credenciais inválidas!");
}
