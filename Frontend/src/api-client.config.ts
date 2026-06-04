import { OpenAPI } from '@/api-client'
import { useUserStore } from '@/stores/userStore'

export function configureApiClient() {
  OpenAPI.BASE = ''
  OpenAPI.TOKEN = async () => {
    const userStore = useUserStore()
    return userStore.getToken ?? ''
  }
}
