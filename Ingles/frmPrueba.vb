Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis
Imports System
Imports System.Media
Imports System.Windows.Forms
Imports WMPLib
Imports System.Drawing.Imaging
Imports AxWMPLib
Public Class frmPrueba
    Dim WithEvents player As AxWindowsMediaPlayer
    Dim video As String = "C:\Legacy\Ingles\audios3\Femenino\14845_final.mp4"
    'Dim video As String = "C:\Legacy\Ingles\audios3\Femenino\14845_sin_rayas.mp4"
    Private Sub frmPrueba_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim imagen As String
         

        imagen = "C:\Legacy\Ingles\Imagenes_Ingles\avatar4.jpg"
        PictureBox1.Image = Image.FromFile(imagen)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        ' PLAYER
        AxWindowsMediaPlayer1.Visible = False

        AxWindowsMediaPlayer1.uiMode = "none"
        AxWindowsMediaPlayer1.settings.autoStart = False
        AxWindowsMediaPlayer1.stretchToFit = True

        ' MISMO TAMAÑO
        '  AxWindowsMediaPlayer1.Left = PictureBox1.Left

        '  AxWindowsMediaPlayer1.Top = PictureBox1.Top

        '  AxWindowsMediaPlayer1.Width = PictureBox1.Width

        '  AxWindowsMediaPlayer1.Height = PictureBox1.Height

        ' ENCIMA
        AxWindowsMediaPlayer1.BringToFront()

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        AxWindowsMediaPlayer1.Visible = False

        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = video

        AxWindowsMediaPlayer1.Ctlcontrols.play()

    End Sub


   
    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        ' 3 = Playing
        If e.newState = 3 Then

            AxWindowsMediaPlayer1.Visible = True

        End If

        ' 8 = MediaEnded
        If e.newState = 8 Then

            AxWindowsMediaPlayer1.Visible = False

        End If

    End Sub

End Class