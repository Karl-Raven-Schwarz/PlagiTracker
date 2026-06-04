// src/stores/userStore.ts
import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import TeacherService from '@/services/TeacherService'
import StudentService from '@/services/StudentService'
import type { Teacher } from '@/types/Teacher'
import type { Student } from '@/types/Student'

export const useUserStore = defineStore('user', () => {
  const user = ref<any>(safeRead('user'))
  const role = ref<string | null>(safeRead('role'))
  const token = ref<string | null>(localStorage.getItem('token'))

  const getUser = computed(() => user.value)
  const getRole = computed(() => role.value)
  const getToken = computed(() => token.value)

  const setUser = (newUser: any) => {
    user.value = newUser
    if (newUser !== undefined && newUser !== null) {
      localStorage.setItem('user', JSON.stringify(newUser))
    } else {
      localStorage.removeItem('user')
    }
  }

  const setRole = (newRole: string) => {
    role.value = newRole
    if (newRole) {
      localStorage.setItem('role', newRole)
    } else {
      localStorage.removeItem('role')
    }
  }

  const setToken = (newToken: string | null) => {
    token.value = newToken
    if (newToken) {
      localStorage.setItem('token', newToken)
    } else {
      localStorage.removeItem('token')
    }
  }

  const login = async (email: string, password: string, userType: 'teacher' | 'student') => {
    try {
      let response: any
      if (userType === 'teacher') {
        response = await TeacherService.loginTeacher(email, password)
        setRole('teacher')
      } else if (userType === 'student') {
        response = await StudentService.loginStudent(email, password)
        setRole('student')
      }
      setUser(response)
      if (response?.token) {
        setToken(response.token)
      }
      return response
    } catch (error) {
      throw error
    }
  }

  const register = async (userData: Teacher | Student, userType: 'teacher' | 'student') => {
    try {
      let response: any
      if (userType === 'teacher') {
        response = await TeacherService.registerTeacher(userData as Teacher)
      } else if (userType === 'student') {
        response = await StudentService.registerStudent(userData as Student)
      }
      setUser(response)
      return response
    } catch (error) {
      throw error
    }
  }

  const clearUser = () => {
    user.value = null
    role.value = null
    token.value = null
    localStorage.removeItem('user')
    localStorage.removeItem('role')
    localStorage.removeItem('token')
  }

  return {
    getUser,
    getRole,
    getToken,
    setUser,
    setRole,
    setToken,
    login,
    register,
    clearUser
  }
})

function safeRead(key: string): any {
  const raw = localStorage.getItem(key)
  if (!raw || raw === 'undefined') return null
  try {
    return JSON.parse(raw)
  } catch {
    return raw
  }
}
