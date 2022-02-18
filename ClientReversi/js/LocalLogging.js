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