using UniversityAdmissionStandards_DataAccess;
using System;
using System.Data;

namespace UniversityAdmissionStandards_Business
{
    public class clsCollegeMajor
    {
        public static DataTable GetAllBranches()
        {
            return clsCollegeMajorData.GetAllCollegesAndMajors();
        }

        public static DataTable GetCollegesAndMajorsByRateAndBranch(short CollegeBinaryNumber,
            int MajorBinaryNumber, float Rate)
        {
            return clsCollegeMajorData.GetCollegesAndMajorsByRateAndBranch
                (CollegeBinaryNumber, MajorBinaryNumber, Rate);
        }
    }

}