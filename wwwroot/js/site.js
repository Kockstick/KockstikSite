let editBtn = document.getElementById("editBtn");
let textArea = document.getElementById("textTextarea");

let btnCansel = document.getElementById("CanselBtn");
let btnSave = document.getElementById("SaveBtn");

let btnModal = document.getElementById("btnModalClose");
let modaldoc = document.querySelector(".modal");
let modal = new bootstrap.Modal(modaldoc);

btnCansel.onclick = () => {
    if (confirm("Отчистить все поля на форме?")) {
        clearFields();
    }   
}

btnSave.onclick = () => {
    let inputFields = document.getElementsByClassName("input_field");
    let textEmpty = "Данные не указаны";
    const fields = [
        "Префикс населенного пункта",
        "Название населенного пункта",
        "Префикс улицы",
        "Название улицы",
        "Номер дома",
        "Литера дома",
        "Номер корпуса",
        "Номер квартиры",
        "Номер комнаты",
        "Комментарий"
    ];

    let text = "";

    for (var i = 0; i < fields.length; i++) {
        if (inputFields[i].value === "") 
            text += fields[i] + " - " + textEmpty + "\n";
        else
            text += fields[i] + " - " + inputFields[i].value + "\n";
    }

    let modalText = document.getElementById("modal-text");
    modalText.textContent = text;
    modal.show();
    /*
    alert(text);
    clearFields();
    */
}

modaldoc.addEventListener("hidden.bs.modal", () => {
    clearFields();
})

function clearFields() {
    let inputFields = document.getElementsByClassName("input_field");

    for (var i = 0; i < inputFields.length; i++) {
        inputFields[i].value = "";
    }
}

editBtn.onclick = () => {
    if (textArea.disabled) {
        textArea.disabled = false;
        editBtn.textContent = "Сохранить";
    }
    else {
        textArea.disabled = true;
        editBtn.textContent = "Редактировать";
    }
}
