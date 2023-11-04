using Ideal.Platform.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Data
{
    public static class GetData
    {
        public static List<KeyValue> SexList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = Sex.Male, Value = Sex.Male_CH });
            list.Add(new KeyValue() { Key = Sex.FeMale, Value = Sex.FeMale_CH });
            list.Add(new KeyValue() { Key = Sex.MToF, Value = Sex.MToF_CH });
            list.Add(new KeyValue() { Key = Sex.FToM, Value = Sex.FToM_CH });
            list.Add(new KeyValue() { Key = Sex.UnDesc, Value = Sex.UnDesc_CH });
            list.Add(new KeyValue() { Key = Sex.Unknown, Value = Sex.Unknown_CH });
            return list;
        }
        public static List<KeyValue> UserStatusList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = UserStatus.Quit, Value = UserStatus.Quit_CH });
            list.Add(new KeyValue() { Key = UserStatus.Incumbency, Value = UserStatus.Incumbency_CH });
            return list;
        }
        public static List<KeyValue> AccountStatusList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = AccountStatus.Normal, Value = AccountStatus.Normal_CH });
            list.Add(new KeyValue() { Key = AccountStatus.Disable, Value = AccountStatus.Disable_CH });
            return list;
        }
        public static List<KeyValue> MyEducationDegreeList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = MyEducationDegree.Postgraduate, Value = MyEducationDegree.Postgraduate_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.Married, Value = MyEducationDegree.Married_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.FirstMarriage, Value = MyEducationDegree.FirstMarriage_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.Remarriage, Value = MyEducationDegree.Remarriage_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.UniversityGraduation, Value = MyEducationDegree.UniversityGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.EquivalentUniversityGraduation, Value = MyEducationDegree.EquivalentUniversityGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.Undergraduate, Value = MyEducationDegree.Undergraduate_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.JuniorCollege, Value = MyEducationDegree.JuniorCollege_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.ProfessionalSchoolGraduation, Value = MyEducationDegree.ProfessionalSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.EquivalentProfessionalSchool, Value = MyEducationDegree.EquivalentProfessionalSchool_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.ProfessionalSchoolStudy, Value = MyEducationDegree.ProfessionalSchoolStudy_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.SecondarySpecialties, Value = MyEducationDegree.SecondarySpecialties_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.SpecialSchool, Value = MyEducationDegree.SpecialSchool_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.TechnicalSkillGraduation, Value = MyEducationDegree.TechnicalSkillGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.EquivalentSpecialSchoolGraduation, Value = MyEducationDegree.EquivalentSpecialSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.SpecialSchoolStudy, Value = MyEducationDegree.SpecialSchoolStudy_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.MechanicSchool, Value = MyEducationDegree.MechanicSchool_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.MechanicSchoolGraduation, Value = MyEducationDegree.MechanicSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.MechanicSchoolStudy, Value = MyEducationDegree.MechanicSchoolStudy_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.HighSchool, Value = MyEducationDegree.HighSchool_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.HighSchoolGraduation, Value = MyEducationDegree.HighSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.OccupationHighSchoolGraduation, Value = MyEducationDegree.OccupationHighSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.AgricultureHighSchoolGraduation, Value = MyEducationDegree.AgricultureHighSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.EquivalentHighSchoolGraduation, Value = MyEducationDegree.EquivalentHighSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.HighSchoolStudy, Value = MyEducationDegree.HighSchoolStudy_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.JuniorMiddleSchool, Value = MyEducationDegree.JuniorMiddleSchool_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.JuniorMiddleSchoolGraduation, Value = MyEducationDegree.JuniorMiddleSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.OccupationJuniorMiddleSchoolGraduation, Value = MyEducationDegree.OccupationJuniorMiddleSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.AgricultureJuniorMiddleSchoolGraduation, Value = MyEducationDegree.AgricultureJuniorMiddleSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.EquivalentJuniorMiddleSchoolGraduation, Value = MyEducationDegree.EquivalentJuniorMiddleSchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.JuniorMiddleSchoolStudy, Value = MyEducationDegree.JuniorMiddleSchoolStudy_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.PrimarySchool, Value = MyEducationDegree.PrimarySchool_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.PrimarySchoolGraduation, Value = MyEducationDegree.PrimarySchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.EquivalentPrimarySchoolGraduation, Value = MyEducationDegree.EquivalentPrimarySchoolGraduation_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.ElementarySchoolStudy, Value = MyEducationDegree.ElementarySchoolStudy_CH });
            list.Add(new KeyValue() { Key = MyEducationDegree.Illiterate, Value = MyEducationDegree.Illiterate_CH });
            return list;
        }
        public static List<KeyValue> MyNationList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = MyNation.Han, Value = MyNation.Han_CH });
            list.Add(new KeyValue() { Key = MyNation.Mongol, Value = MyNation.Mongol_CH });
            list.Add(new KeyValue() { Key = MyNation.Hui, Value = MyNation.Hui_CH });
            list.Add(new KeyValue() { Key = MyNation.Tibetan, Value = MyNation.Tibetan_CH });
            list.Add(new KeyValue() { Key = MyNation.Uighur, Value = MyNation.Uighur_CH });
            list.Add(new KeyValue() { Key = MyNation.Miao, Value = MyNation.Miao_CH });
            list.Add(new KeyValue() { Key = MyNation.Yi, Value = MyNation.Yi_CH });
            list.Add(new KeyValue() { Key = MyNation.Zhuang, Value = MyNation.Zhuang_CH });
            list.Add(new KeyValue() { Key = MyNation.Buyi, Value = MyNation.Buyi_CH });
            list.Add(new KeyValue() { Key = MyNation.Korean, Value = MyNation.Korean_CH });
            list.Add(new KeyValue() { Key = MyNation.Manchu, Value = MyNation.Manchu_CH });
            list.Add(new KeyValue() { Key = MyNation.Dong, Value = MyNation.Dong_CH });
            list.Add(new KeyValue() { Key = MyNation.Yao, Value = MyNation.Yao_CH });
            list.Add(new KeyValue() { Key = MyNation.Bai, Value = MyNation.Bai_CH });
            list.Add(new KeyValue() { Key = MyNation.Tujia, Value = MyNation.Tujia_CH });
            list.Add(new KeyValue() { Key = MyNation.Hani, Value = MyNation.Hani_CH });
            list.Add(new KeyValue() { Key = MyNation.Kazakh, Value = MyNation.Kazakh_CH });
            list.Add(new KeyValue() { Key = MyNation.Dai, Value = MyNation.Dai_CH });
            list.Add(new KeyValue() { Key = MyNation.Li, Value = MyNation.Li_CH });
            list.Add(new KeyValue() { Key = MyNation.Lisu, Value = MyNation.Lisu_CH });
            list.Add(new KeyValue() { Key = MyNation.Wa, Value = MyNation.Wa_CH });
            list.Add(new KeyValue() { Key = MyNation.She, Value = MyNation.She_CH });
            list.Add(new KeyValue() { Key = MyNation.Gaoshan, Value = MyNation.Gaoshan_CH });
            list.Add(new KeyValue() { Key = MyNation.Lahu, Value = MyNation.Lahu_CH });
            list.Add(new KeyValue() { Key = MyNation.Shui, Value = MyNation.Shui_CH });
            list.Add(new KeyValue() { Key = MyNation.Dongxiang, Value = MyNation.Dongxiang_CH });
            list.Add(new KeyValue() { Key = MyNation.Naxi, Value = MyNation.Naxi_CH });
            list.Add(new KeyValue() { Key = MyNation.Jingpo, Value = MyNation.Jingpo_CH });
            list.Add(new KeyValue() { Key = MyNation.Kirghiz, Value = MyNation.Kirghiz_CH });
            list.Add(new KeyValue() { Key = MyNation.Du, Value = MyNation.Du_CH });
            list.Add(new KeyValue() { Key = MyNation.Daur, Value = MyNation.Daur_CH });
            list.Add(new KeyValue() { Key = MyNation.Mulam, Value = MyNation.Mulam_CH });
            list.Add(new KeyValue() { Key = MyNation.Qiang, Value = MyNation.Qiang_CH });
            list.Add(new KeyValue() { Key = MyNation.Blang, Value = MyNation.Blang_CH });
            list.Add(new KeyValue() { Key = MyNation.Salar, Value = MyNation.Salar_CH });
            list.Add(new KeyValue() { Key = MyNation.Maonan, Value = MyNation.Maonan_CH });
            list.Add(new KeyValue() { Key = MyNation.Gelao, Value = MyNation.Gelao_CH });
            list.Add(new KeyValue() { Key = MyNation.Xibe, Value = MyNation.Xibe_CH });
            list.Add(new KeyValue() { Key = MyNation.Achang, Value = MyNation.Achang_CH });
            list.Add(new KeyValue() { Key = MyNation.Pumi, Value = MyNation.Pumi_CH });
            list.Add(new KeyValue() { Key = MyNation.Tajik, Value = MyNation.Tajik_CH });
            list.Add(new KeyValue() { Key = MyNation.Nu, Value = MyNation.Nu_CH });
            list.Add(new KeyValue() { Key = MyNation.Uzbek, Value = MyNation.Uzbek_CH });
            list.Add(new KeyValue() { Key = MyNation.Russian, Value = MyNation.Russian_CH });
            list.Add(new KeyValue() { Key = MyNation.Evenki, Value = MyNation.Evenki_CH });
            list.Add(new KeyValue() { Key = MyNation.BengLong, Value = MyNation.BengLong_CH });
            list.Add(new KeyValue() { Key = MyNation.Bonan, Value = MyNation.Bonan_CH });
            list.Add(new KeyValue() { Key = MyNation.Yugur, Value = MyNation.Yugur_CH });
            list.Add(new KeyValue() { Key = MyNation.Gin, Value = MyNation.Gin_CH });
            list.Add(new KeyValue() { Key = MyNation.Tatar, Value = MyNation.Tatar_CH });
            list.Add(new KeyValue() { Key = MyNation.Drung, Value = MyNation.Drung_CH });
            list.Add(new KeyValue() { Key = MyNation.Oroqin, Value = MyNation.Oroqin_CH });
            list.Add(new KeyValue() { Key = MyNation.Hezhen, Value = MyNation.Hezhen_CH });
            list.Add(new KeyValue() { Key = MyNation.Menba, Value = MyNation.Menba_CH });
            list.Add(new KeyValue() { Key = MyNation.Lhoba, Value = MyNation.Lhoba_CH });
            list.Add(new KeyValue() { Key = MyNation.Jino, Value = MyNation.Jino_CH });
            return list;
        }
        public static List<KeyValue> PoliticalStatusList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = PoliticalStatus.PartyMember, Value = PoliticalStatus.PartyMember_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.ProbationaryPartyMembers, Value = PoliticalStatus.ProbationaryPartyMembers_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.CommunistYouthLeague, Value = PoliticalStatus.CommunistYouthLeague_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.CommunistParty, Value = PoliticalStatus.CommunistParty_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.ChinaDemocraticLeague, Value = PoliticalStatus.ChinaDemocraticLeague_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.ChinaDemocraticConstruction, Value = PoliticalStatus.ChinaDemocraticConstruction_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.DemocraticProgressiveParty, Value = PoliticalStatus.DemocraticProgressiveParty_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.PeasantLabourParty, Value = PoliticalStatus.PeasantLabourParty_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.ZhiGongParty, Value = PoliticalStatus.ZhiGongParty_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.JiusanSociety, Value = PoliticalStatus.JiusanSociety_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.TaiLeague, Value = PoliticalStatus.TaiLeague_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.NonPartisanDemocracy, Value = PoliticalStatus.NonPartisanDemocracy_CH });
            list.Add(new KeyValue() { Key = PoliticalStatus.TheMasses, Value = PoliticalStatus.TheMasses_CH });
            return list;
        }

        public static List<KeyValue> IDCardTypeList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = IDCardType.ResidentID, Value = IDCardType.ResidentID_CH });
            list.Add(new KeyValue() { Key = IDCardType.Passport, Value = IDCardType.Passport_CH });
            list.Add(new KeyValue() { Key = IDCardType.MainlandPass, Value = IDCardType.MainlandPass_CH });
            return list;

        }
        public static List<KeyValue> CheckTypeList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = CheckType.Cost, Value = CheckType.Cost_CH });
            list.Add(new KeyValue() { Key = CheckType.Management, Value = CheckType.Management_CH });
            return list;
        }
        
        public static List<KeyValue> AccountLevelList()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue() { Key = AccountLevel.Advanced, Value = AccountLevel.Advanced_CH });
            list.Add(new KeyValue() { Key = AccountLevel.Ordinary, Value = AccountLevel.Ordinary_CH });
            return list;
        }
    }
}
