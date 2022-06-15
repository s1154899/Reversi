


var FeedbackWidget = (function(){

    function show(elementId,type,message){
        LocalLogging.log("feedback_widget",type,message);
        var container = document.getElementById(elementId);
        switch (type) {
            case "succes":
                container.className = "alert alert-success fade-in";
                break;
            default:
                container.className = "alert alert-danger fade-in";
                break;
        }

        container.getElementsByTagName("p")[0].innerText = message;
        if (container.style.display != "block"){
            toggleFeedback(elementId);
        }
    }
    function hide(elementId){
        if (document.getElementById(elementId).style.display != "none"){
            toggleFeedback(elementId);
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

        log : function(){LocalLogging.log("feedback_widget");},
        removeLog : function(){LocalLogging.removeLog("feedback_widget");},
        history : function(){LocalLogging.history("feedback_widget");}

    }
})();


//TODO make return work
//TODO remove the class