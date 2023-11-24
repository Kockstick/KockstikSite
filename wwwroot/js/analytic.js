//LoadData();

async function LoadData() {
    var responce = await fetch("https://www.cbr-xml-daily.ru/daily_utf8.xml");
    let textXml = (await responce.text()).toString();
    let domParser = new DOMParser();
    
    let xmlDOM = domParser.parseFromString(textXml, "text/xml");
    let names = xmlDOM.querySelectorAll("Name");
    let values = xmlDOM.querySelectorAll("Value");

    let tableBody = document.getElementById("table_body");

    for (var i = 0; i < names.length; i++) {
        let row = document.createElement("tr");

        let nameData = document.createElement("td");
        let nameText = document.createTextNode(names[i].textContent);

        let valueData = document.createElement("td");
        let valueText = document.createTextNode(values[i].textContent);

        nameData.appendChild(nameText);
        valueData.appendChild(valueText);
        row.appendChild(nameData);
        row.appendChild(valueData);
        tableBody.appendChild(row);
    }
}

$(document).ready(function () {
    $('#tableid').DataTable();
});