Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationManager
Imports SharedProperties
Imports System.Text.RegularExpressions
Imports Anetics.Crypto.CryptoService
Imports Anetics.Data
Imports System.Data

Public Class SharedProperties
    Public Shared Property CookieTimeout As TimeSpan = New TimeSpan(365, 0, 0, 0)

    Public Shared ReadOnly Property MyAppSettings(Key As String) As String
        Get
            Dim db = New EasySql
            db.AddParameter("@SetName", Key)
            db.ReturnType = EasyDBReturnType.DataRow
            Dim dr = db.Select("tblSetting")
            If Not dr Is Nothing Then
                Return CN(dr("SetValue"))
            End If
            Try
                Return System.Configuration.ConfigurationManager.AppSettings(Key)
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property ConceptID As Integer
        Get
            Dim Part As String = "ConceptID"
            Dim qs = HttpContext.Current.Request.QueryString
            If IsNumeric(qs(Part)) Then Return qs(Part)
            Return 0
        End Get
    End Property
    Public Shared ReadOnly Property CoolID As Integer
        Get
            Dim Part As String = "CoolID"
            Dim qs = HttpContext.Current.Request.QueryString
            If IsNumeric(qs(Part)) Then Return qs(Part)
            Return 0
        End Get
    End Property
    Public Shared ReadOnly Property ProductID As Integer
        Get
            Dim Part As String = "ProductID"
            Dim qs = HttpContext.Current.Request.QueryString
            If IsNumeric(qs(Part)) Then Return qs(Part)
            Return 0
        End Get
    End Property

    Public Shared ReadOnly Property ThisSession As String
        Get
            Dim sess = MyCookie("SessionKey")
            If sess = "" Then
                sess = HashString(Now & HttpContext.Current.Request.UserHostAddress)
                MyCookie("SessionKey") = sess
            End If
            Return sess
        End Get
    End Property

    Public Shared Property MyCookie(key As String) As String
        Get
            Dim ck = HttpContext.Current.Request.Cookies(key)
            If ck Is Nothing Then Return ""
            ck.Expires = Now.Add(CookieTimeout)
            HttpContext.Current.Response.Cookies.Add(ck)
            Return ck.Value
        End Get
        Set(value As String)
            Dim ck = HttpContext.Current.Request.Cookies(key)
            If ck Is Nothing Then ck = New HttpCookie(key)
            ck.Value = value
            ck.Expires = Now.Add(CookieTimeout)
            HttpContext.Current.Response.Cookies.Add(ck)
        End Set
    End Property

    Public Shared ReadOnly Property Constring As String
        Get
            If My.Computer.Name.ToLower = "development" Then Return ConnectionStrings("Net1-DB").ConnectionString
            If My.Computer.Name.ToLower = "net1" Then Return ConnectionStrings("Net1-DB").ConnectionString
            Return ConnectionStrings("DB").ConnectionString
        End Get
    End Property

    Public Shared ReadOnly Property ThisUser As Data.DataRow
        Get
            Dim db = New EasySql(Constring)
            db.AddParameter("@Session", ThisSession)
            db.ReturnType = EasyDBReturnType.DataRow
            db.CommandText = "SELECT * FROM tblUser WHERE UsrSession = @Session"
            Dim dr As DataRow = db.Execute
            If dr Is Nothing Then Return Nothing
            If Not IsDBNull(dr("UsrPassResetKey")) Then Return Nothing
            Return dr
        End Get
    End Property

    Public Shared ReadOnly Property ThisUserLowSecurity As Data.DataRow
        Get
            Dim db = New EasySql(Constring)
            db.AddParameter("@Session", ThisSession)
            db.ReturnType = EasyDBReturnType.DataRow
            db.CommandText = "SELECT * FROM tblUser LEFT JOIN tblDesigner ON DesID = UsrDesignerID WHERE UsrSession = @Session"
            Dim dr As DataRow = db.Execute
            If dr Is Nothing Then Return Nothing
            'If Not IsDBNull(dr("UsrPassResetKey")) Then Return Nothing
            Return dr
        End Get
    End Property

    Public Shared Function PublicLogon(EmailAddress As String, Password As String) As Boolean
        Dim db = New EasySql(Constring)
        db.AddParameter("@Session", ThisSession)
        db.ReturnType = EasyDBReturnType.Rows_Affected
        db.CommandText = "UPDATE tblUser SET UsrSession = null WHERE UsrSession = @Session;"
        db.Execute()

        db = New EasySql(Constring)
        db.AddParameter("@Session", ThisSession)
        db.AddParameter("@UsrEmailAddress", EmailAddress)
        db.AddParameter("@UsrPassword", HashString(Password))
        db.ReturnType = EasyDBReturnType.Rows_Affected
        db.CommandText = "UPDATE tblUser SET UsrSession = @Session WHERE UsrEmailAddress = @UsrEmailAddress AND UsrPassword = @UsrPassword AND UsrPassResetKey is null;"
        Dim i = db.Execute()
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub LogoffCurrentUser()
        Dim db = New EasySQL(Constring)
        db.AddParameter("@Session", ThisSession)
        db.ReturnType = EasyDBReturnType.Rows_Affected
        db.CommandText = "UPDATE tblUser SET UsrSession = null WHERE UsrSession = @Session;"
        db.Execute()
    End Sub


    Public Shared Function PublicUserFindByEmail(EmailAddress As String) As DataRow
        Dim db = New EasySQL(Constring)
        db.AddParameter("@UsrEmailAddress", EmailAddress)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblUser WHERE UsrEmailAddress = @UsrEmailAddress;"
        Dim dr As DataRow = db.Execute()
        Return dr
    End Function

    Public Shared Function FindDesigner(Name As String) As DataRow
        Dim db = New EasySQL(Constring)
        db.AddParameter("@DesName", Name)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT * FROM tblDesigner WHERE DesName = @DesName;"
        Dim dr As DataRow = db.Execute()
        Return dr
    End Function

    Public Shared Function PublicUserFindVote(UserID As Integer, ConceptID As Integer) As Integer
        Dim db = New EasySQL(Constring)
        db.AddParameter("@CvtUserID", UserID)
        db.AddParameter("@CvtConceptID", ConceptID)
        db.ReturnType = EasyDBReturnType.DataRow
        db.CommandText = "SELECT CvtVote FROM tblConceptVote WHERE CvtUserID = @CvtUserID AND CvtConceptID = @CvtConceptID;"
        Dim dr As DataRow = db.Execute()
        If dr Is Nothing Then Return -1
        Return dr(0)
    End Function

    Public Shared Function PublicRegister(Name As String, EmailAddress As String, Password As String) As Boolean
        Dim db = New EasySQL(Constring)
        db.AddParameter("@UsrSession", ThisSession)
        db.AddParameter("@UsrName", Name)
        db.AddParameter("@UsrEmailAddress", EmailAddress)
        db.AddParameter("@UsrPassword", HashString(Password))
        db.ReturnType = EasyDBReturnType.Scope_Identity
        db.CommandText = db.InsertString("tblUser", True, "UsrEmailAddress")
        Dim i = db.Execute()
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Coalesce Null, Converts null values into a string or other chosen default
    ''' </summary>
    ''' <param name="obj">The input object</param>
    ''' <param name="DefaultValue">A default value to return if object is Null, Nothing or DbNull.value</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CN(obj As Object, Optional DefaultValue As Object = "") As Object
        Get
            If IsDBNull(obj) Then Return DefaultValue
            If IsNothing(obj) Then Return DefaultValue
            Return obj
        End Get
    End Property

    Public Shared Function CurrentHost() As String()
        Dim hst As String = HttpContext.Current.Request.Url.Host
        Dim pattern As String = ""
        pattern = "(www.|concept.|cool.|store.)(pdh.omega|pdh.development.anetics.co.uk|petdreamhouse.com)"
        Dim r = New Regex(pattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Dim m As Match = r.Match(hst)

        If m.Success Then Return Split(m.Groups(0).Value, ".", 2)


        Return New String(1) {"", hst}
    End Function

    Public Shared Function IsEmail(txt As String) As Boolean
        Dim re1 As String = "([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})"  'Email Address 1

        Dim r As Regex = New Regex(re1, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Dim m As Match = r.Match(txt)
        Return m.Success
    End Function

    Public Shared Function IsUrl(url As String) As Boolean
        Dim u As Uri = Nothing

        Return Uri.TryCreate(url, UriKind.Absolute, u)
    End Function

    Public Shared Function TypeToCollection(t As Type) As Specialized.NameValueCollection
        Dim sp = New Specialized.NameValueCollection

        Dim arr = [Enum].GetNames(t)
        Dim arv = [Enum].GetValues(t)

        For n As Integer = 0 To arr.Length - 1
            sp.Add(arr(n), arv(n))

        Next


        Return sp
    End Function

    Shared Sub SetField(tb As TextBox, ValidityState As Boolean, err As String, ErrLabel As Label)
        If ValidityState Then
            tb.CssClass = ""
        Else
            tb.CssClass = "Wrong"
            ErrLabel.Text = err
        End If

    End Sub

    Shared Sub SetField(ddl As DropDownList, ValidityState As Boolean, err As String, ErrLabel As Label)
        If ValidityState Then
            ddl.CssClass = ""
        Else
            ddl.CssClass = "Wrong"
            ErrLabel.Text = err
        End If
    End Sub

    Shared Function GenerateResetKey(len As Integer) As String
        Dim arr As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim txt As String = ""
        While txt.Length < len
            Dim i = arr(RandomNumber(0, arr.Length - 1))
            If Not txt.Contains(i) Then txt &= i
        End While
        Return txt
    End Function

    Public Shared ReadOnly Property RandomNumber(Min As Integer, Max As Integer) As Integer
        Get
            Dim r = New Random(Now.Millisecond)
            Return r.Next(Min, Max)
        End Get
    End Property


    Shared Function GetPageData(name As String) As DataRow
        Dim db = New EasySql
        db.AddParameter("@PagTag", name)
        db.ReturnType = EasyDBReturnType.DataRow

        Dim b = New EasySqlJoinBuilder("tblPage", True)
        b.AddJoin(JoinOption.LEFT, "tblHeaderImages", "PagHeaderImage = HedID")
        db.CommandText = b.CommandText

        db.CommandText &= " WHERE PagTag = @PagTag"

        db.ThowErrors = True
        Dim dr As DataRow = db.Execute

        Return dr
    End Function

End Class

Public Class BasketManager

    Public Shared Function AddProduct(ProductID As Integer, OptionID As Integer) As Boolean
        Dim db = New EasySQL(Constring)
        db.AddParameter("@BasSession", ThisSession)
        db.AddParameter("@BasProductID", ProductID)
        db.AddParameter("@BasOptionID", OptionID)
        db.AddParameter("@BasPrice", 0)
        db.CommandText = "DELETE FROM tblBasket WHERE BasPrice = 0;" & vbCrLf
        db.CommandText &= "SET @BasPrice = (SELECT COALESCE((SELECT OptPrice FROM tblProductOption WHERE OptID = @BasOptionID), PrdPrice) FROM tblProduct WHERE PrdID = @BasProductID);" & vbCrLf
        db.CommandText &= "IF NOT EXISTS(SELECT * FROM tblBasket WHERE BasComplete = 0 AND BasSession = @BasSession AND BasProductID = @BasProductID AND BasOptionID = @BasOptionID)" & vbCrLf
        db.CommandText &= "INSERT INTO tblBasket (BasSession,BasProductID,BasOptionID,BasPrice) VALUES(@BasSession,@BasProductID,@BasOptionID,@BasPrice)"
        db.Execute()

        Return db.ErrorString = ""
    End Function

    Public Shared Sub RemoveProduct(ProductID As Integer, OptionID As Integer)
        Dim db = New EasySQL(Constring)
        db.AddParameter("@BasSession", ThisSession)
        db.AddParameter("@BasProductID", ProductID)
        db.AddParameter("@BasOptionID", OptionID)
        db.CommandText = "DELETE FROM tblBasket WHERE BasSession = @BasSession AND BasProductID = @BasProductID AND BasOptionID = @BasOptionID"
        db.Execute()
    End Sub

    Public Shared Sub RemoveProduct(BasID As Integer)
        Dim db = New EasySQL(Constring)
        db.AddParameter("@BasSession", ThisSession)
        db.AddParameter("@BasID", BasID)
        db.CommandText = "DELETE FROM tblBasket WHERE BasSession = @BasSession AND BasID = @BasID"
        db.Execute()
    End Sub

    Public Shared Sub UpdateQuantity(BasID As Integer, NewQuantity As Integer)
        Dim db = New EasySQL(Constring)
        db.AddParameter("@BasSession", ThisSession)
        db.AddParameter("@BasID", BasID)
        db.AddParameter("@BasQuantity", NewQuantity)
        db.CommandText = "UPDATE tblBasket SET BasQuantity = @BasQuantity WHERE BasSession = @BasSession AND BasID = @BasID"
        db.Execute()
    End Sub

    Public Shared Function GetContents() As DataTable
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataTable
        db.AddParameter("@BasSession", ThisSession)
        db.CommandText = "SELECT * FROM tblBasket,tblProduct,tblProductOption WHERE BasComplete = 0 AND BasSession = @BasSession AND BasProductID = PrdID AND BasOptionID = OptID"
        Dim dt As DataTable = db.Execute
        Return dt
    End Function

    Public Shared Function GetSummary() As DataRow
        Dim db = New EasySQL(Constring)
        db.ReturnType = EasyDBReturnType.DataRow
        db.AddParameter("@BasSession", ThisSession)
        db.CommandText = "WITH TBL AS(SELECT * FROM tblBasket,tblProduct,tblProductOption WHERE BasComplete = 0 AND BasSession = @BasSession AND BasProductID = PrdID AND BasOptionID = OptID)"
        db.CommandText &= "SELECT COUNT(*) as Items,COALESCE((SELECT SUM(BasPrice*BasQuantity) FROM TBL),0) as Total,(SELECT SUM(BasQuantity) FROM TBL) as TotalItems FROM TBL"
        Dim dr As DataRow = db.Execute
        Return dr
    End Function

End Class