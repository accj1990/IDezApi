export interface Token {
  id_token: string;
  access_token: string;
  token_type: string;
  expires_in: number;
  refresh_token?: string;
  expirationDate: Date;
  refresh_expires_in: number;
  not_before_policy: number;
  session_state: string;
  scope: string;
  userId?: string;
  username?: string;
}
