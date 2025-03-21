<template>
  <div class="container mt-5">
    <header class="text-center mb-4">
      <img src="@/assets/images.jpeg" alt="logoPGE" class="img-fluid" style="max-width: 200px;">
      <h1 class="mt-3">Procuradoria Geral do Estado de Sergipe</h1>
    </header>
    <div class="card p-4 shadow-sm">
      <h2 class="text-center">Cadastro de Usuário</h2>
      
      <div class="mb-3 text-center">
        <label class="form-label">Tipo de Usuário:</label>
        <div class="btn-group">
          <button class="btn btn-primary" @click="tipoUsuario = 'cliente'">Cliente</button>
          <button class="btn btn-secondary" @click="tipoUsuario = 'procurador'">Procurador</button>
        </div>
      </div>

      <form @submit.prevent="cadastrarUsuario">
        <div v-if="tipoUsuario === 'cliente'">
          <div class="mb-3">
            <label class="form-label">Nome Completo</label>
            <input type="text" class="form-control" v-model="form.nome" required>
          </div>
          <div class="mb-3">
            <label class="form-label">CPF</label>
            <input type="text" class="form-control" v-model="form.cpf" @input="formatarCPF" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Email</label>
            <input type="email" class="form-control" v-model="form.email" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Senha</label>
            <input type="password" class="form-control" v-model="form.senha" required>
          </div>
        </div>
        
        <div v-if="tipoUsuario === 'procurador'">
          <div class="mb-3">
            <label class="form-label">Nome Completo</label>
            <input type="text" class="form-control" v-model="form.nome" required>
          </div>
          <div class="mb-3">
            <label class="form-label">CPF</label>
            <input type="text" class="form-control" v-model="form.cpf" @input="formatarCPF" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Número de Série da OAB</label>
            <input type="text" class="form-control" v-model="form.oab" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Email</label>
            <input type="email" class="form-control" v-model="form.email" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Senha</label>
            <input type="password" class="form-control" v-model="form.senha" required>
          </div>
        </div>
        
        <button type="submit" class="btn btn-success w-100">Cadastrar Usuário</button>
      </form>
    </div>
  </div>
</template>

<script>
import { api } from '@/services/api'; 

export default {
  data() {
    return {
      tipoUsuario: '',
      form: {
        nome: '',
        cpf: '',
        email: '',
        senha: '',
        oab: '', 
      },
    };
  },
  methods: {
    formatarCPF() {
      let cpf = this.form.cpf.replace(/\D/g, '').slice(0, 11);
      cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
      cpf = cpf.replace(/(\d{3})\.(\d{3})(\d)/, '$1.$2.$3');
      cpf = cpf.replace(/(\d{3})\.(\d{3})\.(\d{3})(\d)/, '$1.$2.$3-$4');
      this.form.cpf = cpf;
    },
    
    async cadastrarUsuario() {
      const usuario = {
        nome: this.form.nome,
        cpf: this.form.cpf,
        email: this.form.email,
        senha: this.form.senha,
        tipo: this.tipoUsuario,
        codigoOAB: this.form.oab
      };

      try {
        const response = await api.post('/api/Usuario/', usuario);
        if (response.status === 201) {
          alert('Cadastro realizado com sucesso!');
          this.$router.push('/'); 
        }
      } catch (error) {
        console.error('Erro ao cadastrar usuário:', error);
        alert('Erro ao cadastrar usuário.');
      }
    },
  },
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

.card {
  max-width: 600px;
  margin: auto;
}

.btn-group button {
  width: 120px;
}

.form-control {
  border-color: #ccc;
}

.form-control:focus {
  border-color: #3498db;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.btn-success {
  background-color: #28a745;
  border-color: #28a745;
}

.btn-success:hover {
  background-color: #218838;
  border-color: #218838;
}
</style>