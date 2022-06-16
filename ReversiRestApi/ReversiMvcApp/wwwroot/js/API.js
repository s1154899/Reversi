const API = (function () {
    function GetFactAsync() {
        return new Promise(resolve => {
            try {
                var xmlHttp = new XMLHttpRequest();
                xmlHttp.onreadystatechange = function () {
                    if (xmlHttp.readyState == 4 && xmlHttp.status == 200)
                        resolve(JSON.parse(xmlHttp.responseText).text)
                }
                xmlHttp.open("GET", "https://uselessfacts.jsph.pl/random.json", true); // true for asynchronous
                xmlHttp.send(null);
            } catch (err) {
                resolve("The Pentagon, in Arlington, Virginia, has twice as many bathrooms as is necessary, because when it was built in the 1940s, the state of Virginia still had segregation laws requiring separate toilet facilities for blacks and whites.");

            }
        });
    }
        
    

    return {
        GetFactAsync: GetFactAsync,
    }
})()