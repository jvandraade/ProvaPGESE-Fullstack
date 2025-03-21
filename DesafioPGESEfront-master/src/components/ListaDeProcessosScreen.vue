<template>
  <div class="container mt-4">
    <header class="d-flex align-items-center mb-4">
      <img src="@/assets/images.jpeg" alt="logoPGE" class="logo me-3">
      <h1 class="title mx-auto">Procuradoria Geral do Estado de Sergipe</h1>
    </header>
    <div class="card p-4 shadow-sm">
      <h2 class="text-center text-primary">Lista de Processos</h2>
      <table class="table table-striped mt-3">
        <thead class="table-dark">
          <tr>
            <th>Processo</th>
            <th>Procurador</th>
            <th>ID do Processo</th>
            <th>Cliente</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="processo in processos" :key="processo.numUnico">
            <td>{{ processo.numeroProcesso }}</td>
            <td>{{ processo.procuradorId }}</td>
            <td>{{ processo.numUnico }}</td>
            <td>{{ processo.clientes.map(cliente => cliente.nome).join(', ') }}</td>
            <td>{{ processo.status }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import{ api } from '@/services/api'; 

export default {
  data() {
    return {
      processos: [], 
    };
  },
  async created() {
    await this.carregarProcessos();
  },
  methods: {
    async carregarProcessos() {
      try {
        const procuradorId = localStorage.getItem('userId'); 
        const response = await api.get(`/api/ProcessoJuridico?procuradorId=${procuradorId}`); 
        this.processos = response.data;
      } catch (error) {
        console.error('Erro ao buscar processos:', error);
      }
    },
  },
};
</script>
  
  <style scoped>
  .logo {
    width: 120px;
    height: auto;
  }
  .title {
    font-size: 1.8rem;
    text-align: center;
    flex-grow: 1;
  }
  p {
    font-weight: bold;
    text-transform: uppercase;
  }

  th {
  padding: 15px;
  text-align: center;
}
  </style>