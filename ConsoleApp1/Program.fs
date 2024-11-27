open System
open System.Windows.Forms
open System.Drawing
open System.IO
open Newtonsoft.Json

// Define a record type for user data
type UserData = { Name: string; Age: string; Country: string }

// Define the main form
let form = new Form(Text = "User Information", Width = 600, Height = 400, StartPosition = FormStartPosition.CenterScreen)

// Set the background color and form properties
form.BackColor <- ColorTranslator.FromHtml("#d6eaf8")  
form.FormBorderStyle <- FormBorderStyle.FixedDialog
form.MaximizeBox <- false

// Create label and textbox for 'Name'
let nameLabel = new Label(Text = "Name:", Left = 50, Top = 30, Width = 100, Font = new Font("Arial", 10.0f, FontStyle.Bold))
let nameTextBox = new TextBox(Left = 150, Top = 30, Width = 300, Font = new Font("Arial", 10.0f))
nameTextBox.BackColor <- Color.WhiteSmoke  

// Create label and textbox for 'Age'
let ageLabel = new Label(Text = "Age:", Left = 50, Top = 70, Width = 100, Font = new Font("Arial", 10.0f, FontStyle.Bold))
let ageTextBox = new TextBox(Left = 150, Top = 70, Width = 300, Font = new Font("Arial", 10.0f))
ageTextBox.BackColor <- Color.WhiteSmoke 

// Create label and textbox for 'Country'
let countryLabel = new Label(Text = "Country:", Left = 50, Top = 110, Width = 100, Font = new Font("Arial", 10.0f, FontStyle.Bold))
let countryTextBox = new TextBox(Left = 150, Top = 110, Width = 300, Font = new Font("Arial", 10.0f))
countryTextBox.BackColor <- Color.WhiteSmoke  

// Create a button to submit the form
let submitButton = new Button(Text = "Submit", Left = 150, Top = 150, Width = 100, Height = 30, Font = new Font("Arial", 10.0f, FontStyle.Bold))
submitButton.BackColor <- ColorTranslator.FromHtml("#1f77b4")  
submitButton.ForeColor <- Color.White

// Add hover effect for the submit button
submitButton.MouseEnter.Add(fun _ -> submitButton.BackColor <- ColorTranslator.FromHtml("#155a8a"))
submitButton.MouseLeave.Add(fun _ -> submitButton.BackColor <- ColorTranslator.FromHtml("#1f77b4"))

// Adjust the DataGridView to dynamically set the width based on form dimensions
let margin = 50
let dataGridView = new DataGridView(Left = margin, Top = 200, Height = 150, Width = form.ClientSize.Width - (2 * margin))
dataGridView.AllowUserToAddRows <- false
dataGridView.ColumnCount <- 3
dataGridView.Columns.[0].HeaderText <- "Name"
dataGridView.Columns.[1].HeaderText <- "Age"
dataGridView.Columns.[2].HeaderText <- "Country"
dataGridView.BackgroundColor <- Color.White
dataGridView.BorderStyle <- BorderStyle.Fixed3D
dataGridView.DefaultCellStyle.BackColor <- Color.LightCyan
dataGridView.DefaultCellStyle.SelectionBackColor <- Color.Teal
dataGridView.DefaultCellStyle.SelectionForeColor <- Color.White

// Adjust column resizing to fill the DataGridView width
dataGridView.AutoSizeColumnsMode <- DataGridViewAutoSizeColumnsMode.Fill

// Ensure each column resizes equally
for i in 0 .. dataGridView.ColumnCount - 1 do
    dataGridView.Columns.[i].MinimumWidth <- dataGridView.Width / dataGridView.ColumnCount

// Immutable function to save user inputs to a file
let saveData (data: UserData list) =
    let jsonData = JsonConvert.SerializeObject(data)
    File.WriteAllText("user_data.json", jsonData)

// Immutable function to load user inputs from a file
let loadData () =
    match File.Exists("user_data.json") with
    | true -> 
        let jsonData = File.ReadAllText("user_data.json")
        JsonConvert.DeserializeObject<UserData list>(jsonData)
    | false -> []  

// Function to update DataGridView with user data
let updateDataGridView data =
    dataGridView.Rows.Clear()
    data |> List.iter (fun user ->
        let row = dataGridView.Rows.Add()
        dataGridView.Rows.[row].Cells.[0].Value <- user.Name
        dataGridView.Rows.[row].Cells.[1].Value <- user.Age
        dataGridView.Rows.[row].Cells.[2].Value <- user.Country
    )

// Function to handle the submit button click event
let handleSubmitClick () =
    let name = nameTextBox.Text
    let age = ageTextBox.Text
    let country = countryTextBox.Text

    // Use pattern matching to handle the input validation
    match (name.Trim(), age.Trim(), country.Trim()) with
    | ("", _, _) | (_, "", _) | (_, _, "") ->
        MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
    | (name, age, country) ->
        let newUser = { Name = name; Age = age; Country = country }
        let currentData = loadData()
        let updatedData = newUser :: currentData
        saveData(updatedData)  
        updateDataGridView updatedData  

// Button click event handler
submitButton.Click.Add(fun _ -> handleSubmitClick ())

// Load data into the DataGridView when the form starts
let initialData = loadData()
updateDataGridView initialData

// Add controls to the form
form.Controls.Add(nameLabel)
form.Controls.Add(nameTextBox)
form.Controls.Add(ageLabel)
form.Controls.Add(ageTextBox)
form.Controls.Add(countryLabel)
form.Controls.Add(countryTextBox)
form.Controls.Add(submitButton)
form.Controls.Add(dataGridView)

// Run the application
[<STAThread>]
Application.Run(form)
