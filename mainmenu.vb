Public Class mainmenu
    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim con As New OleDb.OleDbConnection
    Dim sql As String
    Private Sub mainmenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbldate.Text = Date.Now
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
                Dim balance As String

                balance = Log_in.Rows(0).Item("balance")

                Receipt.Show()
                Receipt.lblname.Text = lblname.Text
                'Receipt.lblaccno.Text = lblaccno.Text
                Receipt.lblbal.Text = balance
                Receipt.Label4.Hide()
                Receipt.Label3.Hide()
                Receipt.lbldep.Hide()
                Receipt.lblwith.Hide()
                Receipt.Label6.Hide()
                Receipt.lbldate.Show()
                Receipt.lblnewbal.Hide()


                Me.Hide()


            Else
                MsgBox("Pincode is Incoreect Jooo")

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnwith_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnwith.Click
        Withdraw.Show()
        Me.Hide()
    End Sub

    Private Sub btndep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndep.Click
        Deposit.Show()
        Me.Hide()
    End Sub

    Private Sub btnlogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogout.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class