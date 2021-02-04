function solve() {

    let textarea = [...document.getElementsByTagName('textarea')];
    let outputTextarea = textarea[1].value;
    let table = document.querySelector('table > tbody')

    let buttons = [...document.getElementsByTagName('button')];
    buttons[0].addEventListener('click', generateBtn);
    //buttons[1].addEventListener('click', buyBtn)

    function generateBtn() {
        let jsonParser = JSON.parse(textarea[0].value)
        for (const item of jsonParser) {
            let split = item;
            const obj = {
                name: split[0],
                img: split[1],
                price: Number(split[2]),
                decFactor: Number(split[3]),
            };

            console.log(obj);

        }
    }
}