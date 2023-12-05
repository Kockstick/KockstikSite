CheckMessage();

async function CheckMessage() {
    let message = document.querySelector(".message_div");
    let text = document.getElementById("message_text");

    if (text.textContent == "")
        return;

    message.classList.add("message-showing");

    message.onclick = () => {
        message.classList.remove("message-showing");
    }

    /*const delay = ms => new Promise(resolve => setTimeout(resolve, ms))
    await delay(5000);
    message.classList.remove("message-showing");*/
}
