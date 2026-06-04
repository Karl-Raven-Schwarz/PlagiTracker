import axios from 'axios';
import router from '@/router/index';

const axiosInstance = axios.create({
  baseURL: '',
  headers: {
    'Content-Type': 'application/json'
  }
});

axiosInstance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token && token !== 'undefined') {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    const statusCode = error.response ? error.response.status : null;

    if (statusCode >= 500) {
      router.push({ name: 'ServerError' });
    }

    if (error.message === 'Network Error' || error.code === 'ERR_CONNECTION_REFUSED') {
      router.push({ name: 'ServerError' });
    }

    return Promise.reject(error);
  }
);

export default axiosInstance;
