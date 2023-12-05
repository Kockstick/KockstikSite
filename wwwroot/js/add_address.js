
let btnCansel = document.getElementById("CanselBtn");
let btnSave = document.getElementById("SaveBtn");

btnCansel.onclick = () => {
    if (confirm("Отчистить все поля на форме?")) {
        clearFields();
    }
}

function clearFields() {
    let inputFields = document.getElementsByClassName("input_field");

    for (var i = 0; i < inputFields.length; i++) {
        inputFields[i].value = "";
    }
}

/*
btnSave.onclick = async function () {
    let inputFields = document.getElementsByClassName("input_field");
    let textEmpty = "Данные не указаны";
    let fields = [
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
}

modaldoc.addEventListener("hidden.bs.modal", () => {
    clearFields();
})
*/