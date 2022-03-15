


var FeedbackWidget = (function(){
    var _elementId;

    function SetElementId(elementId){
        _elementId = elementId;
        init();
    }

    function init(){

        var Element = document.getElementById(_elementId);
        var Buttons = Element.getElementsByTagName("button");


        for(var i = 0; i < Buttons.length; i++) {
            Buttons[i].addEventListener( "click",function(){hide(_elementId);});
        }

    }

    function show(type,message){
        LocalLogging.log("feedback_widget",type,message);
        var container = document.getElementById(_elementId);
        switch (type) {
            case "succes":
                container.className = "alert alert-success";
                break;
            default:
                container.className = "alert alert-danger";
                break;
        }

        container.getElementsByTagName("p")[0].innerText = message;
        if (container.style.display != "block"){
            toggleFeedback(_elementId);
        }
    }
    function hide(element){
        if (document.getElementById(element).style.display != "none"){
            toggleFeedback(element);
        }
    }

    function toggleFeedback(elementId) {
        var x = document.getElementById(elementId);
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }
    }



    return {
        show : show,
        hide : hide,
        SetElementId : SetElementId,

        log : function(){LocalLogging.log("feedback_widget");},
        removeLog : function(){LocalLogging.removeLog("feedback_widget");},
        history : function(){LocalLogging.history("feedback_widget");}

    }
})();


//TODO make return work
//TODO remove the class

Game.Data = (function(){
    let stateMap = {
        environment : 'development'
    }

    //Configuratie en state waarden
    let configMap = {
        apiUrl: url,
        mock : {
            

            "/api/Spel":[
                "Potje snel reveri, dus niet lang nadenken",
                "Ik zoek een gevorderde tegenspeler!",
                "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander",
                "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander"
            ],

        }
    }

    function init(){
        switch (stateMap.enviroment) {
            case "development":
                //TODO local mock request
                break;
            case "production":
                //TODO online data request
                break;
            default:
                throw new Error("no Environment selected");
        }


    }
    const getMockData = function(url){

        //filter mock data, configMap.mock ... oei oei, moeilijk moeilijk :-)
        const mockData = configMap.mock[url].test;

        return new Promise((resolve, reject) => {
            resolve(mockData);
        });

    }
    return{

        getMockData : getMockData,
        init : init
    }

})();

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
    getMockData : getMockData,
    Data: Data,
    Model:Model

}
})('/api/url');
Game.Model = (function(){

    //Configuratie en state waarden
    let configMap = {
        apiUrl: "http://api.openweathermap.org/data/2.5/weather?q=zwolle&apikey=c3af2af9cfd832a16a22419d4d32697b"
    };


    const _getGameState = function(){

        //aanvraag via Game.Data

        //controle of ontvangen data valide is

    }


    function init(){}

    const getWeather = function(){

        return Game.Data.get(configMap.apiUrl).then(r =>{ return r});
    };

    return{
        getWeather : getWeather,
        getGameState: _getGameState,
        init : init
    }

})();

var LocalLogging = (function(){
    function log(key,type,message){
        //localStorage.setItem()

        var obj = {message , type};
        obj.message = message;
        obj.type = type;


        var obj2 = [];
        var feedbackJson =JSON.parse( localStorage.getItem(key));
        obj2.push(obj);
        if(feedbackJson != null) {
            for (var i = 0; (i < feedbackJson.length) && (i < 10 ); i++) {

                obj2.push(feedbackJson[i]);
            }
        }

        localStorage.setItem(key,JSON.stringify(obj2));

    }
    function removeLog(key){

        localStorage.removeItem(key);
    }

    function history(key){
        return JSON.parse( localStorage.getItem(key));

    }

    return{
        log:log,
        removeLog: removeLog,
        history : history

    }

    })();