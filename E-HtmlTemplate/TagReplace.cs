using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Data;
using System.Text;
using E_BLL;
using E_Common;

namespace E_HtmlTemplate
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
        About mAbout = new About();
        Link mLink = new Link();
        ECode mCode = new ECode();
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
                            str.Append("<li><span>0" + (i+1) + "</span>");
                        }
                        else
                        {
                            str.Append("<li><span>" + (i+1) + "</span>");
                        }
                        str.Append("<p><a href='goldCourse.html ' target='_blank' class='yy'><img src='../" + ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' width='400' height='450' alt=''/></a><a href='javascript:; '>" + ds.Tables[0].Rows[i]["BRANDNAME"].ToString() + "<i>" + ds.Tables[0].Rows[i]["BRANDENAME"].ToString() + "</i></a></p>");
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
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString()+ "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");

                    break;
                //团操学院老师
                case "$super_mentor_teacher_2$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, " AND  CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");
                    break;
                //瑜伽老师
                case "$super_mentor_teacher_3$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  AND CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>"); break;
                //资格认证
                case "$certification_cont$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " cms_news.status = '1' and CHANNELNAME = '资格认证'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<p></p>");
                        str.Append("<a href='javascript:; '><img src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='302' height='283' /></a>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                //明星学员
                case "$stu_box_boxlist_clearfix$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " cms_student.status = '1' ");
                    str.Append("<div class='stu_boxlist clearfix'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + (i + 1) + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["SNAME"].ToString());
                        str.Append("<br />"+ds.Tables[0].Rows[i]["STUDENTINFO"].ToString());
                        str.Append("<div class='btn_blue02'><a href='getJob.html' target='_blank'>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");

                        str.Append("<div class='img_stu'><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' /></div>");
                        str.Append("</div>");
                    }
                    str.Append("</div>");
                    break;
                //学员列表
                case "$stu_box_starStuList$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " cms_student.status = '1' ");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (i != 0)
                        {
                            str.Append("<li>");
                            str.Append("<p class='font hide'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                        else
                        {
                            str.Append("<li class='current'>");
                            str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                    }
                    str.Append("</ul>");
                    break;
                //图片视频
                case "$phote_vedio_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(8, " CMS_NEWS.status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<img class='jsVedioPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li >");
                            str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }

                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " CMS_NEWS.status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='374' height='280' />");
                        str.Append("<div>");
                        if (ds.Tables[0].Rows[i]["TITLE"].ToString().Length > 20)
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString().Substring(0, 20) + "...</a>");
                        }
                        else
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        }
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0, 100) + "...</span>");
                        }
                        else
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()) + "</span>");
                        }
                        str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                case "$our_partner_index$":
                    ds = new DataSet();
                    ds = mLink.GetTopList(12," status = '1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<a href='"+ds.Tables[0].Rows[i]["LINKURL"].ToString()+ "' target = '_blank' class='mar'><img src='../" + ds.Tables[0].Rows[i]["LINKIMAGE"].ToString() +"' /></a>");
                        }
                    }
                    break;

                case "$ewm$":
                    ds = new DataSet();
                    ds = this.mCode.GetTopList(1, " status = '1'");
                    str.Append("<img src='../" + this.ds.Tables[0].Rows[0]["CODEIMAGE"].ToString() + "'  width=\"140\" height=\"128\" />");
                    break;

                #endregion

                #region 金牌课程
                //金牌课程
                case "$goldCourse_brand_sj$":
                    ds = new DataSet();
                    //ds = mBrand.GetList(" status = '1'");
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$goldCourse_brand_sj$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<a href = 'eliteEdu.html' target='_blank'><img broder = '0' src='../" + path[0].ToString() + "' width='1199' height='468'/></a>");
                    }
                    break;

                case "$goldCourse_brand_tc$":
                    ds = new DataSet();
                    //ds = mBrand.GetList(" status = '1'");
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$goldCourse_brand_tc$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<a href = 'eliteEduTc.html' target='_blank'><img broder = '0' src='../" + path[0].ToString() + "' width='1199' height='468'/></a>");
                    }
                    break;

                case "$goldCourse_brand_yg$":
                    ds = new DataSet();
                    //ds = mBrand.GetList(" status = '1'");
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$goldCourse_brand_yg$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<a href = 'eliteEduYoga.html' target='_blank'><img broder = '0' src='../" + path[0].ToString() + "' width='1199' height='468'/></a>");
                    }
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    str.Append("<a href= 'eliteEdu.html' target = '_blank'>");
                    //    str.Append("<img broder = '0' src='../" + ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' width='1199' height='468'/>");
                    //    str.Append("</a>");
                    //}
                    break;
                #endregion

                #region 金牌教师
                //私教老师
                case "$mentor_list_sd$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '私教学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");

                    break;
                //团操老师
                case "$mentor_list_tc$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, " AND  CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");
                    break;
                //瑜伽老师
                case "$mentor_list_yg$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  AND CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");  break;
                case "$Teacher_banner_1$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$Teacher_banner_1$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                case "$Teacher_banner_2$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$Teacher_banner_2$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                #endregion

                #region 资格认证
                //资格认证
                case "$certification_list$":
                    ds = new DataSet();
                    ds = mNews.GetSearchList("  T.status = '1' and CHANNELNAME = '资格认证'  ");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            str.Append("<div class='img_box fl'><img src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='377' height='520' /></div>");
                            str.Append("<div class='font_box fr'>");
                            str.Append("<h3>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</h3>");
                            str.Append("<div class='info'>" + ds.Tables[0].Rows[i]["NEWSTEXT"].ToString() + "</div>");
                            str.Append("</div>");
                            str.Append("<div class='clear'></div>");
                        }
                        else
                        {

                            str.Append("<div class='font_box fl'>");
                            str.Append("<h3>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</h3>");
                            str.Append("<div class='info'>" + ds.Tables[0].Rows[i]["NEWSTEXT"].ToString() + "</div>");
                            str.Append("</div>");
                            str.Append("<div class='img_box fr'><img src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='377' height='520' /></div>");
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
                        str.Append("<div class='l'><img src='../" + ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' width='455' height='529' alt=' ' /></div>");
                        str.Append("<div class='r'>" + ds.Tables[0].Rows[i]["DESCRIPTION"].ToString() + "</div>");
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
                            str.Append("<li><span>0" + (i+1) + "</span>");
                        }
                        else
                        {
                            str.Append("<li><span>" + (i+1) + "</span>");
                        }
                        str.Append("<p><a href='javascript:; ' class='yy'><img src='../" + ds.Tables[0].Rows[i]["SHOWPICTURE"].ToString() + "' width='400' height='450' alt=''/></a><a href='javascript:; '>" + ds.Tables[0].Rows[i]["BRANDNAME"].ToString() + "<i>" + ds.Tables[0].Rows[i]["BRANDENAME"].ToString() + "</i></a></p>");
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
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");
                    break;
                //团操学院老师
                case "$schoolZone_teacher_2$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, " AND  CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");
                    break;
                //瑜伽老师
                case "$schoolZone_teacher_3$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  AND CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>"); break;
                //明星学员
                case "$schoolZone_student_1$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " cms_student.status = '1' ");
                    str.Append("<div class='stu_boxlist clearfix'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + (i + 1) + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["SNAME"].ToString());
                        str.Append("<br />" + ds.Tables[0].Rows[i]["STUDENTINFO"].ToString());
                        str.Append("<div class='btn_blue02'><a href='getJob.html' target='_blank'>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");

                        str.Append("<div class='img_stu'><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' /></div>");
                        str.Append("</div>");
                    }
                    str.Append("</div>");
                    break;
                //学员列表
                case "$schoolZone_student_2$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " cms_student.status = '1' ");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (i != 0)
                        {
                            str.Append("<li>");
                            str.Append("<p class='font hide'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                        else
                        {
                            str.Append("<li class='current'>");
                            str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                    }
                    str.Append("</ul>");
                    break;
                //图片视频
                case "$schoolZone_phote_vedio$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(8, " CMS_NEWS.status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<img class='jsVedioPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li >");
                            str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }

                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$schoolZone_news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " CMS_NEWS.status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态') ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='374' height='280' />");
                        str.Append("<div>");
                        if (ds.Tables[0].Rows[i]["TITLE"].ToString().Length > 20)
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString().Substring(0, 20) + "...</a>");
                        }
                        else
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        }
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0, 100) + "...</span>");
                        }
                        else
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()) + "</span>");
                        }
                        str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;
                case "$our_partner_xq$":
                    ds = new DataSet();
                    ds = mLink.GetTopList(12, " status = '1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["LINKURL"].ToString() + "' target = '_blank'><img src='../" + ds.Tables[0].Rows[i]["LINKIMAGE"].ToString() + "' /></a>");
                        }
                    }
                    break;
                #endregion

                #region 私教
                //今非昔比
                case "$eliteEdu_gpc$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_gpc$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;

                //明星教师
                case "$eliteEdu_startTeacher$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '私教学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");

                    break;
                //课程介绍banner
                case "$eliteEdu_Banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_Banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
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
                            str.Append("<li><i><img src='../" + ds.Tables[0].Rows[0]["CONTENTPICTURE"].ToString() + "' width='243' height='240' /></i>");
                            if (i < 10)
                            {
                                str.Append("<p>0" + (i+1).ToString() + "<span><em>" + ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            else
                            {
                                str.Append("<p>" + (i+1) + "<span><em>" + ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            str.Append(PageValidate.NoHTML( ds.Tables[0].Rows[0]["CONTENTBODY"].ToString()) + "</span></p></li>");
                        }
                    }
                    str.Append("</ul>");
                    break;

                //明星学员
                case "$eliteEdu_clearfix$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " cms_student.status = '1' ");
                    str.Append("<div class='stu_boxlist clearfix'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + (i + 1) + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["SNAME"].ToString());
                        str.Append("<br />" + ds.Tables[0].Rows[i]["STUDENTINFO"].ToString());
                        str.Append("<div class='btn_blue02'><a href='getJob.html' target='_blank'>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");

                        str.Append("<div class='img_stu'><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' /></div>");
                        str.Append("</div>");
                    }
                    str.Append("</div>");
                    break;
                //学员列表
                case "$eliteEdu_starStuList$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " cms_student.status = '1'   and  brandname = '私教学院'");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (i != 0)
                        {
                            str.Append("<li>");
                            str.Append("<p class='font hide'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                        else
                        {
                            str.Append("<li class='current'>");
                            str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                    }
                    str.Append("</ul>");
                    break;
                //学员banner
                //case "$eliteEdu_student_banner$":
                //    ds = new DataSet();
                //    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_student_banner$'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                //    }
                //    break;

                ////结业保障editor
                //case "$employment_List$":
                //    ds = new DataSet();
                //    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$employment_List$'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                //    }
                //    break;
                //图片视频
                case "$eliteEdu_phote_vedio_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(8, " CMS_NEWS.status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频')  and CMS_BRAND.BRANDNAME='私教学院'  ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<img class='jsVedioPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li >");
                            str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }

                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$eliteEdu_news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " CMS_NEWS.status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态') and CMS_BRAND.BRANDNAME='私教学院' ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='374' height='280' />");
                        str.Append("<div>");
                        if (ds.Tables[0].Rows[i]["TITLE"].ToString().Length > 20)
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString().Substring(0, 20) + "...</a>");
                        }
                        else
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        }
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0, 100) + "...</span>");
                        }
                        else
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()) + "</span>");
                        }
                        str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;

                case "$eliteEdu_banner05$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_banner05$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;
                case "$eliteEdu_banner04$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_banner04$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;

                case "$our_partner_sj$":
                    ds = new DataSet();
                    ds = mLink.GetTopList(12, " status = '1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["LINKURL"].ToString() + "' target = '_blank'><img src='../" + ds.Tables[0].Rows[i]["LINKIMAGE"].ToString() + "' /></a>");
                        }
                    }
                    break;
                #endregion

                #region 团操
                //今非昔比
                case "$eliteEduTG_gpc$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_gpc$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;

                //明星教师
                case "$eliteEduTG_startTeacher$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '团操学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");

                    break;
                //课程介绍banner
                case "$eliteEduTG_Banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_Banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                //课程
                case "$eliteEduTG_Class$":
                    ds = new DataSet();
                    ds = mClass.GetListByBrand(" X.BRANDNAME = '团操学院'");
                    str.Append("<ul>");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<li><i><img src='../" + ds.Tables[0].Rows[0]["CONTENTPICTURE"].ToString() + "' width='243' height='240' /></i>");
                            if (i < 10)
                            {
                                str.Append("<p>0" + (i + 1).ToString() + "<span><em>" + ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            else
                            {
                                str.Append("<p>" + (i + 1) + "<span><em>" + ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            str.Append(PageValidate.NoHTML(ds.Tables[0].Rows[0]["CONTENTBODY"].ToString()) + "</span></p></li>");
                        }
                    }
                    str.Append("</ul>");
                    break;

                //明星学员
                case "$eliteEduTG_clearfix$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " cms_student.status = '1' and  brandname = '团操学院' ");
                    str.Append("<div class='stu_boxlist clearfix'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + (i + 1) + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["STUDENTINFO"].ToString());
                        str.Append("<div class='btn_blue02'><a href='javascript:;'>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");

                        str.Append("<div class='img_stu'><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' /></div>");
                        str.Append("</div>");
                    }
                    str.Append("</div>");
                    break;
                //学员列表
                case "$eliteEduTG_starStuList$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " cms_student.status = '1'   and  brandname = '团操学院'");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (i != 0)
                        {
                            str.Append("<li>");
                            str.Append("<p class='font hide'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                        else
                        {
                            str.Append("<li class='current'>");
                            str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                    }
                    str.Append("</ul>");
                    break;
                //学员banner
                //case "$eliteEdu_student_banner$":
                //    ds = new DataSet();
                //    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_student_banner$'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                //    }
                //    break;

                ////结业保障editor
                //case "$employment_List$":
                //    ds = new DataSet();
                //    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$employment_List$'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                //    }
                //    break;
                //图片视频
                case "$eliteEduTG_phote_vedio_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(8, " CMS_NEWS.status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频')  and CMS_BRAND.BRANDNAME='团操学院'  ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<img class='jsVedioPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li >");
                            str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }

                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$eliteEduTG_news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " CMS_NEWS.status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态')  and CMS_BRAND.BRANDNAME='团操学院' ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='374' height='280' />");
                        str.Append("<div>");
                        if (ds.Tables[0].Rows[i]["TITLE"].ToString().Length > 20)
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString().Substring(0, 20) + "...</a>");
                        }
                        else
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        }
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0, 100) + "...</span>");
                        }
                        else
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()) + "</span>");
                        }
                        str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;

                case "$eliteEduTG_banner05$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_banner05$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;
                case "$eliteEduTG_banner04$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_banner04$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                case "$our_partner_tg$":
                    ds = new DataSet();
                    ds = mLink.GetTopList(12, " status = '1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["LINKURL"].ToString() + "' target = '_blank'><img src='../" + ds.Tables[0].Rows[i]["LINKIMAGE"].ToString() + "' /></a>");
                        }
                    }
                    break;
                #endregion

                #region 瑜伽
                //今非昔比
                case "$eliteEduYG_gpc$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_gpc$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;

                //明星教师
                case "$eliteEduYG_startTeacher$":
                    ds = new DataSet();
                    ds = mTeacher.GetTopList(4, "  and CMS_BRAND.status = '1' and  CMS_BRAND.brandname = '瑜伽学院'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><a href='javascript:; '><em><img src='../" + ds.Tables[0].Rows[i]["TPICTURE"].ToString() + "'  /></em>");
                        str.Append("<p><span><b>" + ds.Tables[0].Rows[i]["ENGNAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["CHNNAME"].ToString() + "</span>");
                        str.Append("<i>" + ds.Tables[0].Rows[i]["RANK"].ToString() + "</i>");
                        str.Append("</p></a></li> ");
                    }
                    str.Append("</ul>");

                    break;
                //课程介绍banner
                case "$eliteEduYG_Banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_Banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                //课程
                case "$eliteEduYG_Class$":
                    ds = new DataSet();
                    ds = mClass.GetListByBrand(" X.BRANDNAME = '瑜伽学院'");
                    str.Append("<ul>");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<li><i><img src='../" + ds.Tables[0].Rows[0]["CONTENTPICTURE"].ToString() + "' width='243' height='240' /></i>");
                            if (i < 10)
                            {
                                str.Append("<p>0" + (i + 1).ToString() + "<span><em>" + ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            else
                            {
                                str.Append("<p>" + (i + 1) + "<span><em>" + ds.Tables[0].Rows[0]["CLASSNAME"].ToString() + "</em>");
                            }
                            str.Append(PageValidate.NoHTML(ds.Tables[0].Rows[0]["CONTENTBODY"].ToString()) + "</span></p></li>");
                        }
                    }
                    str.Append("</ul>");
                    break;

                //明星学员
                case "$eliteEduYG_clearfix$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(5, " cms_student.status = '1' and  brandname = '瑜伽学院' ");
                    str.Append("<div class='stu_boxlist clearfix'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<div class='stu_boxdetail clearfix'>");
                        str.Append("<div class='font'>");
                        str.Append("<h3>" + (i + 1) + "<span>/5</span></h3>");
                        str.Append(ds.Tables[0].Rows[i]["STUDENTINFO"].ToString());
                        str.Append("<div class='btn_blue02'><a href='javascript:;'>更多优秀学员<i></i></a></div>");
                        str.Append("</div>");

                        str.Append("<div class='img_stu'><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' /></div>");
                        str.Append("</div>");
                    }
                    str.Append("</div>");
                    break;
                //学员列表
                case "$eliteEduYG_starStuList$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(7, " cms_student.status = '1'   and  brandname = '瑜伽学院'");
                    str.Append("<ul  id='starStuList'>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (i != 0)
                        {
                            str.Append("<li>");
                            str.Append("<p class='font hide'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "'  width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                        else
                        {
                            str.Append("<li class='current'>");
                            str.Append("<p class='font'><span><em>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</span><i>" + ds.Tables[0].Rows[i]["SCHOOLNAME"].ToString() + "</i></p>");
                            str.Append("<p><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' width='200' height='128' /></p>");
                            str.Append("</li>");
                        }
                    }
                    str.Append("</ul>");
                    break;
                //学员banner
                //case "$eliteEdu_student_banner$":
                //    ds = new DataSet();
                //    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_student_banner$'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                //    }
                //    break;

                ////结业保障editor
                //case "$employment_List$":
                //    ds = new DataSet();
                //    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$employment_List$'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                //    }
                //    break;
                //图片视频
                case "$eliteEduYG_phote_vedio_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(8, " CMS_NEWS.status = '1' and (CHANNELNAME = '照片' or CHANNELNAME = '视频') and CMS_BRAND.BRANDNAME='瑜伽学院' ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "视频")
                        {
                            str.Append("<li class='vedio'><i></i>");
                            str.Append("<img class='jsVedioPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }
                        if (ds.Tables[0].Rows[i]["CHANNELNAME"].ToString() == "照片")
                        {
                            str.Append("<li >");
                            str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='360' height='360'/>");
                            str.Append("</li>");
                        }

                    }
                    str.Append("</ul>");
                    break;
                //新闻动态
                case "$eliteEduYG_news_list$":
                    ds = new DataSet();
                    ds = mNews.GetTopList(3, " CMS_NEWS.status = '1' and (CHANNELNAME = '清波新闻' or CHANNELNAME = '行业动态')  and CMS_BRAND.BRANDNAME='瑜伽学院' ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        str.Append("<li>");
                        str.Append("<p>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Day.ToString() + "<i>" + DateTime.Parse(ds.Tables[0].Rows[i]["CREATEDATE"].ToString()).Month.ToString() + "月</i></p>");
                        str.Append("<img class='jsImgPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='374' height='280' />");
                        str.Append("<div>");
                        if (ds.Tables[0].Rows[i]["TITLE"].ToString().Length > 20)
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString().Substring(0, 20) + "...</a>");
                        }
                        else
                        {
                            str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "'  class='biaoti'>" + ds.Tables[0].Rows[i]["TITLE"].ToString() + "</a>");
                        }
                        if (E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Length > 100)
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()).Substring(0, 100) + "...</span>");
                        }
                        else
                        {
                            str.Append("<span>" + E_Common.PageValidate.NoHTML(ds.Tables[0].Rows[i]["NEWSTEXT"].ToString()) + "</span>");
                        }
                        str.Append("<a href='../" + ds.Tables[0].Rows[i]["NEWSURL"].ToString() + "' class='find'>查看<i></i></a>");
                        str.Append("</div>");
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                    break;

                case "$eliteEduYG_banner05$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_banner05$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div>" + ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() + "</div>");
                    }
                    break;
                case "$eliteEduYG_banner04$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$eliteEdu_banner04$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                case "$our_partner_yg$":
                    ds = new DataSet();
                    ds = mLink.GetTopList(12, " status = '1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["LINKURL"].ToString() + "' target = '_blank'><img src='../" + ds.Tables[0].Rows[i]["LINKIMAGE"].ToString() + "' /></a>");
                        }
                    }
                    break;
                #endregion

                #region 工作机会
                case "$getJob_List$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$getJob_List$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append(ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString() );
                    }
                    break;
                case "$getJob_banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$getJob_banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string[] path = ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString().Split(',');
                        str.Append("<div><img src = '../" + path[0] + "'></div>");
                    }
                    break;
                case "$getJob_Student$":
                    ds = new DataSet();
                    ds = mStudent.GetTopList(10, " cms_student.status ='1'");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li>");
                        str.Append("<i><img src='../" + ds.Tables[0].Rows[i]["STUDENTIMG"].ToString() + "' width='243' height='240' /></i>");
                        str.Append("<p><span><em><b>" + ds.Tables[0].Rows[i]["ENAME"].ToString() + "</b>" + ds.Tables[0].Rows[i]["SNAME"].ToString() + "</em><br />");
                        str.Append("<span style='font-size:10pt'>"+ds.Tables[0].Rows[i]["STUDENTINFO"].ToString()+"</span>");
                        str.Append("</span></p></li>");
                    }

                    str.Append("</ul>");
                    break;
                case "$our_partner_jy$":
                    ds = new DataSet();
                    ds = mLink.GetTopList(12, " status = '1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<a href='" + ds.Tables[0].Rows[i]["LINKURL"].ToString() + "' target = '_blank'><img src='../" + ds.Tables[0].Rows[i]["LINKIMAGE"].ToString() + "' /></a>");
                        }
                    }
                    break;

                #endregion

                #region 关于清波
                case "$about_info$":
                    ds = new DataSet();
                    ds = mAbout.GetTopList(1, " CMS_About.status = '1' and  cms_about.channel = '434fffda-64f6-40cf-85dc-e0c000320b78'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<img src= '../"+ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "'  width = '1185' height = '470' class='us_img'/>");
                            string rs = ds.Tables[0].Rows[i]["DESCRIPTION"].ToString();
                            if (PageValidate.NoHTML(rs).Length > 300)
                            {
                                str.Append(rs.Substring(0, 300) + "...<a href='../" + ds.Tables[0].Rows[i]["PATHURL"].ToString() + "' target='_blank'>详情</a>");
                            }
                            else
                            {
                                str.Append(rs);
                            }
                            str.Append("<div class=\"clear\"></div>");
                        }
                    }
                    break;

                case "$about_banner$":
                    ds = new DataSet();
                    ds = mTag.GetSearchListByProperty(" TAGNAEM = '$about_banner$'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append(ds.Tables[0].Rows[0]["PROPERTYVALUE"].ToString());
                    }
                    break;

                case "$about_img$":
                    ds = new DataSet();
                    ds = mAbout.GetTopList(8 , " CMS_ABOUT.STATUS = '1' AND CMS_ABOUT.channel = 'ef64fb73-e900-48ba-a2aa-5e678e6a5e5b' ");
                    str.Append("<ul>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        str.Append("<li><img class='jsPreview' src = '../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='271' height='271' /><a href='../" + ds.Tables[0].Rows[i]["PATHURL"].ToString() + "' target='_blank'>");
                        if (ds.Tables[0].Rows[i]["TITLE"].ToString().Length > 10)
                        {
                            str.Append(ds.Tables[0].Rows[i]["TITLE"].ToString().Substring(0,10)+"...");
                        }
                        else
                        {
                            str.Append(ds.Tables[0].Rows[i]["TITLE"].ToString());
                        }
                        str.Append(" </a ></li> ");
                    }
                    str.Append("</ul>");
                    break;
                case "$about_teaching_box$":
                    ds = new DataSet();
                    ds = mAbout.GetTopList(9, " CMS_ABOUT.STATUS = '1' AND CMS_ABOUT.channel = '710ba4b9-077d-4ebb-a9c3-f861ec7102f9'");
                    string x = "";
                    string y = "";
                    string z = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i<=2)
                            {
                                x += "<span><img class='jsPreview' src='../"+ ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='100%' height='100%'></span>";
                            }
                            if (i > 2&&i<=5)
                            {
                                if (i == 3)
                                {
                                    y += "<span  class='big'><img class='jsPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "'  width='100%' height='100%'></span>";
                                }
                                if (i == 4)
                                {
                                    y += "<span  class='mar'><img class='jsPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='100%' height='100%'></span>";
                                }
                                if (i == 5)
                                {
                                    y += "<span><img class='jsPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='100%' height='100%'></span>";
                                }
                                
                            }
                            if (i > 5 && i < ds.Tables[0].Rows.Count)
                            {
                                if (i == 6)
                                {
                                    z += "<span class='mar'><img  class='jsPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='100%' height='100%'></span>";
                                }
                                if (i == 7)
                                {
                                    z += "<span><img class='jsPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='100%' height='100%' ></span>";
                                }
                                if (i == 8)
                                {
                                    z += "<span  class='big' ><img  class='jsPreview' src='../" + ds.Tables[0].Rows[i]["IMAGESHOW"].ToString() + "' width='100%' height='100%' ></span>";
                                }
                            }
                        }
                    }
                    str.Append("<div class='l'>");
                    str.Append(x);
                    str.Append("</div>");
                    str.Append("<div class='c'>");
                    str.Append(y);
                    str.Append("</div>");
                    str.Append("<div class='r'>");
                    str.Append(z);
                    str.Append("</div>");
                    break;

                case "$about_rout$":
                    ds = new DataSet();
                    ds = mAbout.GetTopList(8, " CMS_ABOUT.STATUS = '1' AND CMS_ABOUT.channel ='4a1a475e-1367-4c7b-9e8f-142ae90dbbbb' ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str.Append("<div class='tit'>");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            str.Append("<span>"+ ds.Tables[0].Rows[i]["DESCRIPTION"].ToString() + "</span>");
                           
                        }
                        str.Append("</div>");
                    }
                    break;
                #endregion
            }

            return str.ToString();
        }
    }
}
