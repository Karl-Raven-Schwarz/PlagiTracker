import AssigmenstView from "@/views/Student/Assigments/AssigmentsView.vue";
import SubmitForm from "@/views/Student/Assigments/SubmitForm.vue";

import CoursesView from "@/views/Student/Courses/CoursesView.vue";
import ArchivedCoursesView from "@/views/Student/Courses/ArchivedCoursesView.vue";
import EnrollmentView from "@/views/Student/Enrollments/EnrollmentView.vue";

const assigmentsRoutes = [
  {
    path: '/student/submit/:id',
    name: 'StudentSubmit',
    component: SubmitForm,
    meta: {
      title: 'Submit',
      requiresAuth: true,
      allowedRoles: ['student']
    },
  },
  {
    path: '/student/courses',
    name: 'CoursesStudent',
    component: CoursesView,
    meta: {
      title: 'Courses',
      requiresAuth: true,
      allowedRoles: ['student']
    },
  },
  {
    path: '/student/archived-courses',
    name: 'ArchivedCoursesStudent',
    component: ArchivedCoursesView,
    meta: {
      title: 'Archived Courses',
      requiresAuth: true,
      allowedRoles: ['student']
    },
  },
  {
    path: '/student/assigments/:id',  // Dynamic segment for id
    name: 'AssigmentsStudent',
    component: AssigmenstView,
    meta: {
      title: 'My Assignments',
      requiresAuth: true,
      allowedRoles: ['student']
    },
  },
  {
    path: '/student/enrrolment',  // Dynamic segment for id
    name: 'Enrollments',
    component: EnrollmentView,
    meta: {
      title: 'Enrrolments',
      requiresAuth: true,
      allowedRoles: ['student']
    },
  }

];

export default assigmentsRoutes;
