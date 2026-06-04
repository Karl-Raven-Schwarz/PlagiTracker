import { CourseService as OpenAPICourseService } from '@/api-client/services/CourseService'
import { ApiError } from '@/api-client/core/ApiError'

class CourseService {
  static async createCourse(course: any): Promise<any> {
    try {
      return await OpenAPICourseService.postApiCourseCreate({ requestBody: course })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async getCourseById(courseId: string): Promise<any> {
    try {
      return await OpenAPICourseService.getApiCourseGetById({ id: courseId })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async getCourseByName(name: string): Promise<any> {
    try {
      return await OpenAPICourseService.getApiCourseGetByName({ name })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async getCoursesByStudent(archived: boolean = false): Promise<any> {
    try {
      return await OpenAPICourseService.getApiCourseGetAll({ archived })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async getAllByTeacher(archived: boolean = false): Promise<any> {
    try {
      return await OpenAPICourseService.getApiCourseGetAll({ archived })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async updateCourse(course: any): Promise<any> {
    try {
      return await OpenAPICourseService.putApiCourseUpdate({ requestBody: course })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async deleteCourse(courseId: string): Promise<any> {
    try {
      return await OpenAPICourseService.deleteApiCourseDelete({ id: courseId })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async archiveCourse(courseId: string): Promise<any> {
    try {
      return await OpenAPICourseService.deleteApiCourseArchive({ id: courseId })
    } catch (error) {
      throw CourseService.normalizeError(error)
    }
  }

  static async unarchiveCourse(courseId: string): Promise<any> {
    try {
      return await OpenAPICourseService.deleteApiCourseUnarchive({ id: courseId })
    } catch (error) {
      throw CourseService.normalizeError(error)
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

export default CourseService
