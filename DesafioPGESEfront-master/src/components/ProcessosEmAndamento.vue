<template>
  <div class="container mt-4">
    <header class="d-flex align-items-center mb-4">
      <img src="@/assets/images.jpeg" alt="logoPGE" class="logo me-3">
      <h1 class="title mx-auto">Procuradoria Geral do Estado de Sergipe</h1>
    </header>
    
    <div class="table-responsive">
      <h1>Processos em Andamento</h1>
      <table class="table table-bordered table-striped">
        <thead class="table-primary text-center">
          <tr>
            <th>Nome do Processo</th>
            <th>Nome do Cliente</th>
            <th>Nome do Procurador</th>
            <th>Tipo de Processo</th>
            <th>Status do Processo</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="processo in processos" :key="processo.id">
            <td>
              <input v-if="processo.editando" v-model="processo.nome" class="form-control">
              <span v-else>{{ processo.nome }}</span>
            </td>
            <td>
              <input v-if="processo.editando" v-model="processo.cliente" class="form-control">
              <span v-else>{{ processo.cliente }}</span>
            </td>
            <td>
              <input v-if="processo.editando" v-model="processo.procurador" class="form-control">
              <span v-else>{{ processo.procurador }}</span>
            </td>
            <td>
              <input v-if="processo.editando" v-model="processo.tipo" class="form-control">
              <span v-else>{{ processo.tipo }}</span>
            </td>
            <td>
              <input v-if="processo.editando" v-model="processo.status" class="form-control">
              <span v-else>{{ processo.status }}</span>
            </td>
            <td>
              <button v-if="processo.editando" class="btn btn-success btn-sm" @click="salvarProcesso(processo)">
                Salvar
              </button>
              <button v-else class="btn btn-warning btn-sm" @click="editarProcesso(processo)">
                Editar
              </button>
              <button class="btn btn-danger btn-sm" @click="excluirProcesso(processo.id)">
                Excluir
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import api from '@/services/api';

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
        const response = await api.get('/api/Processo/em-andamento'); 
        this.processos = response.data.map(processo => ({ ...processo, editando: false })); 
      } catch (error) {
        console.error('Erro ao buscar processos:', error);
      }
    },
    editarProcesso(processo) {
      processo.editando = true;
    },
    async salvarProcesso(processo) {
      try {
        await api.put(`/api/Processo/${processo.id}`, processo);
        processo.editando = false; 
        alert('Processo atualizado com sucesso!');
      } catch (error) {
        console.error('Erro ao atualizar processo:', error);
        alert('Erro ao atualizar processo.');
      }
    },

    
    async excluirProcesso(id) {
      try {
        await api.delete(`/api/Processo/${id}`); 
        this.processos = this.processos.filter(p => p.id !== id); 
        alert('Processo excluído com sucesso!');
      } catch (error) {
        console.error('Erro ao excluir processo:', error);
        alert('Erro ao excluir processo.');
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

.logo {
  width: 100px;
  height: auto;
}

.title {
  text-align: center;
}

.table-responsive {
  margin-top: 20px;
}

.btn-sm {
  margin: 2px;
}
</style>