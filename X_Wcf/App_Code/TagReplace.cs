using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Data;
using System.Text;
using E_BLL;
using E_Common;

namespace X_Wcf.App_Code
{
    public class TagReplace
    {
        School mSchool = new School();
        Brand mBrand = new Brand();
        Class mClass = new Class();
        Teacher mTeacher = new Teacher();
        Student mStudent = new Student();
        News mNews = new News();
        Brock mBrock = new Brock();
        Tag mTag = new Tag();
        PropertyValue mPropertyValue = new PropertyValue();
        DataSet source;
        DataSet ds;
        StringBuilder str;
        public TagReplace()
        { }

        public string ChangeReplace(string tag)
        {
            str = new StringBuilder();
            switch (tag)
            {
                #region 首页
                //品牌课程
                case "$gold_course_class$":
                    ds = new DataSet();
                    ds = mBrand.GetList(" status = '1'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i < 10)
                        {
                            str.Append("<li><span>0" + i + "</span>");
                        }
                        else
                        {
                            str.Append("<li><span>" + i + "</span>");
                        }
                        str.Append("<p><a href='javascript:; ' class='yy'><img src='"+ ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' width='400' height='450' alt=''/></a><a href='javascript:; '>"+ds.Tables[0].Rows[i]["BRANDNAME"].ToString() +"<i>" + ds.Tables[0].Rows[i]["BRANDENAME"].ToString() + "</i></a></p>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                    //私教学院老师
                case "$super_mentor_teacher_1$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '私教学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='"+ ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>"+ ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>"+ ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>"+ ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");

                    break;
                    //团操学院老师
                case "$super_mentor_teacher_2$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");
                    break;
                    //瑜伽老师
                case "$super_mentor_teacher_3$":

                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>"); break;
                    //资格认证
                case "$certification_cont$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " status = '1' and CHANNELNAME = '资格认证'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<p></p>");
                        str.Append("<a href='javascript:; '><img src="+ ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='302' height='283' /></a>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                    //明星学员
                case "$stu_box_boxlist_clearfix$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5," and status = '1' ");
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>"+i+"<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["STUDENTIMG"].ToString());
                        str.Append("<div class='btn_blue02'><a href='javascript:; '>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");
                        str.Append("<div class='img_stu'><img src="+ ds.Tables[0].Rows[i]["STUDENTINFO"].ToString() + " /></div>");
                        str.Append("</div>");
                    }
                    break;
                    //学员列表
                case "$stu_box_starStuList$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " and status = '1' ");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li class='current'>");
                        str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>"+ ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                        str.Append("<p><img src="+ ds.Tables[0].Rows[i]["STUDENTINFO"].ToString() + "/></p>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                    //图片视频
                case "$phote_vedio_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(6, " status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'><imgsrc=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='360' height='360'/></a>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li>");
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'><imgsrc=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='360' height='360'/></a>");
                            str.Append("</li>");
                        }
                        
                    }
                    str.Append("</ul>");
                    break;
                    //新闻动态
                case "$news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(6, " status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<a href='javascript:; '><img src=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='374' height='280' /></a>");
                        str.Append("<div>");
                        str.Append("<a href='javascript:; ' class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append(E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0, 100) + "...");
                        }
                        else
                        {
                            str.Append(E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()));
                        }
                        str.Append("<a href='javascript:; ' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                #endregion

                #region 金牌课程
                    //金牌课程
                case "$goldCourse_brand$":
                    ds = new DataSet();
                    ds = mBrand.GetList(" status = '1'");
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<a href= 'eliteEdu.html' target = '_blank'>");
                        str.Append("<img broder = '0' src='" + ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' idth='1199' height='468'/>");
                        str.Append("</a>");
                    }
                    break;
                #endregion

                #region 金牌教师
                    //私教老师
                case "$mentor_list_sd$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(10, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '私教学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");
                    
                    break;
                    //团操老师
                case "$mentor_list_tc$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(10, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");
                    break;
                    //瑜伽老师
                case "$mentor_list_yg$":

                    ds = new DataSet();
                    ds = mTeacher.GetTopList(10, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");
                    break;
                case "$Teacher_banner_1$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$Teacher_banner_1$'");
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '"+ path[0] + "'></div>");
                    }
                    break;
                case "$Teacher_banner_2$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$Teacher_banner_2$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '" + path[0] + "'></div>");
                    }
                    break;
                #endregion

                #region 资格认证
                //资格认证
                case "$certification_list$":
                    ds = new DataSet();
                    ds = mNews.GetSearchList("  status = '1' and CHANNELNAME = '资格认证'  ");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            str.Append("<div class='img_box fl'><img src='"+ ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='377' height='520' /></div>");
                            str.Append("<div class='font_box fr'>");
                            str.Append("<h3>"+ ds.Tables[0].Rows[i]["TITLE"].ToString() + "</h3>");
                            str.Append("<div class='info'>"+ ds.Tables[0].Rows[i]["NEWSTEXT"].ToString() + "</div>");
                            str.Append("</div>");
                            str.Append("<div class='clear'></div>");
                        }
                        else
                        {
                            
                            str.Append("<div class='font_box fl'>");
                            str.Append("<h3>"+ ds.Tables[0].Rows[i]["TITLE"].ToString() + "</h3>");
                            str.Append("<div class='info'>"+ ds.Tables[0].Rows[i]["NEWSTEXT"].ToString() + "</div>");
                            str.Append("</div>");
                            str.Append("<div class='img_box f2'><img src='" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='377' height='520' /></div>");
                            str.Append("<div class='clear'></div>");
                        }
                    }
                    break;
                #endregion

                #region 奥林匹克校区
                case "$schoolZone_List$":
                    ds = new DataSet();
                    ds = mSchool.GetList(" status = '1'");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='l'><img src='"+ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString()+"' width='455' height='529' alt=' ' /></div>");
                        str.Append("<div class='r'>"+ ds.Tables[0].Rows[i]["DESCRIPTION"].ToString() + "</div>");
                        str.Append("<div class='clear'></div>");
                    }
                    break;

                case "$schoolZone_gold_brand$":
                    ds = new DataSet();
                    ds = mBrand.GetList(" status = '1'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i < 10)
                        {
                            str.Append("<li><span>0" + i + "</span>");
                        }
                        else
                        {
                            str.Append("<li><span>" + i + "</span>");
                        }
                        str.Append("<p><a href='javascript:; ' class='yy'><img src='" + ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' width='400' height='450' alt=''/></a><a href='javascript:; '>" + ds.Tables[0].Rows[i]["BRANDNAME"].ToString() + "<i>" + ds.Tables[0].Rows[i]["BRANDENAME"].ToString() + "</i></a></p>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;

                //私教学院老师
                case "$schoolZone_teacher_1$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '私教学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");

                    break;
                //团操学院老师
                case "$schoolZone_teacher_2$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");
                    break;
                //瑜伽老师
                case "$schoolZone_teacher_3$":

                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");
                    break;
                //明星学员
                case "$schoolZone_student_1$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " and status = '1' ");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + i + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["STUDENTIMG"].ToString());
                        str.Append("<div class='btn_blue02'><a href='javascript:; '>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");
                        str.Append("<div class='img_stu'><img src=" + ds.Tables[0].Rows[i]["STUDENTINFO"].ToString() + " /></div>");
                        str.Append("</div>");
                    }
                    break;
                //学员列表
                case "$schoolZone_student_2$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " and status = '1' ");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li class='current'>");
                        str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                        str.Append("<p><img src=" + ds.Tables[0].Rows[i]["STUDENTINFO"].ToString() + "/></p>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                //图片视频
                case "$schoolZone_phote_vedio$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(6, " status = '1' and CHANNELNAME = '照片视频'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<a href='" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'><imgsrc=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='360' height='360'/></a>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$schoolZone_news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(6, " status = '1' and CHANNELNAME = '新闻动态'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<a href='javascript:; '><img src=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='374' height='280' /></a>");
                        str.Append("<div>");
                        str.Append("<a href='javascript:; ' class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        str.Append(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString());
                        str.Append("<a href='javascript:; ' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                #endregion

                #region 私教
                    //今非昔比
                case "$eliteEdu_gpc$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$eliteEdu_gpc$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;

                    //明星教师
                case "$eliteEdu_startTeacher$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(10, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '私教学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><img src='" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "' width='240' height='350' />");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CNGNAME"].ToString() + "</span><i>");
                        str.Append("<br/>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString());
                        str.Append("</i></p></ a ></ li > ");
                    }
                    str.Append("</ul>");

                    break;
                    //课程介绍banner
                case "$eliteEdu_Banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$eliteEdu_Banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '" + path[0] + "'></div>");
                    }
                    break;
                    //课程
                case "$eliteEdu_Class$":
                    ds = new DataSet();
                    ds = mClass.GetListByBrand(" X.BRANDNAME = '私教学院'");
                    str.Append("<ul>");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<li><i><img src=" + ds.Tables[0].Rows[0]["CONTENTPICTURE"].ToString() + " width='243' height='240' /></i>");
                            if (i < 10)
                            {
                                str.Append("<p>0"+i.ToString()+"<span><em>"+ ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            else
                            {
                                str.Append("<p>"+i+"<span><em>"+ ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            str.Append(ds.Tables[0].Rows[0]["CONTENTBODY"].ToString() + "</span></p></li>");
                        }
                    }
                    str.Append("</ul>");
                    break;

                //明星学员
                case "$eliteEdu_clearfix$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " and status = '1' ");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + i + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["STUDENTIMG"].ToString());
                        str.Append("<div class='btn_blue02'><a href='javascript:; '>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");
                        str.Append("<div class='img_stu'><img src=" + ds.Tables[0].Rows[i]["STUDENTINFO"].ToString() + " /></div>");
                        str.Append("</div>");
                    }
                    break;
                //学员列表
                case "$eliteEdu_starStuList$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " and status = '1' ");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li class='current'>");
                        str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                        str.Append("<p><img src=" + ds.Tables[0].Rows[i]["STUDENTINFO"].ToString() + "/></p>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                    //学员banner
                case "$eliteEdu_student_banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$eliteEdu_student_banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;

                //结业保障editor
                case "$employment_List$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$employment_List$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;
                //图片视频
                case "$eliteEdu_phote_vedio_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(6, " status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'><imgsrc=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='360' height='360'/></a>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li>");
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'><imgsrc=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='360' height='360'/></a>");
                            str.Append("</li>");
                        }

                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$eliteEdu_news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(6, " status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<a href='javascript:; '><img src=" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + " width='374' height='280' /></a>");
                        str.Append("<div>");
                        str.Append("<a href='javascript:; ' class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append(E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0,100)+"...");
                        }
                        else
                        { 
                            str.Append(E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()));
                        }
                        str.Append("<a href='javascript:; ' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                #endregion

                #region 工作机会
                case "$getJob_List$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$getJob_List$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;
                case "$getJob_banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAME = '$getJob_banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '" + path[0] + "'></div>");
                    }
                    break;
                case "$getJob_Student$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(10," status ='1'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<i><img src='"+ ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' width='243' height='240' /></i>");
                        str.Append("<p><span><em><b>"+ ds.Tables[0].Rows[i]["ENAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em><br/>");
                        str.Append(ds.Tables[0].Rows[i]["STUDENTINFO"].ToString());
                        str.Append("</span></p></li>");
                    }
                    
                    str.Append("</ul>");
                    break;
                    #endregion
            }

            return str.ToString();
        }
    }
}