<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128551713/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4271)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DevExpress.Razor/Controllers/HomeController.cs)
* [Company.cs](./CS/DevExpress.Razor/Models/Company.cs)
* [GridViewDetailPartial.cshtml](./CS/DevExpress.Razor/Views/Home/GridViewDetailPartial.cshtml)
* **[GridViewMasterPartial.cshtml](./CS/DevExpress.Razor/Views/Home/GridViewMasterPartial.cshtml)**
* [Index.cshtml](./CS/DevExpress.Razor/Views/Home/Index.cshtml)
<!-- default file list end -->
# How to implement the master detail GridView with editing capabilities
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4271/)**
<!-- run online end -->


<p>This example illustrates how to implement the master detail GridView with editing capabilities.<br /> Perform the following steps to define the master-detail layout:<br /> 1) Define both master and detail GridView settings within separate PartialView files (see <a href="https://docs.devexpress.com/AspNetMvc/9052/common-features/callback-based-functionality"><u>Callback-Based Functionality</u></a>);<br /> 2) Set the master grid's <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.MVCxGridViewDetailSettings._members"><u>SettingsDetail.ShowDetailRow</u></a> property to "True";<br /> 3) Define the master grid's DetailRow content via the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewSettings.SetDetailRowTemplateContent.overloads?p=netframework"><u>SetDetailRowTemplateContent</u></a> method and render the detail grid's PartialView inside.<br /><br /><strong>Note:<br /></strong>Values passed in a detail grid's CallbackRoute must have a unique name and must not replicate any other names on a page: <a href="https://supportcenter.devexpress.com/ticket/details/q577974/gridview-the-parameters-dictionary-contains-a-null-entry-for-parameter-id-of-non">Q577974: GridView - "The parameters dictionary contains a null entry for parameter 'id' of non-nullable type 'System.Int32'" error occurs when canceling editing in the detail GridView</a><strong><br /><br /><br />See also:<br /></strong><a href="https://supportcenter.devexpress.com/ticket/details/t203289/gridview-advanced-master-detail-view">GridView - Advanced Master-Detail View</a><strong><br /></strong><a href="https://supportcenter.devexpress.com/ticket/details/e248/a-simple-example-of-master-detail-grids-with-editing-capabilities">A simple example of master-detail grids with editing capabilities</a><br /><br /></p>

<br/>


