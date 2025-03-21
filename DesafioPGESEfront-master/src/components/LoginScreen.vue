<template>
  <div class="container">
    <header class="header">
      <img src="@/assets/images.jpeg" alt="logoPGE" class="logo">
    </header>
    <main class="main">
      <h1 class="title">Procuradoria Geral do Estado de Sergipe</h1>
      <div class="login-area">
        <h1 class="login-title">Login</h1>
        <form @submit.prevent="login">
          <div class="form-group">
            <input type="text" class="form-control" v-model="cpf" placeholder="Insira seu CPF" required>
          </div>
          <div class="form-group">
            <input type="password" class="form-control" v-model="password" placeholder="Insira sua senha" required>
          </div>
          <button type="submit" class="btn btn-primary">Entrar</button>
          <button type="button" class="btn btn-secondary" @click="irParaCadastro">Cadastrar novo usuário</button>
        </form>
      </div>
    </main>
  </div>
</template>

<script>
import { api } from '@/services/api'; 

export default {
  data() {
    return {
      cpf: '',
      password: '',
    };
  },
  methods: {
    async login() {
      try {
        const response = await api.post('/api/Auth/login', { 
          cpf: this.cpf,
          password: this.password,
        }, {
        headers: {
          'Content-Type': 'application/json',
        }
        });
        
        const { token, usuario } = response.data;
        localStorage.setItem('token', token); 
        localStorage.setItem('tipoUsuario', usuario.tipo);

        console.log(response.data);
        if (usuario.tipo === 'cliente') {
          this.$router.push('/home-cliente');
        } else if (usuario.tipo === 'procurador') {
          this.$router.push('/home-procurador');
        }
      } catch (error) {
        console.error('Erro ao fazer login:', error);
        alert('CPF ou senha incorretos.');
      }
    },
    irParaCadastro() {
      this.$router.push('/cadastro-usuario');
    },
  },
};
</script>
  
  <style>
  .container {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
  }
  
  .header {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
    position: absolute;
    top: 0;
    left: 0;
    padding: 20px;
  }
  
  .logo {
    width: 200px;
    height: 200px;
    border-radius: 50%;
  }
  
  .main {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
  }
  
  .title {
    font-size: 36px;
    font-weight: bold;
    color: #333;
    text-align: center;
    margin: 0 auto;
    position: absolute;
    top: 30px;
    left: 50%;
    transform: translateX(-50%);
  }
  
  .login-area {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
    margin-top: 100px;
    border: 1px solid #ddd;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }
  
  .login-title {
    font-size: 24px;
    font-weight: bold;
    color: #333;
    margin-bottom: 20px;
  }
  
  .form-group {
    margin-bottom: 20px;
  }
  
  .form-control {
    width: 300px;
    height: 40px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
  }
  
  .btn-primary {
    background-color: #337ab7;
    color: #fff;
    border-color: #337ab7;
    padding: 10px 20px;
    font-size: 18px;
    font-weight: bold;
    margin-bottom: 10px;
    border-radius: 5px;
  }
  
  .btn-secondary {
    background-color: #5cb85c;
    color: #fff;
    border-color: #5cb85c;
    padding: 10px 20px;
    font-size: 18px;
    font-weight: bold;
    margin-bottom: 10px;
    border-radius: 5px;
  }
  </style>