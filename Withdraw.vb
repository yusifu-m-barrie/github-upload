Public Class Withdraw
    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim con As New OleDb.OleDbConnection
    Dim balance As String
    Dim num1, num2, total As Integer
    Private Sub Withdraw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbldate.Text = Date.Now
        lblaccno.Text = mainmenu.lblaccno.Text
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
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
                    MsgBox("You can Only Withdraw Php 25,000!")
                ElseIf num2 < 200 Then
                    MsgBox("Minimum Withdrawal is 200")
                ElseIf num1 < num2 Then
                    MsgBox("INsufficient balance")


                Else
                    total = num1 - num2

                    Receipt.Show()

                    Receipt.lblbal.Text = balance
                    Receipt.Label3.Hide()
                    Receipt.lblwith.Hide()
                    Receipt.lbldep.Text = num2
                    Receipt.lblnewbal.Text = total

                    Receipt.Label5.Show()
                    Receipt.Label6.Show()

                    Receipt.lblbal.Show()
                    Receipt.Label4.Hide()
                    Receipt.lbldep.Show()
                    Receipt.lblwith.Hide()
                    Receipt.lblnewbal.Show()
                    'MsgBox("Success Joooo")
                    Receipt.lblname.Text = mainmenu.lblname.Text
                    Me.Hide()

                End If
            Else

            End If

        Catch ex As Exception
            MsgBox("Please Enter Amount!")
            'MsgBox(ex.Message)

        End Try
        txtamount.Text = ""
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub lblaccno_Click(sender As Object, e As EventArgs) Handles lblaccno.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        mainmenu.Show()
        Me.Hide()
    End Sub
End Class