

function onLoadIcin() {
    haberGetir();
    bigparaGetir();
    mahmureGetir();
    emlakGetir();
    currencyGetir();
    wheaterGetirIst();
    wheaterGetirAnk();
}

const haberlerDiv1 = document.getElementById("haberler1");

const currencyDiv = document.getElementById("currency");
const wheatherDiv1 = document.getElementById("wheaterIst");
const wheatherDiv2 = document.getElementById("wheaterAnk");
const bigparaDiv = document.getElementById("bigParaHaber");
const mahmureDiv = document.getElementById("mahureHaber");
const emlakDiv = document.getElementById("emlakHaber");

function haberGetir() {
    fetch('http://localhost:64069/api/Data/GetHome')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            for (var i = 0; i < data.length; i++) {
                haberlerDiv1.innerHTML +=
                    `
                <li class=" cards-list-item">
                     <a href="${data[i].Link}" id="cardId" href="#" class="card">
                       <img src=${data[i].Image} class="card-media" alt=" ${data[i].Title}">
                        <span id="card-text" class="card-header-sub"><b> ${data[i].Title} </b></span>
                        <span id="card-text" class="card-sub-text">${data[i].Spot} </span>
                        <span id="card-text" class="card-sub-text"><i>${data[i].Category}</i> </span>
                    </a>
                 </li>
                `
            }

        })
}

function bigparaGetir() {
    fetch('http://localhost:64069/api/Data/GetBigPara')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            for (var i = 0; i < data.length; i++) {
                bigparaDiv.innerHTML +=
                    `
               <div class="b-card">
                        <img class="b-img" src="${data[i].Image}">
                        <p class="b-head" > ${ data[i].Title}</p><br>
                        <p class="b-text">${data[i].Spot}</p>
               </div>
                     `
            }

        })
}

function mahmureGetir() {
    fetch('http://localhost:64069/api/Data/GetMahmure')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            for (var i = 0; i < data.length; i++) {
                mahmureDiv.innerHTML +=
                    `
               <figure class="snip1529">
                       <img src="${data[i].Image}" alt="pr-sample13" />
                 <figcaption>
                       <h3 class="snip-head">${data[i].Title}</h3>
                       <p>${data[i].Spot}</p>
                 </figcaption>
                 <div class="hover"><i class="ion-android-open"></i></div>
                     <a href="${data[i].Link}"></a>
                    </figure>
                     `
            }

        })
}

function emlakGetir() {
    fetch('http://localhost:64069/api/Data/GetEmlak')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            for (var i = 0; i < data.length; i++) {
                emlakDiv.innerHTML +=
                    `
               <div class="column">
                    <div class="card">
                        <img src="${data[i].Image}" class="card-img" />
                         <p>${data[i].Title}</p>
                         <p>${data[i].Spot}</p>
                     </div>
               </div>
                     `
            }

        })
}


function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

function currencyGetir() {

    fetch('http://www.apilayer.net/api/live?access_key=abefbc2fbe9e74c962d10d0c549c7b63')
        .then(response => response.json())
        .then(data => {
            currencyDiv.innerHTML +=
                `
                        <td> ${data.quotes.USDTRY} </td>
                        <td> ${data.quotes.USDEUR} </td>
                        <td> ${data.quotes.USDANG} </td>
                        <td> ${data.quotes.USDKRW} </td>
                    
                 `
        })
}

function wheaterGetirIst() {
    var d = new Date();
    var weekday = new Array(7);
    weekday[0] = "Pazar";
    weekday[1] = "Pazartesi";
    weekday[2] = "Sali";
    weekday[3] = "Carsamba";
    weekday[4] = "Persembe";
    weekday[5] = "Cuma";
    weekday[6] = "Cumartesi";;

    var n = weekday[d.getUTCDay()];
    fetch('http://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=json&lang=tr&units=metric&appid=5fc10de79207f8e878cbbaeebce21dd1')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            wheatherDiv1.innerHTML +=
                `
                    <div  class="left-panel panel">
                         <div class="date">
                                  ${n}
                        <img class= "weather_image" src="http://openweathermap.org/img/w/${data.weather[0].icon}.png"
                         </div>

                    <div class="city">
                              ${data.name}
                        </div>
                       
                     <div class="temp">
                          
                                 ${data.main.temp}&deg;
                         </div>
                        <p><i>${data.weather[0].description}</i></p>
                         
                     </div>
                

                 `
        })
}

function wheaterGetirAnk() {
    var d = new Date();
    var weekday = new Array(7);
    weekday[0] = "Pazar";
    weekday[1] = "Pazartesi";
    weekday[2] = "Sali";
    weekday[3] = "Carsamba";
    weekday[4] = "Persembe";
    weekday[5] = "Cuma";
    weekday[6] = "Cumartesi";

    var n = weekday[d.getUTCDay()];
    fetch('http://api.openweathermap.org/data/2.5/weather?q=Ankara&mode=json&lang=tr&units=metric&appid=5fc10de79207f8e878cbbaeebce21dd1')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            wheatherDiv2.innerHTML +=
                `
                    <div  class="left-panel panel">
                         <div class="date">
                                  ${n}
                         <img class= "weather_image" src="http://openweathermap.org/img/w/${data.weather[0].icon}.png"
                         </div>
                    <div class="city">
                              ${data.name}
                        </div>
                   
                     <div class="temp">
                          
                                 ${data.main.temp}&deg;
                         </div>
                        <p class="weather_text"><i>${data.weather[0].description}</i></p>
                     </div>
                

                 `
        })
}




$(document).ready(function () {
    onLoadIcin();
})

//$(window).load(function () {

//})

//$(window).resize(function () {

//})

//$(window).scroll(function () {

//})