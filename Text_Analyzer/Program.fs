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
    let labelInput = new Label()
    let labelOutput = new Label()
    let pictureBoxIcon = new PictureBox()  

    let createPanelWithLabel text location size color =
        let panel = new Panel(Size = size, Location = location, BackColor = color)
        let label = new Label(Text = text, Font = new Font("Century Gothic", 12.0F), AutoSize = true, Location = Point(5, 16))
        panel.Controls.Add(label)
        panel

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
        textBoxInput.Size <- Size(660, 137)
        textBoxInput.Location <- Point(20, 50)

        let panel7 = createPanelWithLabel "Most Frequent Words:" (Point(693, 50)) (Size(218, 137)) (Color.FromArgb(255, 230, 255))

        labelOutput.Text <- "Output:"
        labelOutput.Font <- new Font("Century Gothic", 12.0F)
        labelOutput.Location <- Point(20, 193)

        // Panels with labels for each output item
        let panel1 = createPanelWithLabel "Readability Score:" (Point(276, 357)) (Size(232, 100)) (Color.FromArgb(230, 230, 255))
        let panel2 = createPanelWithLabel "Paragraph Count:" (Point(25, 357)) (Size(232, 100)) (Color.FromArgb(230, 255, 230))
        let panel3 = createPanelWithLabel "Word Count:" (Point(25, 234)) (Size(232, 100)) (Color.FromArgb(255, 230, 230))
        let panel4 = createPanelWithLabel "Average Sentence Length:" (Point(533, 234)) (Size(375, 60)) (Color.FromArgb(255, 255, 230))
        let panel5 = createPanelWithLabel "Sentence Count:" (Point(276, 234)) (Size(232, 100)) (Color.FromArgb(230, 255, 255))
        let panel6 = createPanelWithLabel "Most Frequent Words:" (Point(533, 317)) (Size(375, 140)) (Color.FromArgb(255, 230, 255))

        panelContent.Controls.AddRange([| panel1; panel2; panel3; panel4; panel5; panel6 |])
        panelContent.Controls.Add(labelInput)
        panelContent.Controls.Add(textBoxInput)
        panelContent.Controls.Add(labelOutput)

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

[<STAThread>]
[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    Application.Run(new Form2())
    0