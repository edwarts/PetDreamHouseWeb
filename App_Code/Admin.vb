Imports Microsoft.VisualBasic
Imports Anetics.Data
Imports Anetics.Crypto.CryptoService
Imports SharedProperties
Imports System.Data

Public Class Admin

    Public Shared Function AdminLogon(Username As String, Password As String) As Boolean
        Dim sess = HashString(Now & Username & Now.AddDays(Now.DayOfWeek) & Password)

        Dim db As New EasySql
        db.ReturnType = EasyDBReturnType.Rows_Affected
        db.AddParameter("@AdmSession", sess)
        db.AddParameter("@AdmEmail", Username)
        db.AddParameter("@AdmPassword", HashString(Password))

        db.CommandText = "UPDATE tblAdminUsers SET AdmSession = @AdmSession,AdmLastLogin = GetDate() WHERE AdmEmail = @AdmEmail AND AdmPassword = @AdmPassword"

        Dim i = db.Execute

        If i > 0 Then
            MyCookie("AdminSession") = sess
            MyCookie("AdminEmail") = Username
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared ReadOnly Property ThisAdmin As datarow
        Get
            Dim db = New EasySql
            db.ReturnType = EasyDBReturnType.DataRow
            db.AddParameter("@AdmSession", MyCookie("AdminSession"))
            db.CommandText = "SELECT * FROM tblAdminUsers WHERE AdmSession = @AdmSession AND AdmSession IS NOT NULL"
            Dim dr As DataRow = db.Execute
            Return dr
        End Get
    End Property

    Public Shared Function GetProductList() As DataTable

        Dim db = New EasySql
        db.ReturnType = EasyDBReturnType.DataTable
        db.CommandText = "SELECT *," & vbCrLf
        db.CommandText &= "COALESCE((SELECT count(*) FROM tblBasket WHERE BasProductID = PrdID AND BasComplete = 1),0) as Sales," & vbCrLf
        db.CommandText &= "COALESCE((SELECT count(*) FROM tblProductOption WHERE OptProductID = PrdID),0) as Options," & vbCrLf
        db.CommandText &= "COALESCE((SELECT count(*) FROM tblProductImage WHERE PimProductID = PrdID),0) as Images" & vbCrLf
        db.CommandText &= "" & vbCrLf
        db.CommandText &= "FROM tblProduct ORDER BY PrdFullName ASC"
        db.ThowErrors = True
        Dim dt As DataTable = db.Execute
        Return dt
    End Function
End Class
