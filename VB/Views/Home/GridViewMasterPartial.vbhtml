@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "masterGrid"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewMasterPartial"}
            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "GridViewMasterAddNewPartial"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "GridViewMasterUpdatePartial"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "GridViewMasterDeletePartial"}
            settings.Width = 400

            settings.KeyFieldName = "ID"
            settings.Columns.Add("Number")
            settings.Columns.Add("Floor")
            settings.Columns.Add("Description")

            settings.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
            settings.SettingsDetail.ShowDetailRow = True

            settings.CommandColumn.Visible = True
            settings.CommandColumn.NewButton.Visible = True
            settings.CommandColumn.DeleteButton.Visible = True
            settings.CommandColumn.EditButton.Visible = True

            settings.SetDetailRowTemplateContent( _
                Sub(c)
                        Html.RenderAction("GridViewDetailPartial", New With {.RoomID = DataBinder.Eval(c.DataItem, "ID")})
                End Sub)
    End Sub).Bind(Model).GetHtml()
