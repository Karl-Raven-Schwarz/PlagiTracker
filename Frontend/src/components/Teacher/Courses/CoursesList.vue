<script setup lang="ts">
import { onMounted } from 'vue';
import { useCoursesStore } from '@/stores/coursesStore';
import CourseCard from './CourseCard.vue';
import LoadingSpinner from '@/components/LoadingSpinner.vue';

const props = defineProps<{
  archived?: boolean
}>()

const coursesStore = useCoursesStore();

const fetchCourses = async () => {
  await coursesStore.fetchCoursesByTeacher(props.archived ?? false);
};

onMounted(() => {
  fetchCourses();
});
</script>

<template>
  <!-- Loading screen -->
  <LoadingSpinner :isLoading="coursesStore.isLoading" />


  <!-- Show message if no courses are available -->
  <div v-if="!coursesStore.isLoading && coursesStore.courses.length === 0" class="text-gray-500 dark:text-gray-400 text-center mt-6">
    No courses available.
  </div>

  <!-- List of courses -->
  <div class="grid grid-cols-1 sm:grid-cols-2 gap-4 mt-6">
    <!-- Iterate over the list of courses and show a CourseCard for each one -->
    <CourseCard
      v-for="course in coursesStore.courses"
      :key="course.id"
      :course="course"
      @course-deleted="fetchCourses"
    />
  </div>
</template>
