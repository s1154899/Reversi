
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
