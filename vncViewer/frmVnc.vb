﻿Public Class frmVnc
    Public Shared Property vncPath As String = "C:\Program Files\TightVNC\"
    Dim line As String
    Dim station As String
    Dim machine As String
    Dim cmdA As String = "/c C: & cd " + vncPath + " & start tvnviewer -host="
    Dim cmdB As String = " -password=123 -scale=auto"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        SplashScreen.Show()
    End Sub

    Private Sub cmbLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLine.SelectedIndexChanged
        line = cmbLine.SelectedItem
        station = ""
        machine = ""
        cmbStation.Items.Clear()
        cmbMachine.Items.Clear()
        cmbStation.Text = "Station"
        cmbMachine.Text = "Machine"
        If cmbLine.SelectedItem = "Line 1" Then
            cmbStation.Items.AddRange(New Object() {"PD Download Test", "PD SF", "ISN Input", "DFU Test", "F0-Board Level",
                                      "F1-Rf Conductive", "Led Board Test", "Verify LED", "Print Unit Label", "Link Led Board",
                                      "Link Battery", "F3-OTA Tx Test", "F4-Key Felling Test", "F5-Optical Test", "Charging Battery",
                                      "F6-Acoustic Test", "F8-RF OTA Tx/Rx", "F9 Eero", "Black Box Test", "Carton_acc", "Carton Weight",
                                      "Visual Inspection", "Carton", "Pallet", "Run-In", "PC Backup data PD"})
        ElseIf cmbLine.SelectedItem = "Line 2" Then
        ElseIf cmbLine.SelectedItem = "Line 3" Then
        ElseIf cmbLine.SelectedItem = "Line 4" Or cmbLine.SelectedItem = "Line 5" Or cmbLine.SelectedItem = "Line 6" Then
            cmbStation.Items.AddRange(New Object() {"Dashboard", "ISN Input", "Pre RF Test", "RF Test", "Power Test (PWB)",
                                      "BT Test", "Laser Engrave", "SSN Upload", "RF Link", "Safety Test", "Fan Test", "Wlan Test",
                                      "OTA Test", "Set Burn Test", "Final Test", "Auto Final Test", "Reflash", "FW Check", "FQC Test",
                                      "Print Box Label", "Weight Giftbox", "Carton", "Pallet"})
        ElseIf cmbLine.SelectedItem = "Line 7" Then
        ElseIf cmbLine.SelectedItem = "Line 8" Then
        ElseIf cmbLine.SelectedItem = "Line 9" Then
        Else
        End If
    End Sub

    Private Sub cmbStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStation.SelectedIndexChanged
        station = cmbStation.SelectedItem
        machine = ""
        cmbMachine.Items.Clear()
        cmbMachine.Text = "Machine"
        cmbMachine.Items.AddRange(New Object() {"ALL"})

        'SUPERPOD
        If station = "Pre RF Test" Then
            For indexA = 1 To 5
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "RF Test" Then
            For indexA = 1 To 12
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "Power Test (PWB)" Then
            For indexA = 1 To 4
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "BT Test" Then
            For indexA = 1 To 6
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "Safety Test" Or station = "Fan Test" Or station = "OTA Test" Or station = "Set Burn Test" Or station = "FQC Test" Then
            For indexA = 1 To 2
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "Wlan Test" Or station = "Final Test" Or station = "Auto Final Test" Then
            For indexA = 1 To 10
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "FW Check" Then
            For indexA = 1 To 3
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next

            'KILIMANJARO
        ElseIf station = "DFU Test" Or station = "F3-OTA Tx Test" Or station = "F8-RF OTA Tx/Rx" Then
            For indexA = 1 To 9
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "F0-Board Level" Then
            For indexA = 1 To 10
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "F1-Rf Conductive" Then
            For indexA = 1 To 5
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "Led Board Test" Or station = "Charging Battery" Then
            For indexA = 1 To 3
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "F4-Key Felling Test" Or station = "F5-Optical Test" Or station = "F6-Acoustic Test" Then
            For indexA = 1 To 4
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        ElseIf station = "Run-In" Then
            For indexA = 1 To 8
                cmbMachine.Items.AddRange(New Object() {"Machine " + indexA.ToString})
            Next
        End If
    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged
        machine = cmbMachine.SelectedItem
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim viewIp As String = ""
        If Not System.IO.Directory.Exists(vncPath) Then
            MsgBox("TightVNC path not found!", vbCritical, "TSF vncViewer")
            SplashScreen.Show()
        ElseIf line = "" Or station = "" Or machine = "" Then
            MsgBox("'Line', 'Station' and 'Machine' must fill completely.", vbExclamation, "TSF vncViewer")
        ElseIf line = "Line 1" Then
            If station = "PD Download Test" Then
                Process.Start("cmd", cmdA + "172.16.20.40" + cmdB)
            ElseIf station = "PD SF" Then
                Process.Start("cmd", cmdA + "172.16.20.42" + cmdB)
            ElseIf station = "ISN Input" Then
                Process.Start("cmd", cmdA + "172.16.20.43" + cmdB)
            ElseIf station = "DFU Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.44"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.45"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.196"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.52"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.67"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.73"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.20.76"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.78"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.80"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.44" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.45" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.196" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.52" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.67" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.73" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.76" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.78" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.80" + cmdB)
                End If
            ElseIf station = "F0-Board Level" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.81"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.82"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.87"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.91"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.92"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.93"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.20.94"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.95"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.96"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.20.98"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.81" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.82" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.87" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.91" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.92" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.93" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.94" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.95" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.96" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.98" + cmdB)
                End If
            ElseIf station = "F1-Rf Conductive" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.101"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.102"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.103"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.104"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.105"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.101" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.102" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.103" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.104" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.105" + cmdB)
                End If
            ElseIf station = "Led Board Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.106"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.107"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.108"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.106" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.107" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.108" + cmdB)
                End If
            ElseIf station = "Verify LED" Then
                Process.Start("cmd", cmdA + "172.16.20.109" + cmdB)
            ElseIf station = "Print Unit Label" Then
                Process.Start("cmd", cmdA + "172.16.20.112" + cmdB)
            ElseIf station = "Link Led Board" Then
                Process.Start("cmd", cmdA + "172.16.20.114" + cmdB)
            ElseIf station = "Link Battery" Then
                Process.Start("cmd", cmdA + "172.16.20.120" + cmdB)
            ElseIf station = "F3-OTA Tx Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.121"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.123"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.124"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.125"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.126"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.127"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.20.128"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.129"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.130"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.121" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.123" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.124" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.125" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.126" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.127" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.128" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.129" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.130" + cmdB)
                End If
            ElseIf station = "F4-Key Felling Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.131"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.132"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.133"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.134"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.131" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.132" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.133" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.134" + cmdB)
                End If
            ElseIf station = "F5-Optical Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.135"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.136"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.137"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.138"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.135" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.136" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.137" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.138" + cmdB)
                End If
            ElseIf station = "Charging Battery" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.139"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.140"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.141"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.139" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.140" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.141" + cmdB)
                End If
            ElseIf station = "F6-Acoustic Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.142"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.143"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.144"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.145"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.142" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.143" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.144" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.145" + cmdB)
                End If
            ElseIf station = "F8-RF OTA Tx/Rx" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.146"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.147"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.148"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.149"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.150"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.151"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.20.152"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.153"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.154"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.146" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.147" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.148" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.149" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.150" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.151" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.152" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.153" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.154" + cmdB)
                End If
            ElseIf station = "F9 Eero" Then
                Process.Start("cmd", cmdA + "172.16.20.155" + cmdB)
            ElseIf station = "Black Box Test" Then
                Process.Start("cmd", cmdA + "172.16.20.156" + cmdB)
            ElseIf station = "Carton_acc" Then
                Process.Start("cmd", cmdA + "172.16.20.252" + cmdB)
            ElseIf station = "Carton Weight" Then			
                Process.Start("cmd", cmdA + "172.16.20.179" + cmdB)
			ElseIf station = "Visual Inspection" Then
                Process.Start("cmd", cmdA + "172.16.20.159" + cmdB)
            ElseIf station = "Carton" Then
                Process.Start("cmd", cmdA + "172.16.20.161" + cmdB)
            ElseIf station = "Pallet" Then
                Process.Start("cmd", cmdA + "172.16.20.186" + cmdB)
            ElseIf station = "Run-In" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.172"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.163"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.164"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.165"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.166"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.167"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.20.169"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.170"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.172" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.163" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.164" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.165" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.166" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.167" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.169" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.170" + cmdB)
                End If
            ElseIf station = "PC Backup data PD" Then
                Process.Start("cmd", cmdA + "172.16.20.178" + cmdB)
            End If
        ElseIf line = "Line 2" Then
        ElseIf line = "Line 3" Then
        ElseIf line = "Line 4" Then
            If station = "Dashboard" Then
                Process.Start("cmd", cmdA + "172.16.23.171" + cmdB)
            ElseIf station = "ISN Input" Then
                Process.Start("cmd", cmdA + "172.16.20.64" + cmdB)
            ElseIf station = "Pre RF Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.21.70"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.59"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.48"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.110"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.194"
                Else
                    Process.Start("cmd", cmdA + "172.16.21.70" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.59" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.48" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.110" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.194" + cmdB)
                End If
            ElseIf station = "RF Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.71"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.69"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.72"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.74"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.68"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.53"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.20.54"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.85"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.58"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.20.56"
                ElseIf machine = "Machine 11" Then
                    viewIp = "172.16.20.57"
                ElseIf machine = "Machine 12" Then
                    viewIp = "172.16.20.55"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.71" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.69" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.72" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.74" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.68" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.53" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.54" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.85" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.58" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.56" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.57" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.55" + cmdB)
                End If
            ElseIf station = "Power Test (PWB)" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.21.110"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.21.111"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.21.112"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.23.133"
                Else
                    Process.Start("cmd", cmdA + "172.16.21.110" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.111" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.112" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.23.133" + cmdB)
                End If
            ElseIf station = "BT Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.60"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.62"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.20.61"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.20.63"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.21.129"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.20.65"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.60" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.62" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.61" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.63" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.129" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.65" + cmdB)
                End If
            ElseIf station = "Laser Engrave" Then
                Process.Start("cmd", cmdA + "172.16.21.119" + cmdB)
            ElseIf station = "SSN Upload" Then
                Process.Start("cmd", cmdA + "172.16.22.50" + cmdB)
            ElseIf station = "RF Link" Then
                Process.Start("cmd", cmdA + "172.16.22.52" + cmdB)
            ElseIf station = "Safety Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.222"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.91"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.222" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.91" + cmdB)
                End If
            ElseIf station = "Fan Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.3"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.4"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.3" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.4" + cmdB)
                End If
            ElseIf station = "Wlan Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.59"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.58"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.56"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.55"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.60"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.61"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.62"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.22.64"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.97"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.22.69"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.59" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.58" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.56" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.55" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.60" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.61" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.62" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.64" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.97" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.69" + cmdB)
                End If
            ElseIf station = "OTA Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.66"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.65"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.66" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.65" + cmdB)
                End If
            ElseIf station = "Set Burn Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.47"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.70"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.47" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.70" + cmdB)
                End If
            ElseIf station = "Final Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.71"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.72"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.73"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.74"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.78"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.76"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.77"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.22.75"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.118"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.22.143"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.71" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.72" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.73" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.74" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.78" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.76" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.77" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.75" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.118" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.143" + cmdB)
                End If
            ElseIf station = "Auto Final Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.21.139"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.21.140"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.21.141"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.21.142"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.21.143"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.21.144"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.21.145"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.21.146"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.21.147"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.21.148"
                Else
                    Process.Start("cmd", cmdA + "172.16.21.139" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.140" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.141" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.142" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.143" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.144" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.145" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.146" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.147" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.148" + cmdB)
                End If
            ElseIf station = "Reflash" Then
                Process.Start("cmd", cmdA + "172.16.22.68" + cmdB)
            ElseIf station = "FW Check" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.81"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.80"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.79"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.81" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.80" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.79" + cmdB)
                End If
            ElseIf station = "FQC Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.21.20"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.79"
                Else
                    Process.Start("cmd", cmdA + "172.16.21.20" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.79" + cmdB)
                End If
            ElseIf station = "Print Box Label" Then
                Process.Start("cmd", cmdA + "172.16.22.84" + cmdB)
            ElseIf station = "Weight Giftbox" Then
                Process.Start("cmd", cmdA + "172.16.22.85" + cmdB)
            ElseIf station = "Carton" Then
                Process.Start("cmd", cmdA + "172.16.22.86" + cmdB)
            ElseIf station = "Pallet" Then
                Process.Start("cmd", cmdA + "172.16.22.87" + cmdB)
            End If
        ElseIf line = "Line 5" Then
            If station = "Dashboard" Then
                Process.Start("cmd", cmdA + "172.16.21.210" + cmdB)
            ElseIf station = "ISN Input" Then
                Process.Start("cmd", cmdA + "172.16.22.188" + cmdB)
            ElseIf station = "Pre RF Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.173"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.174"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.175"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.176"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.39"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.173" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.174" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.175" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.176" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.39" + cmdB)
                End If
            ElseIf station = "RF Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.236"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.179"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.178"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.177"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.235"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.180"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.130"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.168"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.22.184"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.22.183"
                ElseIf machine = "Machine 11" Then
                    viewIp = "172.16.22.182"
                ElseIf machine = "Machine 12" Then
                    viewIp = "172.16.22.181"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.236" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.179" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.178" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.177" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.235" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.180" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.130" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.168" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.184" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.183" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.182" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.181" + cmdB)
                End If
            ElseIf station = "Power Test (PWB)" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.45"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.46"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.47"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.170"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.45" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.46" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.47" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.170" + cmdB)
                End If
            ElseIf station = "BT Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.185"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.224"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.187"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.247"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.21.0"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.40"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.185" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.224" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.187" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.247" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.0" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.40" + cmdB)
                End If
            ElseIf station = "Laser Engrave" Then
                Process.Start("cmd", cmdA + "172.16.22.240" + cmdB)
            ElseIf station = "SSN Upload" Then
                Process.Start("cmd", cmdA + "172.16.22.192" + cmdB)
            ElseIf station = "RF Link" Then
                Process.Start("cmd", cmdA + "172.16.22.193" + cmdB)
            ElseIf station = "Safety Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.195"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.155"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.195" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.155" + cmdB)
                End If
            ElseIf station = "Fan Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.196"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.156"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.196" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.156" + cmdB)
                End If
            ElseIf station = "Wlan Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.145"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.200"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.23.199"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.198"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.5"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.204"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.203"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.22.249"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.22.239"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.20.117"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.145" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.200" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.23.199" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.198" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.5" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.204" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.203" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.249" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.239" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.117" + cmdB)
                End If
            ElseIf station = "OTA Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.208"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.209"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.208" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.209" + cmdB)
                End If
            ElseIf station = "Set Burn Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.20.50"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.49"
                Else
                    Process.Start("cmd", cmdA + "172.16.20.50" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.49" + cmdB)
                End If
            ElseIf station = "Final Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.213"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.214"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.215"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.216"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.217"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.218"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.232"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.22.245"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.22.221"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.22.228"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.213" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.214" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.215" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.216" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.217" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.218" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.232" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.245" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.221" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.228" + cmdB)
                End If
            ElseIf station = "Auto Final Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.21.233"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.21.249"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.21.231"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.23.189"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.21.234"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.21.113"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.21.114"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.83"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.20.88"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.20.86"
                Else
                    Process.Start("cmd", cmdA + "172.16.21.233" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.249" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.231" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.23.189" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.234" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.113" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.114" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.83" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.88" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.86" + cmdB)
                End If
            ElseIf station = "Reflash" Then
                Process.Start("cmd", cmdA + "172.16.22.223" + cmdB)
            ElseIf station = "FW Check" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.225"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.227"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.190"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.225" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.227" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.190" + cmdB)
                End If
            ElseIf station = "FQC Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.226"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.190"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.226" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.190" + cmdB)
                End If
            ElseIf station = "Print Box Label" Then
                Process.Start("cmd", cmdA + "172.16.20.75" + cmdB)
            ElseIf station = "Weight Giftbox" Then
                Process.Start("cmd", cmdA + "172.16.22.233" + cmdB)
            ElseIf station = "Carton" Then
                Process.Start("cmd", cmdA + "172.16.22.230" + cmdB)
            ElseIf station = "Pallet" Then
                Process.Start("cmd", cmdA + "172.16.22.231" + cmdB)
            End If
        ElseIf line = "Line 6" Then
            If station = "Dashboard" Then
                Process.Start("cmd", cmdA + "172.16.22.103" + cmdB)
            ElseIf station = "ISN Input" Then
                Process.Start("cmd", cmdA + "172.16.22.106" + cmdB)
            ElseIf station = "Pre RF Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.108"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.191"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.109"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.111"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.20.41"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.108" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.191" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.109" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.111" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.41" + cmdB)
                End If
            ElseIf station = "RF Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.115"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.25"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.113"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.112"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.241"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.116"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.117"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.22.244"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.22.121"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.22.120"
                ElseIf machine = "Machine 11" Then
                    viewIp = "172.16.22.118"
                ElseIf machine = "Machine 12" Then
                    viewIp = "172.16.22.119"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.115" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.25" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.113" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.112" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.241" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.116" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.117" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.244" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.121" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.120" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.118" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.119" + cmdB)
                End If
            ElseIf station = "Power Test (PWB)" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.104"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.105"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.255"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.107"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.104" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.105" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.255" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.107" + cmdB)
                End If
            ElseIf station = "BT Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.253"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.238"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.122"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.21.120"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.126"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.43"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.253" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.238" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.122" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.120" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.126" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.43" + cmdB)
                End If
            ElseIf station = "Laser Engrave" Then
                Process.Start("cmd", cmdA + "172.16.22.125" + cmdB)
            ElseIf station = "SSN Upload" Then
                Process.Start("cmd", cmdA + "172.16.22.127" + cmdB)
            ElseIf station = "RF Link" Then
                Process.Start("cmd", cmdA + "172.16.22.131" + cmdB)
            ElseIf station = "Safety Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.134"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.137"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.134" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.137" + cmdB)
                End If
            ElseIf station = "Fan Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.135"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.5"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.135" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.5" + cmdB)
                End If
            ElseIf station = "Wlan Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.141"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.140"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.139"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.138"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.142"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.251"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.144"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.20.219"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.22.207"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.20.70"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.141" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.140" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.139" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.138" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.142" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.251" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.144" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.219" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.207" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.70" + cmdB)
                End If
            ElseIf station = "OTA Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.136"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.154"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.136" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.154" + cmdB)
                End If
            ElseIf station = "Set Burn Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.167"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.20.48"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.167" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.20.48" + cmdB)
                End If
            ElseIf station = "Final Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.147"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.151"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.149"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.22.153"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.22.146"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.22.152"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.22.150"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.22.148"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.22.41"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.22.42"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.147" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.151" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.149" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.153" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.146" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.152" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.150" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.148" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.41" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.42" + cmdB)
                End If
            ElseIf station = "Auto Final Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.21.208"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.21.209"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.21.212"
                ElseIf machine = "Machine 4" Then
                    viewIp = "172.16.21.213"
                ElseIf machine = "Machine 5" Then
                    viewIp = "172.16.21.214"
                ElseIf machine = "Machine 6" Then
                    viewIp = "172.16.21.215"
                ElseIf machine = "Machine 7" Then
                    viewIp = "172.16.21.216"
                ElseIf machine = "Machine 8" Then
                    viewIp = "172.16.21.217"
                ElseIf machine = "Machine 9" Then
                    viewIp = "172.16.21.218"
                ElseIf machine = "Machine 10" Then
                    viewIp = "172.16.21.219"
                Else
                    Process.Start("cmd", cmdA + "172.16.21.208" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.209" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.212" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.213" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.214" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.215" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.216" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.217" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.218" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.21.219" + cmdB)
                End If
            ElseIf station = "Reflash" Then
                Process.Start("cmd", cmdA + "172.16.22.166" + cmdB)
            ElseIf station = "FW Check" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.157"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.159"
                ElseIf machine = "Machine 3" Then
                    viewIp = "172.16.22.169"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.157" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.159" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.169" + cmdB)
                End If
            ElseIf station = "FQC Test" Then
                If machine = "Machine 1" Then
                    viewIp = "172.16.22.158"
                ElseIf machine = "Machine 2" Then
                    viewIp = "172.16.22.169"
                Else
                    Process.Start("cmd", cmdA + "172.16.22.158" + cmdB)
                    Process.Start("cmd", cmdA + "172.16.22.169" + cmdB)
                End If
            ElseIf station = "Print Box Label" Then
                Process.Start("cmd", cmdA + "172.16.22.161" + cmdB)
            ElseIf station = "Weight Giftbox" Then
                Process.Start("cmd", cmdA + "172.16.20.241" + cmdB)
            ElseIf station = "Carton" Then
                Process.Start("cmd", cmdA + "172.16.22.163" + cmdB)
            ElseIf station = "Pallet" Then
                Process.Start("cmd", cmdA + "172.16.22.164" + cmdB)
            End If
        ElseIf line = "Line 7" Then
        ElseIf line = "Line 8" Then
        ElseIf line = "Line 9" Then
        Else
        End If
        If Not machine = "ALL" And Not machine = "" Then
            txtIp.Text = "IP: " + viewIp
            Process.Start("cmd", cmdA + viewIp + cmdB)
        End If
        System.Console.WriteLine(cmdA + viewIp + cmdB)
    End Sub
End Class
