import { apiClient } from '@/http/GenericClientHttp';
import { Token } from '@/http/Token';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import React, { useEffect, useMemo, useState } from 'react';
import { ActivityIndicator, View } from 'react-native';
import { AuthContext } from '../contexts/AuthContext';
import LoginScreen from './screens/LoginScreen';
import Tabs from './screens/Tabs';

const Stack = createNativeStackNavigator();

const Layout = () => {
  const [userToken, setUserToken] = useState<Token | null>(null);
  const [userEmail, setUserEmail] = useState<string | null>(null);

  const [loading, setLoading] = useState(true);

  const authContext = useMemo(() => ({
    signIn: async (data: { email: string; password: string; token: Token }) => {
      apiClient.setAuthToken(data.token.access_token);
      var response = await apiClient.post('/api/post/Login', {
        username: data.email,
        password: data.password,
      });

      console.log('Response Login:', response);
      if (response.businessRuleViolation){
        await AsyncStorage.removeItem('userToken');
        setUserToken(null);
        setUserEmail(null);
      }
      else{
        await AsyncStorage.setItem('userToken', JSON.stringify(data.token));
        setUserToken(data.token);
        await AsyncStorage.setItem('userEmail', data.email);
        setUserEmail(data.email);
      }

    },
    signOut: async () => {
      const utoken = await AsyncStorage.getItem('userToken');
      const email = await AsyncStorage.getItem('userEmail');
      var response = await apiClient.post('/api/post/Logout', {
        username: email,
        idtoken: utoken
      });
      debugger;
      console.log('Response Logout:', response);
      const token = await AsyncStorage.removeItem('userToken');
      setUserToken(null);
      await AsyncStorage.removeItem('userEmail');
      setUserEmail(null);
      apiClient.setAuthToken("");

    },
  }), []);

  useEffect(() => {
    const loadToken = async () => {
      try {
        const token = await AsyncStorage.getItem('userToken');
        //setUserToken(token);
        const email = await AsyncStorage.getItem('userEmail');
        //setUserToken(email);
      } catch (e) {
        console.log('Erro ao carregar token', e);
      } finally {
        setLoading(false);
      }
    };
    loadToken();
  }, []);

  if (loading) {
    debugger;
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  

return (
  <AuthContext.Provider value={authContext}>
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      {!userToken ? (
        <Stack.Screen name="Login" component={LoginScreen} />
      ) : (
        <Stack.Screen name="Tabs" component={Tabs} />
      )}
    </Stack.Navigator>
  </AuthContext.Provider>
);


};

export default Layout;

