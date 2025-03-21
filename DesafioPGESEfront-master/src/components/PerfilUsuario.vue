<template>
    <div class="perfil-usuario">
      <div class="perfil-icone" @click="toggleMenu">
        <i class="bi bi-person-circle" style="font-size: 24px; color: #000;"></i>
        <span class="nome-usuario">{{ nomeUsuario }}</span>
      </div>
      <div v-if="menuAberto" class="menu-perfil">
        <button class="btn btn-link" @click="editarPerfil">Editar Perfil</button>
        <button class="btn btn-link" @click="logout">Sair</button>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        menuAberto: false,
        nomeUsuario: 'Maria da Silva', // Substitua pelo nome do usuário logado
      };
    },
    methods: {
      toggleMenu() {
        this.menuAberto = !this.menuAberto;
      },
      editarPerfil() {
        this.$router.push('/editar-perfil');
      },
      logout() {
        // Lógica para encerrar a sessão
        localStorage.removeItem('usuarioLogado'); // Exemplo: remover dados do localStorage
        this.$router.push('/');
      },
    },
  };
  </script>
  
  <style scoped>
  .perfil-usuario {
  position: fixed; /* Fixa o ícone no canto superior direito */
  top: 20px;
  right: 20px;
  display: flex;
  align-items: center;
  cursor: pointer;
  z-index: 1000; /* Garante que o ícone fique acima de outros elementos */
}

.perfil-icone {
  display: flex;
  align-items: center;
  background-color: #f7f7f7; /* Fundo claro para destacar */
  padding: 8px 12px;
  border-radius: 20px; /* Bordas arredondadas */
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* Sombra sutil */
}

.nome-usuario {
  margin-left: 10px;
  font-size: 16px;
  font-weight: bold;
  color: #333; /* Cor do texto */
}

.menu-perfil {
  position: absolute;
  top: 40px;
  right: 0;
  background-color: #fff;
  border: 1px solid #ddd;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  padding: 10px;
  z-index: 1000;
}

.menu-perfil button {
  display: block;
  width: 100%;
  text-align: left;
  padding: 5px 10px;
  color: #333;
  text-decoration: none;
}

.menu-perfil button:hover {
  background-color: #f7f7f7;
}
  </style>