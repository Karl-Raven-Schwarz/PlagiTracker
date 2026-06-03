import { OpenAPI } from '@/api-client'
import { useUserStore } from '@/stores/userStore'

export function configureApiClient() {
  OpenAPI.BASE = import.meta.env.VITE_BACKEND_URL ?? ''
  OpenAPI.TOKEN = async () => {
    const userStore = useUserStore()
    return userStore.getToken ?? ''
  }
}
