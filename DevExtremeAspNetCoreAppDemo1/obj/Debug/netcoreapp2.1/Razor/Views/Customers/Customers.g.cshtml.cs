#pragma checksum "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\Customers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "031ac4b0a38837dbfc5d34be719c3ea18e3fd12a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customers_Customers), @"mvc.1.0.view", @"/Views/Customers/Customers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customers/Customers.cshtml", typeof(AspNetCore.Views_Customers_Customers))]
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
#line 1 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\_ViewImports.cshtml"
using DevExtremeAspNetCoreAppDemo1;

#line default
#line hidden
#line 2 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\_ViewImports.cshtml"
using DevExtremeAspNetCoreAppDemo1.Models;

#line default
#line hidden
#line 3 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\_ViewImports.cshtml"
using DevExtremeAspNetCoreAppDemo1.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"031ac4b0a38837dbfc5d34be719c3ea18e3fd12a", @"/Views/Customers/Customers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10a737c4be0bb9561789261b7c39d890207533ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Customers_Customers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Customer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 24, true);
            WriteLiteral("\r\n<h3>Customers</h3>\r\n\r\n");
            EndContext();
            BeginContext(56, 940, false);
#line 5 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\Customers.cshtml"
Write(Html.DevExtreme().DataGrid<DevExtremeAspNetCoreAppDemo1.Models.Customer>()
        .DataSource(ds => ds.Mvc()
            .Controller("Customers")
            .LoadAction("Get")
            .InsertAction("Post")
            .UpdateAction("Put")
            .DeleteAction("Delete")
            .Key("Id")
        )
        .RemoteOperations(true)
        .Columns(columns =>
        {
            columns.AddFor(m => m.Name);

            columns.AddFor(m => m.Gender);

            columns.AddFor(m => m.Phone);

            columns.AddFor(m => m.Address);

            columns.AddFor(m => m.City);

            columns.AddFor(m => m.Country);
        })
        .Paging(p => p.PageSize(10))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(f => f.Visible(true))
        .Editing(e => e
            .AllowAdding(true)
            .AllowUpdating(true)
            .AllowDeleting(true)
        )
);

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
