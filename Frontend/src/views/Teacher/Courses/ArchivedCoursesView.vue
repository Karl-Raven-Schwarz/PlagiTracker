<script setup lang="ts">
import DefaultLayout from '@/layouts/DefaultLayout.vue'
import CoursesList from '@/components/Teacher/Courses/CoursesList.vue'
import BreadcrumbDefault from '@/components/Breadcrumbs/BreadcrumbDefault.vue'
import { ref } from 'vue'

const pageTitle = ref('Archived Courses')
</script>

<template>
  <DefaultLayout>
    <BreadcrumbDefault :pageTitle="pageTitle" />
    <CoursesList :archived="true" />
  </DefaultLayout>
</template>
