<template>
    <div class="container">
      <header class="text-center mb-4">
        <img src="@/assets/images.jpeg" alt="logoPGE" class="img-fluid" style="max-width: 200px">
        <h1 class="mt-3">Procuradoria Geral do Estado de Sergipe</h1>
      </header>
      <div>
        <h2>Filtrar processos de outros procuradores</h2>
        <form>
          <div class="form-group">
            <label for="procurador">Selecione o procurador:</label>
            <select class="form-control" id="procurador" v-model="procuradorSelecionado">
              <option value="">Todos os procuradores</option>
              <option v-for="procurador in procuradores" :key="procurador.id" :value="procurador.id">{{ procurador.nome }}</option>
            </select>
          </div>
          <div class="form-group">
            <label for="numeroProcesso">Número do processo:</label>
            <input type="text" class="form-control" id="numeroProcesso" v-model="numeroProcesso">
          </div>
          <button type="submit" class="btn btn-primary" @click.prevent="filtrarProcessos">Filtrar</button>
        </form>
        <div v-if="processosFiltrados.length > 0">
          <h3>Processos filtrados:</h3>
          <ul>
            <li v-for="processo in processosFiltrados" :key="processo.id">{{ processo.numero }} - {{ processo.titulo }}</li>
          </ul>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        procuradores: [],
        procuradorSelecionado: '',
        numeroProcesso: '',
        processosFiltrados: []
      }
    },
    mounted() {
      // Aqui você pode fazer uma requisição para buscar os procuradores e processos
      // e preencher os dados nos arrays
    },
    methods: {
      filtrarProcessos() {
        // Aqui você pode fazer a lógica para filtrar os processos com base nos dados selecionados
        // e atualizar o array de processos filtrados
      }
    }
  }
  </script>

<style scoped>
  .container {
    background-color: #f7f7f7;
    padding: 20px;
    border: 1px solid #ddd;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }
  .text-center {
    margin-bottom: 20px;
  }
  .mb-4 {
    margin-bottom: 40px;
  }
  .mt-3 {
    margin-top: 30px;
  }
  .form-group {
    margin-bottom: 20px;
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
  .list-group {
    margin-top: 20px;
  }
  .list-group-item {
    padding: 10px;
    border-bottom: 1px solid #ddd;
  }
  .list-group-item:last-child {
    border-bottom: none;
  }
</style>