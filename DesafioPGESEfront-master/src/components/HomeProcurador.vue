<template>
    <div class="container">
      <header class="header">
        <img src="@/assets/images.jpeg" alt="logoPGE" class="logo">
        <PerfilUsuario />
      </header>
      <main class="main">
        <h1 class="title">Procuradoria Geral do Estado de Sergipe</h1>
        <div class="button-group">
          <button type="button" class="btn btn-info" @click="irParaListaDeProcessos">Lista de processos</button>
<button type="button" class="btn btn-info" @click="irParaProcessosEmAndamento">Processos em andamento</button>
<button type="button" class="btn btn-info" @click="irParaOutrosProcessos">Processos de outros procuradores</button>
        </div>
      </main>
      <footer class="footer">
      <button type="button" class="btn btn-success" @click="irParaCadastroProcesso">
        <i class="bi bi-plus-circle"></i> Cadastrar Novo Processo
      </button>
    </footer>
    </div>
  </template>

<script>
import 'bootstrap-icons/font/bootstrap-icons.css';
import PerfilUsuario from './PerfilUsuario.vue';

export default {
  
  components: {
    PerfilUsuario,
  },
  data() {
    return {
      usuarioTipo: 'cliente', 
    };
  }, methods: {
    irParaListaDeProcessos() {
      this.$router.push('/lista-processos');
    },
    irParaProcessosEmAndamento() {
      this.$router.push('/processos-andamento');
    },
    irParaOutrosProcessos() {
      this.$router.push('/outros-processos');
    },
    irParaCadastroProcesso() {
      this.$router.push('/cadastro-processo');
    },
  },
};
</script>

<style>
.container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100vw;
  background-color: #f7f7f7;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 20px;
  color: #fff; 
}

.logo {
  width: 50px;
  height: 50px;
  margin-right: 20px;
  color: #000;
}

.main {
  padding: 20px;
}

.user-info {
  display: flex;
  align-items: center;
  font-size: 18px;
  font-weight: bold;
  color: #333;
}

.user-info p {
  margin-right: 10px;
}

.main {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 40px;
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

.button-group {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
  margin-bottom: 20px;
  margin-right: 800px;
}

.btn-info {
  background-color: #337ab7; 
  color: #fff; 
  border-color: #337ab7; 
  padding: 10px 20px;
  font-size: 18px;
  font-weight: bold;
  margin-bottom: 10px;
}

.bi-person-circle {
  font-size: 48px;
  margin-left: 20px;
  color: #000;
}

.footer {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  background-color: #f7f7f7;
  padding: 10px;
  text-align: center;
  border-top: 1px solid #ddd;
}

.btn-cadastrar {
  font-size: 18px;
  font-weight: bold;
  padding: 12px 24px;
  border-radius: 30px; 
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); 
  transition: all 0.3s ease;
}

.btn-cadastrar:hover {
  transform: translateY(-2px);
  box-shadow: 0 6px 10px rgba(0, 0, 0, 0.15); 
}

.btn-cadastrar i {
  margin-right: 8px; 
}
</style>