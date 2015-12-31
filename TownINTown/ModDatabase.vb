Imports CarParkingSystem
Imports System.IO

Module ModDatabase

#Region "Use DLL File"
    Public CPSBarrier As New CPS_Barrier
    Public CPSDatabase As New CPS_Database
    Public CPSNetwork As New CPS_Network
    Public CPSImage As New CPS_Image
    Public Conn As New SqlClient.SqlConnection

    Public CheckConnDB As Boolean = False
#End Region   'ใช้งาน Dll



End Module
