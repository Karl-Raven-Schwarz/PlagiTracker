import { StudentService as OpenAPIStudentService } from '@/api-client/services/StudentService'
import { ApiError } from '@/api-client/core/ApiError'

class StudentService {
  static async registerStudent(student: any): Promise<any> {
    try {
      return await OpenAPIStudentService.postApiStudentSignUp({ requestBody: student })
    } catch (error) {
      throw StudentService.normalizeError(error)
    }
  }

  static async loginStudent(email: string, passwordHash: string): Promise<any> {
    try {
      return await OpenAPIStudentService.postApiStudentLogIn({
        requestBody: { email, passwordHash }
      })
    } catch (error) {
      throw StudentService.normalizeError(error)
    }
  }

  static async sendResetPasswordEmail(email: string): Promise<any> {
    try {
      return await OpenAPIStudentService.postApiStudentSendResetPasswordEmail({ email })
    } catch (error) {
      throw StudentService.normalizeError(error)
    }
  }

  static async resetPasswordVerification(email: string, code: number): Promise<any> {
    try {
      return await OpenAPIStudentService.postApiStudentResetPasswordVerification({ email, code })
    } catch (error) {
      throw StudentService.normalizeError(error)
    }
  }

  static async resetPassword(payload: {
    email: string
    verificationCode: number
    newPasswordHash: string
  }): Promise<any> {
    try {
      return await OpenAPIStudentService.postApiStudentResetPassword({ requestBody: payload })
    } catch (error) {
      throw StudentService.normalizeError(error)
    }
  }

  static async getStudentsByCourse(courseId: string): Promise<any> {
    try {
      return await OpenAPIStudentService.getApiStudentGetAllByCourse({ courseId })
    } catch (error) {
      throw StudentService.normalizeError(error)
    }
  }

  private static normalizeError(error: any): any {
    if (error instanceof ApiError) {
      return {
        response: {
          status: error.status,
          data: error.body
        }
      }
    }
    return error
  }
}

export default StudentService
