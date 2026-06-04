<script setup lang="ts">
import Swal from 'sweetalert2'
import EnrollmentService from '@/services/EnrollmentService'
import { useUserStore } from '@/stores/userStore'

const props = defineProps<{
  course: any
}>()

const emit = defineEmits<{
  (event: 'course-left'): void
}>()

const userStore = useUserStore()

const handleLeave = async () => {
  const { isConfirmed } = await Swal.fire({
    title: 'Are you sure?',
    text: 'You will leave this course.',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes, leave it!',
    cancelButtonText: 'Cancel'
  })

  if (isConfirmed) {
    try {
      const studentId = userStore.getUser?.id
      await EnrollmentService.deleteEnrollment(props.course.id, studentId)
      Swal.fire('Left!', 'You have left the course.', 'success')
      emit('course-left')
    } catch (error) {
      console.error('Error leaving course:', error)
      Swal.fire('Error!', 'There was a problem leaving the course.', 'error')
    }
  }
}
</script>

<template>
  <div class="max-w-md overflow-hidden border border-stroke shadow-lg bg-card text-card-foreground">
    <router-link :to="`/student/assigments/${props.course.id}`" class="block">
      <div class="bg-accent p-4">
        <h2 class="text-lg font-bold truncate">
          {{ props.course.name }}
        </h2>
        <p class="text-sm text-muted-foreground">
          {{ props.course.teacher?.firstName }} {{ props.course.teacher?.lastName }}
        </p>
      </div>
    </router-link>

    <div class="flex items-center bg-white dark:bg-boxdark justify-end p-4">
      <button
        @click="handleLeave"
        aria-label="Leave Course"
        class="text-muted hover:text-red transition-colors duration-200"
      >
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 24 24">
          <path fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 0 1-3 3H6a3 3 0 0 1-3-3V7a3 3 0 0 1 3-3h4a3 3 0 0 1 3 3v1"/>
        </svg>
      </button>
    </div>
  </div>
</template>
