<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128551713/12.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4271)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DevExpress.Razor/Controllers/HomeController.cs)
* [Company.cs](./CS/DevExpress.Razor/Models/Company.cs)
* [GridViewDetailPartial.cshtml](./CS/DevExpress.Razor/Views/Home/GridViewDetailPartial.cshtml)
* [GridViewMasterPartial.cshtml](./CS/DevExpress.Razor/Views/Home/GridViewMasterPartial.cshtml)
* [Index.cshtml](./CS/DevExpress.Razor/Views/Home/Index.cshtml)
<!-- default file list end -->
# How to implement the master detail GridView with editing capabilities


<p>This example illustrates how to implement the master detail GridView with editing capabilities.<br /> Perform the following steps to define the master-detail layout:<br /> 1) Define both master and detail GridView settings within separate PartialView files (see the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9052"><u>Using Callbacks</u></a>);<br /> 2) Set the master grid's <a href="https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridViewDetailSettings.ShowDetailRow"><u>SettingsDetail.ShowDetailRow</u></a> property to "True";<br /> 3) Define the master grid's DetailRow content via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_SetDetailRowTemplateContenttopic"><u>SetDetailRowTemplateContent</u></a> method and render the detail grid's PartialView inside.<br /><br /><strong>Note:<br /></strong>Values passed in a detail grid's CallbackRoute must have a unique name and must not replicate any other names on a page: <a href="https://www.devexpress.com/Support/Center/p/Q577974">Q577974: GridView - "The parameters dictionary contains a null entry for parameter 'id' of non-nullable type 'System.Int32'" error occurs when canceling editing in the detail GridView</a><strong><br /><br /><br />See also:<br /></strong><a href="https://www.devexpress.com/Support/Center/p/T203289">GridView - Advanced Master-Detail View</a><strong><br /></strong><a href="https://www.devexpress.com/Support/Center/p/E248">A simple example of master-detail grids with editing capabilities</a><br /><br /></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-gridview-master-detail-with-editing&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-gridview-master-detail-with-editing&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
