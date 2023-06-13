using System;
using System.Collections.Generic;
using System.Text;

namespace Ideal.Platform.Common.Data
{

    /// <summary>
    /// 文化程度
    /// </summary>
    public  class MyEducationDegree
    {
        /// <summary>
        /// 研究生
        /// </summary>
        public const string Postgraduate  = "2";
        public const string Postgraduate_CH  = "研究生";
        /// <summary>
        /// 研究生毕业
        /// </summary>
        public const string Married  = "1";
        public const string Married_CH  = "研究生毕业";
        /// <summary>
        /// 研究生肄业
        /// </summary>
        public const string FirstMarriage  = "9";
        public const string FirstMarriage_CH  = "研究生肄业";
        /// <summary>
        /// 大学本科（简称大学)
        /// </summary>
        public const string Remarriage  = "10";
        public const string Remarriage_CH  = "大学本科（简称大学)";
        /// <summary>
        /// 大学毕业
        /// </summary>
        public const string UniversityGraduation  = "11";
        public const string UniversityGraduation_CH  = "大学毕业";
        /// <summary>
        /// 相当大学毕业
        /// </summary>
        public const string EquivalentUniversityGraduation  = "18";
        public const string EquivalentUniversityGraduation_CH  = "相当大学毕业";
        /// <summary>
        /// 大学肄业
        /// </summary>
        public const string Undergraduate  = "19";
        public const string Undergraduate_CH  = "大学肄业";
        /// <summary>
        /// 大学专科和专科学校
        /// </summary>
        public const string JuniorCollege  = "20";
        public const string JuniorCollege_CH  = "大学专科和专科学校";
        /// <summary>
        /// 专科毕业
        /// </summary>
        public const string ProfessionalSchoolGraduation  = "21";
        public const string ProfessionalSchoolGraduation_CH  = "专科毕业";
        /// <summary>
        /// 专科毕业
        /// </summary>
        public const string EquivalentProfessionalSchool  = "28";
        public const string EquivalentProfessionalSchool_CH  = "相当专科毕业";
        /// <summary>
        /// 专科肄业
        /// </summary>
        public const string ProfessionalSchoolStudy  = "29";
        public const string ProfessionalSchoolStudy_CH  = "专科肄业";
        /// <summary>
        /// 中等专业学校或中等技术学校
        /// </summary>
        public const string SecondarySpecialties  = "30";
        public const string SecondarySpecialties_CH  = "中等专业学校或中等技术学校";
        /// <summary>
        /// 中专毕业
        /// </summary>
        public const string SpecialSchool  = "31";
        public const string SpecialSchool_CH  = "中专毕业";
        /// <summary>
        /// 中技毕业 
        /// </summary>
        public const string TechnicalSkillGraduation  = "32";
        public const string TechnicalSkillGraduation_CH  = "中技毕业";
        /// <summary>
        /// 相当中专或中技毕业 
        /// </summary>
        public const string EquivalentSpecialSchoolGraduation  = "38";
        public const string EquivalentSpecialSchoolGraduation_CH  = "相当中专或中技毕业";
        /// <summary>
        /// 中专或中技肄业 
        /// </summary>
        public const string SpecialSchoolStudy  = "39";
        public const string SpecialSchoolStudy_CH  = "中专或中技肄业";
        /// <summary>
        /// 技工学校 
        /// </summary>
        public const string MechanicSchool  = "40";
        public const string MechanicSchool_CH  = "技工学校";
        /// <summary>
        /// 技工学校毕业 
        /// </summary>
        public const string MechanicSchoolGraduation  = "41";
        public const string MechanicSchoolGraduation_CH  = "技工学校毕业";
        /// <summary>
        /// 技工学校肄业 
        /// </summary>
        public const string MechanicSchoolStudy  = "49";
        public const string MechanicSchoolStudy_CH  = "技工学校肄业";
        /// <summary>
        /// 高中 
        /// </summary>
        public const string HighSchool  = "50";
        public const string HighSchool_CH  = "高中";
        /// <summary>
        /// 高中毕业 
        /// </summary>
        public const string HighSchoolGraduation  = "51";
        public const string HighSchoolGraduation_CH  = "高中毕业";
        /// <summary>
        /// 职业高中毕业 
        /// </summary>
        public const string OccupationHighSchoolGraduation  = "52";
        public const string OccupationHighSchoolGraduation_CH  = "职业高中毕业";
        /// <summary>
        /// 农业高中毕业 
        /// </summary>
        public const string AgricultureHighSchoolGraduation  = "53";
        public const string AgricultureHighSchoolGraduation_CH  = "农业高中毕业";
        /// <summary>
        /// 相当高中毕业 
        /// </summary>
        public const string EquivalentHighSchoolGraduation  = "58";
        public const string EquivalentHighSchoolGraduation_CH  = "相当高中毕业";
        /// <summary>
        /// 高中肄业 
        /// </summary>
        public const string HighSchoolStudy  = "59";
        public const string HighSchoolStudy_CH  = "高中肄业";
        /// <summary>
        /// 初中 
        /// </summary>
        public const string JuniorMiddleSchool  = "60";
        public const string JuniorMiddleSchool_CH  = "初中";
        /// <summary>
        /// 初中毕业 
        /// </summary>
        public const string JuniorMiddleSchoolGraduation  = "61";
        public const string JuniorMiddleSchoolGraduation_CH  = "初中毕业";
        /// <summary>
        /// 职业初中毕业 
        /// </summary>
        public const string OccupationJuniorMiddleSchoolGraduation  = "62";
        public const string OccupationJuniorMiddleSchoolGraduation_CH  = "职业初中毕业";
        /// <summary>
        /// 农业初中毕业 
        /// </summary>
        public const string AgricultureJuniorMiddleSchoolGraduation  = "63";
        public const string AgricultureJuniorMiddleSchoolGraduation_CH  = "农业初中毕业";
        /// <summary>
        /// 相当初中毕业 
        /// </summary>
        public const string EquivalentJuniorMiddleSchoolGraduation  = "68";
        public const string EquivalentJuniorMiddleSchoolGraduation_CH  = "相当初中毕业";
        /// <summary>
        /// 初中肄业 
        /// </summary>
        public const string JuniorMiddleSchoolStudy  = "69";
        public const string JuniorMiddleSchoolStudy_CH  = "初中肄业";
        /// <summary>
        /// 小学 
        /// </summary>
        public const string PrimarySchool  = "70";
        public const string PrimarySchool_CH  = "小学";
        /// <summary>
        /// 小学毕业 
        /// </summary>
        public const string PrimarySchoolGraduation  = "71";
        public const string PrimarySchoolGraduation_CH  = "小学毕业";
        /// <summary>
        /// 相当小学毕业 
        /// </summary>
        public const string EquivalentPrimarySchoolGraduation  = "78";
        public const string EquivalentPrimarySchoolGraduation_CH  = "相当小学毕业";
        /// <summary>
        /// 小学肄业 
        /// </summary>
        public const string ElementarySchoolStudy  = "79";
        public const string ElementarySchoolStudy_CH  = "小学肄业";
        /// <summary>
        /// 文盲或半文盲 
        /// </summary>
        public const string Illiterate  = "80";
        public const string Illiterate_CH  = "文盲或半文盲";

    }
}
