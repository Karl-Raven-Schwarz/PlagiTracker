<script setup lang="ts">
import FullScreenLayout from '@/layouts/FullScreenLayout.vue'
</script>

<template>
  <FullScreenLayout>
    <div class="flex items-center justify-center min-h-screen bg-gray-100 dark:bg-boxdark-2">
      <div class="text-center">
        <h1 class="text-4xl font-bold text-red-600 dark:text-red-400">Access Denied</h1>
        <p class="mt-4 text-lg text-gray-700 dark:text-gray-300">
          You do not have sufficient permissions to access this page.
        </p>
        <router-link
          to="/"
          class="mt-6 inline-block px-6 py-3 text-sm font-semibold text-white bg-blue-600 rounded hover:bg-blue-700"
        >
          Return to the home page
        </router-link>
      </div>
    </div>
  </FullScreenLayout>
</template>
