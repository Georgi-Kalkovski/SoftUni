async function attachEvents() {

    const symbols = {
        Sunny: '☀',
        'Partly sunny': '⛅',
        Overcast: '☁',
        Rain: '☂',
        Degrees: '°',
    }

    const current = document.getElementById('current');
    const forecast = document.getElementById('forecast');

    document.getElementById('submit').addEventListener('click', async () => {
        const location = document.getElementById('location').value;
        let currentConditions;
        let upcomingConditions;

        try {
            const url = 'http://localhost:3030/jsonstore/forecaster/locations';
            const data = await gettingData(url);
            let currentCity;

            for (const city of data) {
                if (location == city.name) {
                    currentCity = city.code;
                    break;
                }
            }

            const urlCurrent = `http://localhost:3030/jsonstore/forecaster/today/${currentCity}`;
            const urlUpcoming = `http://localhost:3030/jsonstore/forecaster/upcoming/${currentCity}`;

            currentConditions = await gettingData(urlCurrent);
            upcomingConditions = await gettingData(urlUpcoming);

        } catch {
            current.firstElementChild.textContent = 'Error';
            document.getElementById('current').lastChild.remove();
            document.getElementById('upcoming').lastChild.remove();
            forecast.style.removeProperty('display');
            return;
        }

        createCurrent(currentConditions);
        createUpcoming(upcomingConditions);


        document.getElementById('location').value = '';
    });

    async function gettingData(url) {
        const response = await fetch(url);
        const data = await response.json();

        return data;
    }

    function createCurrent(data) {

        current.firstElementChild.textContent = 'Current conditions';
        current.lastChild.remove();

        const spanCity =
            e('span', data.name, 'forecast-data');
        const spanTemperature =
            e('span', `${data.forecast.low}${symbols.Degrees}/${data.forecast.high}${symbols.Degrees}`, 'forecast-data');
        const spanCondition =
            e('span', data.forecast.condition, 'forecast-data');
        const spanConditions =
            e('span', undefined, 'condition');

        spanConditions.appendChild(spanCity);
        spanConditions.appendChild(spanTemperature);
        spanConditions.appendChild(spanCondition);

        const symbol = data.forecast.condition

        const spanSymbol =
            e('span', symbols[symbol], 'condition symbol');

        const div =
            e('div', undefined, 'forecasts');

        div.appendChild(spanSymbol);
        div.appendChild(spanConditions);

        current.appendChild(div);
        
        forecast.style.removeProperty('display');
    }

    function createUpcoming(data) {

        const upcoming = document.getElementById('upcoming');
        upcoming.firstElementChild.textContent = 'Three-day forecast';
        upcoming.lastChild.remove();

        const div =
            e('div', undefined, 'forecast-info');

        for (const token of data.forecast) {
            const span =
                e('span', undefined, 'upcoming');
            const spanSymbol =
                e('span', symbols[token.condition], 'symbol');
            const spanTemperature =
                e('span', `${token.low}${symbols.Degrees}/${token.high}${symbols.Degrees}`, 'forecast-data');
            const spanCondition =
                e('span', token.condition, 'forecast-data');

            span.appendChild(spanSymbol);
            span.appendChild(spanTemperature);
            span.appendChild(spanCondition);
            div.appendChild(span);
        }

        upcoming.appendChild(div);
    }

    function e(type, text, style) {

        const element = document.createElement(type);

        if (text) {
            element.textContent = text;
        }
        if (style) {
            element.className = style;
        }
        return element;
    }
}

attachEvents();