#pragma checksum "E:\asp.netcore2.1\ReleaseNews\ReleaseNews.Web\Areas\Admin\Views\Users\UsersAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6a6a17f95837cae9081f87fe1f6e1a7fcc137c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_UsersAdd), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/UsersAdd.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Users/UsersAdd.cshtml", typeof(AspNetCore.Areas_Admin_Views_Users_UsersAdd))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6a6a17f95837cae9081f87fe1f6e1a7fcc137c6", @"/Areas/Admin/Views/Users/UsersAdd.cshtml")]
    public class Areas_Admin_Views_Users_UsersAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\asp.netcore2.1\ReleaseNews\ReleaseNews.Web\Areas\Admin\Views\Users\UsersAdd.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 25, true);
            WriteLiteral("<!DOCTYPE HTML>\r\n<html>\r\n");
            EndContext();
            BeginContext(54, 1013, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6a6a17f95837cae9081f87fe1f6e1a7fcc137c63246", async() => {
                BeginContext(60, 1000, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""renderer"" content=""webkit|ie-comp|ie-stand"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"" />
    <meta http-equiv=""Cache-Control"" content=""no-siteapp"" />
    <!--[if lt IE 9]>
    <script type=""text/javascript"" src=""/admin/js/html5.js""></script>
    <script type=""text/javascript"" src=""/admin/js/respond.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/PIE_IE678.js""></script>
    <![endif]-->
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/css/H-ui.css"" />
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/css/H-ui.admin.css"" />
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/font/font-awesome.min.css"" />
    <!--[if IE 7]>
    <link href=""/admin/font/font-awesome-ie7.min.css"" rel=""stylesheet"" type=""text/css"" />
    <![endif]-->
    <title>添加用户</title>
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
            BeginContext(1067, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1069, 3733, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6a6a17f95837cae9081f87fe1f6e1a7fcc137c65483", async() => {
                BeginContext(1075, 3720, true);
                WriteLiteral(@"
    <div class=""pd-20"">
        <div class=""Huiform"">
            <form method=""post"" enctype=""multipart/form-data"" id=""addForm"">
                <table class=""table table-bg"">
                    <tbody>
                        <tr>
                            <th width=""300"" class=""text-r""><span class=""c-red"">*</span> 账号：</th>
                            <td>
                                <input type=""text"" style=""width:300px"" class=""input-text"" value="""" placeholder="""" id=""F_Account"" name=""F_Account"" datatype=""*2-16"" nullmsg=""账号不能为空"">
                            </td>
                        </tr>
                        <tr>
                            <th class=""text-r""><span class=""c-red"">*</span> 密码：</th>
                            <td>
                                <input type=""text"" style=""width:300px"" class=""input-text"" value="""" placeholder="""" id=""F_Password"" name=""F_Password"" datatype=""*2-16"" nullmsg=""密码不能为空"">
                            </td>
                        </tr>
  ");
                WriteLiteral(@"                      <tr>
                            <th class=""text-r"">真实姓名：</th>
                            <td>
                                <input type=""text"" style=""width:300px"" class=""input-text"" value="""" placeholder="""" id=""F_RealName"" name=""F_RealName"" datatype=""*2-16"">
                            </td>
                        </tr>
                        <tr>
                            <th class=""text-r"">性别：</th>
                            <td>
                                <input type=""radio"" value=""1"" placeholder="""" id=""F_Sex"" name=""F_Sex"" datatype=""*2-16"">男
                                <input type=""radio"" value=""0"" placeholder="""" id=""F_Sex"" name=""F_Sex"" datatype=""*2-16"">女
                            </td>
                        </tr>
                        <tr>
                            <th class=""text-r"">头像：</th>
                            <td><input type=""file"" style=""width:300px"" class="""" name=""img"" multiple datatype=""*2-120"" nullmsg=""头像不能为空""></td>
            ");
                WriteLiteral(@"            </tr>
                        <tr>
                            <th class=""text-r"">备注：</th>
                            <td><textarea class=""input-text"" name=""F_Remark"" id=""F_Remark"" style=""height:400px;width:350px;""></textarea></td>
                        </tr>
                        <tr>
                            <th></th>
                            <td><button class=""btn btn-success radius"" type=""button"" onclick=""add()""><i class=""icon-ok""></i> 确定</button></td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    </div>
    <script type=""text/javascript"" src=""/admin/js/jquery.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/Validform_v5.3.2_min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/H-ui.js""></script>
    <script type=""text/javascript"" src=""/admin/js/H-ui.admin.js""></script>
    <script type=""text/javascript"">
        $("".Huiform"").Validform();
        functio");
                WriteLiteral(@"n add() {
            var formData = new FormData(document.getElementById(""addForm""));
            $.ajax({
                type: 'post',
                async: false,
                cache: false,
                contentType: false,
                processData: false,
                url: '/Admin/Users/AddUser',
                data: formData,
                success: function (data) {
                    if (data.code == 200) {
                        parent.reload();
                    } else {
                        alert(data.result);
                    }
                }
            });
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
            BeginContext(4802, 9, true);
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