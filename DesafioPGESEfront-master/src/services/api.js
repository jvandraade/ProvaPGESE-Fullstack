import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44350',
  // headers: {
  //   // Authorization: 'Bearer ' + localStorage.getItem('Token'),
  //   'Content-Type': 'application/json', 
  // },
});

 api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token'); 
   if (token) {
    config.headers.Authorization = `Bearer ${token}`; 
  }
 return config;
 });

const UsuarioService = {
  async listarUsuarios() {
    try {
      const response = await api.get('/api/Usuario');
      return response.data;
    } catch (error) {
      console.error('Erro ao listar usuários:', error);
      throw error;
    }
  },

  async buscarUsuarioPorId(id) {
    try {
      const response = await api.get(`/api/Usuario/${id}`);
      return response.data;
    } catch (error) {
      console.error('Erro ao buscar usuário:', error);
      throw error;
    }
  },

  async criarUsuario(usuario) {
    try {
      const response = await api.post('/api/Usuario', usuario);
      return response.data;
    } catch (error) {
      console.error('Erro ao criar usuário:', error);
      throw error;
    }
  },

  async atualizarUsuario(id, usuario) {
    try {
      const response = await api.put(`/api/Usuario/${id}`, usuario);
      return response.data;
    } catch (error) {
      console.error('Erro ao atualizar usuário:', error);
      throw error;
    }
  },

  async excluirUsuario(id) {
    try {
      const response = await api.delete(`/api/Usuario/${id}`);
      return response.data;
    } catch (error) {
      console.error('Erro ao excluir usuário:', error);
      throw error;
    }
  },
};

export { api, UsuarioService };
