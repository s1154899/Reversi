const AJAXReversi = (function () {
    function CheckForNew() {

    }

    function PlaceDisk(rijzet, kolomZet, spelToken) {
        
       
        $.ajax({
            url: 'https://localhost:5001/api/Spel/',
            type: "GET",
            headers: { 'Content-Type': 'application/json', 'rijZet': rijzet, 'kolomZet': kolomZet },
            dataType: "jsonp",
            data: { spelToken}
        });
        

    }

function s()
{
    var xmlhttp = new XMLHttpRequest();
        xmlhttp.open("GET", "https://localhost:5001/api/Spel", true);
        xmlhttp.withCredentials = true;
        xmlhttp.setRequestHeader("Content-Type", "application/json");
        xmlhttp.setRequestHeader("rijZet", rijzet);
        xmlhttp.setRequestHeader("kolomZet", kolomZet);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin", "*");
        xmlhttp.send(spelToken);

    }

    return {
        place: PlaceDisk,
        Check: CheckForNew
    }
})()