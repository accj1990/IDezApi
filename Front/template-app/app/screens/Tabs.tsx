import AsyncStorage from '@react-native-async-storage/async-storage';
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import React, { useContext } from "react";
import { Button, StyleSheet, Text, View } from "react-native";
import { AuthContext } from "../../contexts/AuthContext";

const Tab = createBottomTabNavigator();

 
function HomeScreen() {
  const { signOut } = useContext(AuthContext);
  const recuperarEmail = async () => {
    return await AsyncStorage.getItem('userEmail');
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Bem-vinda(o) {recuperarEmail()}👋</Text>
      <Text style={styles.subtitle}>Tela inicial do app</Text>
      <View style={{ marginTop: 20 }}>
        <Button title="Sair" onPress={signOut} />
      </View>
    </View>
  );
}

function ProfileScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>👤 Perfil</Text>
      <Text style={styles.subtitle}>Aqui ficam os dados do usuário</Text>
    </View>
  );
}

function SettingsScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>⚙️ Configurações</Text>
      <Text style={styles.subtitle}>Ajustes do aplicativo</Text>
    </View>
  );
}

export default function Tabs() {
  return (
    <Tab.Navigator screenOptions={{ headerShown: false }}>
      <Tab.Screen name="Início" component={HomeScreen} />
      <Tab.Screen name="Perfil" component={ProfileScreen} />
      <Tab.Screen name="Configurações" component={SettingsScreen} />
    </Tab.Navigator>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center", padding: 20 },
  title: { fontSize: 26, fontWeight: "700" },
  subtitle: { fontSize: 16, color: "#666", marginTop: 8 },
});
