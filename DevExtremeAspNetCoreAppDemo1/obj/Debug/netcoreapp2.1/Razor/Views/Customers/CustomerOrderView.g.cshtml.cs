#pragma checksum "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fc5d793462566cabc06ed9a75605326009a14fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customers_CustomerOrderView), @"mvc.1.0.view", @"/Views/Customers/CustomerOrderView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customers/CustomerOrderView.cshtml", typeof(AspNetCore.Views_Customers_CustomerOrderView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fc5d793462566cabc06ed9a75605326009a14fd", @"/Views/Customers/CustomerOrderView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10a737c4be0bb9561789261b7c39d890207533ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Customers_CustomerOrderView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Customer>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 2, true);
            WriteLiteral(" \n");
            EndContext();
#line 3 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
  
    Layout = "_LayoutCustomer";

#line default
#line hidden
            BeginContext(55, 41, true);
            WriteLiteral("\n<div class=\"cust-details\">\r\n    <h5>ID: ");
            EndContext();
            BeginContext(97, 8, false);
#line 8 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
       Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(105, 15, true);
            WriteLiteral("  &nbsp  Name: ");
            EndContext();
            BeginContext(121, 10, false);
#line 8 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
                               Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(131, 23, true);
            WriteLiteral("</h5>\r\n    <h5>Gender: ");
            EndContext();
            BeginContext(155, 12, false);
#line 9 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
           Write(Model.Gender);

#line default
#line hidden
            EndContext();
            BeginContext(167, 17, true);
            WriteLiteral("   &nbsp  Phone: ");
            EndContext();
            BeginContext(185, 11, false);
#line 9 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
                                         Write(Model.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(196, 24, true);
            WriteLiteral("</h5>\r\n    <h5>Address: ");
            EndContext();
            BeginContext(221, 13, false);
#line 10 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
            Write(Model.Address);

#line default
#line hidden
            EndContext();
            BeginContext(234, 16, true);
            WriteLiteral("   &nbsp  City: ");
            EndContext();
            BeginContext(251, 10, false);
#line 10 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
                                          Write(Model.City);

#line default
#line hidden
            EndContext();
            BeginContext(261, 24, true);
            WriteLiteral("</h5>\r\n    <h5>Country: ");
            EndContext();
            BeginContext(286, 13, false);
#line 11 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
            Write(Model.Country);

#line default
#line hidden
            EndContext();
            BeginContext(299, 36, true);
            WriteLiteral("</h5>\r\n</div> \r\n<h2>My Orders</h2>\r\n");
            EndContext();
            BeginContext(337, 1027, false);
#line 14 "C:\Users\aaijaz\source\repos\DevExtremeAspNetCoreAppDemo1\DevExtremeAspNetCoreAppDemo1\Views\Customers\CustomerOrderView.cshtml"
Write(Html.DevExtreme().DataGrid<DevExtremeAspNetCoreAppDemo1.Models.Order>()
    .DataSource(ds => ds.Mvc()
        .Controller("Orders")
        .LoadAction("Get")
        .LoadParams(new { customerId = @Model.Id })
        .InsertAction("Post")
        .UpdateAction("Put")
        .DeleteAction("Delete")
        .Key("OrderId")
    )
    .RemoteOperations(true)
    .Columns(columns => {

        columns.AddFor(m => m.OrderId).AllowEditing(false);

        columns.AddFor(m => m.CustomerId).Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Orders").LoadAction("CustomersLookup").LoadParams( new { custid = @Model.Id }) .Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
        );

        columns.AddFor(m => m.NumberOfItems);

        columns.AddFor(m => m.TotalPrice);

        columns.AddFor(m => m.PaymentStatus);
    })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
