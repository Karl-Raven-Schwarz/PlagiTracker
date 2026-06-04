import { AssignmentService as OpenAPIAssignmentService } from '@/api-client/services/AssignmentService'
import { ApiError } from '@/api-client/core/ApiError'
import axiosInstance from './axiosInstance'

class AssignmentService {
  static async createAssignment(assignment: any): Promise<any> {
    try {
      return await OpenAPIAssignmentService.postApiAssignmentCreate({ requestBody: assignment })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async getAssignmentsByCourse(courseId: string): Promise<any> {
    try {
      return await OpenAPIAssignmentService.getApiAssignmentGetAllByCourseForStudent({ courseId })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async getAssignmentsByCourseForTeacher(courseId: string): Promise<any> {
    try {
      return await OpenAPIAssignmentService.getApiAssignmentGetAllByCourseForTeacher({ courseId })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async getAllByCourseForStudent(studentId: string, courseId: string): Promise<any> {
    try {
      return await OpenAPIAssignmentService.getApiAssignmentGetAllByCourseForStudent({ courseId })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async updateAssignment(assignment: any): Promise<any> {
    try {
      return await OpenAPIAssignmentService.putApiAssignmentUpdate({ requestBody: assignment })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async deleteAssignment(assignmentId: string): Promise<any> {
    try {
      return await OpenAPIAssignmentService.deleteApiAssignmentDelete({ id: assignmentId })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async getAssignmentById(assignmentId: string): Promise<any> {
    try {
      return await OpenAPIAssignmentService.getApiAssignmentGetById({ id: assignmentId })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async analyzeWithDolos(assignmentId: string, email: string): Promise<any> {
    try {
      return await OpenAPIAssignmentService.postApiAssignmentDolosAnalysisCustomEmail({
        assignmentId,
        email
      })
    } catch (error) {
      throw AssignmentService.normalizeError(error)
    }
  }

  static async analyzeAssignment(assignmentId: string): Promise<void> {
    const url = `/api/Assignment/Analyze?assignmentId=${assignmentId}`
    const response = await axiosInstance.post(url, {}, { responseType: 'blob' })
    const pdfBlob = new Blob([response.data], { type: 'application/pdf' })
    const downloadUrl = window.URL.createObjectURL(pdfBlob)
    const link = document.createElement('a')
    link.href = downloadUrl
    link.download = `PlagiarismReport-${assignmentId}.pdf`
    document.body.appendChild(link)
    link.click()
    document.body.removeChild(link)
    window.URL.revokeObjectURL(downloadUrl)
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

export default AssignmentService
