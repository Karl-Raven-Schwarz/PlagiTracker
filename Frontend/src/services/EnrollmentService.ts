import { EnrollmentService as OpenAPIEnrollmentService } from '@/api-client/services/EnrollmentService'
import { ApiError } from '@/api-client/core/ApiError'

class EnrollmentService {
  static async createEnrollment(courseId: string, studentId: string): Promise<any> {
    try {
      return await OpenAPIEnrollmentService.postApiEnrollmentCreate({ courseId, studentId })
    } catch (error) {
      throw EnrollmentService.normalizeError(error)
    }
  }

  static async getAllEnrollmentsByStudent(): Promise<any> {
    try {
      return await OpenAPIEnrollmentService.getApiEnrollmentGetAllByStudent()
    } catch (error) {
      throw EnrollmentService.normalizeError(error)
    }
  }

  static async deleteEnrollment(courseId: string, studentId: string): Promise<any> {
    try {
      return await OpenAPIEnrollmentService.deleteApiEnrollmentDelete({
        requestBody: { courseId, studentId }
      })
    } catch (error) {
      throw EnrollmentService.normalizeError(error)
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

export default EnrollmentService
