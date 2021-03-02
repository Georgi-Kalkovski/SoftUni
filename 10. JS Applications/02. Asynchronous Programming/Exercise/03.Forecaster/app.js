function attachEvents() {
    const input = document.getElementById('location');

    const symbol = {
        Sunny: '&#x2600;',
        "Partly sunny": '&#x26C5;',
        Overcast: '&#x2601;',
        Rain: '&#x2614',
        Degrees: '&#176;'
    };

    document.getElementById('submit')
        .addEventListener('click', () => weather(input.value, symbol));
}

attachEvents();

async function weather(cityName, symbol) {

    document.getElementById('forecast').style.display = 'block';

    const checkCurrent = document.querySelector('#current').children[1];
    const checkUpcoming = document.querySelector('#upcoming').children[1];

    if (checkCurrent) {
        checkCurrent.remove();
    }
    if (checkUpcoming) {
        checkUpcoming.remove();
    }
    const code = await findCity(cityName);
    const currentDay = await getCurrentForecast(code);
    const threeDays = await getUpcomingForecast(code);

    const CurrentDayHtml =
        e('div', { class: 'forecasts' }, '',
            e('span', { class: 'condition symbol' }, `${symbol[currentDay.forecast.condition]}`),
            e('span', { class: 'condition' }, '',
                e('span', { class: 'forecast-data' }, `${currentDay.name}`),
                e('span', { class: 'forecast-data' }, `${currentDay.forecast.high}${symbol.Degrees}/${currentDay.forecast.low}${symbol.Degrees}`),
                e('span', { class: 'forecast-data' }, `${currentDay.forecast.condition}`)))

    document.querySelector('#current').appendChild(CurrentDayHtml);

    const threeDaysHtml =
        e('div', { class: 'forecast-info' }, '',
            e('span', { class: 'upcoming' }, '',
                e('span', { class: 'symbol' }, `${symbol[threeDays.forecast[0].condition]}`),
                e('span', { class: 'forecast-data' }, `${threeDays.forecast[0].high}${symbol.Degrees}/${threeDays.forecast[0].low}${symbol.Degrees}`),
                e('span', { class: 'forecast-data' }, `${threeDays.forecast[0].condition}`)),
            e('span', { class: 'upcoming' }, '',
                e('span', { class: 'symbol' }, `${symbol[threeDays.forecast[1].condition]}`),
                e('span', { class: 'forecast-data' }, `${threeDays.forecast[1].high}${symbol.Degrees}/${threeDays.forecast[1].low}${symbol.Degrees}`),
                e('span', { class: 'forecast-data' }, `${threeDays.forecast[1].condition}`)),
            e('span', { class: 'upcoming' }, '',
                e('span', { class: 'symbol' }, `${symbol[threeDays.forecast[2].condition]}`),
                e('span', { class: 'forecast-data' }, `${threeDays.forecast[2].high}${symbol.Degrees}/${threeDays.forecast[2].low}${symbol.Degrees}`),
                e('span', { class: 'forecast-data' }, `${threeDays.forecast[2].condition}`)))

    document.querySelector('#upcoming').appendChild(threeDaysHtml);

}

async function findCity(city) {
    try {
        document.querySelector('#current div').textContent = 'Current conditions';
        document.querySelector('#upcoming div').textContent = 'Three-day forecast';

        const url = 'http://localhost:3030/jsonstore/forecaster/locations';
        const responce = await fetch(url);
        const data = await responce.json();

        return data.find(x => x.name.toLowerCase() == city.toLowerCase()).code;
    } catch {
        document.querySelector('#current div').textContent = 'Error';
        document.querySelector('#upcoming div').textContent = 'Error';


    }
}

async function getCurrentForecast(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

async function getUpcomingForecast(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

function e(type, attribute, text, ...params) {

    const element = document.createElement(type);

    if (attribute != {} && attribute != undefined) {
        Object.entries(attribute)
            .forEach(([name, value]) => {
                element.setAttribute(`${name}`, `${value}`);
            })
    }
    if (text != undefined && text != '') {
        element.innerHTML = text;
    }
    if (params != undefined && params.length != 0) {
        params.forEach(e => {
            element.appendChild(e);
        })
    }
    return element;
}