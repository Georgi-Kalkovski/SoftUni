function attachEventsListeners() {

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    let daysBtn = document.getElementById('daysBtn').addEventListener('click', onDaysClick);
    let hoursBtn = document.getElementById('hoursBtn').addEventListener('click', onHoursClick);
    let minutesBtn = document.getElementById('minutesBtn').addEventListener('click', onMinutesClick);
    let secondsBtn = document.getElementById('secondsBtn').addEventListener('click', onSecondsClick);

    function onDaysClick(){
        hours.value = days.value * 24;
        minutes.value = days.value * 1440;
        seconds.value = days.value * 86400;
    };
    function onHoursClick(){
        days.value = hours.value / 24;
        minutes.value = hours.value * 60;
        seconds.value = hours.value * 3600;
     }
     function onMinutesClick(){ 
        days.value = minutes.value / 1440;
        hours.value = minutes.value / 60;
        seconds.value = minutes.value * 60;
    }
    function onSecondsClick(){ 
        days.value = seconds.value / 86400;
        hours.value = seconds.value / 3600;
        minutes.value = seconds.value / 60;
    }
}