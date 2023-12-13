let myCars = []

async function getCars(){
    let response = await fetch('http://localhost:5030/api/cars', [])
    myCars = await response.json() 
    console.log(myCars);
}

async function handleOnLoad(){
    await getCars();
    let html = `<div class="jumbotron">
                    <h1 class="text-center">CAR INVENTORY</h1>
                </div>
                <br>
                <div id="tableBody"></div>
        
                <form class = "container" onsubmit="return false">
                  <label for="makeAndModel">Make and Model:</label>
                  <label for="mileage">Mileage:</label>
                  <label for="date">Date (YYYY-MM-DD):</label><br>
                  <input type="text" id="makeAndModel" name="makeAndModel">
                  <input type="text" id="mileage" name="mileage">
                  <input type="text" id="date" name="date">
                  <button class="btn btn-light" onclick="handleCarAdd()">Submit</button>
                  <br>
                  <br>
              </form>`
    
    document.getElementById('app').innerHTML = html;
    populateTable();
}


function populateTable(){
    
    let html =`
    <table class="container">
    <tr>
        <th >ID</th>
        <th >Make and Model</th>
        <th >Mileage</th>
        <th >Date Entered in Inventory</th>
        <th >Hold Status</th>
    </tr>`;
    if(myCars === null){
        console.log('no cars');
    }
    else{

            myCars.forEach(function(car) {

                if(car.deleted != 1){
                    
                let day = keepFirstTenCharacters(car.carDate)

                
                html += `
                <tr>
                <td>${car.carID}</td>
                <td>${car.makeAndModel}</td>
                <td>${car.mileage}</td>
                <td>${day}</td>
                <td>${car.hold}</td>
                <td>
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <button type="button" class="btn btn-light" onclick="handleCarHold('${car.carID}')">Hold</button>
                        <button type="button" class="btn btn-dark" onclick="handleCarDelete('${car.carID}')">Sell (Delete)</button>
                    </div>
                </td>
                </tr>`

                }
            })
        }
  html += `</table>`
  document.getElementById(`tableBody`).innerHTML = html;
}

async function handleCarAdd(){
    let car = {CarID: 1, MakeAndModel: document.getElementById('makeAndModel').value, Mileage: document.getElementById('mileage').value, CarDate: document.getElementById('date').value, Hold: false, Deleted: false}

    await fetch('http://localhost:5030/api/cars', {
      method: "POST",
      body: JSON.stringify(car),
      headers: {
          "Content-type": "application/json; charset=UTF-8"
      }
  })

    location.reload();

}

function keepFirstTenCharacters(inputString) {
    if (inputString) {
        return inputString.slice(0, 10);
    } else {
        return '';
    }
}   

async function handleCarDelete(CarID){
    response = await fetch('http://localhost:5030/api/cars/' + CarID + '/?carID=' + CarID)
    let car = await response.json() 

    console.log(car.deleted)

    await fetch('http://localhost:5030/api/Cars' + '/' + CarID + '?carID=' + CarID, {
        method: "DELETE",
        body: JSON.stringify(car),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })

     location.reload();
}


async function handleCarHold(CarID){

    response = await fetch('http://localhost:5030/api/cars/' + CarID + '/?carID=' + CarID)
    let car = await response.json() 

    if(car.hold == true){
        car.hold = false
    }
    else if(car.hold == false){
        car.hold = true
    }


    await fetch('http://localhost:5030/api/Cars' + '/' + CarID + '?carID=' + CarID, {
        method: "PUT",
        body: JSON.stringify(car),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })

     location.reload();
}





