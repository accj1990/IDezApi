import { Token } from '@/http/Token';
import React from 'react';

type AuthContextType = {
  signIn: (data: { email: string; password: string ; token: Token}) => Promise<void>;
  signOut: () => Promise<void>;
};

export const AuthContext = React.createContext<AuthContextType>({
  signIn: async () => {

  },
  signOut: async () => {

  },
});