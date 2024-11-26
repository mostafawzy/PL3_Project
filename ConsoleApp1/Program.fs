open System
open System.Windows.Forms
open System.Drawing

// Define the Book type as immutable
type Book = {
    Title: string
    Author: string
    Genre: string
    IsBorrowed: bool
    BorrowDate: DateTime option
}

// Library as an immutable list (starts with sample data)
let initialLibrary = [
    { Title = "F# for Fun and Profit"; Author = "Scott Wlaschin"; Genre = "Programming"; IsBorrowed = false; BorrowDate = None }
    { Title = "The Hobbit"; Author = "J.R.R. Tolkien"; Genre = "Fantasy"; IsBorrowed = false; BorrowDate = None }
]

// Helper function to update books in the library
let updateLibrary library updateFunc =
    library |> List.map updateFunc

// Create the main UI form
let createForm() =
    let form = new Form(Text = "Library Management System", Width = 600, Height = 500)

    // UI Controls
    let titleLabel = new Label(Text = "Title:", Top = 20, Left = 20)
    let titleInput = new TextBox(Top = 20, Left = 80, Width = 200)

    let authorLabel = new Label(Text = "Author:", Top = 60, Left = 20)
    let authorInput = new TextBox(Top = 60, Left = 80, Width = 200)

    let genreLabel = new Label(Text = "Genre:", Top = 100, Left = 20)
    let genreInput = new TextBox(Top = 100, Left = 80, Width = 200)

    let addButton = new Button(Text = "Add Book", Top = 140, Left = 20, Width = 100)

    let searchLabel = new Label(Text = "Search Title:", Top = 200, Left = 20)
    let searchInput = new TextBox(Top = 200, Left = 120, Width = 200)
    let searchButton = new Button(Text = "Search", Top = 200, Left = 350, Width = 100)

    let resultBox = new ListBox(Top = 240, Left = 20, Width = 550, Height = 150)

    let borrowButton = new Button(Text = "Borrow", Top = 400, Left = 20, Width = 100)
    let returnButton = new Button(Text = "Return", Top = 400, Left = 150, Width = 100)

    form.Controls.AddRange [| titleLabel; titleInput; authorLabel; authorInput; genreLabel; genreInput;
                              addButton; searchLabel; searchInput; searchButton; resultBox;
                              borrowButton; returnButton |]
    (form, titleInput, authorInput, genreInput, addButton, searchInput, searchButton, resultBox, borrowButton, returnButton)

// Functional logic for UI actions

// Add a book to the library
let addBook title author genre library =
    let newBook = { Title = title; Author = author; Genre = genre; IsBorrowed = false; BorrowDate = None }
    newBook :: library

// Search for books by title
let searchBooks searchTitle library =
    library |> List.filter (fun book -> book.Title.ToLower().Contains(searchTitle.ToLower()))

// Borrow a book
let borrowBook title library =
    library |> updateLibrary (fun book ->
        if book.Title = title && not book.IsBorrowed then { book with IsBorrowed = true; BorrowDate = Some(DateTime.Now) }
        else book
    )

// Return a book
let returnBook title library =
    library |> updateLibrary (fun book ->
        if book.Title = title && book.IsBorrowed then { book with IsBorrowed = false; BorrowDate = None }
        else book
    )

// Display books in the ListBox
let displayBooks books listBox =
    listBox.Items.Clear()
    books |> List.iter (fun book ->
        let status = if book.IsBorrowed then $"Borrowed (Since: {book.BorrowDate.Value.ToShortDateString()})" else "Available"
        listBox.Items.Add($"{book.Title} by {book.Author} [{book.Genre}] - {status}") |> ignore
    )

// Main application
[<STAThread>]
do
    // Create the form and UI elements
    let (form, titleInput, authorInput, genreInput, addButton, searchInput, searchButton, resultBox, borrowButton, returnButton) = createForm()

    // Initialize library state
    let mutable library = initialLibrary

    // Add Book Event
    addButton.Click.Add(fun _ ->
        if titleInput.Text <> "" && authorInput.Text <> "" && genreInput.Text <> "" then
            library <- addBook titleInput.Text authorInput.Text genreInput.Text library
            MessageBox.Show("Book added successfully!") |> ignore
            titleInput.Clear(); authorInput.Clear(); genreInput.Clear()
            displayBooks library resultBox
        else
            MessageBox.Show("Please fill in all fields!") |> ignore
    )

    // Search Book Event
    searchButton.Click.Add(fun _ ->
        let searchResults = searchBooks searchInput.Text library
        displayBooks searchResults resultBox
    )

    // Borrow Book Event
    borrowButton.Click.Add(fun _ ->
        if resultBox.SelectedItem <> null then
            let selectedBook = resultBox.SelectedItem.ToString().Split(" by ").[0]
            library <- borrowBook selectedBook library
            MessageBox.Show("Book borrowed successfully!") |> ignore
            displayBooks library resultBox
    )

    // Return Book Event
    returnButton.Click.Add(fun _ ->
        if resultBox.SelectedItem <> null then
            let selectedBook = resultBox.SelectedItem.ToString().Split(" by ").[0]
            library <- returnBook selectedBook library
            MessageBox.Show("Book returned successfully!") |> ignore
            displayBooks library resultBox
    )

    // Display initial library
    displayBooks library resultBox

    // Run the application
    Application.Run(form)
