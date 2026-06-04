import { TeacherService as OpenAPITeacherService } from '@/api-client/services/TeacherService'
import { ApiError } from '@/api-client/core/ApiError'

class TeacherService {
  static async registerTeacher(teacher: any): Promise<any> {
    try {
      return await OpenAPITeacherService.postApiTeacherSignUp({ requestBody: teacher })
    } catch (error) {
      throw TeacherService.normalizeError(error)
    }
  }

  static async loginTeacher(email: string, passwordHash: string): Promise<any> {
    try {
      return await OpenAPITeacherService.postApiTeacherLogIn({
        requestBody: { email, passwordHash }
      })
    } catch (error) {
      throw TeacherService.normalizeError(error)
    }
  }

  static async sendResetPasswordEmail(email: string): Promise<any> {
    try {
      return await OpenAPITeacherService.postApiTeacherSendResetPasswordEmail({ email })
    } catch (error) {
      throw TeacherService.normalizeError(error)
    }
  }

  static async resetPasswordVerification(email: string, code: number): Promise<any> {
    try {
      return await OpenAPITeacherService.postApiTeacherResetPasswordVerification({ email, code })
    } catch (error) {
      throw TeacherService.normalizeError(error)
    }
  }

  static async resetPassword(payload: {
    email: string
    verificationCode: number
    newPasswordHash: string
  }): Promise<any> {
    try {
      return await OpenAPITeacherService.postApiTeacherResetPassword({ requestBody: payload })
    } catch (error) {
      throw TeacherService.normalizeError(error)
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

export default TeacherService
