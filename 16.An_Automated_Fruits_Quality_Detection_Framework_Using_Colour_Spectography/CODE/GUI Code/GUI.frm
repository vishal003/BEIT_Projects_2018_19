VERSION 5.00
Object = "{648A5603-2C6E-101B-82B6-000000000014}#1.1#0"; "MSCOMM32.OCX"
Begin VB.Form main 
   BackColor       =   &H00FFC0C0&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Project"
   ClientHeight    =   7185
   ClientLeft      =   1125
   ClientTop       =   2160
   ClientWidth     =   9045
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   8.25
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   7185
   ScaleWidth      =   9045
   Begin VB.CommandButton cmdLoadConfig 
      Caption         =   "Reload"
      Height          =   435
      Left            =   240
      TabIndex        =   29
      Top             =   4050
      Width           =   765
   End
   Begin VB.TextBox txtRV 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   6420
      TabIndex        =   25
      Text            =   "0"
      Top             =   2790
      Width           =   435
   End
   Begin VB.TextBox txtGV 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   7320
      TabIndex        =   24
      Text            =   "0"
      Top             =   2790
      Width           =   435
   End
   Begin VB.TextBox txtBV 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   8250
      TabIndex        =   23
      Text            =   "0"
      Top             =   2790
      Width           =   435
   End
   Begin VB.TextBox txtRS 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   22.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   675
      Left            =   6150
      TabIndex        =   21
      Text            =   "000"
      Top             =   2070
      Width           =   915
   End
   Begin VB.TextBox txtGS 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   22.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   660
      Left            =   7095
      TabIndex        =   20
      Text            =   "000"
      Top             =   2070
      Width           =   915
   End
   Begin VB.TextBox txtBS 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   22.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   660
      Left            =   8040
      TabIndex        =   19
      Text            =   "000"
      Top             =   2070
      Width           =   915
   End
   Begin VB.CommandButton cmdReverse 
      Caption         =   "R"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   6450
      TabIndex        =   16
      Top             =   6660
      Width           =   885
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "S"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   5490
      TabIndex        =   15
      Top             =   6660
      Width           =   885
   End
   Begin VB.CommandButton cmdForward 
      Caption         =   "F"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   4530
      TabIndex        =   14
      Top             =   6660
      Width           =   885
   End
   Begin VB.TextBox txt_B_Offset 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   6690
      TabIndex        =   13
      Text            =   "5"
      Top             =   5610
      Width           =   435
   End
   Begin VB.TextBox txt_G_Offset 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   5700
      TabIndex        =   12
      Text            =   "5"
      Top             =   5610
      Width           =   435
   End
   Begin VB.TextBox txt_R_Offset 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   14.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   4800
      TabIndex        =   11
      Text            =   "5"
      Top             =   5610
      Width           =   435
   End
   Begin VB.TextBox txtReceivedData 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   1920
      TabIndex        =   10
      Top             =   5970
      Visible         =   0   'False
      Width           =   585
   End
   Begin VB.Timer Timer1 
      Interval        =   50
      Left            =   1440
      Top             =   5910
   End
   Begin VB.ComboBox cmbSerial 
      Height          =   315
      Left            =   210
      TabIndex        =   9
      Text            =   "Combo1"
      Top             =   6030
      Width           =   1155
   End
   Begin VB.CommandButton cmdSerialConnect 
      Caption         =   "Connect"
      Height          =   405
      Left            =   210
      TabIndex        =   8
      Top             =   6420
      Width           =   1185
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Port Close"
      Height          =   405
      Left            =   1440
      TabIndex        =   7
      Top             =   6420
      Width           =   1185
   End
   Begin VB.TextBox txtB 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   22.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   660
      Left            =   6510
      TabIndex        =   6
      Text            =   "00"
      Top             =   4920
      Width           =   915
   End
   Begin VB.TextBox txtG 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   22.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   660
      Left            =   5520
      TabIndex        =   5
      Text            =   "00"
      Top             =   4920
      Width           =   915
   End
   Begin VB.TextBox txtR 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   22.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   660
      Left            =   4560
      TabIndex        =   4
      Text            =   "00"
      Top             =   4920
      Width           =   915
   End
   Begin VB.TextBox Text1 
      Height          =   375
      Left            =   2190
      TabIndex        =   3
      Text            =   "Text1"
      Top             =   5040
      Width           =   2055
   End
   Begin VB.ComboBox cmbColor 
      Height          =   315
      Left            =   11310
      TabIndex        =   2
      Text            =   "Combo1"
      Top             =   1080
      Width           =   1455
   End
   Begin VB.ListBox List1 
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3570
      Left            =   90
      TabIndex        =   0
      Top             =   330
      Width           =   5865
   End
   Begin MSCommLib.MSComm MSComm1 
      Left            =   9510
      Top             =   4830
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      DTREnable       =   -1  'True
   End
   Begin VB.Label Label7 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Raw data"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2130
      TabIndex        =   30
      Top             =   4740
      Width           =   1155
   End
   Begin VB.Label lblSampleName 
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   6570
      TabIndex        =   28
      Top             =   720
      Width           =   2115
   End
   Begin VB.Label Label6 
      BackStyle       =   0  'Transparent
      Caption         =   "Sample selected :"
      Height          =   495
      Left            =   6570
      TabIndex        =   27
      Top             =   510
      Width           =   2085
   End
   Begin VB.Label Label5 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "RGB variance"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   6600
      TabIndex        =   26
      Top             =   3300
      Width           =   2115
   End
   Begin VB.Label Label2 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "R-G-B Primary"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   6510
      TabIndex        =   22
      Top             =   1740
      Width           =   2115
   End
   Begin VB.Label Label4 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "WB correction"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4860
      TabIndex        =   18
      Top             =   6330
      Width           =   2115
   End
   Begin VB.Label Label3 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "R-G-B detected"
      BeginProperty Font 
         Name            =   "Verdana"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4770
      TabIndex        =   17
      Top             =   4590
      Width           =   2115
   End
   Begin VB.Label Label1 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFC0C0&
      Caption         =   "Sample List"
      ForeColor       =   &H80000008&
      Height          =   195
      Index           =   0
      Left            =   90
      TabIndex        =   1
      Top             =   90
      Width           =   990
   End
   Begin VB.Menu mnuabout 
      Caption         =   "About"
   End
   Begin VB.Menu mnuexit 
      Caption         =   "E&xit"
   End
End
Attribute VB_Name = "main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Option Explicit
Const INVALID_NOTE = -1     ' Code for keyboard keys that we don't handle
Dim baseNote As Integer     ' the first note on our "piano"
Dim keyindex, volume, mse, movmse, prevnote As Integer
Dim Inst, Tplay, Tstop 'Instrument Index & Time Play and Time Stop in milliseconds in Demos
Dim StopIt As Boolean, DemoOn As Boolean
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

' NO
Private Sub cmdForward_Click()
    Dim lngStatus As Long
    Dim strError  As String
    Dim strData   As String
   
    ' Write maximum of 64 bytes to serial port.
    lngStatus = CommWrite(intPortID, "F")
    If lngStatus <> 0 Then
        ' Data send
        'txtReceivedData.Text = strData
    Else
        MsgBox ("Error Code (during cmdForward_Click):" & lngStatus)
    End If

End Sub


' OK
Private Sub cmdLoadConfig_Click()
    
    Call FileLoad
End Sub


' NO
Private Sub cmdReverse_Click()
    Dim lngStatus As Long
    Dim strError  As String
    Dim strData   As String
   
    ' Write maximum of 64 bytes to serial port.
    lngStatus = CommWrite(intPortID, "R")
    If lngStatus <> 0 Then
        ' Data send
        'txtReceivedData.Text = strData
    Else
        MsgBox ("Error Code (during cmdForward_Click):" & lngStatus)
    End If


End Sub

'OK
Private Sub cmdSerialConnect_Click()
         ' Ex. 1, 2, 3, 4 for COM1 - COM4
    Dim lngStatus As Long
    Dim strError  As String
    Dim strData   As String
    Dim CurrentPortNumber As String
    
    

    intPortID = cmbSerial.Text ' "\\.\COM" & cmbSerial.Text & vbNullChar

    ' Initialize Communications
    lngStatus = CommOpen(intPortID, "\\.\COM" & cmbSerial.Text & vbNullChar, _
        "baud=115200 parity=N data=8 stop=1")
    
    If lngStatus <> 0 Then
    ' Handle error.
        lngStatus = CommGetError(strError)
        MsgBox "COM Error: " & strError
    Else
        MsgBox ("Connected.")
    End If

End Sub


' NO
Private Sub cmdStop_Click()
    Dim lngStatus As Long
    Dim strError  As String
    Dim strData   As String
   
    ' Write maximum of 64 bytes to serial port.
    lngStatus = CommWrite(intPortID, "S")
    If lngStatus <> 0 Then
        ' Data send
        'txtReceivedData.Text = strData
    Else
        MsgBox ("Error Code (during cmdForward_Click):" & lngStatus)
    End If


End Sub


' OK
Private Sub Command2_Click()
    Call CommClose(intPortID)
        MsgBox ("Port closed.")
End Sub


' OK
Private Sub Form_Initialize()
    
    
    cmbSerial.Clear
    For i = 1 To 20
    cmbSerial.AddItem i
    Next i
    Text1.Text = ""
    
    
    cmbColor.Clear
    cmbColor.AddItem "Red"
    cmbColor.AddItem "Green"
    cmbColor.AddItem "Blue"
    
    
    Call FileLoad
    
End Sub

'OK
 Private Sub FileLoad()
    Dim sFileText As String
    Dim iFileNo As Integer
    
    iFileNo = FreeFile
    List1.Clear
    
    'open the file for reading
    Open App.Path & "\Config.txt" For Input As #iFileNo
    'change this filename to an existing file!  (or run the example below first)
    'read the file until we reach the end
    Do While Not EOF(iFileNo)
    Line Input #iFileNo, sFileText
    List1.AddItem sFileText
    'show the text (you will probably want to replace this line as appropriate to your program!)
    
    'MsgBox sFileText
    Loop
    'close the file (if you dont do this, you wont be able to open it again!)
    Close #iFileNo


 End Sub
 
' OK
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
mnuexit_Click
End Sub

 'OK
Private Sub Form_Terminate()
 Unload Me
End Sub

' OK
Private Sub List1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim str As String
    str = List1.List(List1.ListIndex)
    
    Dim fields() As String

    ' Split the string at the comma characters and add each field to a ListBox
    fields() = Split(str, ",")
    
    lblSampleName = Trim$(fields(0))
    txtRS.Text = Trim$(fields(1))
    txtGS.Text = Trim$(fields(2))
    txtBS.Text = Trim$(fields(3))
    
    txtRV.Text = Trim$(fields(4))
    txtGV.Text = Trim$(fields(5))
    txtBV.Text = Trim$(fields(6))
    
    txtRS.BackColor = vbWhite
    txtGS.BackColor = vbWhite
    txtBS.BackColor = vbWhite

End Sub


Private Sub mnuabout_Click()
    frmAbout.Show
End Sub


Private Sub mnuexit_Click()

 Unload Me
End
End Sub



Private Sub mnuDemo_Click()
StopIt = True
End Sub



Private Sub Timer1_Timer()
    Dim lngStatus As Long
    Dim strError  As String
    Dim strData   As String
   
    ' Read maximum of 64 bytes from serial port.
    lngStatus = CommRead(intPortID, strData, 1)
    If lngStatus > 0 Then
        ' Process data.
        txtReceivedData.Text = strData
    ElseIf lngStatus < 0 Then
        ' Handle error.
    End If
    

End Sub


Private Sub txtB_Change()
    If ((txtB.Text > (Int(txtBS.Text) + Int(txtBV.Text))) Or (txtB.Text < (Int(txtBS.Text) - Int(txtBV.Text)))) Then
        txtBS.BackColor = vbRed
    Else
        If (txtBS.Text <> "") Then txtBS.BackColor = vbGreen
    End If
End Sub

Private Sub txtG_Change()
    If ((txtG.Text > (Int(txtGS.Text) + Int(txtGV.Text))) Or (txtG.Text < (Int(txtGS.Text) - Int(txtGV.Text)))) Then
        txtGS.BackColor = vbRed
    Else
        If (txtGS.Text <> "") Then txtGS.BackColor = vbGreen
    End If
End Sub

Private Sub txtR_Change()
    If ((txtR.Text > (Int(txtRS.Text) + Int(txtRV.Text))) Or (txtR.Text < (Int(txtRS.Text) - Int(txtRV.Text)))) Then
        txtRS.BackColor = vbRed
    Else
        If (txtRS.Text <> "") Then txtRS.BackColor = vbGreen
    End If
    
End Sub

Private Sub txtReceivedData_Change()
    On Error Resume Next
    
    Dim arr() As String
    
    Arrival_Data = txtReceivedData.Text
    
    If Arrival_Data = "" Then Exit Sub
    If InStr(1, Arrival_Data, "R") Then
        Text1.Text = ""
    End If
    
    
    Text1.Text = Text1.Text & Arrival_Data
    'Exit Sub
    'On Error GoTo SomeError
    a = Len(Text1.Text)
    If (a = 12) Then
        TheData = Replace(Text1.Text, "R=", "")
        TheData = Replace(TheData, "G=", " ")
        TheData = Replace(TheData, "B=", " ")
        
        arr = Split(TheData, " ")
        
        txtR.Text = CInt(arr(0)) + CInt(txt_R_Offset.Text)
        txtG.Text = CInt(arr(1)) + CInt(txt_G_Offset.Text)
        txtB.Text = CInt(arr(2)) + CInt(txt_B_Offset.Text)
        
    End If
    
SomeError:
    
    Exit Sub

End Sub
