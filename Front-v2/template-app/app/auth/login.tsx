import { apiClient } from '@/http/GenericClient';
import React, { useContext, useState } from 'react';
import { Alert, Button, StyleSheet, Text, TextInput, View } from 'react-native';
import { AuthContext } from '../../contexts/AuthContext';

const LoginScreen = () => {
  const {signIn} = useContext(AuthContext);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

 const handleLogin = async () => {
  if (!email || !password) {
    Alert.alert('Erro', 'Preencha todos os campos!');
    return;
  }
    try {
      var response = await apiClient.post('/api/post/Token', { email, password });
      console.log('Response Token:', response);
      const token = response.data;
      await signIn({ email, password, token: token });
    } catch (e) {
      Alert.alert('Erro', 'Falha no login!');
      console.log(e);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Login</Text>
      <TextInput
        placeholder="Email"
        value={email}
        onChangeText={setEmail}
        style={styles.input}
        keyboardType="email-address"
        autoCapitalize="none"
      />
      <TextInput
        placeholder="Senha"
        value={password}
        onChangeText={setPassword}
        style={styles.input}
        secureTextEntry
      />
      <Button title="Entrar" onPress={handleLogin} />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    paddingHorizontal: 20,
    backgroundColor: '#f5f5f5',
  },
  title: {
    fontSize: 28,
    fontWeight: 'bold',
    marginBottom: 20,
    textAlign: 'center',
  },
  input: {
    height: 50,
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 8,
    paddingHorizontal: 10,
    marginBottom: 15,
    backgroundColor: '#fff',
  },
});

export default LoginScreen;
