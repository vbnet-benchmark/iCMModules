
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web



    Public Class EditorDB

        Public Function SaveImage(ByVal moduleId As Integer, ByVal url As String, ByVal content() As Byte, ByVal contentType As String, ByVal size As Integer) As Integer
            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("AddImage", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parameterModuleID As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
            parameterModuleID.Value = moduleId
            myCommand.Parameters.Add(parameterModuleID)

            Dim parameterFileUrl As New SqlParameter("@FileNameUrl", SqlDbType.NVarChar, 250)
            parameterFileUrl.Value = url
            myCommand.Parameters.Add(parameterFileUrl)

            Dim parameterContent As New SqlParameter("@Content", SqlDbType.Image)
            parameterContent.Value = content
            myCommand.Parameters.Add(parameterContent)

            Dim parameterContentType As New SqlParameter("@ContentType", SqlDbType.NVarChar, 50)
            parameterContentType.Value = contentType
            myCommand.Parameters.Add(parameterContentType)

            Dim parameterContentSize As New SqlParameter("@ContentSize", SqlDbType.Int, 4)
            parameterContentSize.Value = size
            myCommand.Parameters.Add(parameterContentSize)

            Dim parameterItemId As New SqlParameter("@ItemID", SqlDbType.Int, 4)
            parameterItemId.Direction = ParameterDirection.Output
            myCommand.Parameters.Add(parameterItemId)

            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

            Return CInt(parameterItemId.Value)
        End Function

    End Class

