import Constants from 'expo-constants';

type HttpMethod = 'GET' | 'POST' | 'PUT' | 'DELETE';

interface RequestOptions<T = any> {
  method?: HttpMethod;
  headers?: Record<string, string>;
  body?: T;
}

export class GenericClientHttp {
  private baseUrl: string;
  private authToken?: string;

  constructor(urlKey: string) {
    const url = Constants.expoConfig?.extra?.[urlKey];
    if (!url) throw new Error(`Base URL não encontrada no app.json -> extra.${urlKey}`);
    this.baseUrl = url as string;
  }

  setAuthToken(token?: string) {
    this.authToken = token;
  }

  async request<TResponse = any, TRequest = any>(
    endpoint: string,
    options: RequestOptions<TRequest> = {}
  ): Promise<TResponse> {
    const url = `${this.baseUrl}${endpoint}`;
    const { method = 'GET', headers = {}, body } = options;

    const fetchOptions: RequestInit = {
      method,
      headers: {
        'Content-Type': 'application/json',
        ...headers,
        ...(this.authToken ? { Authorization: `Bearer ${this.authToken}` } : {}),
      },
    };

    if (body && method !== 'GET') fetchOptions.body = JSON.stringify(body);

    const response = await fetch(url, fetchOptions);

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`HTTP Error! status: ${response.status}, message: ${errorText}`);
    }

    try {
      return (await response.json()) as TResponse;
    } catch {
      return {} as TResponse;
    }
  }

  get<TResponse = any>(endpoint: string, headers?: Record<string, string>) {
    return this.request<TResponse>(endpoint, { method: 'GET', headers });
  }

  post<TResponse = any, TRequest = any>(
    endpoint: string,
    body: TRequest,
    headers?: Record<string, string>
  ) {
    return this.request<TResponse, TRequest>(endpoint, { method: 'POST', headers, body });
  }

  put<TResponse = any, TRequest = any>(
    endpoint: string,
    body: TRequest,
    headers?: Record<string, string>
  ) {
    return this.request<TResponse, TRequest>(endpoint, { method: 'PUT', headers, body });
  }

  delete<TResponse = any>(endpoint: string, headers?: Record<string, string>) {
    return this.request<TResponse>(endpoint, { method: 'DELETE', headers });
  }
}

export const apiClient = new GenericClientHttp('apiBaseUrl');
