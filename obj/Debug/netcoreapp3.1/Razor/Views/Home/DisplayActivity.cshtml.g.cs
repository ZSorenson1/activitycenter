#pragma checksum "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ad0aca7d792eb4c3d0d18f01aefd8bea0f989a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayActivity), @"mvc.1.0.view", @"/Views/Home/DisplayActivity.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\_ViewImports.cshtml"
using activitycenter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\_ViewImports.cshtml"
using activitycenter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ad0aca7d792eb4c3d0d18f01aefd8bea0f989a2", @"/Views/Home/DisplayActivity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e84ac10d5b89967672778e1c122d865c8591d18", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayActivity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AnActivity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
  
    ViewData["Title"] = "Activity";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">");
#nullable restore
#line 6 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
                     Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 7 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
     foreach (UserActivity ua in ViewBag.User.Activities)
    {
        if(ua.AnActivityID == @Model.AnActivityId)
        {
            ViewBag.Valid = true;
            break;
        }
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
     if(ViewBag.Valid == false){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=\"", 377, "\"", 409, 3);
            WriteAttributeValue("", 384, "/", 384, 1, true);
#nullable restore
#line 16 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
WriteAttributeValue("", 385, Model.AnActivityId, 385, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 404, "/join", 404, 5, true);
            EndWriteAttribute();
            WriteLiteral(">Join</a>\r\n");
#nullable restore
#line 17 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
    }
    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("href", " href=\"", 449, "\"", 482, 3);
            WriteAttributeValue("", 456, "/", 456, 1, true);
#nullable restore
#line 19 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
WriteAttributeValue("", 457, Model.AnActivityId, 457, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 476, "/leave", 476, 6, true);
            EndWriteAttribute();
            WriteLiteral(">Leave</a>\r\n");
#nullable restore
#line 20 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h2>Event Coordinator: ");
#nullable restore
#line 22 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
                      Write(Model.Coordinator.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <h2>Description:</h2>\r\n    <h3>");
#nullable restore
#line 24 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
   Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h3>Participants</h3>\r\n    <ul>\r\n");
#nullable restore
#line 27 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
         foreach (UserActivity u in @Model.Participants)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>");
#nullable restore
#line 29 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
           Write(u.user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 30 "C:\Users\Zach\desktop\CodingDojo\csharp\activitycenter\Views\Home\DisplayActivity.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AnActivity> Html { get; private set; }
    }
}
#pragma warning restore 1591
