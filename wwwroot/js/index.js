
$(document).ready(async function () {
    var table = $('#tableid').DataTable();
    table.column(0).visible(false);
});

CheckMessage();

async function CheckMessage() {
    let message = document.querySelector(".message_div");
    let text = document.getElementById("message_text");
    let type = document.getElementById("message_type");

    if (text.textContent == "")
        return;

    const delay = ms => new Promise(resolve => setTimeout(resolve, ms));
    await delay(100);

    message.classList.add("message-showing");

    message.classList.add("message-" + type.textContent);

    message.onclick = () => {
        message.classList.remove("message-showing");
    }

    /*
    await delay(5000);
    message.classList.remove("message-showing");*/
}
