import { readFileSync, writeFileSync } from 'node:fs'
import { execSync } from 'node:child_process'
import { resolve, dirname } from 'node:path'
import { fileURLToPath } from 'node:url'

const __dirname = dirname(fileURLToPath(import.meta.url))
const root = resolve(__dirname, '..')

function loadEnv() {
  try {
    const env = readFileSync(resolve(root, '.env'), 'utf-8')
    for (const line of env.split('\n')) {
      const [key, ...rest] = line.split('=')
      if (key?.trim() === 'VITE_BACKEND_URL') return rest.join('=').trim()
    }
  } catch {}
  return null
}

const backendUrl = process.env.VITE_BACKEND_URL || loadEnv() || 'https://localhost:19200'
const swaggerUrl = `${backendUrl}/swagger/v1/swagger.json`

console.log(`Fetching OpenAPI spec from ${swaggerUrl}...`)

process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0'

const response = await fetch(swaggerUrl)
if (!response.ok) {
  console.error(`Failed to fetch: ${response.status} ${response.statusText}`)
  process.exit(1)
}

const spec = await response.json()
writeFileSync(resolve(root, 'swagger.json'), JSON.stringify(spec, null, 2))
console.log('Saved swagger.json')

console.log('Generating OpenAPI client...')
execSync(
  'npx openapi --input swagger.json --output src/api-client --client axios --useOptions --exportServices true --exportModels true --exportSchemas false',
  { cwd: root, stdio: 'inherit' }
)
console.log('Done!')
