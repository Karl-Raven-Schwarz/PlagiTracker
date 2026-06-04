import { defineStore } from 'pinia'
import { ref } from 'vue'
import CourseService from '@/services/CourseService'
import type { Course } from '@/types/Course'
import { useUserStore } from '@/stores/userStore'

export const useCoursesStore = defineStore('coursesStore', () => {
  const courses = ref<Course[]>([])
  const isLoading = ref(false)
  const errorMessage = ref('')

  const fetchCoursesByTeacher = async (archived: boolean = false) => {
    const userStore = useUserStore()
    const user = userStore.getUser
    courses.value = []
    errorMessage.value = ''
    if (user && user.id) {
      try {
        isLoading.value = true
        errorMessage.value = ''
        const coursesData = await CourseService.getAllByTeacher(archived)
        courses.value = coursesData.data ?? []
      } catch (error) {
        console.error('Error fetching courses:', error)
        errorMessage.value = 'Failed to load courses'
      } finally {
        isLoading.value = false
      }
    } else {
      console.error('User not authenticated or ID not available.')
      errorMessage.value = 'User not authenticated or ID not available.'
    }
  }

  return {
    courses,
    isLoading,
    errorMessage,
    fetchCoursesByTeacher
  }
})
