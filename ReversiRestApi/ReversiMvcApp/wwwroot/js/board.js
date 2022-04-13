const board = (function (){

    function CreateBoard(length , width ) {
        var board = document.createElement("div");

        board.className = "board-container";

        for (var x = 0; x < length; x++) {
            for (var y = 0; y < width; y++) {

                board.innerHTML += createSquare("green", x, y, onclick);


            }

        }
        return board;
    }

    function PlaceDisk(x,y,color){
        var square = document.getElementById("x" + x + "y" + y);
        
        square.innerHTML = "<div color='"+color+"' class='discs-animation-drop-" + color + "' ></div>";
        
        
    }

    function flipDisk(x,y,color){
        var square = document.getElementById("x"+x+"y"+y);
        if (square.children[0].getAttribute("color") == color) {

        } else {
            square.innerHTML = "<div color='" + color + "' class='discs-animation-to-" + color + "'></div>";
        }
    }
        {
        function createSquare(color, x, y) {
            var ret = document.createElement("div");


            ret = "<div id='x" + x + "y" + y + "' x='" + x + "' y='" + y +"'  class='board-" + color + "-square' onclick=\"clickedSquare(this)\"></div>";

                return ret;
            }
        }




    return {
        create: CreateBoard,
        flip : flipDisk,
        place : PlaceDisk
    }
})()