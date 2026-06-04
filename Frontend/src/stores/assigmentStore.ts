import { defineStore } from 'pinia';
import { ref } from 'vue';
import AssignmentService from '@/services/AssigmentService';
import type { Assignment } from '@/types/Assigment';

export const useAssignmentStore = defineStore('assignment', () => {
  const assignments = ref<Assignment[]>([]);
  const isLoading = ref(false);
  const errorMessage = ref('');

  const fetchAssignmentsByCourse = async (courseId: string) => {
    isLoading.value = true;
    errorMessage.value = '';
    assignments.value = [];

    try {
      const response = await AssignmentService.getAssignmentsByCourseForTeacher(courseId);
      assignments.value = response.data ?? [];
    } catch (error) {
      console.error('Error fetching assignments:', error);
      errorMessage.value = 'Failed to load assignments';
    } finally {
      isLoading.value = false;
    }
  };

  return {
    assignments,
    isLoading,
    errorMessage,
    fetchAssignmentsByCourse,
  };
});
