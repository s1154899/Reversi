const Game = (function(url){
    var Data;
    var Model;
    console.log('hallo, vanuit een module');


//Configuratie en state waarden
let configMap = {
    apiUrl: url
}

// Private function init
const privateInit = function(){
    console.log(configMap.apiUrl);

}

// Waarde/object geretourneerd aan de outer scope
return {
    init: privateInit,
    Data: Data,
    Model:Model

}
})('/api/url');