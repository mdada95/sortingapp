﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function myFunction()
{
    event.preventDefault(); 

    //Debugging 
    console.log($ ("#valueType").val());
    console.log($ ("#sortType").val()); 

    $.ajax({
        type: "POST",
        url: "sortingapp/Program.cs",
        data: $("#textInput"),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            window.alert("HELP ME NOW"); 
        }
    })

}