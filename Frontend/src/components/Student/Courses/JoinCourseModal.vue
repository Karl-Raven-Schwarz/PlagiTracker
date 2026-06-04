<template>
  <div>
    <ModalLayout :modalOpen="modalOpen" @close="handleClose" :disableClose="isSubmitting">
      <template #default>
        <h3 class="pb-2 text-xl font-bold text-black dark:text-white sm:text-2xl">Join Course</h3>
        <form @submit.prevent="handleSubmit">
          <div>
            <label for="courseId" class="block mb-2 dark:text-white">Course Code</label>
            <input
              type="text"
              id="courseId"
              v-model="courseId"
              class="border dark:border-form-strokedark dark:bg-form-input dark:text-white rounded w-full px-3 py-2"
              placeholder="Paste the course code here"
              required
            />
          </div>

          <button
            type="submit"
            :disabled="isSubmitting"
            :class="[
              'mt-4 block w-full rounded p-3 text-white',
              isSubmitting ? 'bg-blue-300 cursor-not-allowed' : 'bg-blue-500 hover:bg-blue-600'
            ]"
          >
            {{ isSubmitting ? 'Joining...' : 'Join Course' }}
          </button>
        </form>
      </template>
    </ModalLayout>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import ModalLayout from '@/layouts/ModalLayout.vue'
import { useUserStore } from '@/stores/userStore'
import EnrollmentService from '@/services/EnrollmentService'
import Swal from 'sweetalert2'

const props = defineProps({
  modalOpen: Boolean
})

const emit = defineEmits(['close', 'joined'])

const courseId = ref('')
const isSubmitting = ref(false)

const userStore = useUserStore()

const handleClose = () => {
  emit('close')
}

const handleSubmit = async () => {
  try {
    isSubmitting.value = true
    const studentId = userStore.getUser?.id
    await EnrollmentService.createEnrollment(courseId.value, studentId)
    handleClose()
    emit('joined')
    Swal.fire({
      title: 'Joined!',
      text: 'You have joined the course successfully.',
      icon: 'success',
      confirmButtonText: 'Ok'
    })
  } catch (error: any) {
    handleClose()
    let message = 'An error occurred while trying to join.'
    if (error.response?.status === 409) {
      message = 'You are already enrolled in this course.'
    } else if (error.response?.status === 404) {
      message = 'Course not found.'
    }
    Swal.fire({
      title: 'Join Failed',
      text: message,
      icon: 'error',
      confirmButtonText: 'Try Again'
    })
  } finally {
    isSubmitting.value = false
    courseId.value = ''
  }
}
</script>
