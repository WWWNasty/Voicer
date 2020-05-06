// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let count = 0;
let mass = [];
$('.addPick').click(function(){

    var input = document.createElement("input");
    var btn = document.createElement("span");
    var div = document.createElement("div");

    if (count < 4) {
        count++;

        input.setAttribute("type", "text");
        input.setAttribute("class", "form-control");
        input.setAttribute("id", "pick" + count);


        btn.innerHTML = "&times;";
        btn.setAttribute("class", "delete-pick close");
        div.append(input,btn);

        $('.new-input').append(div);


        $('.delete-pick').click(function(){
            count--;

            $(this).parent().remove();
        })
    } else {
        alert("Можно выбрать максимум 4 точки");
    }


})