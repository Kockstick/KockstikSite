$(document).ready(async function () {
    var responce = await fetch("https://www.cbr-xml-daily.ru/daily_utf8.xml");
    let textXml = (await responce.text()).toString();
    let domParser = new DOMParser();

    let xmlDOM = domParser.parseFromString(textXml, "text/xml");
    let names = xmlDOM.querySelectorAll("Name");
    let values = xmlDOM.querySelectorAll("Value");

    var table = $('#tableid').DataTable();

    $.each(names, function (i, v) {
        table.row.add([
            v.innerHTML,
            values[i].innerHTML
        ]).draw(false);
    })
});