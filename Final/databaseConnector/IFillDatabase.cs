using System;
namespace CSConnector
{
    interface IFillDatabase
    {
        string[] course { get; }
        void deleteFromAllClassesHelper(string emailDel, System.Data.OleDb.OleDbCommand cmd);
        void deleteStudentFromACourse(string emailDel, string classIDDel);
        void deleteStudentFromAllCourses(string emailDel);
        string[] email { get; }
        string[] firstName { get; }
        System.Collections.Generic.List<string> getClassesStudentTaking(string emailStudent);
        void getRoster(string excelFileName);
        string[] lastName { get; }
        void purgeAllStudentData();
        void rosterToDatabaseTables();
        void setUserInfo(string[] classIDIn, string[] studentIDIn, string[] lastNameIn, string[] firstNameIn, string[] emailIn);
        string[] studentID { get; }
    }
}
