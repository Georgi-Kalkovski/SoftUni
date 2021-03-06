function attachEvents() {
    const locationField = document.getElementById('location');
    const button = document.getElementById('submit');

    button.addEventListener('click', showInfo);

    async function showInfo() {
        const symbols = {
            'Sunny': '&#x2600',
            'Partly sunny': '&#x26C5',
            'Overcast': '&#x2601',
            'Rain': '&#x2614',
            'Degrees': '&#176'
        };

        try {
            const citiesResponse = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
            const cityCode = await getCityCode(citiesResponse);

            const [currentTemperaturesResponse, forecasterResponse] = await Promise.all([
                fetch(`http://localhost:3030/jsonstore/forecaster/today/${cityCode}`),
                fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${cityCode}`)
            ]);
            const [temperaturesData, forecasterData] = await Promise.all([
                currentTemperaturesResponse.json(),
                forecasterResponse.json()
            ]);

            showCurrentTemperature(temperaturesData);
            showForecaster(forecasterData);
        } catch (err) {
            const forecastDiv = document.getElementById('forecast');
            
            forecastDiv.textContent = 'Error';

            // not enough info (and examples) about (of) the error handling in .docx
            // by the condition in .docx, if tried to enter a valid city, no data is shown - because...
            // ... forecastDiv.textContent = 'Error' will 'delete' above twos div elements  
        }

        locationField.value = '';

        async function getCityCode(response) {
            const jsonData = await response.json();
            for (const city of jsonData) {
                if (city.name === locationField.value) {
                    return city.code;
                }
            }

            throw new Error('City not found.');
        }

        function showCurrentTemperature(objData) {
            const currentTemperatureSection = document.getElementById('current');

            if (currentTemperatureSection.children.length > 1) {
                currentTemperatureSection.children[1].outerHTML = '';
            }

            currentTemperatureSection.parentElement.style.display = 'block';

            const div = ce('div', '', 'forecasts');
            const span1 = ce('span', symbols[objData.forecast.condition], 'condition symbol');

            const span2 = ce('span', '', 'condition');
            const span3 = ce('span', objData.name, 'forecast-data');
            const span4 = ce('span', `${objData.forecast.low}${symbols.Degrees}/${objData.forecast.high}${symbols.Degrees}`, 'forecast-data');

            const span5 = ce('span', '', 'forecast-data');
            span5.innerHTML = objData.forecast.condition;

            span2.appendChild(span3);
            span2.appendChild(span4);
            span2.appendChild(span5);

            div.appendChild(span1);
            div.appendChild(span2);

            currentTemperatureSection.appendChild(div);
        }

        function showForecaster(objData) {
            const upcomingTemperatureSection = document.getElementById('upcoming');

            if (upcomingTemperatureSection.children.length > 1) {
                upcomingTemperatureSection.children[1].outerHTML = '';
            }

            const div = ce('div', '', 'forecast-info');

            let i = 0;
            while (i < 3) {
                const span1 = ce('span', '', 'upcoming');
                const span2 = ce('span', symbols[objData.forecast[i].condition], 'symbol');
                const span3 = ce('span', `${objData.forecast[i].low}${symbols.Degrees}/${objData.forecast[i].high}${symbols.Degrees}`, 'forecast-data');
                const span4 = ce('span', objData.forecast[i].condition, 'forecast-data');
    
                span1.appendChild(span2);
                span1.appendChild(span3);
                span1.appendChild(span4);
    
                div.appendChild(span1);

                i++;
            }

            upcomingTemperatureSection.appendChild(div);
        }

        function ce(tagName, content, className) {
            const element = document.createElement(tagName);

            if (content) element.innerHTML = content;
            if (className) element.className = className;

            return element;
        }
    }
}

attachEvents();