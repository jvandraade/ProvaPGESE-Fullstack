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
              <th>Documentos do Processo</th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  </template>

<script>
export default {
  data() {
    return {
      processos: []
    };
  },
  async mounted() {
    try {
      const response = await fetch('http://localhost:3000/processos');
      this.processos = await response.json();
    } catch (error) {
      console.error('Erro ao buscar processos:', error);
    }
  },
  methods: {
    // async editarProcesso(processo) {
    //   // Lógica para editar o processo
    // },
    async salvarProcesso(processo) {
      try {
        const response = await fetch(`http://localhost:3000/processos/${processo.id}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(processo),
        });

        if (response.ok) {
          alert('Processo salvo com sucesso!');
        } else {
          alert('Erro ao salvar processo.');
        }
      } catch (error) {
        console.error('Erro ao salvar processo:', error);
      }
    },
    async excluirProcesso(processo) {
      try {
        const response = await fetch(`http://localhost:3000/processos/${processo.id}`, {
          method: 'DELETE',
        });

        if (response.ok) {
          this.processos = this.processos.filter(p => p.id !== processo.id);
          alert('Processo excluído com sucesso!');
        } else {
          alert('Erro ao excluir processo.');
        }
      } catch (error) {
        console.error('Erro ao excluir processo:', error);
      }
    }
  }
};
</script>
  
  <style scoped>
  .logo {
    width: 100px;
    height: auto;
  }
  .title {
    text-align: center;
  }

  th {
  padding: 15px;
  text-align: center;
}
  </style>
  