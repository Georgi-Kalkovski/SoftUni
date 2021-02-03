//function encodeAndDecodeMessages() {
//    const sendMessage = document.querySelector('#main > div:nth-child(1) > textarea');
//    const receivedMessage = document.querySelector('#main > div:nth-child(2) > textarea');
//    document.querySelector('#main > div:nth-child(1) > button').addEventListener('click', encodeAndSend);
//    document.querySelector('#main > div:nth-child(2) > button').addEventListener('click', decodeAndRead);
//
//    function encodeAndSend() {
//        let passingText = '';
//        sendMessage.value.split('')
//            .forEach(c => passingText += String.fromCharCode(c.charCodeAt(0) + 1));
//        receivedMessage.value = passingText;
//        sendMessage.value = '';
//        document.querySelector('#main > div:nth-child(2) > button').disabled = false;
//    }
//
//    function decodeAndRead() {
//        let passingText = '';
//        receivedMessage.value.split('')
//            .forEach(c => passingText += String.fromCharCode(c.charCodeAt(0) - 1));
//        receivedMessage.value = passingText;
//        document.querySelector('#main > div:nth-child(2) > button').disabled = true;
//    }
//}

function encodeAndDecodeMessages() {
    const textareas = document.querySelectorAll('textarea');
    const buttons = document.querySelectorAll('button');

    const map = {
        encode: {
            text: textareas[0],
            btn: buttons[0],
            transform: (char) => String.fromCharCode(char.charCodeAt(0) + 1),
        },
        decode: {
            text: textareas[1],
            btn: buttons[1],
            transform: (char) => String.fromCharCode(char.charCodeAt(0) - 1),
        },
    };

    document.getElementById('main').addEventListener('click', (e) => {
        if (e.target.tagName !== 'BUTTON') {
            return;
        }

        const type = e.target.textContent
            .toLowerCase()
            .trim()
            .includes('encode') ? 'encode' : 'decode';

        const message = map[type].text.value
            .split('')
            .map(map[type].transform)
            .join('');

        map.encode.text.value = '';
        map.decode.text.value = message;
    })
}