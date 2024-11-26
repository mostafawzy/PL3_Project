open System
open System.Windows.Forms

type Book = {
    Title: string
    Author: string
    Genre: string
    IsBorrowed: bool
    BorrowDate: DateTime option
}

let initialLibrary = [
    { Title = "F# for Fun and Profit"; Author = "Scott Wlaschin"; Genre = "Programming"; IsBorrowed = false; BorrowDate = None }
    { Title = "The Hobbit"; Author = "J.R.R. Tolkien"; Genre = "Fantasy"; IsBorrowed = false; BorrowDate = None }
]

let createForm() =
    let form = new Form(Text = "Library Management System", Width = 600, Height = 500)
    let titleLabel = new Label(Text = "Title:", Top = 20, Left = 20)
    let titleInput = new TextBox(Top = 20, Left = 80, Width = 200)
    let addButton = new Button(Text = "Add Book", Top = 60, Left = 20)
    let resultBox = new ListBox(Top = 100, Left = 20, Width = 550, Height = 300)
    form.Controls.AddRange [| titleLabel; titleInput; addButton; resultBox |]
    (form, titleInput, addButton, resultBox)

let addBook title library =
    let newBook = { Title = title; Author = "Unknown"; Genre = "General"; IsBorrowed = false; BorrowDate = None }
    newBook :: library

[<STAThread>]
do
    let (form, titleInput, addButton, resultBox) = createForm()
    let mutable library = initialLibrary

    addButton.Click.Add(fun _ ->
        if titleInput.Text <> "" then
            library <- addBook titleInput.Text library
            titleInput.Clear()
            resultBox.Items.Clear()
            library |> List.iter (fun book -> resultBox.Items.Add(book.Title) |> ignore)
        else
            MessageBox.Show("Title cannot be empty.") |> ignore
    )

    Application.Run(form)
