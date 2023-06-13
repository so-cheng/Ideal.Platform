using Ideal.Ideal.Redis;
using Ideal.Platform.Common.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Config
{
    public static class ConfigClass
    {
        public static string SqlConnectionStr { get; set; }

        public static string RedisConnectionStr { get; set; }

        public static void Inti()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "", "appsettings.json");
            string appsettingsJsonstr = string.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
                {
                    appsettingsJsonstr = sr.ReadToEnd().ToString();
                }
            }
            JObject appsettingsJObject = JObject.Parse(appsettingsJsonstr);
            SqlConnectionStr = appsettingsJObject["SqlConnection"].ToString();
            RedisConnectionStr = appsettingsJObject["RedisConnection"].ToString();
            //SetRedis();
        }

        public static void SetRedis()
        {
            RedisHelper.SetValue((int)RedisType.Sex, Sex.Male, Sex.Male_CH);
            RedisHelper.SetValue((int)RedisType.Sex, Sex.FeMale, Sex.FeMale_CH);
            RedisHelper.SetValue((int)RedisType.Sex, Sex.MToF, Sex.MToF_CH);
            RedisHelper.SetValue((int)RedisType.Sex, Sex.FToM, Sex.FToM_CH);
            RedisHelper.SetValue((int)RedisType.Sex, Sex.UnDesc, Sex.UnDesc_CH);
            RedisHelper.SetValue((int)RedisType.Sex, Sex.Unknown, Sex.Unknown_CH);

            RedisHelper.SetValue((int)RedisType.UserStatus, UserStatus.Quit, UserStatus.Quit_CH);
            RedisHelper.SetValue((int)RedisType.UserStatus, UserStatus.Incumbency, UserStatus.Incumbency_CH);

            RedisHelper.SetValue((int)RedisType.AccountStatus, AccountStatus.Normal, AccountStatus.Normal_CH);
            RedisHelper.SetValue((int)RedisType.AccountStatus, AccountStatus.Disable, AccountStatus.Disable_CH);


            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.Postgraduate, MyEducationDegree.Postgraduate_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.Married, MyEducationDegree.Married_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.FirstMarriage, MyEducationDegree.FirstMarriage_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.Remarriage, MyEducationDegree.Remarriage_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.UniversityGraduation, MyEducationDegree.UniversityGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.EquivalentUniversityGraduation, MyEducationDegree.EquivalentUniversityGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.Undergraduate, MyEducationDegree.Undergraduate_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.JuniorCollege, MyEducationDegree.JuniorCollege_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.ProfessionalSchoolGraduation, MyEducationDegree.ProfessionalSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.EquivalentProfessionalSchool, MyEducationDegree.EquivalentProfessionalSchool_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.ProfessionalSchoolStudy, MyEducationDegree.ProfessionalSchoolStudy_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.SecondarySpecialties, MyEducationDegree.SecondarySpecialties_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.SpecialSchool, MyEducationDegree.SpecialSchool_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.TechnicalSkillGraduation, MyEducationDegree.TechnicalSkillGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.EquivalentSpecialSchoolGraduation, MyEducationDegree.EquivalentSpecialSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.SpecialSchoolStudy, MyEducationDegree.SpecialSchoolStudy_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.MechanicSchool, MyEducationDegree.MechanicSchool_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.MechanicSchoolGraduation, MyEducationDegree.MechanicSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.MechanicSchoolStudy, MyEducationDegree.MechanicSchoolStudy_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.HighSchool, MyEducationDegree.HighSchool_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.HighSchoolGraduation, MyEducationDegree.HighSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.OccupationHighSchoolGraduation, MyEducationDegree.OccupationHighSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.AgricultureHighSchoolGraduation, MyEducationDegree.AgricultureHighSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.EquivalentHighSchoolGraduation, MyEducationDegree.EquivalentHighSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.HighSchoolStudy, MyEducationDegree.HighSchoolStudy_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.JuniorMiddleSchool, MyEducationDegree.JuniorMiddleSchool_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.JuniorMiddleSchoolGraduation, MyEducationDegree.JuniorMiddleSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.OccupationJuniorMiddleSchoolGraduation, MyEducationDegree.OccupationJuniorMiddleSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.AgricultureJuniorMiddleSchoolGraduation, MyEducationDegree.AgricultureJuniorMiddleSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.EquivalentJuniorMiddleSchoolGraduation, MyEducationDegree.EquivalentJuniorMiddleSchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.JuniorMiddleSchoolStudy, MyEducationDegree.JuniorMiddleSchoolStudy_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.PrimarySchool, MyEducationDegree.PrimarySchool_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.PrimarySchoolGraduation, MyEducationDegree.PrimarySchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.EquivalentPrimarySchoolGraduation, MyEducationDegree.EquivalentPrimarySchoolGraduation_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.ElementarySchoolStudy, MyEducationDegree.ElementarySchoolStudy_CH);
            RedisHelper.SetValue((int)RedisType.MyEducationDegree, MyEducationDegree.Illiterate, MyEducationDegree.Illiterate_CH);



            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Han, MyNation.Han_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Mongol, MyNation.Mongol_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Hui, MyNation.Hui_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Tibetan, MyNation.Tibetan_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Uighur, MyNation.Uighur_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Miao, MyNation.Miao_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Yi, MyNation.Yi_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Zhuang, MyNation.Zhuang_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Buyi, MyNation.Buyi_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Korean, MyNation.Korean_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Manchu, MyNation.Manchu_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Dong, MyNation.Dong_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Yao, MyNation.Yao_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Bai, MyNation.Bai_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Tujia, MyNation.Tujia_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Hani, MyNation.Hani_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Kazakh, MyNation.Kazakh_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Dai, MyNation.Dai_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Li, MyNation.Li_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Lisu, MyNation.Lisu_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Wa, MyNation.Wa_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.She, MyNation.She_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Gaoshan, MyNation.Gaoshan_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Lahu, MyNation.Lahu_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Shui, MyNation.Shui_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Dongxiang, MyNation.Dongxiang_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Naxi, MyNation.Naxi_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Jingpo, MyNation.Jingpo_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Kirghiz, MyNation.Kirghiz_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Du, MyNation.Du_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Daur, MyNation.Daur_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Mulam, MyNation.Mulam_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Qiang, MyNation.Qiang_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Blang, MyNation.Blang_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Salar, MyNation.Salar_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Maonan, MyNation.Maonan_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Gelao, MyNation.Gelao_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Xibe, MyNation.Xibe_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Achang, MyNation.Achang_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Pumi, MyNation.Pumi_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Tajik, MyNation.Tajik_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Nu, MyNation.Nu_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Uzbek, MyNation.Uzbek_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Russian, MyNation.Russian_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Evenki, MyNation.Evenki_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.BengLong, MyNation.BengLong_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Bonan, MyNation.Bonan_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Yugur, MyNation.Yugur_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Gin, MyNation.Gin_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Tatar, MyNation.Tatar_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Drung, MyNation.Drung_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Oroqin, MyNation.Oroqin_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Hezhen, MyNation.Hezhen_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Menba, MyNation.Menba_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Lhoba, MyNation.Lhoba_CH);
            RedisHelper.SetValue((int)RedisType.MyNation, MyNation.Jino, MyNation.Jino_CH);


            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.PartyMember, PoliticalStatus.PartyMember_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.ProbationaryPartyMembers, PoliticalStatus.ProbationaryPartyMembers_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.CommunistYouthLeague, PoliticalStatus.CommunistYouthLeague_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.CommunistParty, PoliticalStatus.CommunistParty_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.ChinaDemocraticLeague, PoliticalStatus.ChinaDemocraticLeague_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.ChinaDemocraticConstruction, PoliticalStatus.ChinaDemocraticConstruction_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.DemocraticProgressiveParty, PoliticalStatus.DemocraticProgressiveParty_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.PeasantLabourParty, PoliticalStatus.PeasantLabourParty_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.ZhiGongParty, PoliticalStatus.ZhiGongParty_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.JiusanSociety, PoliticalStatus.JiusanSociety_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.TaiLeague, PoliticalStatus.TaiLeague_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.NonPartisanDemocracy, PoliticalStatus.NonPartisanDemocracy_CH);
            RedisHelper.SetValue((int)RedisType.PoliticalStatus, PoliticalStatus.TheMasses, PoliticalStatus.TheMasses_CH);


            RedisHelper.SetValue((int)RedisType.IDCardType, IDCardType.ResidentID, IDCardType.ResidentID_CH);
            RedisHelper.SetValue((int)RedisType.IDCardType, IDCardType.Passport, IDCardType.Passport_CH);
            RedisHelper.SetValue((int)RedisType.IDCardType, IDCardType.MainlandPass, IDCardType.MainlandPass_CH);

            RedisHelper.SetValue((int)RedisType.CheckType, CheckType.Cost, CheckType.Cost_CH);
            RedisHelper.SetValue((int)RedisType.CheckType, CheckType.Management, CheckType.Management_CH);


            RedisHelper.SetValue((int)RedisType.AccountLevel, AccountLevel.Advanced, AccountLevel.Advanced_CH);
            RedisHelper.SetValue((int)RedisType.AccountLevel, AccountLevel.Ordinary, AccountLevel.Ordinary_CH);
        }


    }
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
