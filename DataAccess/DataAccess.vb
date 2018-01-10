Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

Public Class DataAccess
    Private Function ConnectionString() As String
        Dim connStr As String
        connStr = "Server=" & My.Settings.serverName & ";Database=" & My.Settings.databaseName & "" & _
                    ";User Id=" & My.Settings.userID & ";password=" & My.Settings.passwordUser & ";"
        Return connStr
    End Function

    Function SqlConnection() As MySqlConnection
        Dim myConnection As MySqlConnection = New MySqlConnection(ConnectionString)
        If myConnection.State = ConnectionState.Closed Then
            myConnection.Open()
        End If
        Return myConnection
    End Function

    Public Function TestConnection() As Boolean
        Using conn As New MySqlConnection(ConnectionString())
            Try
                conn.Open()
                conn.Close()
                Return True
            Catch ex As Exception
                'Throw ex
                Return False
            End Try
        End Using
    End Function
    Public Function GeneratedCode(ByVal query As String, ByVal code As String) As String
        Dim hasil As String
        Dim urutan As String
        Dim hitung As Long
        Dim reader As MySqlDataReader
        Try
            reader = ExecuteReader(query)
            reader.Read()

            If Not reader.HasRows Then
                urutan = code + "001"
            Else
                hitung = Microsoft.VisualBasic.Right(reader.Item(0), 3) + 1
                urutan = code & Microsoft.VisualBasic.Right("000" & hitung, 3)
            End If

            hasil = urutan
            reader.Close()
            Return hasil
        Catch ex As Exception
            Throw ex
        End Try
        reader.Close()
    End Function

    Public Function InsertMasterData(ByVal queryString As String) As Boolean
        Using conn As New MySqlConnection(ConnectionString())
            Using myCommand As New MySqlCommand(queryString, conn)
                Try
                    conn.Open()
                    myCommand.ExecuteNonQuery()
                    conn.Close()
                    Return True
                Catch ex As Exception
                    conn.Close()
                    Throw ex
                    Return False
                End Try
            End Using
        End Using
    End Function
    Public Function RetrieveListData(ByVal query As String) As DataTable
        Dim dataTable As DataTable = New DataTable
        Try
            Using conn = New MySqlConnection(ConnectionString())
                conn.Open()
                Dim myCommand As MySqlCommand = New MySqlCommand(query, conn)
                Using dataAdapter As MySqlDataAdapter = New MySqlDataAdapter(myCommand)
                    dataAdapter.Fill(dataTable)
                End Using
                myCommand.Dispose()
                conn.Close()
                Return dataTable
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExecuteReader(ByVal query As String) As MySqlDataReader
        Try
            Dim reader As MySqlDataReader
            Dim myConnection As New MySqlConnection(ConnectionString)
            myConnection.Open()
            Dim myCommand As MySqlCommand = New MySqlCommand(query, myConnection)
            reader = myCommand.ExecuteReader(CommandBehavior.Default)
            myCommand.Dispose()
            Return reader
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Function ValidationValue(ByVal query As String) As Boolean
        Using myConnection As MySqlConnection = New MySqlConnection(ConnectionString())
            Dim status As Boolean = False
            Using myCommand As MySqlCommand = New MySqlCommand(query, myConnection)
                Try
                    myConnection.Open()
                    Dim myReader As MySqlDataReader = myCommand.ExecuteReader
                    myReader.Read()
                    If myReader.HasRows Then
                        status = True
                    End If
                    myReader.Close()
                    myCommand.Dispose()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
            Return status
            myConnection.Close()
        End Using
    End Function
    Public Function InsertMasterDetail(ByVal queryList As List(Of String)) As Boolean
        Using myConnection As MySqlConnection = New MySqlConnection(ConnectionString())
            myConnection.Open()
            Using myCommand As MySqlCommand = myConnection.CreateCommand
                Using myTransaction As MySqlTransaction = myConnection.BeginTransaction()
                    myCommand.Connection = myConnection
                    myCommand.Transaction = myTransaction
                    Try
                        For Each sqlDetail In queryList
                            myCommand.CommandText = sqlDetail
                            myCommand.ExecuteNonQuery()
                        Next

                        myTransaction.Commit()
                        myConnection.Close()
                        myCommand.Dispose()
                        Return True
                    Catch ex As Exception
                        myConnection.Close()
                        myCommand.Dispose()
                        Throw ex
                        Try
                            myTransaction.Rollback()
                        Catch ex2 As Exception
                            Throw ex2
                        End Try
                    End Try
                End Using
            End Using
        End Using
    End Function

    Function MD5Hash(ByVal value As String) As Byte()
        Try
            Dim md5 As New MD5CryptoServiceProvider
            Dim des As New TripleDESCryptoServiceProvider
            Return md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Encrypted(ByVal input As String, ByVal key As String) As String
        Try
            Dim md5 As New MD5CryptoServiceProvider
            Dim des As New TripleDESCryptoServiceProvider

            des.Key = MD5Hash(key)
            des.Mode = CipherMode.ECB

            Dim buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(input)
            Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Decrypted(ByVal input As String, ByVal key As String) As String
        Try
            Dim md5 As New MD5CryptoServiceProvider
            Dim des As New TripleDESCryptoServiceProvider

            des.Key = MD5Hash(key)
            des.Mode = CipherMode.ECB

            Dim buffer As Byte() = Convert.FromBase64String(input)
            Return ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub PopulateComBoBox(ByVal cmb As ComboBox, ByVal query As String, ByVal strDisplay As String, ByVal strValue As String)
        Try
            With cmb
                .DataSource = RetrieveListData(query)
                .DisplayMember = strDisplay
                .ValueMember = strValue
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
