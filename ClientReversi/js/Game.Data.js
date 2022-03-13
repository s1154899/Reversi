
Game.Data = (function(){

    //Configuratie en state waarden
    let configMap = {
        apiUrl: "c3af2af9cfd832a16a22419d4d32697b",
            mock: [
                {
                    url: api/Spel/Beurt,
                    data: 0
                }
            ]
    };

    function init(){}



    const get = function(url){
        return $.get(url)
            .then(r => {
                return r
            })
            .catch(e => {
                console.log(e.message);
            });
    };

    return{
        get : get,
        init : init
    }

})();