function Edit() {
  for (var i = 1; i < 11; i++) {
    for (var j = 2; j < 7; j++) {
      document.getElementById("Grades").rows[i].cells[j].contentEditable = true; 
      //make every cell in table editable where contentEditable hasn't been set to false in HTML
    }
  }
}


function Unsubmitted() {
  var table = document.getElementById("Grades");
  var rows = table.rows.length;
  var cols = table.rows[0].cells.length;
  var Unsubcount = 0;
  
  for (var i = 1; i < rows; i++) {
    for (var j = 2; j < (cols - 1); j++) {
      var add = table.rows[i].cells[j]; //check through every cell 
      if (add.innerHTML === '-' || add.innerHTML === '') {
       Unsubcount++; //if they are empty increment unsubmitted count
      }
    }
  }
  
  Average();
  
  var Unsub = document.getElementById("Unsubmitted");
  var Unsubrows = Unsub.rows;
  Unsubrows[1].style.backgroundColor = "red";
  Unsubrows[1].style.color = "white";
  Unsubrows[1].style.textAlign = "right";
  Unsubrows[1].innerHTML = "<td>" + Unsubcount + "</td>"; //show count how unsubmitted assignments
  if(Unsubcount == 0) { //checnge colour when there are no unsubmitted assignments
    Unsubrows[1].style.backgroundColor = "white";
    Unsubrows[1].style.color = "black";
    Unsubrows[1].style.textAlign = "right";
  }
}


function Average() {
  var table = document.getElementById("Grades");
  var rows = table.rows;
  
  for (var i = 1; i < rows.length; i++) {
    var cells = rows[i].cells;
    var sum = 0;

    for (var j = 2; j < (cells.length - 1); j++) {
      var cell = cells[j];
      var num = parseInt(cell.innerHTML); //assign value in cell to var
      
      if (!isNaN(num)) { //check that input is only numbers
        //https://www.w3schools.com/jsref/jsref_isnan.asp
        if(num <= 100 || num >= 0){ //check inputted grade is only 0-100 (doesn't work?)
        sum += num;
        rows[i].cells[j].style.backgroundColor = "white";
        rows[i].cells[j].style.color = "black";
        rows[i].cells[j].style.textAlign = "right"
        }
      } else { //if it's not 0-100, then it is invalid
        rows[i].cells[j].style.backgroundColor = "yellow";
        rows[i].cells[j].style.color = "black";
        rows[i].cells[j].innerHTML = "-";
      }
    }
    
    var avg = sum / 5; //calculate average of the 5 grades

    if (avg < 60) { //check if grade is above or below 60
      rows[i].cells[7].innerHTML = "<td>" + Math.round(avg) + "%" + "</td>";
      rows[i].cells[7].style.backgroundColor = "red";
      rows[i].cells[7].style.color = "white";
      rows[i].cells[7].style.textAlign = "right"
    } else {
      rows[i].cells[7].innerHTML = "<td>" + Math.round(avg) + "%" + "</td>";
      rows[i].cells[7].style.backgroundColor = "white";
      rows[i].cells[7].style.color = "black";
      rows[i].cells[7].style.textAlign = "right"
    }
  }
}
