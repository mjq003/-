#pragma checksum "E:\asp.netcore2.1\ReleaseNews\ReleaseNews.Web\Areas\Admin\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5c3c43cd54a4af3fd531e4f2dbcdeb94bfb3ea2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Users/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Users_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5c3c43cd54a4af3fd531e4f2dbcdeb94bfb3ea2", @"/Areas/Admin/Views/Users/Index.cshtml")]
    public class Areas_Admin_Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\asp.netcore2.1\ReleaseNews\ReleaseNews.Web\Areas\Admin\Views\Users\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(27, 25, true);
            WriteLiteral("<!DOCTYPE HTML>\r\n<html>\r\n");
            EndContext();
            BeginContext(52, 1028, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5c3c43cd54a4af3fd531e4f2dbcdeb94bfb3ea23121", async() => {
                BeginContext(58, 1015, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""renderer"" content=""webkit|ie-comp|ie-stand"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"" />
    <meta http-equiv=""Cache-Control"" content=""no-siteapp"" />
    <!--[if lt IE 9]>
    <script type=""text/javascript"" src=""/admin/js/html5.js""></script>btn btn-success
    <script type=""text/javascript"" src=""/admin/js/respond.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/PIE_IE678.js""></script>
    <![endif]-->
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/css/H-ui.css"" />
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/css/H-ui.admin.css"" />
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/font/font-awesome.min.css"" />
    <!--[if IE 7]>
    <link href=""/admin/font/font-awesome-ie7.min.css"" rel=""stylesheet"" type=""text/css"" />
    <![endif]-->
    <title>用户管理</title>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1080, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1082, 6942, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5c3c43cd54a4af3fd531e4f2dbcdeb94bfb3ea25373", async() => {
                BeginContext(1088, 6929, true);
                WriteLiteral(@"
    <nav class=""Hui-breadcrumb""><i class=""icon-home""></i> 首页 <span class=""c-gray en"">&gt;</span> 用户中心 <span class=""c-gray en"">&gt;</span> 用户管理 <a class=""btn btn-success radius r mr-20"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""icon-refresh""></i></a></nav>
    <div class=""pd-20"">
        <div class=""text-c"">
            &nbsp;
            <input type=""text"" class=""input-text"" style=""width:250px"" placeholder=""输入用户名称或账号"" id=""keyword"" name=""keyword"">&nbsp;<button type=""button"" class=""btn btn-success"" onclick=""search()""><i class=""icon-search""></i> 搜用户</button>

        </div>
        <div class=""cl pd-5 bg-1 bk-gray mt-20"">
            <span class=""l"">
                <a href=""javascript:;"" onClick=""user_add('620','750','添加用户','/Admin/Users/UsersAdd')"" class=""btn btn-primary radius""><i class=""icon-plus""></i> 添加用户</a>
            </span>

        </div>
        <table class=""table table-border table-bordered table-hover table-bg t");
                WriteLiteral(@"able-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""80"">ID</th>
                    <th width=""100"">账号</th>
                    <th width=""100"">真实姓名</th>
                    <th width=""80"">性别</th>
                    <th width=""80"">头像</th>
                    <th width=""150"">创建日期</th>
                    <th width=""200"">备注</th>
                    <th width=""100"">操作</th>
                </tr>
            </thead>
            <tbody id=""users_contents""></tbody>
        </table>
        <div id=""pageNav"" class=""pageNav""></div>
    </div>
    <script type=""text/javascript"" src=""/admin/js/jquery.min.js""></script>
    <script type=""text/javascript"" src=""/admin/layer/layer.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/pagenav.cn.js""></script>
    <script type=""text/javascript"" src=""/admin/js/H-ui.js""></script>
    <script type=""text/javascript"" src=""/admin/plugin/My97DatePicker/WdatePicker.js""></script>
    <script type=""text");
                WriteLiteral(@"/javascript"" src=""/admin/js/jquery.dataTables.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/H-ui.admin.js""></script>
    <script type=""text/javascript"">
        var pageSize = 20;
        var pageIndex = 1;
        var currentPageCount = 0;
        var keyword = """";
        var lastPage = 1;
        window.onload = (function () {
            // optional set
            pageNav.pre = ""&lt;上一页"";
            pageNav.next = ""下一页&gt;"";
            getUsers(pageIndex, pageSize, keyword);
        });
        $('.table-sort').dataTable({
            ""lengthMenu"": false,//显示数量选择
            ""bFilter"": false,//过滤功能
            ""bPaginate"": false,//翻页信息
            ""bInfo"": false,//数量信息
            ""aaSorting"": [[1, ""desc""]],//默认第几个排序
            ""bStateSave"": true,//状态保存
            ""aoColumnDefs"": [
                //{""bVisible"": false, ""aTargets"": [ 3 ]} //控制列的隐藏显示
                { ""orderable"": false, ""aTargets"": [0, 1, 2, 3, 4, 5, 6, 7] }// 制定列不参与排序
            ]
     ");
                WriteLiteral(@"   });
        function search() {
            var keyword = $(""#keyword"").val();
            pageIndex = 1;
            getUsers(pageIndex, pageSize, keyword);
        }
        function getUsers(pageIndex, pageSize, keyword) {
            $.ajax({
                type: 'get',
                async: true,
                url: '/Admin/Users/GetUsers',
                data: { pageIndex: pageIndex, pageSize: pageSize, keyword: keyword },
                success: function (result) {
                    currentPageCount = result.data.length;//当前页的新闻数量
                    var totalPage = parseInt(result.total / pageSize + 1);//总页数
                    // p,当前页码,pn,总页面
                    pageNav.fn = function (p, pn) {
                        $(""#pageinfo"").text(""当前页:"" + p + "" 总页: "" + totalPage);
                        if (p != lastPage)
                            getUsers(p, pageSize, keyword)
                    };
                    pageNav.go(pageIndex, totalPage);
                    $");
                WriteLiteral(@"(""#users_contents"").empty();
                    for (var i = 0; i < result.data.length; i++) {
                        var trData = result.data[i];
                        console.log(trData);
                        var tr = '<tr class=""text-c""><td>' + trData.f_UserId + '</td><td>' + trData.f_Account + '</td><td>' + trData.f_RealName + '</td><td>' + trData.f_Sex + '</td><td><image src=""' + trData.f_Image + '"" style=""width: 80px;height: 80px;border-radius: 50%;align-items: center;justify-content: center;overflow: hidden;"" /></td><td>' + trData.f_CreateTime + '</td><td>' + trData.f_Remark + '</td><td class=""f-14 user-manage""><a title=""删除"" href=""javascript:;"" onClick=""del(this,' + trData.f_UserId + ')"" class=""ml-5"" style=""text-decoration:none""><i class=""icon-trash""></i></a><a title=""编辑"" href=""javascript:;"" onClick=""user_edit(\'4\',\'720\',\'830\',\'编辑' + trData.f_Account + '信息\',\'/Admin/Users/UserEdit?id=' + trData.f_UserId + '\')"" class=""ml-5"" style=""text-decoration:none""><i class=""icon-edit""></i></a><a ");
                WriteLiteral(@"title=""修改密码"" href=""javascript:;"" onClick=""user_edit(\'4\',\'550\',\'300\',\'修改' + trData.f_Account + '密码\',\'/Admin/Users/UserUpdatePwd?id=' + trData.f_UserId + '\')"" class=""ml-5"" style=""text-decoration:none""><i class=""icon-keyboard""></i></a></td></tr>';
                        $(""#users_contents"").append(tr);
                    }
                    lastPage = pageIndex;
                }
            });
        }
        //删除新闻
        function del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                //$(obj).parents(""tr"").remove();
                //layer.msg('已删除!', 1);
                $.ajax({
                    type: 'post',
                    async: true,
                    url: '/Admin/News/DelNews',
                    data: { id: id },
                    success: function (result) {
                        if (result.code == 200) {
                            layer.msg('已删除!', 1);
                            if (currentPageCount == 1) {
       ");
                WriteLiteral(@"                         if (pageIndex == 1) {
                                    reload();
                                } else {
                                    getNews(pageIndex - 1, pageSize, classifyId, keyword);
                                }
                            } else {
                                getNews(pageIndex, pageSize, classifyId, keyword);
                                //$(obj).parents(""tr"").remove();
                            }
                        } else {
                            layer.msg(result.result, 1);
                        }
                    }
                });
            });
        }




        function reload() {
            location.replace(location.href);
        }
    </script>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8024, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591