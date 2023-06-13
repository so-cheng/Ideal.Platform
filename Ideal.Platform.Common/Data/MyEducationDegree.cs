using System;
using System.Collections.Generic;
using System.Text;

namespace Ideal.Platform.Common.Data
{

    /// <summary>
    /// �Ļ��̶�
    /// </summary>
    public  class MyEducationDegree
    {
        /// <summary>
        /// �о���
        /// </summary>
        public const string Postgraduate  = "2";
        public const string Postgraduate_CH  = "�о���";
        /// <summary>
        /// �о�����ҵ
        /// </summary>
        public const string Married  = "1";
        public const string Married_CH  = "�о�����ҵ";
        /// <summary>
        /// �о�����ҵ
        /// </summary>
        public const string FirstMarriage  = "9";
        public const string FirstMarriage_CH  = "�о�����ҵ";
        /// <summary>
        /// ��ѧ���ƣ���ƴ�ѧ)
        /// </summary>
        public const string Remarriage  = "10";
        public const string Remarriage_CH  = "��ѧ���ƣ���ƴ�ѧ)";
        /// <summary>
        /// ��ѧ��ҵ
        /// </summary>
        public const string UniversityGraduation  = "11";
        public const string UniversityGraduation_CH  = "��ѧ��ҵ";
        /// <summary>
        /// �൱��ѧ��ҵ
        /// </summary>
        public const string EquivalentUniversityGraduation  = "18";
        public const string EquivalentUniversityGraduation_CH  = "�൱��ѧ��ҵ";
        /// <summary>
        /// ��ѧ��ҵ
        /// </summary>
        public const string Undergraduate  = "19";
        public const string Undergraduate_CH  = "��ѧ��ҵ";
        /// <summary>
        /// ��ѧר�ƺ�ר��ѧУ
        /// </summary>
        public const string JuniorCollege  = "20";
        public const string JuniorCollege_CH  = "��ѧר�ƺ�ר��ѧУ";
        /// <summary>
        /// ר�Ʊ�ҵ
        /// </summary>
        public const string ProfessionalSchoolGraduation  = "21";
        public const string ProfessionalSchoolGraduation_CH  = "ר�Ʊ�ҵ";
        /// <summary>
        /// ר�Ʊ�ҵ
        /// </summary>
        public const string EquivalentProfessionalSchool  = "28";
        public const string EquivalentProfessionalSchool_CH  = "�൱ר�Ʊ�ҵ";
        /// <summary>
        /// ר����ҵ
        /// </summary>
        public const string ProfessionalSchoolStudy  = "29";
        public const string ProfessionalSchoolStudy_CH  = "ר����ҵ";
        /// <summary>
        /// �е�רҵѧУ���еȼ���ѧУ
        /// </summary>
        public const string SecondarySpecialties  = "30";
        public const string SecondarySpecialties_CH  = "�е�רҵѧУ���еȼ���ѧУ";
        /// <summary>
        /// ��ר��ҵ
        /// </summary>
        public const string SpecialSchool  = "31";
        public const string SpecialSchool_CH  = "��ר��ҵ";
        /// <summary>
        /// �м���ҵ 
        /// </summary>
        public const string TechnicalSkillGraduation  = "32";
        public const string TechnicalSkillGraduation_CH  = "�м���ҵ";
        /// <summary>
        /// �൱��ר���м���ҵ 
        /// </summary>
        public const string EquivalentSpecialSchoolGraduation  = "38";
        public const string EquivalentSpecialSchoolGraduation_CH  = "�൱��ר���м���ҵ";
        /// <summary>
        /// ��ר���м���ҵ 
        /// </summary>
        public const string SpecialSchoolStudy  = "39";
        public const string SpecialSchoolStudy_CH  = "��ר���м���ҵ";
        /// <summary>
        /// ����ѧУ 
        /// </summary>
        public const string MechanicSchool  = "40";
        public const string MechanicSchool_CH  = "����ѧУ";
        /// <summary>
        /// ����ѧУ��ҵ 
        /// </summary>
        public const string MechanicSchoolGraduation  = "41";
        public const string MechanicSchoolGraduation_CH  = "����ѧУ��ҵ";
        /// <summary>
        /// ����ѧУ��ҵ 
        /// </summary>
        public const string MechanicSchoolStudy  = "49";
        public const string MechanicSchoolStudy_CH  = "����ѧУ��ҵ";
        /// <summary>
        /// ���� 
        /// </summary>
        public const string HighSchool  = "50";
        public const string HighSchool_CH  = "����";
        /// <summary>
        /// ���б�ҵ 
        /// </summary>
        public const string HighSchoolGraduation  = "51";
        public const string HighSchoolGraduation_CH  = "���б�ҵ";
        /// <summary>
        /// ְҵ���б�ҵ 
        /// </summary>
        public const string OccupationHighSchoolGraduation  = "52";
        public const string OccupationHighSchoolGraduation_CH  = "ְҵ���б�ҵ";
        /// <summary>
        /// ũҵ���б�ҵ 
        /// </summary>
        public const string AgricultureHighSchoolGraduation  = "53";
        public const string AgricultureHighSchoolGraduation_CH  = "ũҵ���б�ҵ";
        /// <summary>
        /// �൱���б�ҵ 
        /// </summary>
        public const string EquivalentHighSchoolGraduation  = "58";
        public const string EquivalentHighSchoolGraduation_CH  = "�൱���б�ҵ";
        /// <summary>
        /// ������ҵ 
        /// </summary>
        public const string HighSchoolStudy  = "59";
        public const string HighSchoolStudy_CH  = "������ҵ";
        /// <summary>
        /// ���� 
        /// </summary>
        public const string JuniorMiddleSchool  = "60";
        public const string JuniorMiddleSchool_CH  = "����";
        /// <summary>
        /// ���б�ҵ 
        /// </summary>
        public const string JuniorMiddleSchoolGraduation  = "61";
        public const string JuniorMiddleSchoolGraduation_CH  = "���б�ҵ";
        /// <summary>
        /// ְҵ���б�ҵ 
        /// </summary>
        public const string OccupationJuniorMiddleSchoolGraduation  = "62";
        public const string OccupationJuniorMiddleSchoolGraduation_CH  = "ְҵ���б�ҵ";
        /// <summary>
        /// ũҵ���б�ҵ 
        /// </summary>
        public const string AgricultureJuniorMiddleSchoolGraduation  = "63";
        public const string AgricultureJuniorMiddleSchoolGraduation_CH  = "ũҵ���б�ҵ";
        /// <summary>
        /// �൱���б�ҵ 
        /// </summary>
        public const string EquivalentJuniorMiddleSchoolGraduation  = "68";
        public const string EquivalentJuniorMiddleSchoolGraduation_CH  = "�൱���б�ҵ";
        /// <summary>
        /// ������ҵ 
        /// </summary>
        public const string JuniorMiddleSchoolStudy  = "69";
        public const string JuniorMiddleSchoolStudy_CH  = "������ҵ";
        /// <summary>
        /// Сѧ 
        /// </summary>
        public const string PrimarySchool  = "70";
        public const string PrimarySchool_CH  = "Сѧ";
        /// <summary>
        /// Сѧ��ҵ 
        /// </summary>
        public const string PrimarySchoolGraduation  = "71";
        public const string PrimarySchoolGraduation_CH  = "Сѧ��ҵ";
        /// <summary>
        /// �൱Сѧ��ҵ 
        /// </summary>
        public const string EquivalentPrimarySchoolGraduation  = "78";
        public const string EquivalentPrimarySchoolGraduation_CH  = "�൱Сѧ��ҵ";
        /// <summary>
        /// Сѧ��ҵ 
        /// </summary>
        public const string ElementarySchoolStudy  = "79";
        public const string ElementarySchoolStudy_CH  = "Сѧ��ҵ";
        /// <summary>
        /// ��ä�����ä 
        /// </summary>
        public const string Illiterate  = "80";
        public const string Illiterate_CH  = "��ä�����ä";

    }
}
