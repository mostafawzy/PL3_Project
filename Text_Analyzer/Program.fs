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
    let labelInput = new Label()
    let pictureBoxIcon = new PictureBox()  

    
    let createPanel location size color =
        let panel = new Panel(Size = size, Location = location, BackColor = color)
        panel

    do
        // Panel Header
        panelHeader.BackColor <- ColorTranslator.FromHtml("#367CAF")
        panelHeader.Dock <- DockStyle.Top
        panelHeader.Size <- Size(1100, 80)
        labelTitle.Text <- "Text Analyzer"
        labelTitle.Font <- new Font("Century Gothic", 25.0F)
        labelTitle.ForeColor <- Color.White
        labelTitle.AutoSize <- true
        labelTitle.TextAlign <- ContentAlignment.MiddleRight
        labelTitle.Location <- Point(840,21)
        panelHeader.Controls.Add(labelTitle)

        // Sidebar Panel
        panelSidebar.BackColor <- ColorTranslator.FromHtml("#ece0d0") 
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
        panelContent.BackColor <- ColorTranslator.FromHtml("#fcfcf4")  
        panelContent.Dock <- DockStyle.Fill
        panelContent.Size <- Size(1000, 646)

        labelInput.Text <- "Input Text:"
        labelInput.Font <- new Font("Century Gothic", 12.0F)
        labelInput.Location <- Point(20, 20)

        textBoxInput.Font <- new Font("Century Gothic", 10.0F)
        textBoxInput.Multiline <- true
        textBoxInput.ScrollBars <- ScrollBars.Vertical
        textBoxInput.Size <- Size(660, 137)
        textBoxInput.Location <- Point(20, 50)

       

        // Output labels positioned above the panels
        let panel1Label = new Label(Text = "Readability Score:", Font = new Font("Century Gothic", 12.0F), AutoSize = true, Location = Point(276, 357))
        let panel2Label = new Label(Text = "Paragraph Count:", Font = new Font("Century Gothic", 12.0F), AutoSize = true, Location = Point(25, 357))
        let panel3Label = new Label(Text = "Word Count:", Font = new Font("Century Gothic", 12.0F), AutoSize = true, Location = Point(25, 234))
        let panel5Label = new Label(Text = "Sentence Count:", Font = new Font("Century Gothic", 12.0F), AutoSize = true, Location = Point(276, 234))
        let panel6Label = new Label(Text = "Most Frequent Words:", Font = new Font("Century Gothic", 12.0F), AutoSize = true, Location = Point(533, 234))

      // Panels without inside labels
        let panel1 = createPanel (Point(276, 387)) (Size(232, 90)) (Color.FromArgb(230, 230, 255))
        let panel2 = createPanel (Point(25, 387)) (Size(232, 90)) (ColorTranslator.FromHtml("#eaeded"))
        let panel3 = createPanel (Point(25, 264)) (Size(232, 90)) (Color.FromArgb(255, 230, 230))
        let panel5 = createPanel (Point(276, 264)) (Size(232, 90)) (ColorTranslator.FromHtml("#c3eafb"))
        let panel6 = createPanel (Point(533, 264)) (Size(355, 210)) (ColorTranslator.FromHtml("#dafada"))

        panelContent.Controls.AddRange([| panel1Label; panel2Label; panel3Label; panel5Label; panel6Label |])
        panelContent.Controls.AddRange([| panel1; panel2; panel3;panel5; panel6 |])
        panelContent.Controls.Add(labelInput)
        panelContent.Controls.Add(textBoxInput)
        

        // PictureBox for the icon
        pictureBoxIcon.Location <- Point(730, 50)
        pictureBoxIcon.Size <- Size(140, 137)
        pictureBoxIcon.Image <- Image.FromFile("1.png")  
        pictureBoxIcon.SizeMode <- PictureBoxSizeMode.StretchImage 
        panelContent.Controls.Add(pictureBoxIcon)

        
        this.Controls.Add(panelContent)
        this.Controls.Add(panelSidebar)
        this.Controls.Add(panelHeader)

       
        this.ClientSize <- Size(1130, 600)
        this.Text <- "Text Analyzer"
        this.TransparencyKey <- Color.AntiqueWhite
        this.StartPosition <- FormStartPosition.CenterScreen

[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    Application.Run(new Form2())
    0
