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
