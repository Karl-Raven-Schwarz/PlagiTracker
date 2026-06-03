import './assets/css/satoshi.css'
import './assets/css/style.css'
//import 'jsvectormap/dist/css/jsvectormap.min.css'
import 'flatpickr/dist/flatpickr.min.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import VueApexCharts from 'vue3-apexcharts'

import App from './App.vue'
import router from './router'
import { configureApiClient } from './api-client.config'

import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';


const app = createApp(App)

app.use(createPinia())
configureApiClient()
app.use(router)
app.use(VueSweetalert2);
app.use(VueApexCharts)

app.mount('#app')
