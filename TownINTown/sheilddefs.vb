Module sheilddefs

  

    Public Declare Function GetMachineID Lib "SerialShield.dll" () As String

    Public Declare Function SS_LicenseInfo Lib "SerialShield.dll" () As String

    Public Declare Function SS_TrialMode Lib "SerialShield.dll" () As Integer

    Public Declare Function SS_GetUserName Lib "SerialShield.dll" () As String

    Public Declare Function SS_GetUserKey Lib "SerialShield.dll" () As String

    Public Declare Function SS_GetUserSerialID Lib "SerialShield.dll" () As String

    Public Declare Function TrialPeriodInfo Lib "SerialShield.dll" () As String

    Public Declare Function SS_IServer Lib "SerialShield.dll" _
     (ByVal URLServer As String, _
     ByVal AppName As String, _
     ByVal SerialID As String, _
     ByVal MachineID As String, _
     ByVal UserName As String, _
     ByVal UsernEMail As String) As Integer

    Public Declare Function SSUser Lib "SerialShield.dll" _
     (ByVal FullName As String, _
     ByVal Key As String, _
     ByVal SerialID As String) As Integer

    Public Declare Function TripleDESEncrypt Lib "SerialShield.dll" _
     (ByVal Text As String, _
     ByVal Key As String) As String

    Public Declare Function TripleDESDecrypt Lib "SerialShield.dll" _
     (ByVal Text As String, _
     ByVal Key As String) As String

    Declare Sub SetApplicationInfo Lib "SerialShield.dll" _
     (ByVal ApplicationName As String, _
     ByVal SoftKey As String)

    Declare Sub Antidebugging Lib "SerialShield.dll" ()

    Declare Sub AntiMonitors Lib "SerialShield.dll" ()

    Public Declare Function SS_TrialExpired Lib "SerialShield.dll" _
     () As Boolean

    Public Declare Function SS_RemoveKey Lib "SerialShield.dll" _
     () As Boolean

    Declare Sub SS_DefaultKey Lib "SerialShield.dll" (ByVal UserName As String, ByVal Key As String, ByVal SerialID As String)

    Public Declare Function SS_IsUnlocked Lib "SerialShield.dll" () As Boolean

    Declare Sub SS_Initialize Lib "SerialShield.dll" ()

    Declare Sub SS_R Lib "SerialShield.dll" (ByVal Name As String, ByVal Key As String)
End Module
