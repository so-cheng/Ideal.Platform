using System;
using System.Collections.Generic;
using System.Text;

namespace Ideal.Platform.Common.Data
{
    /// <summary>";
    /// 民族类
    /// </summary>
    public class MyNation
    {
        /// <summary>
        /// 汉族
        /// </summary>
        public const string Han = "01";
        public const string Han_CH = "汉族";
        /// <summary>
        /// 蒙古族
        /// </summary>
        public const string Mongol = "02";
        public const string Mongol_CH = "蒙古族";
        /// <summary>
        /// 回族
        /// </summary>
        public const string Hui = "03";
        public const string Hui_CH = "回族";
        /// <summary>
        /// 藏族
        /// </summary>
        public const string Tibetan = "04";
        public const string Tibetan_CH = "藏族";
        /// <summary>
        /// 维吾尔族
        /// </summary>
        public const string Uighur = "05";
        public const string Uighur_CH = "维吾尔族";
        /// <summary>
        /// 苗族
        /// </summary>
        public const string Miao = "06";
        public const string Miao_CH = "苗族";
        /// <summary>
        /// 彝族
        /// </summary>
        public const string Yi = "07";
        public const string Yi_CH = "彝族";
        /// <summary>
        /// 壮族
        /// </summary>
        public const string Zhuang = "08";
        public const string Zhuang_CH = "壮族";
        /// <summary>
        /// 布依族
        /// </summary>
        public const string Buyi = "09";

        public const string Buyi_CH = "布依族";
        /// <summary>
        /// 朝鲜族
        /// </summary>
        public const string Korean = "10";
        public const string Korean_CH = "朝鲜族";
        /// <summary>
        /// 满族
        /// </summary>
        public const string Manchu = "11";
        public const string Manchu_CH = "满族";
        /// <summary>
        /// 侗族
        /// </summary>
        public const string Dong = "12";
        public const string Dong_CH = "侗族";
        /// <summary>
        /// 瑶族
        /// </summary>
        public const string Yao = "13";
        public const string Yao_CH = "瑶族";
        /// <summary>
        /// 白族
        /// </summary>
        public const string Bai = "14";
        public const string Bai_CH = "白族";
        /// <summary>
        /// 土家族
        /// </summary>
        public const string Tujia = "15";
        public const string Tujia_CH = "土家族";
        /// <summary>
        /// 哈尼族
        /// </summary>
        public const string Hani = "16";
        public const string Hani_CH = "哈尼族";
        /// <summary>
        /// 哈萨克族
        /// </summary>
        public const string Kazakh = "17";
        public const string Kazakh_CH = "哈萨克族";
        /// <summary>
        /// 傣族
        /// </summary>
        public const string Dai = "18";
        public const string Dai_CH = "傣族";
        /// <summary>
        /// 黎族
        /// </summary>
        public const string Li = "19";
        public const string Li_CH = "黎族";
        /// <summary>
        /// 傈僳族
        /// </summary>
        public const string Lisu = "20";
        public const string Lisu_CH = "傈僳族";
        /// <summary>
        /// 佤族
        /// </summary>
        public const string Wa = "21";
        public const string Wa_CH = "佤族";
        /// <summary>
        /// 畲族
        /// </summary>
        public const string She = "22";
        public const string She_CH = "畲族";
        /// <summary>
        /// 高山族
        /// </summary>
        public const string Gaoshan = "23";
        public const string Gaoshan_CH = "高山族";
        /// <summary>
        /// 拉祜族
        /// </summary>
        public const string Lahu = "24";
        public const string Lahu_CH = "拉祜族";
        /// <summary>
        /// 水族
        /// </summary>
        public const string Shui = "25";
        public const string Shui_CH = "水族";
        /// <summary>
        /// 东乡族
        /// </summary>
        public const string Dongxiang = "26";
        public const string Dongxiang_CH = "东乡族";
        /// <summary>
        /// 纳西族
        /// </summary>
        public const string Naxi = "27";
        public const string Naxi_CH = "纳西族";
        /// <summary>
        /// 景颇族
        /// </summary>
        public const string Jingpo = "28";
        public const string Jingpo_CH = "景颇族";
        /// <summary>
        /// 柯尔克孜族
        /// </summary>
        public const string Kirghiz = "29";
        public const string Kirghiz_CH = "柯尔克孜族";
        /// <summary>
        /// 土族
        /// </summary>
        public const string Du = "30";
        public const string Du_CH = "土族";
        /// <summary>
        /// 达斡尔族
        /// </summary>
        public const string Daur = "31";
        public const string Daur_CH = "达斡尔族";
        /// <summary>
        /// 仫佬族
        /// </summary>
        public const string Mulam = "32";
        public const string Mulam_CH = "仫佬族";
        /// <summary>
        /// 羌族
        /// </summary>
        public const string Qiang = "33";
        public const string Qiang_CH = "羌族";
        /// <summary>
        /// 布朗族
        /// </summary>
        public const string Blang = "34";
        public const string Blang_CH = "布朗族";
        /// <summary>
        /// 撒拉族
        /// </summary>
        public const string Salar = "35";
        public const string Salar_CH = "撒拉族";
        /// <summary>
        /// 毛南族
        /// </summary>
        public const string Maonan = "36";
        public const string Maonan_CH = "毛南族";
        /// <summary>
        /// 仡佬族
        /// </summary>
        public const string Gelao = "37";
        public const string Gelao_CH = "仡佬族";
        /// <summary>
        /// 锡伯族
        /// </summary>
        public const string Xibe = "38";
        public const string Xibe_CH = "锡伯族";
        /// <summary>
        /// 阿昌族
        /// </summary>
        public const string Achang = "39";
        public const string Achang_CH = "阿昌族";
        /// <summary>
        /// 普米族
        /// </summary>
        public const string Pumi = "40";
        public const string Pumi_CH = "普米族";
        /// <summary>
        /// 塔吉克族
        /// </summary>
        public const string Tajik = "41";
        public const string Tajik_CH = "塔吉克族";
        /// <summary>
        /// 怒族
        /// </summary>
        public const string Nu = "42";
        public const string Nu_CH = "怒族";
        /// <summary>
        /// 乌孜别克族
        /// </summary>
        public const string Uzbek = "43";
        public const string Uzbek_CH = "乌孜别克族";
        /// <summary>
        /// 俄罗斯族
        /// </summary>
        public const string Russian = "44";
        public const string Russian_CH = "俄罗斯族";
        /// <summary>
        /// 鄂温克族
        /// </summary>
        public const string Evenki = "45";
        public const string Evenki_CH = "鄂温克族";
        /// <summary>
        /// 崩龙族
        /// </summary>
        public const string BengLong = "46";
        public const string BengLong_CH = "崩龙族";
        /// <summary>
        /// 保安族
        /// </summary>
        public const string Bonan = "47";
        public const string Bonan_CH = "保安族";
        /// <summary>
        /// 裕固族
        /// </summary>
        public const string Yugur = "48";
        public const string Yugur_CH = "裕固族";
        /// <summary>
        /// 京族
        /// </summary>
        public const string Gin = "49";
        public const string Gin_CH = "京族";
        /// <summary>
        /// 塔塔尔族
        /// </summary>
        public const string Tatar = "50";
        public const string Tatar_CH = "塔塔尔族";
        /// <summary>
        /// 独龙族
        /// </summary>
        public const string Drung = "51";
        public const string Drung_CH = "独龙族";
        /// <summary>
        /// 鄂伦春族
        /// </summary>
        public const string Oroqin = "52";
        public const string Oroqin_CH = "鄂伦春族";
        /// <summary>
        /// 赫哲族
        /// </summary>
        public const string Hezhen = "53";
        public const string Hezhen_CH = "赫哲族";
        /// <summary>
        /// 门巴族
        /// </summary>
        public const string Menba = "54";
        public const string Menba_CH = "门巴族";
        /// <summary>
        /// 珞巴族
        /// </summary>
        public const string Lhoba = "55";
        public const string Lhoba_CH = "珞巴族";
        /// <summary>
        /// 基诺族
        /// </summary>
        public const string Jino = "56";

        public const string Jino_CH = "基诺族";
    }
}
