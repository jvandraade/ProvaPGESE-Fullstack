<template>
  <div class="container mt-5">
    <header class="text-center mb-4">
      <img src="@/assets/images.jpeg" alt="logoPGE" class="img-fluid" style="max-width: 200px;">
      <h1 class="mt-3 text-primary">Procuradoria Geral do Estado de Sergipe</h1>
    </header>
    <div class="row justify-content-center">
      <div class="col-md-8">
        <h1 class="text-center">Editar Perfil</h1>
        <form @submit.prevent="salvarAlteracoes">
          <div class="form-group">
            <label for="nomeCompleto">Nome Completo</label>
            <input type="text" class="form-control" id="nomeCompleto" v-model="perfil.nomeCompleto" required>
          </div>
          <div class="form-group">
            <label for="cpf">CPF</label>
            <input type="text" class="form-control" id="cpf" v-model="perfil.cpf" disabled>
          </div>
          <div class="form-group">
            <label for="dataNascimento">Data de Nascimento</label>
            <input type="date" class="form-control" id="dataNascimento" v-model="perfil.dataNascimento" required>
          </div>
          <div class="form-group" v-if="perfil.tipo === 'procurador'">
            <label for="numeroOAB">Número da OAB</label>
            <input type="text" class="form-control" id="numeroOAB" v-model="perfil.numeroOAB" required>
          </div>
          <button type="submit" class="btn btn-primary">Salvar Alterações</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { api } from '@/services/api';

export default {
  data() {
    return {
      perfil: {
        nomeCompleto: '',
        cpf: '',
        dataNascimento: '',
        tipo: '',
        numeroOAB: '',
      },
    };
  },
  async carregarPerfil() {
    try {
      const id = localStorage.getItem('userId'); 
      const response = await api.get(`/api/Usuario/${id}`); 
      this.perfil = response.data;
    } catch (error) {
      console.error('Erro ao carregar perfil:', error);
    }
  },
  async salvarAlteracoes() {
    try {
      const id = localStorage.getItem('userId'); 
      await api.put(`/api/Usuario/${id}`, this.perfil); 
      alert('Perfil atualizado com sucesso!');
    } catch (error) {
      console.error('Erro ao atualizar perfil:', error);
      alert('Erro ao atualizar perfil.');
    }
  }
};
</script>
  
  <style scoped>
    .container {
      background-color: #f7f7f7;
      padding: 20px;
      border: 1px solid #ddd;
      border-radius: 10px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }
    .text-primary {
      color: #3498db;
    }
    .form-control {
      border-color: #ccc;
    }
    .form-control:focus {
      border-color: #3498db;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }
    .btn-primary {
      background-color: #3498db;
      border-color: #3498db;
    }
    .btn-primary:hover {
      background-color: #2980b9;
      border-color: #2980b9;
    }
  </style>