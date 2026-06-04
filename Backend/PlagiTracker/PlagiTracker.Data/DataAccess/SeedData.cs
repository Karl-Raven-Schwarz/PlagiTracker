using PlagiTracker.Data.Entities;

namespace PlagiTracker.Data.DataAccess
{
    public static class SeedData
    {
        private static readonly DateTime MinDate = DateTime.MinValue.ToUniversalTime();

        private static readonly byte[] PasswordHash = new byte[]
        {
            0x5e, 0x88, 0x48, 0x98, 0xda, 0x28, 0x04, 0x71,
            0x51, 0xd0, 0xe5, 0x6f, 0x8d, 0xc6, 0x29, 0x27,
            0x73, 0x60, 0x3d, 0x0d, 0x6a, 0xab, 0xbd, 0xd6,
            0x2a, 0x11, 0xef, 0x72, 0x1d, 0x15, 0x42, 0xd8,
            0xaf, 0xdc, 0x75, 0x0c, 0xfd, 0xb7, 0x58, 0x77,
            0x2f, 0xc0, 0x5a, 0x62, 0x49, 0x17, 0xc7, 0x6c
        };

        private static readonly byte[] PasswordHashShort = new byte[]
        {
            0x5e, 0x88, 0x48, 0x98, 0xda, 0x28, 0x04, 0x71,
            0x51, 0xd0, 0xe5, 0x6f, 0x8d, 0xc6, 0x29, 0x27,
            0x73, 0x60, 0x3d, 0x0d, 0x6a, 0xab, 0xbd, 0xd6,
            0x2a, 0x11, 0xef, 0x72, 0x1d, 0x15, 0x42, 0xd8
        };

        private static Teacher MakeTeacher(Guid id, string firstName, string lastName, string email,
            byte[] pwdHash, int logInAttempts = 0, bool isLocked = false, DateTime? unlockDate = null,
            int verificationCode = 0, bool isVerified = false, DateTime? verificationCodeExpiration = null,
            int resetPasswordAttempts = 0, DateTime? createdAt = null)
        {
            return new Teacher
            {
                Id = id, FirstName = firstName, LastName = lastName, Email = email,
                PasswordHash = pwdHash, LogInAttempts = logInAttempts, IsLocked = isLocked,
                UnlockDate = unlockDate ?? MinDate, VerificationCode = verificationCode,
                IsVerified = isVerified, VerificationCodeExpiration = verificationCodeExpiration ?? MinDate,
                ResetPasswordAttempts = resetPasswordAttempts, IsEnabled = true,
                CreatedAt = createdAt ?? MinDate, UpdatedAt = MinDate
            };
        }

        private static Student MakeStudent(Guid id, string firstName, string lastName, string email,
            byte[] pwdHash, int logInAttempts = 0, bool isLocked = false, DateTime? unlockDate = null,
            int verificationCode = 0, bool isVerified = false, DateTime? verificationCodeExpiration = null,
            int resetPasswordAttempts = 0, DateTime? createdAt = null)
        {
            return new Student
            {
                Id = id, 
                FirstName = firstName, 
                LastName = lastName, 
                Email = email,
                PasswordHash = pwdHash, 
                LogInAttempts = logInAttempts, 
                IsLocked = isLocked,
                UnlockDate = unlockDate ?? MinDate, 
                VerificationCode = verificationCode,
                IsVerified = isVerified, 
                VerificationCodeExpiration = verificationCodeExpiration ?? MinDate,
                ResetPasswordAttempts = resetPasswordAttempts, 
                IsEnabled = true,
                CreatedAt = createdAt ?? MinDate, 
                UpdatedAt = MinDate
            };
        }

        public static IEnumerable<Teacher> GetTeachers()
        {
            return new List<Teacher>
            {
                MakeTeacher(Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c102"),
                    "Pablo", "Illanes", "pillanes@plagitracker.com", PasswordHash),
                MakeTeacher(Guid.Parse("0392d24c-a1f5-4022-8278-cfa4efb14b8c"),
                    "Luis", "Kennedy", "lkennedy@plagitracker.com", PasswordHash,
                    logInAttempts: 2,
                    unlockDate: DateTime.Parse("2024-10-07T19:53:02.247-05:00").ToUniversalTime()),
                MakeTeacher(Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    "Anas", "Laghari", "alaghari@plagitracker.com", PasswordHashShort,
                    verificationCode: 10000000),
                MakeTeacher(Guid.Parse("865bf0cc-1fe7-4203-944e-f353540d7210"),
                    "Luis Enrique", "Riquelme", "lriquelme@plagitracker.com", PasswordHashShort,
                    verificationCode: 10000000),
            };
        }

        public static IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                MakeStudent(Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b8"),
                    "Bastian", "Schweinsteiger", "bschweinsteiger@plagitracker.com", PasswordHashShort,
                    verificationCode: 10000000),
                MakeStudent(Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b2"),
                    "Aron", "Poulsen", "apoulsen@plagitracker.com", PasswordHashShort,
                    verificationCode: 10000000),
                MakeStudent(Guid.Parse("a37b3252-3e54-4199-8c4b-728238fc76b8"),
                    "Daoblur", "Privat", "dprivat@plagitracker.com", PasswordHash,
                    verificationCode: 10000000),
                MakeStudent(Guid.Parse("8d676dc9-1a50-48f6-aa83-cb47535c5af3"),
                    "Elmersson", "Procke", "eprocke@plagitracker.com", PasswordHash),
                MakeStudent(Guid.Parse("af2eff91-54b0-43b4-91c4-57b7e2d62f15"),
                    "Ramzan", "Kadyrov", "rkadyrov@plagitracker.com", PasswordHash),
                MakeStudent(Guid.Parse("e7c43279-2bcc-4c09-9165-b824041166fc"),
                    "August", "von Kageneck", "avonkageneck@plagitracker.com", PasswordHash),
                MakeStudent(Guid.Parse("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"),
                    "Ben", "Tennyson", "btennyson@plagitracker.com", PasswordHash,
                    logInAttempts: 3, isLocked: true,
                    unlockDate: DateTime.Parse("2024-10-27T05:50:01.462304-05:00").ToUniversalTime()),
                MakeStudent(Guid.Parse("239e66d0-16c3-4ce4-b321-058b64269f5e"),
                    "Khvicha", "Kvaratskhelia", "kkvaratskhelia@plagitracker.com", PasswordHash),
                MakeStudent(Guid.Parse("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"),
                    "Khabib", "Nurmagomedov", "knurmagomedov@plagitracker.com", PasswordHash),
                MakeStudent(Guid.Parse("1979d2a7-de35-4d83-9aa9-857171cba7fa"),
                    "Pedro", "Torres", "ptorres@plagitracker.com", PasswordHash),
            };
        }

        public static IEnumerable<Course> GetCourses()
        {
            var defaultDate = DateTime.Parse("2024-10-10T10:10:10.1-05:00").ToUniversalTime();
            return new List<Course>
            {
                new Course
                {
                    Id = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Name = "Programming Language I",
                    TeacherId = Guid.Parse("0392d24c-a1f5-4022-8278-cfa4efb14b8c"),
                    InvitationId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("bf9ee4c7-b051-4dd8-ba56-101f2688888c"),
                    Name = "Introduction to Programming",
                    TeacherId = Guid.Parse("0392d24c-a1f5-4022-8278-cfa4efb14b8c"),
                    InvitationId = Guid.Parse("bf9ee4c7-b051-4dd8-ba56-101f2688888c"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a1"),
                    Name = "Programming Language II",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a2"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a3"),
                    Name = "Programming Language III",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a4"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a5"),
                    Name = "Data Structure I",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a6"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a7"),
                    Name = "Data Structure II",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a8"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88a9"),
                    Name = "Analysis and Design of Algorithms I",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88e0"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88b1"),
                    Name = "Analysis and Design of Algorithms II",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88b1"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
                new Course
                {
                    Id = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88b2"),
                    Name = "Fundamentals of Programming Languages",
                    TeacherId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e79e0"),
                    InvitationId = Guid.Parse("aa597a6c-b219-4743-b5c6-8740551e88d2"),
                    IsArchived = false, IsEnabled = true,
                    CreatedAt = defaultDate, UpdatedAt = MinDate
                },
            };
        }

        public static IEnumerable<Assignment> GetAssignments()
        {
            return new List<Assignment>
            {
                new Assignment
                {
                    Id = Guid.Parse("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"),
                    Title = "Programación Orientada a Objetos",
                    Description = "",
                    SubmissionDate = DateTime.Parse("2024-12-07T10:14:26.713-05:00").ToUniversalTime(),
                    AnalysisDate = DateTime.Parse("2024-10-09T18:40:04.711558-05:00").ToUniversalTime(),
                    IsAnalyzed = true, DolosURLId = null,
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:46:30.389-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Assignment
                {
                    Id = Guid.Parse("e4be8d12-8d5e-43d2-817c-b5997043304d"),
                    Title = "Programación Orientada a Objetos 2",
                    Description = "Ninguna",
                    SubmissionDate = DateTime.Parse("2024-12-24T19:43:58.85-05:00").ToUniversalTime(),
                    AnalysisDate = MinDate,
                    IsAnalyzed = false, DolosURLId = null,
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:46:30.389352-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Assignment
                {
                    Id = Guid.Parse("025f1811-79ec-43b2-9693-652fa2f7bdb1"),
                    Title = "Programación Orientada a Objetos 3",
                    Description = null,
                    SubmissionDate = DateTime.Parse("2024-12-24T19:43:58.85-05:00").ToUniversalTime(),
                    AnalysisDate = MinDate,
                    IsAnalyzed = false, DolosURLId = "8299776248912629284",
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:48:36.691752-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Assignment
                {
                    Id = Guid.Parse("e4be8d12-8d5e-43d2-817c-b5987043404d"),
                    Title = "Cylinder",
                    Description = "Ninguna",
                    SubmissionDate = DateTime.Parse("2024-12-24T19:43:58.85-05:00").ToUniversalTime(),
                    AnalysisDate = MinDate,
                    IsAnalyzed = false, DolosURLId = "3950420146690480254",
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:46:30.389-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
            };
        }

        public static IEnumerable<Enrollment> GetEnrollments()
        {
            return new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b8"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-05T23:08:45.690141-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b2"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-05T23:56:54.940662-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("a37b3252-3e54-4199-8c4b-728238fc76b8"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-05T23:59:06.498981-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("8d676dc9-1a50-48f6-aa83-cb47535c5af3"),
                    CourseId = Guid.Parse("bf9ee4c7-b051-4dd8-ba56-101f2688888c"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:49:21.232978-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("8d676dc9-1a50-48f6-aa83-cb47535c5af3"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081327-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b8"),
                    CourseId = Guid.Parse("bf9ee4c7-b051-4dd8-ba56-101f2688888c"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-05T23:08:40.787882-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("1979d2a7-de35-4d83-9aa9-857171cba7fa"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("239e66d0-16c3-4ce4-b321-058b64269f5e"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("af2eff91-54b0-43b4-91c4-57b7e2d62f15"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Enrollment
                {
                    StudentId = Guid.Parse("e7c43279-2bcc-4c09-9165-b824041166fc"),
                    CourseId = Guid.Parse("5500125e-16f5-4b77-9220-cc4dab69c100"),
                    Grade = 0.0, IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T07:59:31.081-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
            };
        }

        public static IEnumerable<Submission> GetSubmissions()
        {
            return new List<Submission>
            {
                new Submission
                {
                    Id = Guid.Parse("6e701991-2a14-4493-a170-f4fe910e9c4a"),
                    Url = "https://www.codiva.io/p/9f4e0e63-82d0-4241-b0bf-e12ae7a9b700",
                    SubmissionDate = DateTime.Parse("2024-10-07T10:05:31.051-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.Codiva, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"),
                    AssignmentId = Guid.Parse("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"),
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("b6c2d5e1-33c4-4048-820b-03d25fe674b9"),
                    Url = "https://www.codiva.io/p/dbc162b6-5afe-46bf-b4b3-ee42f11c37c3",
                    SubmissionDate = DateTime.Parse("2024-10-07T10:35:31.051-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.Codiva, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("af2eff91-54b0-43b4-91c4-57b7e2d62f15"),
                    AssignmentId = Guid.Parse("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"),
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("e0d30fd2-1027-4af3-be3b-238a579dacb8"),
                    Url = "https://www.codiva.io/p/e0f1785e-40a2-4174-a00d-e76fbcfc95f8",
                    SubmissionDate = DateTime.Parse("2024-10-07T10:36:31.051-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.Codiva, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"),
                    AssignmentId = Guid.Parse("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"),
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("31edb16a-feb4-4cab-812c-e8a4bdb6ad45"),
                    Url = "https://www.codiva.io/p/925bfea6-e307-4cbb-8e43-dbf634ec7325",
                    SubmissionDate = DateTime.Parse("2024-10-07T10:55:31.051-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.Codiva, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("239e66d0-16c3-4ce4-b321-058b64269f5e"),
                    AssignmentId = Guid.Parse("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"),
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("6252ac2f-e197-4ec3-821f-56ef3dffc72c"),
                    Url = "https://www.codiva.io/p/dbc162b6-5afe-46bf-b4b3-ee42f11c37c4",
                    SubmissionDate = DateTime.Parse("2024-10-07T10:15:31.051-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.Codiva, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("e7c43279-2bcc-4c09-9165-b824041166fc"),
                    AssignmentId = Guid.Parse("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"),
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("7d0f9c15-9e1b-4301-8b6e-7812cca1d451"),
                    Url = "https://www.onlinegdb.com/cky2lPU84",
                    SubmissionDate = DateTime.Parse("2024-11-17T19:12:19.911-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.OnlineGDB, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("8d676dc9-1a50-48f6-aa83-cb47535c5af3"),
                    AssignmentId = Guid.Parse("025f1811-79ec-43b2-9693-652fa2f7bdb1"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:27:21.610589-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("7397a9ce-94a9-4e5b-9cbb-215f061b197e"),
                    Url = "https://www.onlinegdb.com/zWDNPiT9M",
                    SubmissionDate = DateTime.Parse("2024-11-17T20:27:14.246-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.OnlineGDB, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b8"),
                    AssignmentId = Guid.Parse("025f1811-79ec-43b2-9693-652fa2f7bdb1"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T20:28:27.708371-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("14cabe76-3398-4429-ad34-01679f08acb9"),
                    Url = "https://www.onlinegdb.com/bdoucGuWb",
                    SubmissionDate = DateTime.Parse("2024-11-18T09:28:25.801-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.OnlineGDB, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"),
                    AssignmentId = Guid.Parse("025f1811-79ec-43b2-9693-652fa2f7bdb1"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T09:35:49.879123-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("fe8eb5ea-7686-4539-b13b-51bf931d36bb"),
                    Url = "https://www.codiva.io/p/cf89e5a1-d528-4334-b973-9fcacfbc28d6",
                    SubmissionDate = DateTime.Parse("2024-11-18T09:28:25.801-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.Codiva, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"),
                    AssignmentId = Guid.Parse("025f1811-79ec-43b2-9693-652fa2f7bdb1"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T13:03:38.659325-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Submission
                {
                    Id = Guid.Parse("d00b5731-977d-41cf-b8bf-7f693cb8d97b"),
                    Url = "https://onlinegdb.com/lgantTSY2",
                    SubmissionDate = DateTime.Parse("2024-11-18T09:27:25.801-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.OnlineGDB, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("38141a4f-bc22-4514-8f9b-139a11b004b2"),
                    AssignmentId = Guid.Parse("e4be8d12-8d5e-43d2-817c-b5987043404d"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T13:30:52.604863-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },

                new Submission
                {
                    Id = Guid.Parse("22e13d14-0349-49df-9fc9-ff6c9bbb4bd8"),
                    Url = "https://onlinegdb.com/EsUiHpxUO",
                    SubmissionDate = DateTime.Parse("2024-11-18T09:22:25.801-05:00").ToUniversalTime(),
                    Grade = 0.0, Compiler = UrlCompilerType.OnlineGDB, UrlState = UrlState.Ok,
                    StudentId = Guid.Parse("8d676dc9-1a50-48f6-aa83-cb47535c5af3"),
                    AssignmentId = Guid.Parse("e4be8d12-8d5e-43d2-817c-b5987043404d"),
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T13:46:04.173529-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
            };
        }

        public static IEnumerable<Code> GetCodes()
        {
            return new List<Code>
            {
                new Code
                {
                    Id = Guid.Parse("b0eeb1d1-9e34-4157-9744-b9ee629a61c2"),
                    SubmissionId = Guid.Parse("7d0f9c15-9e1b-4301-8b6e-7812cca1d451"),
                    FileName = "Main.java",
                    Content = "public class Main\n{\n    public static void main(String[] args) {\n        System.out.println(\"Hello PlagiTracker\");\n    }\n}",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:27:48.334268-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("a7b61980-fb3c-46b6-8471-46c7c80b55fd"),
                    SubmissionId = Guid.Parse("7d0f9c15-9e1b-4301-8b6e-7812cca1d451"),
                    FileName = "Person.java",
                    Content = "public class Person {\n    private String name;\n    private int age;\n\n    public Person(String name, int age) {\n        this.name = name;\n        this.age = age;\n    }\n\n    public String getName() {\n        return name;\n    }\n\n    public int getAge() {\n        return age;\n    }\n\n    public void setName(String name) {\n        this.name = name;\n    }\n",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T19:27:48.358448-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("bab848e0-1ce8-4d0f-83b4-8b95afda5047"),
                    SubmissionId = Guid.Parse("7397a9ce-94a9-4e5b-9cbb-215f061b197e"),
                    FileName = "Main.java",
                    Content = "public class Main\n{\n    public static void main(String[] args) {\n\n        // con esto imprimo\n        System.out.println(\"Hello My Friend!\");\n    }\n}",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T20:28:57.76432-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("09b35d8c-a153-4a9a-a218-84a379fe868c"),
                    SubmissionId = Guid.Parse("7397a9ce-94a9-4e5b-9cbb-215f061b197e"),
                    FileName = "Persona.java",
                    Content = "public class Persona {\n    private String nombre;\n    int edad;\n\n    public Persona(String name, int age) {\n        this.nombre = name;\n        this.edad = age;\n    }\n\n    public String getName() {\n        return nombre;\n    }\n\n    public int getAge() {\n        return edad;\n    }\n\n    public void setName(String name) {\n        this.nombre = name;\n    }\n\n    public void setAge(int age) {\n        this.edad = age;\n    }\n}",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-17T20:28:57.782538-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("83bafa2e-f925-4ab5-a1d7-be8d030eb0b9"),
                    SubmissionId = Guid.Parse("14cabe76-3398-4429-ad34-01679f08acb9"),
                    FileName = "Main.java",
                    Content = "public class Main\n{\n    public static void main(String[] args) {\n        System.out.println(\"Hello PlagiTracker\");\n    }\n}",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T09:36:13.451974-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("a3c6fd63-81e7-4bca-8a49-b163f292400b"),
                    SubmissionId = Guid.Parse("14cabe76-3398-4429-ad34-01679f08acb9"),
                    FileName = "Person.java",
                    Content = "public class Person\n{\n    private String fname;\n    private String lname;\n    private int age;\n\n\n    public String getFname()\n    {\n        return fname;\n    }\n\n\n    public String getLname()\n    {\n        return lname;\n    }\n\n\n    public int getAge()\n    {\n        return age;\n    }\n\n\n    ",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T09:36:13.473267-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("4abb984e-aead-4b40-88b0-8c801fdde54c"),
                    SubmissionId = Guid.Parse("31edb16a-feb4-4cab-812c-e8a4bdb6ad45"),
                    FileName = "HelloCodiva.java",
                    Content = "\npackage com.example;\n\nclass HelloCodiva {\n    public static void main(String[] args) {\n        int a = 15;\n        int b = 20; // will generate an error\n        int c = 654;\n        System.out.println(a+b+c);\n    }\n}\n",
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("5c96bfec-28ba-4c23-b9da-fbf4cf835e0d"),
                    SubmissionId = Guid.Parse("31edb16a-feb4-4cab-812c-e8a4bdb6ad45"),
                    FileName = "Main.java",
                    Content = "\npackage com.example;\n\npublic class Main {\n    public static void main(String[] args) {\n        int myNum = 5;\n        float myFloatNum = 5.99f;\n        char myLetter = 'D';\n        boolean myBool = true;\n        String myText = \"Hello\";\n        System.out.println(myNum);\n        System.out.println(myFloatNum);\n        System.out.println(myLetter);\n        System.out.println(myBool);\n        System.out.println(myText);\n    }\n}",
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("301e8585-ac92-4bd2-809b-262228bcc1c1"),
                    SubmissionId = Guid.Parse("e0d30fd2-1027-4af3-be3b-238a579dacb8"),
                    FileName = "HelloCodiva.java",
                    Content = "package com.example;\n\nclass HelloCodiva {\n\n    public static void main(String[] args) {\n\n        String greeting = \"Hello World\";\n        System.out.println(greeting);\n\n    }\n}\n",
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("32914a3b-9b54-4e6b-ad27-033693f8e181"),
                    SubmissionId = Guid.Parse("e0d30fd2-1027-4af3-be3b-238a579dacb8"),
                    FileName = "Main.java",
                    Content = "\npackage com.example;\n\nclass Main {\n    public static void main(String[] args) {\n        char myLetter = 'D';\n        boolean myBool = true;\n        String myText = \"Hello\";\n\n        int myNum = 5;\n        float myFloatNum = 5.99f;\n\n        System.out.println(myNum);\n        System.out.println(myFloatNum);\n        System.out.println(myLetter);\n        System.out.println(myBool);\n        System.out.println(myText);\n    }\n}",
                    IsEnabled = true, CreatedAt = MinDate, UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("c939bfb1-7324-4715-9f85-cd8c3cb99035"),
                    SubmissionId = Guid.Parse("fe8eb5ea-7686-4539-b13b-51bf931d36bb"),
                    FileName = "First_exercise.java",
                    Content = "package E_1_first_exercise;\n\npublic class First_exercise {\n    public static void main(String args[]){\n\n        int number_1 = 8;\n        int number_2 = 15;\n\n        number_1 = number_1 + number_2;\n        number_2 = number_1 - number_2;\n        number_1 = number_1 - number_2;\n\n        System.out.println(\"First: \" + number_1);\n        System.out.println(\"Second: \" + number_2);\n\n        System.out.println(\"Doston Hamrakulov doston.hamrakulov@gmail.com\");\n    }\n}\n",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T13:03:59.319042-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },

                new Code
                {
                    Id = Guid.Parse("c9281571-e24b-4c92-875b-b59e5ae88fdf"),
                    SubmissionId = Guid.Parse("d00b5731-977d-41cf-b8bf-7f693cb8d97b"),
                    FileName = "nCylinder.java",
                    Content = "\nimport java.util.Scanner;\n\npublic class nCylinder {\n    public static void main(String[] args){\n\n        Scanner sc = new Scanner(System.in);\n\n        System.out.print(\"Enter the radius and length of a cylinder: \");\n        double radius = sc.nextDouble();\n        double length = sc.nextDouble();\n\n        double area = radius * radius * 3.14159;\n        double volume = area * length;\n\n        System.out.println(\"The area is \" + (float)area);\n        System.out.printf(\"The volume is %.1f\", volume);\n        System.out.println();\n\n    }\n}\n",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T13:31:07.007507-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
                new Code
                {
                    Id = Guid.Parse("7996e30e-e7c0-4c5a-baa7-dd50faa3a3eb"),
                    SubmissionId = Guid.Parse("22e13d14-0349-49df-9fc9-ff6c9bbb4bd8"),
                    FileName = "ncylinder.java",
                    Content = "\nimport java.util.Scanner;\n\npublic class ncylinder {\n\n    public static void main(String[] args) {\n        Scanner sc = new Scanner(System.in);\n        System.out.print(\"Enter the radius and length of a cylinder : \");\n        double radius = sc.nextDouble();\n        double length = sc.nextDouble();\n        double area = (radius * radius) * 3.14159;\n        double volume = area * length;\n        System.out.println(\"The area is : \" + area);\n        System.out.println(\"The volume is : \" + volume);\n    }\n\n}\n",
                    IsEnabled = true,
                    CreatedAt = DateTime.Parse("2024-11-18T13:36:44.138051-05:00").ToUniversalTime(),
                    UpdatedAt = MinDate
                },
            };
        }
    }
}
