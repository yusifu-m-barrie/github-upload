Public Class Deposit
    Dim da As New OleDb.OleDbDataAdapter
    Dim con As New OleDb.OleDbConnection
    Dim dt As New DataSet
    Dim cmd As New OleDb.OleDbCommand
    Dim balance As String
    Dim num1, num2, total As Integer
    Private Sub Deposit_Load(ByValsender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbldate.Text = Date.Now
        lblaccno.Text = mainmenu.lblaccno.Text
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim sql As String
        Dim Log_in As New DataTable

        Try
            con.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + "D:\atm.mdb")

            sql = "SELECT * FROM tblinfo where account_no = " & lblaccno.Text & ""

            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(Log_in)
            If Log_in.Rows.Count > 0 Then
                balance = Log_in.Rows(0).Item("balance")
                num1 = balance
                num2 = txtamount.Text

                If num2 > 25000 Then
                    MsgBox("You can Only Deposit Php 25000!")
                ElseIf num2 < 200 Then
                    MsgBox("Minimum Deposit is 1000")


                Else
                    total = num1 + num2

                    Receipt.Show()

                    Receipt.lblbal.Text = balance
                    Receipt.Label3.Hide()
                    Receipt.lblwith.Hide()
                    Receipt.lbldep.Text = num2
                    Receipt.lblnewbal.Text = total

                    Receipt.Label5.Show()
                    Receipt.Label6.Show()


                    Receipt.lblbal.Show()
                    Receipt.Label3.Hide()
                    Receipt.lblwith.Hide()
                    Receipt.lbldep.Show()
                    Receipt.lblnewbal.Show()
                    'MsgBox("Success")
                    Receipt.lblname.Text = mainmenu.lblname.Text
                    Me.Hide()
                End If
            Else

            End If
        Catch ex As Exception
            MsgBox("Please Enter Amount!")
        End Try
        txtamount.Text = ""
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        mainmenu.Show()
        Me.Hide()
    End Sub


End Class