Imports System.Data.SqlClient
Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If IO.File.Exists(System.Windows.Forms.Application.StartupPath & "\PathServer") = True Then
                Dim Database() As String = IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath & "\PathServer").ToString.Split("|")
                If Database.Length > 2 Then
                    Try
                        Conn = CPSDatabase.ConnectDatabaseSql(System.Windows.Forms.Application.StartupPath & "\PathServer", True)
                    Catch ex As Exception
                        CheckConnect = False
                        Exit Sub
                    End Try
                Else
                    Try
                        Conn = CPSDatabase.ConnectDatabaseSql(System.Windows.Forms.Application.StartupPath & "\PathServer", False)
                    Catch ex As Exception
                        CheckConnect = False
                        Exit Sub
                    End Try
                End If
                strDatabase = System.IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath & "\PathServer").Split("|")
                My.Application.ChangeCulture("th-TH")
                CheckConnect = True
            Else
                CheckConnect = False
            End If
        End Sub

    End Class

End Namespace

