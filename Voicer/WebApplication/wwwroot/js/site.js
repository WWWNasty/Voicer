// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let count = 1;
$('.addPick').click(function () {

    const template = document.getElementById('voting-option-template');
    const newNode = template.cloneNode(true);

    newNode.removeAttribute('style');
    newNode.removeAttribute('id');

    const input = newNode.querySelector('input');

    input.name = input.name.replace('0', count.toString());
//затирает предидущий
    input.setAttribute('id', input.id.replace('0', count.toString()));
    input.setAttribute('name', input.name.replace('0', count.toString()));
    //дополняет список классов
    input.classList.add('voting-option');


    if (count < 15) {
        count++;

        $('.add-option-container').before(newNode);


    } else {
        alert("Можно выбрать максимум 15 штук");
    }


})


function addDeleteButtonHandler() {

    $('.deletePick').click(удолитьВоутингОпшн);
}

function удолитьВоутингОпшн() {
    if (count > 1) {
        $('.voting-option').last().remove();
        count--;
    }
}


$(document).ready(async () => {
    count = parseInt($('#voting-options-count').text());

    addDeleteButtonHandler();


    const chatId = +$('#chatId').val();

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    hubConnection.on("Send", createMessage);

    document.getElementById("sendBtn").addEventListener("click", function (e) {
        let message = document.getElementById("message").value;
        hubConnection.invoke("Send", message, chatId);
    });

    await hubConnection.start();

    await hubConnection.invoke("Connect", chatId)

    const allMessages = await hubConnection.invoke("GetAllMessages", {
        chatId: chatId,
        count: 5,
        page: 0
    });

    allMessages.reverse().forEach(sendMessageDto => createMessage(sendMessageDto));


    function createMessage(sendMessageDto) {

        // const $message = $('#message-template');
        // const messageTemplate = $message.clone();
        //
        // //сокращенный setAttribute из JQuery
        // messageTemplate.attr('id', undefined);
        // messageTemplate.attr('style', undefined);
        //
        // debugger;
        //
        // const templateContent = messageTemplate.html();
        //
        // const html = templateContent.replace('{{userName}}', sendMessageDto.user.email)
        //     .replace('{{data}}', sendMessageDto.created)
        //     .replace('{{text}}', sendMessageDto.text);
        //
        // messageTemplate.html(html);
        //
        // $message.parent().append(messageTemplate);
debugger;
        let elem = document.createElement("p");
        elem.appendChild(document.createTextNode(`${sendMessageDto.user.userName}: "${sendMessageDto.text}"  ${sendMessageDto.created}`));
        let firstElem = document.getElementById("chatroom").firstChild;
        document.getElementById("chatroom").append(elem);
    }


})


// $(".date").mask("99/99/9999");
// {placeholder: "дд.мм.гг" }
//$('input[name="date"]').mask('00/00/0000');


