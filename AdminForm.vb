Public Class AdminForm
    Dim da As New OleDb.OleDbDataAdapter
    Dim con As New OleDb.OleDbConnection
    Dim dt As New DataTable
    Dim sql As String
    Dim cmd As New OleDb.OleDbCommand
    Dim lblhide As Object

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtlname.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub AdminForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + "D:\atm.mdb")

        Label11.Text = Date.Now

        txtfname.Enabled = False
        txtlname.Enabled = False
        btnblock.Enabled = False
        btnunblock.Enabled = False
        GroupBox2.Enabled = False
        btnok.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtfname.Enabled = True
        txtlname.Enabled = True

        btnok.Enabled = True
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim i, j As Integer

        i = e.RowIndex
        j = e.ColumnIndex
        If j = 0 Then
            txtAcctNo.Text = DataGridView1.Rows(i).Cells(j).Value
            txtfnme.Text = DataGridView1.Rows(i).Cells(j + 1).Value
            lblhide.Text = DataGridView1.Rows(i).Cells(j + 1).Value
            txtlnme.Text = DataGridView1.Rows(i).Cells(j + 2).Value
            'txtlname.Text = DataGridView1.Rows(i).Cells(j + 2).Value
            txtaddr.Text = DataGridView1.Rows(i).Cells(j + 3).Value
            txtcontact.Text = DataGridView1.Rows(i).Cells(j + 4).Value
            cbGender.Text = DataGridView1.Rows(i).Cells(j + 5).Value
            txtbday.Text = DataGridView1.Rows(i).Cells(j + 6).Value
            txtPincode.Text = DataGridView1.Rows(i).Cells(j + 7).Value

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        con.Open()

        Dim ad As New OleDb.OleDbDataAdapter("select * from tblinfo", con)
        Dim data As New DataSet
        ad.Fill(data, "info")
        DataGridView1.DataSource = data.Tables("info").DefaultView

        data.Dispose()
        ad.Dispose()
        con.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        GroupBox2.Enabled = True
        btnedit.Enabled = False
        Button4.Enabled = False
        btnblock.Enabled = True
        btnunblock.Enabled = True
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        sql = "SELECT * FROM tblinfo where Firstname='" & txtfname.Text & "'" & "and Lastname= '" & txtlname.Text & "'"
        Try

            con.Open()
            da = New OleDb.OleDbDataAdapter(sql, con)
            da.Fill(dt)

            DataGridView1.DataSource = dt
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

        con.Close()
        btnok.Enabled = False

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        con.Open()

        'Dim ad As New OleDb.OleDbDataAdapter("select * from book", con)

        sql = " UPDATE tblinfo SET account_no='" & txtAcctNo.Text & "',pin_code='" & txtPincode.Text & "',Firstname'" & txtfnme.Text & "', Lastname='" & txtlnme.Text & "',Address='" & txtaddr.Text & "',Contact_no'" & txtcontact.Text & "',Gender='" & cbGender.Text & "'where Firstname='" & lblhide.Text & "'"
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        MsgBox("Success")

        con.Close()
        Button5_Click(sender, e)
        DataGridView1.Refresh()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        GroupBox2.Enabled = False
        btnedit.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub btnblock_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnblock.Click
        con.Open()

        Dim ad As New OleDb.OleDbDataAdapter("select * from tblinfo", con)

        sql = "UPDATE tblinfo SET type='" & "Block" & "'" & " where Firstname ='" & txtfnme.Text & "'"
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        MsgBox("Success")

        con.Close()
        Button5_Click(sender, e)
    End Sub

    Private Sub btnunblock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnunblock.Click
        con.Open()

        Dim ad As New OleDb.OleDbDataAdapter("select * from tblinfo", con)

        sql = "UPDATE tblinfo SET type='" & "Active" & "'" & " where Firstname ='" & txtfnme.Text & "'"
        cmd.CommandText = sql
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        MsgBox("Success")

        con.Close()
        Button5_Click(sender, e)
    End Sub

    Private Sub txtfname_TextChanged(sender As Object, e As EventArgs) Handles txtfname.TextChanged

    End Sub

   

End Class