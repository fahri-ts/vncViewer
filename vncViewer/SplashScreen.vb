Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title + " by TSF"
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright

        txtPath.Text = frmVnc.vncPath
    End Sub

    Private Sub MainLayoutPanel_Click(sender As Object, e As EventArgs) Handles MainLayoutPanel.Click
        Me.Close()
    End Sub

    Private Sub DetailsLayoutPanel_Click(sender As Object, e As EventArgs) Handles DetailsLayoutPanel.Click
        Me.Close()
    End Sub

    Private Sub ApplicationTitle_Click(sender As Object, e As EventArgs) Handles ApplicationTitle.Click
        Me.Close()
    End Sub

    Private Sub Version_Click(sender As Object, e As EventArgs) Handles Version.Click
        Me.Close()
    End Sub

    Private Sub Copyright_Click(sender As Object, e As EventArgs) Handles Copyright.Click
        Me.Close()
    End Sub

    Private Sub okPath_Click(sender As Object, e As EventArgs) Handles okPath.Click
        frmVnc.vncPath = txtPath.Text
        System.Console.WriteLine("Path=" + txtPath.Text)
        Me.Close()
    End Sub

    Private Sub txtPath_DoubleClick(sender As Object, e As EventArgs) Handles txtPath.DoubleClick
        txtPath.ReadOnly = False
    End Sub
End Class
