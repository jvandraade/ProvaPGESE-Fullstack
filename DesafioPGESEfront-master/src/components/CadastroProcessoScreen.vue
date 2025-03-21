<template>
    <div class="container">
        <header class="text-center mb-4">
        <img src="@/assets/images.jpeg" alt="logoPGE" class="img-fluid" style="max-width: 200px;">
        <h1 class="mt-3">Procuradoria Geral do Estado de Sergipe</h1>
      </header>
      <h1>Cadastro de novo processo</h1>
      <form @submit.prevent="">
        <div class="form-group">
          <label>Nome do procurador</label>
          <input type="text" class="form-control" v-model="procuradorName" />
        </div>
        <div class="form-group">
          <label>CPF</label>
          <input type="text" class="form-control" v-model="procuradorCpf" />
        </div>
        <div class="form-group">
          <label>Número de série OAB</label>
          <input type="text" class="form-control" v-model="procuradorOabNumber" />
        </div>
        <h1>Informações do cliente</h1>
        <div class="form-group">
          <label>Nome do cliente</label>
          <input type="text" class="form-control" v-model="clientName" />
        </div>
        <div class="form-group">
          <label>Número do processo</label>
          <input type="text" class="form-control" v-model="processNumber" />
        </div>
        <div class="form-group">
          <label>Descrição</label>
          <textarea class="form-control" v-model="processDescription"></textarea>
        </div>
        <div class="form-group">
          <label>Status</label>
          <select class="form-control" v-model="processStatus">
            <option value="em_andamento">Em andamento</option>
            <option value="concluido">Concluído</option>
          </select>
        </div>
        <div class="form-group">
          <label>Data de validade</label>
          <input type="date" class="form-control" v-model="processValidityDate" />
        </div>
        <div class="form-group">
          <label>Conteúdos do processo</label>
          <input type="file" class="form-control" v-on:change="processContents" />
        </div>
        <button type="submit" class="btn btn-primary" @click="cadastrarProcesso">Cadastrar processo</button>
      </form>
    </div>
  </template>
  
  <script>
  import { api } from '@/services/api';


  export default {
    data() {
      return {
        procuradorName: '',
        procuradorCpf: '',
        procuradorOabNumber: '',
        clientName: '',
        processNumber: '',
        processDescription: '',
        processValidityDate: '',
        processContents: ''
      }
    },
    methods: {
    async cadastrarProcesso() {
      const novoProcesso = {
        procuradorName: this.procuradorName,
        procuradorCpf: this.procuradorCpf,
        procuradorOabNumber: this.procuradorOabNumber,
        clientName: this.clientName,
        clientCpf: this.clientCpf,
        clientEmail: this.clientEmail,
        processNumber: this.processNumber,
        processDescription: this.processDescription,
        processResponsible: this.processResponsible,
        processStatus: this.processStatus,
        processValidityDate: this.processValidityDate,
        processWitnesses: this.processWitnesses,
        processContents: this.processContents,
      };

      try {
        const response = await api.post('/api/ProcessoJuridico/', novoProcesso); 
        console.log('Processo cadastrado:', response.data);
        alert('Processo cadastrado com sucesso!');
      } catch (error) {
        console.error('Erro ao cadastrar processo:', error);
        alert('Erro ao cadastrar processo.');
      }
    },
  },
};
</script>
