const board = (function (){

    function CreateBoard(length , width) {
        var board = document.createElement("div");

        board.className = "board-container";

        for (var x = 0; x < length; x++) {
            for (var y = 0; y < width; y++) {

                    board.innerHTML += createSquare("green", x, y);


            }

        }
        return board;
    }

    function PlaceDisk(x,y,color){
        var square = document.getElementById("x"+x+"y"+y);
        square.innerHTML = "<div class='discs-animation-drop-"+color+"'></div>";
    }

    function flipDisk(x,y,color){
        var square = document.getElementById("x"+x+"y"+y);
        square.innerHTML = "<div class='discs-animation-to-"+color+"'></div>";
    }
        {
            function createSquare(color,x,y){
                var ret;

                ret = "<div id='x"+x+"y"+y+"' class='board-"+color+"-square'></div>";

                return ret;
            }
        }




    return {
        create: CreateBoard,
        flip : flipDisk,
        place : PlaceDisk
    }
})()