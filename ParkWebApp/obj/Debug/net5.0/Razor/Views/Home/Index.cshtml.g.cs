#pragma checksum "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3630bfa2deb41f7895b3d5f4327105d48083f9b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\_ViewImports.cshtml"
using ParkWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\_ViewImports.cshtml"
using ParkWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3630bfa2deb41f7895b3d5f4327105d48083f9b4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7555ec631fa2185849abdbbdb1a8f083d2bc5ca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ParkWebApp.Models.View_Model.IndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
 foreach (var nationalpark in Model.nationalParkList)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container backgroundWhite pb-4\">\n\n\n    <div class=\"card border\">\n\n        <div class=\"card-header bg-dark text-light ml-0 row container\">\n");
            WriteLiteral("            <div class=\"col-md-6 \">\n                <h1 class=\"text-warning\">Name : ");
#nullable restore
#line 15 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                           Write(nationalpark.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n            </div>\n            <div class=\"col-6\">\n                <h1 class=\"text-warning float-right\">State : ");
#nullable restore
#line 18 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                                        Write(nationalpark.State);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
            </div>
        </div>
        <div class=""card-body"">
            <div class=""container rounded p-2"">
                <div class=""row"">
                    <div class=""col-12 col-lg-8"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <h3 style=""color:#bbb9b9"">Established: ");
#nullable restore
#line 27 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                                                  Write(nationalpark.Established.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            </div>
                            <div class=""col-12"">
                                <table class=""table table-striped"" style=""border:1px solid #808080 "">
                                    <thead>
                                        <tr class=""table-secondary"">
                                            <th>
                                                Trail
                                            </th>
                                            <th>Distance</th>
                                            <th>Elevation Gain</th>
                                            <th>Difficulty</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 42 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                           var traillist = Model.trailList.Where(t => t.NationalParkId == nationalpark.Id); 

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                         foreach (var trail in traillist)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\n                                                <td>");
#nullable restore
#line 46 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                               Write(trail.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 47 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                               Write(trail.Distance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 48 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                               Write(trail.Elevation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 49 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                               Write(trail.Difficulty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                            </tr>\n");
#nullable restore
#line 51 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </tbody>\n                                </table>\n                            </div>\n                        </div>\n                    </div>\n                    <div class=\"col-12 col-lg-4 text-center\">\n");
#nullable restore
#line 59 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
                           
                            var base64 = Convert.ToBase64String(nationalpark.Picture);
                            var ImageSrc = string.Format("data:image/jpg;base64,{0}", base64);
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 2988, "\"", 3003, 1);
#nullable restore
#line 63 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 2994, ImageSrc, 2994, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top p-2 rounded\" width=\"100%\" />\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
#nullable restore
#line 69 "D:\asp.net core web api\parkNationalApi\ParkWebApp\Views\Home\Index.cshtml"
      }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ParkWebApp.Models.View_Model.IndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591