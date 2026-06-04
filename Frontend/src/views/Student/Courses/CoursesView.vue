<script setup lang="ts">
import DefaultLayout from '@/layouts/DefaultLayout.vue'
import CoursesList from '@/components/Student/Courses/CoursesList.vue'
import BreadcrumbDefault from '@/components/Breadcrumbs/BreadcrumbDefault.vue'
import ButtonEvent from '@/components/Buttons/ButtonEvent.vue'
import JoinCourseModal from '@/components/Student/Courses/JoinCourseModal.vue'
import { ref } from 'vue'

const pageTitle = ref('My Courses')
const isModalOpen = ref(false)
const coursesListKey = ref(0)

const openModal = () => {
  isModalOpen.value = true
}

const handleModalClose = () => {
  isModalOpen.value = false
}

const handleJoined = () => {
  coursesListKey.value++
}
</script>

<template>
  <DefaultLayout>
    <BreadcrumbDefault :pageTitle="pageTitle" />

    <ButtonEvent label="Join Course" customClasses="bg-primary text-white" :onClick="openModal">
      <span>
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24">
          <g fill="#ffffff" fill-rule="evenodd" clip-rule="evenodd">
            <path d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10s-4.477 10-10 10S2 17.523 2 12m10-8a8 8 0 1 0 0 16a8 8 0 0 0 0-16"/>
            <path d="M13 7a1 1 0 1 0-2 0v4H7a1 1 0 1 0 0 2h4v4a1 1 0 1 0 2 0v-4h4a1 1 0 1 0 0-2h-4z"/>
          </g>
        </svg>
      </span>
    </ButtonEvent>
    <CoursesList :key="coursesListKey" />

    <JoinCourseModal :modalOpen="isModalOpen" @close="handleModalClose" @joined="handleJoined" />
  </DefaultLayout>
</template>
