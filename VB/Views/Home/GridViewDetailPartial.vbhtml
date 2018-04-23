@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "detailGridView_" & ViewData("RoomID")
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewDetailPartial", .RoomID = ViewData("RoomID")}
            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "GridViewDetailAddNewPartial", .RoomID = ViewData("RoomID")}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "GridViewDetailUpdatePartial", .RoomID = ViewData("RoomID")}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "GridViewDetailDeletePartial", .RoomID = ViewData("RoomID")}

            settings.CommandColumn.Visible = True
            settings.CommandColumn.NewButton.Visible = True
            settings.CommandColumn.DeleteButton.Visible = True
            settings.CommandColumn.EditButton.Visible = True
       
            settings.KeyFieldName = "ID"
            settings.Columns.Add("FirstName")
            settings.Columns.Add("SecondName")
            settings.Columns.Add("Description")
        
            settings.DataBinding = _
                Sub(sender, e)
                        CType(sender, MVCxGridView).ForceDataRowType(GetType(DevExpress.Razor.Models.Person))
                End Sub
    End Sub).Bind(Model).GetHtml()