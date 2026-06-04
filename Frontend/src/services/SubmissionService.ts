import { SubmissionService as OpenAPISubmissionService } from '@/api-client/services/SubmissionService'
import { ApiError } from '@/api-client/core/ApiError'

class SubmissionService {
  static async createSubmission(submission: any): Promise<any> {
    try {
      return await OpenAPISubmissionService.postApiSubmissionCreate({ requestBody: submission })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async getSubmissionById(submissionId: string): Promise<any> {
    try {
      return await OpenAPISubmissionService.getApiSubmissionGet({ id: submissionId })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async getSubmission(id: string): Promise<any> {
    try {
      return await OpenAPISubmissionService.getApiSubmissionGet({ id })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async getAllSubmissionsByStudent(studentId: string): Promise<any> {
    try {
      return await OpenAPISubmissionService.getApiSubmissionGetAllByStudent({ studentId })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async updateSubmission(submission: any, submissionDate: Date): Promise<any> {
    try {
      return await OpenAPISubmissionService.putApiSubmissionUpdate({
        requestBody: { ...submission, dateTime: submissionDate }
      })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async deleteSubmission(submissionId: string): Promise<any> {
    try {
      return await OpenAPISubmissionService.deleteApiSubmissionDelete({ id: submissionId })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async getAllByAssignment(assignmentId: string): Promise<any> {
    try {
      return await OpenAPISubmissionService.getApiSubmissionGetAllByAssignment({ assignmentId })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async verifySubmission(assignmentId: string, studentId: string): Promise<boolean> {
    try {
      return await OpenAPISubmissionService.getApiSubmissionVerifySubmission({
        assignmentId,
        studentId
      })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
    }
  }

  static async getSubmissionByAssignmentAndStudent(
    assignmentId: string,
    studentId: string
  ): Promise<any> {
    try {
      return await OpenAPISubmissionService.getApiSubmissionGetByAssignment({
        assignmentId,
        studentId
      })
    } catch (error) {
      throw SubmissionService.normalizeError(error)
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

export default SubmissionService
