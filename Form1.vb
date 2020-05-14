Public Class Form1


    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim con As New OleDb.OleDbConnection
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim sql As String
        Dim Log_in As New DataTable

        Try

            If txtpin.Text = "" Then
                MsgBox("Please Enter Your Pincode")

            Else
                con.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + "D:\atm.mdb")
                sql = "SELECT * FROM tblinfo where pin_code = " & txtpin.Text & ""

                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da.SelectCommand = cmd
                da.Fill(Log_in)
                If Log_in.Rows.Count > 0 Then
                    Dim Type, Fullname, accno As String
                    Type = Log_in.Rows(0).Item("type")
                    Fullname = Log_in.Rows(0).Item("Firstname")
                    accno = Log_in.Rows(0).Item("account_no")
                    If Type = "admin" Then
                        MsgBox("Welcome Administrator " & Fullname & "")
                        AdminForm.Show()
                        Me.Hide()

                    ElseIf Type = "Block" Then
                        MsgBox("Your account is currently Block")
                        MsgBox("Contact the Administrator for Help")

                    Else
                        MsgBox("Welcome " & Fullname)

                        mainmenu.lblname.Text = Fullname
                        mainmenu.lblaccno.Text = accno
                        mainmenu.Show()
                        Me.Hide()

                    End If

                Else
                    MsgBox("You are not Registered Joo!!!")
                    MsgBox("Please Register Now if you are New Joo!!!")

                End If
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        txtpin.Text = ""
    End Sub

    Private Sub llblreg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblreg.LinkClicked
        Form2.Show()
        Me.Hide()

    End Sub
End Class
