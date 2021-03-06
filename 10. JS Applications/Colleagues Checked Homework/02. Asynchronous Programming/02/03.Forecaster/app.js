function attachEvents() {
    const cityInput = document.getElementById("location");
    const forecastDiv = document.getElementById("forecast");
    const currentDiv = document.getElementById("current");
    const upcomingDiv = document.getElementById("upcoming");
    const submitBtn = document.getElementById("submit");
    let cityCode = '';
    let foundCity = false;
    createDomEls();


    submitBtn.addEventListener('click', () =>{
        getCode(cityInput);
        // since all three functions are running at the same time
        // a time out is set to ensure the city code will be present when the two
        // functions below are called since their server requests need the city code in order to
        // get the data needed for the app to function
        setTimeout(() => {
            getCurrentForecast(cityCode)
        }, 50);
        setTimeout(() => {
            getThreeDayForecast(cityCode)
        }, 70);
    });

    // function will make a request to get today's weather data
    // and will make changes to the corresponding DOM elements
    // to display the data
    async function getCurrentForecast(code) {
        try {
            let url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
            const request = await fetch(url);
            const data = await request.json();
            forecastDiv.style.display = 'block';
            let curForecastSpans = currentDiv.querySelector(".forecasts").querySelectorAll("span");
            let symbol = symbolCreator(data.forecast.condition);
            let temp = `${data.forecast.low}°/${data.forecast.high}°`;
            curForecastSpans[0].textContent = symbol;
            curForecastSpans[2].style.display = 'block';
            curForecastSpans[3].style.display = 'block';
            curForecastSpans[2].textContent = data.name;
            curForecastSpans[3].textContent = temp;
            curForecastSpans[4].textContent = data.forecast.condition;
        }catch (err) {
            console.log('City details missing');
        }
    }

    // Function that will make a request to get data needed for three day forecast
    // and will change corresponding elements of dom to display forecast
    async function getThreeDayForecast(code) {
        try {
            let url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
            const request = await fetch(url);
            const data = await request.json();
            forecastDiv.style.display = 'block';
            const upForecastSpans = Array.from(upcomingDiv.querySelectorAll(".upcoming"));
            console.log(upForecastSpans);
            for (let i = 0; i < upForecastSpans.length; i++) {
                let span = upForecastSpans[i];
                console.log(span)
                let curDay = data.forecast[i];
                let spans = span.childNodes;
                let symbol = symbolCreator(curDay.condition);
                let temp = `${curDay.low}°/${curDay.high}°`;
                spans[0].textContent = symbol;
                spans[1].textContent = temp;
                spans[2].textContent = data.name
            }
        }catch (err) {
            console.log("City details missing")
        }
    }

    // function that makes the first request and is responsible for
    // getting the city code or catch an error if anything goes wrong and
    // display "Error" as text in the app
    async function getCode() {
        let city = cityInput.value.toLowerCase();
        try{
            const url = "http://localhost:3030/jsonstore/forecaster/locations";
            const request = await fetch(url);
            const data = await request.json();
            // here we go through each city in the database to check if input is valid
            // if city is found cityCode variable will be set with the corresponding city code
            for (let i=0; i < data.length; i++) {
                let curCityObj = data[i];
                let name = curCityObj.name.toLowerCase();
                if (city === name) {
                    foundCity = true;
                    cityCode = curCityObj.code;
                }
            }
            if (!foundCity) {
                throw Error('City not found');
            }
            foundCity = false;
        //if an error is thrown cityCode variable will be set to empty str
        //and the displayError function will be called
        }catch (err){
            cityCode = '';
            displayError();
        }
    }

    // function that creates all the DOM elements needed for the app
    function createDomEls() {
        let curForecastDiv = document.createElement('div');
        curForecastDiv.classList.add("forecasts");
        let curForecastSpanSymbol = document.createElement('span');
        curForecastSpanSymbol.classList.add("condition");
        curForecastSpanSymbol.classList.add("symbol");
        curForecastDiv.appendChild(curForecastSpanSymbol);
        let curForecastSpan = document.createElement('span');
        curForecastSpan.classList.add("condition");
        for (let i=1; i<4; i++) {
            let span = document.createElement('span');
            span.classList.add("forecast-data");
            curForecastSpan.appendChild(span);
        }
        curForecastDiv.appendChild(curForecastSpan);

        let upForecastDiv = document.createElement('div');
        upForecastDiv.classList.add("forecast-info");
        for (let i=1; i<4; i++) {
            let upForecastSpan = document.createElement('span');
            upForecastSpan.classList.add("upcoming");
            let spanSymbol = document.createElement('span');
            spanSymbol.classList.add("symbol");
            upForecastSpan.appendChild(spanSymbol);
            for (let i = 1; i < 3; i++) {
                let span = document.createElement('span');
                span.classList.add("forecast-data");
                upForecastSpan.appendChild(span);
            }
            upForecastDiv.appendChild(upForecastSpan);
        }

        currentDiv.appendChild(curForecastDiv);
        upcomingDiv.appendChild(upForecastDiv);
    }

    // this function displays error as text to all corresponding DOM elements
    function displayError() {
        forecastDiv.style.display = 'block';
        let curForecastSpans = currentDiv.querySelector(".forecasts").querySelectorAll("span");
        curForecastSpans[0].textContent = '';
        curForecastSpans[3].style.display = 'none';
        curForecastSpans[4].style.display = 'none';
        let spanForecastCur = currentDiv.querySelector('.forecast-data');
        spanForecastCur.textContent = 'Error';

        let spanForecastUp = upcomingDiv.querySelectorAll('.upcoming');
        console.log(spanForecastUp);
        spanForecastUp[0].childNodes[2].textContent = 'Error';
        spanForecastUp[1].childNodes[2].textContent = 'Error';
        spanForecastUp[2].childNodes[2].textContent = 'Error';
        let spanForecastUpChildrenElOne = spanForecastUp[0].childNodes;
        let spanForecastUpChildrenElTwo = spanForecastUp[1].childNodes;
        let spanForecastUpChildrenElThree = spanForecastUp[2].childNodes;
        spanForecastUpChildrenElOne[0].textContent = 'Error';
        spanForecastUpChildrenElTwo[0].textContent = 'Error';
        spanForecastUpChildrenElThree[0].textContent = 'Error';
        spanForecastUpChildrenElOne[1].textContent = 'Error';
        spanForecastUpChildrenElTwo[1].textContent = 'Error';
        spanForecastUpChildrenElThree[1].textContent = 'Error';
    }

    // function accepts weather data from forecast as string
    // and returns the equivalent symbol to be displayed in the app
    function symbolCreator(str) {
        let symbol = ''
        if (str === 'Sunny') {
            symbol = '☀';
        }else if (str === 'Partly sunny') {
            symbol = '⛅';
        }else if (str === 'Overcast') {
            symbol = '☁';
        }else if (str === 'Rain') {
            symbol = '☂';
        }
        return symbol;
    }

}

attachEvents();
