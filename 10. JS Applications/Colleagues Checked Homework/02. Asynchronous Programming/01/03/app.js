function attachEvents() {
    const locationsUrl = 'http://localhost:3030/jsonstore/forecaster/locations';
    const baseUrl = 'http://localhost:3030/jsonstore/forecaster/';
    const currentDiv = document.getElementById('current');
    const outerForecastDiv = document.getElementById('forecast');
    const upcomingDiv = document.getElementById('upcoming');


    const symbols = {
        Sunny: "&#x2600", // ☀
        'Partly sunny': "&#x26C5",  // ⛅
        Overcast: "&#x2601", // ☁
        Rain: "&#x2614", // ☂
        degrees: "&#176" // °
    }

    const locationName = document.getElementById('location');

    document.getElementById('submit').addEventListener('click', () => {
        fetch(locationsUrl)
            .then(response => response.json())
            .then(data => {
                const { name, code } = data.find(c => c.name.toLowerCase() == locationName.value.toLowerCase());

                let today = fetch(baseUrl + `today/${code}`)
                    .then(response => response.json());

                let upcoming = fetch(baseUrl + `upcoming/${code}`)
                    .then(response => response.json());

                Promise.all([today, upcoming])
                    .then(showForecast)
                    .catch(e => console.log(e));
            })

    });

    function e(type, className, content) {
        const result = document.createElement(type);
        result.className = className;
        result.innerHTML = content;
        return result;
    }

    function showForecast([currentData, upcomingData]) {
        outerForecastDiv.style.display = 'block';
        showCurrent(currentData);
        showUpcoming(upcomingData);
    }

    function showCurrent(currentData) {
        let symbol = symbols[currentData.forecast.condition];
        const highLow = `${currentData.forecast.low}${symbols.degrees}/${currentData.forecast.high}${symbols.degrees}`;

        const forecastDiv = e('div', 'forecasts', '');
        const symbolSpan = e('span', 'condition symbol', symbol);
        const conditionSpan = e('span', 'condition', '');

        const span1 = e('span', 'forecast-data', currentData.name);
        const span2 = e('span', 'forecast-data', highLow);
        const span3 = e('span', 'forecast-data', currentData.forecast.condition);


        forecastDiv.appendChild(symbolSpan);
        conditionSpan.appendChild(span1);
        conditionSpan.appendChild(span2);
        conditionSpan.appendChild(span3);
        forecastDiv.appendChild(conditionSpan);

        currentDiv.appendChild(forecastDiv);
    }

    function showUpcoming(upcomingData) {
        const forecastInfo = e('div', 'forecast-info', '');
        
        upcomingData.forecast.forEach(obj => {
            const upcomingSpan = e('span', 'upcoming', '');
            const highLow = `${obj.low}${symbols.degrees}/${obj.high}${symbols.degrees}`;
            
            const span1 = e('span', 'symbol', symbols[obj.condition]);
            const span2 = e('span', 'forecast-data', highLow);
            const span3 = e('span', 'forecast-data', obj.condition);

            upcomingSpan.appendChild(span1);
            upcomingSpan.appendChild(span2);
            upcomingSpan.appendChild(span3);

            forecastInfo.appendChild(upcomingSpan);
        });
        upcomingDiv.appendChild(forecastInfo);
    }
}

attachEvents();

