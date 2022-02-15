


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