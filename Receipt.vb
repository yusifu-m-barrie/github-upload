Public Class Receipt
    Dim da As New OleDb.OleDbDataAdapter
    Dim con As New OleDb.OleDbConnection
    Dim dt As New DataTable
    Dim sql As String
    Dim cmd As New OleDb.OleDbCommand
    Private Sub Receipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + "D:\atm.mdb")
        lbldate.Text = Date.Now
    End Sub

    Private Sub Button1_Click(ByValsender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lblnewbal.Text = "" Then

        Else
            con.Open()

            Dim total As Integer = lblnewbal.Text
            Dim ad As New OleDb.OleDbDataAdapter("select * from tblinfo", con)

            sql = "UPDATE tblinfo SET balance='" & total & "'" & " where Firstname='" & lblname.Text & "'"
            cmd.CommandText = sql
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            con.Close()


        End If

        If MessageBox.Show("Do You want to Continue Your Transaction??", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            mainmenu.Show()
        Else
            MsgBox("Thanks, We wish to see you Again")

            Form1.Show()
        End If
        Me.Close()
    End Sub
End Class