/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly VITE_BACKEND_URL: string
  readonly VITE_ENCRYPT_KEY: string
  readonly VITE_IV: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}
