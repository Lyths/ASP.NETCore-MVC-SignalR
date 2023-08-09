
let userName = document.getElementById("userName").value;
let groupName = document.getElementById("groupName").value;
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

async function start() {
    try {
        await hubConnection.start();
        console.log("SignalR Connected");
        hubConnection.invoke("Enter", userName, groupName);
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function reset() {
    document.getElementById("message").value = "";
};

hubConnection.onclose(async () => {
    await start();
});

start();

document.getElementById("sendBtn").addEventListener("click", () => {
    const message = document.getElementById("message").value;
    hubConnection.invoke("Send", message, userName, groupName)
        .catch(error => console.error(error));
});

hubConnection.on("Receive", (message, user) => {

    // создаем элемент <b> для имени пользователя
    const userNameElem = document.createElement("b");
    userNameElem.textContent = `${user}: `;

    // создает элемент <p> для сообщения пользователя
    const elem = document.createElement("p");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    const firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(elem, firstElem);
});
