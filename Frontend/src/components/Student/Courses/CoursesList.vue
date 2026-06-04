<script setup lang="ts">
import { ref, onMounted } from 'vue'
import CourseCard from './CourseCard.vue'
import CourseService from '@/services/CourseService'
import LoadingSpinner from '@/components/LoadingSpinner.vue'

const enrollments = ref<any[]>([])
const isLoading = ref(false)

const fetchCourses = async () => {
  try {
    isLoading.value = true
    const response = await CourseService.getCoursesByStudent()
    enrollments.value = response.data ?? []
  } catch (error) {
    console.error('Error fetching courses:', error)
  } finally {
    isLoading.value = false
  }
}

onMounted(() => {
  fetchCourses()
})
</script>

<template>
  <LoadingSpinner :isLoading="isLoading" />

  <div v-if="!isLoading && enrollments.length === 0" class="text-gray-500 dark:text-gray-400 text-center mt-6">
    No courses available.
  </div>

  <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4 mt-6">
    <CourseCard
      v-for="enrollment in enrollments"
      :key="enrollment.course.id"
      :course="enrollment.course"
      @course-left="fetchCourses"
    />
  </div>
</template>
