Public Class Balanceing
    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim con As New OleDb.OleDbConnection
    Dim sql As String
    Private Sub Balanceing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Date.Now

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim Log_in As New DataTable

        Try
            If txtpin.Text = "" Then
                MsgBox("Pls Enter Your Pin")

            Else

            End If
            con.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + "D:\atm.mdb")
            sql = "SELECT * from tblinfo where pin_code = " & txtpin.Text & ""

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
                'Receipt.lblaccno.Text = lblaccno.Text
                Receipt.lblbal.Text = balance
                Receipt.Label4.Hide()
                Receipt.Label3.Hide()
                Receipt.lbldep.Hide()
                Receipt.lblwith.Hide()
                Receipt.Label6.Hide()
                Receipt.lblnewbal.Hide()

                Me.Hide()

            Else
                MsgBox("Pincode is Incorrect")

            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

        txtpin.Text = ""
    End Sub
End Class