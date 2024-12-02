open System
open System.Windows.Forms
open System.Drawing

type Form2() as this =
    inherit Form()

    let panelHeader = new Panel()
    let labelTitle = new Label()
    let panelSidebar = new Panel()
    let buttonLoadFile = new Button()
    let button1 = new Button()
    let button2 = new Button()
    let panelContent = new Panel()
    let textBoxInput = new TextBox()
    let textBoxOutput = new TextBox()
    let labelInput = new Label()
    let labelOutput = new Label()

    do
         // Panel Header
        panelHeader.BackColor <- Color.FromArgb(64, 122, 97)
        panelHeader.Dock <- DockStyle.Top
        panelHeader.Size <- Size(1100, 80)
        labelTitle.Text <- "Text Analyzer"
        labelTitle.Font <- new Font("Century Gothic", 20.0F)
        labelTitle.ForeColor <- Color.White
        labelTitle.AutoSize <- true 
        labelTitle.TextAlign <- ContentAlignment.MiddleRight 
        labelTitle.Location <- Point(panelHeader.Width - labelTitle.Width - 100, (panelHeader.Height - labelTitle.Height) / 2) 

        panelHeader.Controls.Add(labelTitle)

        
        // Sidebar Panel
        panelSidebar.BackColor <- Color.FromArgb(236, 226, 221)
        panelSidebar.Dock <- DockStyle.Left
        panelSidebar.Size <- Size(200, 646)

        buttonLoadFile.Text <- "Load File"
        buttonLoadFile.Font <- new Font("Century Gothic", 14.0F)
        buttonLoadFile.Size <- Size(200, 81)
        buttonLoadFile.FlatStyle <- FlatStyle.Flat
        buttonLoadFile.FlatAppearance.BorderSize <- 0
        panelSidebar.Controls.Add(buttonLoadFile)

        button1.Text <- "Analyze"
        button1.Font <- new Font("Century Gothic", 14.0F)
        button1.Size <- Size(200, 81)
        button1.FlatStyle <- FlatStyle.Flat
        button1.FlatAppearance.BorderSize <- 0
        button1.Location <- Point(0, 87)
        panelSidebar.Controls.Add(button1)

        button2.Text <- "Clear"
        button2.Font <- new Font("Century Gothic", 14.0F)
        button2.Size <- Size(200, 81)
        button2.FlatStyle <- FlatStyle.Flat
        button2.FlatAppearance.BorderSize <- 0
        button2.Location <- Point(0, 174)
        panelSidebar.Controls.Add(button2)

        // Content Panel
        panelContent.BackColor <- Color.FromArgb(248, 241, 244)
        panelContent.Dock <- DockStyle.Fill
        panelContent.Size <- Size(1000, 646)

        labelInput.Text <- "Input Text:"
        labelInput.Font <- new Font("Century Gothic", 12.0F)
        labelInput.Location <- Point(20, 20)

        textBoxInput.Font <- new Font("Century Gothic", 10.0F)
        textBoxInput.Multiline <- true
        textBoxInput.ScrollBars <- ScrollBars.Vertical
        textBoxInput.Size <- Size(860, 157)
        textBoxInput.Location <- Point(20, 50)

        labelOutput.Text <- "Output Data:"
        labelOutput.Font <- new Font("Century Gothic", 12.0F)
        labelOutput.Location <- Point(20, 210)

        textBoxOutput.Font <- new Font("Century Gothic", 10.0F)
        textBoxOutput.Multiline <- true
        textBoxOutput.ReadOnly <- true
        textBoxOutput.ScrollBars <- ScrollBars.Vertical
        textBoxOutput.Size <- Size(860, 335)
        textBoxOutput.Location <- Point(20, 240)

        // Add controls to content panel
        panelContent.Controls.Add(labelInput)
        panelContent.Controls.Add(textBoxInput)
        panelContent.Controls.Add(labelOutput)
        panelContent.Controls.Add(textBoxOutput)

        // Add panels to form
        this.Controls.Add(panelContent)
        this.Controls.Add(panelSidebar)
        this.Controls.Add(panelHeader)

        // Set form properties
        this.ClientSize <- Size(1100, 600)
        this.Text <- "Text Analyzer"
        this.TransparencyKey <- Color.AntiqueWhite


[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    Application.Run(new Form2()) 
    0 
