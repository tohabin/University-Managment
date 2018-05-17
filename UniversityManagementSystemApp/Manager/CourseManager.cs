using System.Collections.Generic;
using UniversityManagementSystemApp.DAL.Model;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();
        public string AddCoures(Course aCourse)
        {
            if (aCourse.Code.Length >= 5)
            {
                if (aCourseGateway.IsExixstByCode(aCourse.Code))
                {
                    if (aCourseGateway.IsExixstByName(aCourse.Name))
                    {
                        if (aCourse.Credit >= (decimal) .5)
                        {
                            if (aCourse.Credit <= 5)
                            {
                                int rowAffected = aCourseGateway.AddCourse(aCourse);
                                if (rowAffected > 0)
                                {
                                    return "Course Saved";
                                }
                                else
                                {
                                    return "Course Not Saved";
                                }

                            }
                            else
                            {
                                return "Credit Must Be With in 5";
                            }


                        }
                        else
                        {
                            return "Credit Must Be getter than .5";
                        }


                    }
                    else
                    {
                        return "Course Name Already Exists";
                    }


                }
                else
                {
                    return "Course code already Exists";
                }


            }
            else
            {
                return "Course  Code Must Be Atleast 5 charcter";
                
            }

           

        }

        public List<Course> GetAllCourse()
        {

            List<Course> aCourses = aCourseGateway.GetAllCourse();
            return aCourses;
        }
        public List<Course> GetAllStuGetCourseByRegtId(int regId)
        {
            List<Course> aCourse = aCourseGateway.GetCourseByRegtId(regId);
            return aCourse;
        }
        public string SaveGrade(EnrollCourse aCourse)
        {

            int rowAfeected = aCourseGateway.SaveGrade(aCourse);
                if (rowAfeected > 0)
                {
                    return "Result Saved";
                }
                else
                {
                    return "Result not Saved";
                }
            
        }
        public string CourseUnassign()
        {

            int rowAfeected = aCourseGateway.CourseUnassign();
            if (rowAfeected > 0)
            {
                return "Classroom Unassigned Successful";
            }
            else
            {
                return "Classroom Unassigned Unsuccessful";
            }

        }
    }
}