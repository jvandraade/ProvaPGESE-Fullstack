import { createRouter, createWebHistory } from 'vue-router';
import LoginScreen from '@/components/LoginScreen.vue';
import HomeCliente from '@/components/HomeCliente.vue';
import HomeProcurador from '@/components/HomeProcurador.vue';
import ListaDeProcessosScreen from '@/components/ListaDeProcessosScreen.vue';
import ProcessosEmAndamento from '@/components/ProcessosEmAndamento.vue';
import OutrosProcessos from '@/components/OutrosProcessos.vue';
import CadastroUsuarioScreen from '@/components/CadastroUsuarioScreen.vue';
import EditarPerfil from '@/components/EditarPerfil.vue';
import ProcessosEmAndamentoCliente from '@/components/ProcessosEmAndamentoCliente.vue';
import CadastroProcessoScreen from '@/components/CadastroProcessoScreen.vue';

const routes = [
  { path: '/', component: LoginScreen },
  { path: '/home-cliente', component: HomeCliente },
  { path: '/home-procurador', component: HomeProcurador },
  { path: '/lista-processos', component: ListaDeProcessosScreen },
  { path: '/processos-andamento', component: ProcessosEmAndamento },
  { path: '/outros-processos', component: OutrosProcessos },
  { path: '/cadastro-usuario', component: CadastroUsuarioScreen },
  { path: '/editar-perfil', component: EditarPerfil },
  { path: '/processos-andamento-cliente', component: ProcessosEmAndamentoCliente },
  { path: '/cadastro-processo', component: CadastroProcessoScreen },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;