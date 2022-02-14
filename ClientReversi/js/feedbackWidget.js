
class FeedbackWidget{
    constructor(elementId) {


        this._elementId = elementId;
        var Element = document.getElementById(this.elementId);
        var Buttons = Element.getElementsByTagName("button");

        var FakeHide = this.hide;
        for(var i = 0; i < Buttons.length; i++) {
            Buttons[i].addEventListener( "click",function(){FakeHide(elementId);});
        }


        //$("#feedback-success-accept").on("click", function(){
        //    alert("The button was clicked.");
        //});
    }

    get elementId() { //getter, set keyword voor setter methode
        return this._elementId;
    }

    show(type,message){
        this.log(type,message);
        var container = document.getElementById(this._elementId);
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
            toggleFeedback(this._elementId);
        }
    }
    hide(element){
        if (document.getElementById(element).style.display != "none"){
            toggleFeedback(element);
        }
    }
    log(type,message){
        //localStorage.setItem()

        var obj = {message , type};
        obj.message = message;
        obj.type = type;


        var obj2 = [];
        var feedbackJson =JSON.parse( localStorage.getItem("feedback_widget"));
        obj2.push(obj);
        if(feedbackJson != null) {
            for (var i = 0; (i < feedbackJson.length) && (i < 10 ); i++) {

                obj2.push(feedbackJson[i]);
            }
        }

        localStorage.setItem("feedback_widget",JSON.stringify(obj2));

    }
    removeLog(){

        localStorage.removeItem('feedback_widget');
    }

    history(){
        return JSON.parse( localStorage.getItem("feedback_widget"));

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