function solution() {
    const sections = document.querySelectorAll('.card');
    const listOfGifts = sections[1];
    const sentGifts = sections[2];
    const discardedGifts = sections[3];

    sections[0].querySelector('button').addEventListener('click', function () {

        const giftName = sections[0].querySelector('input[type=text]');

        const button1 = document.createElement('button')
        button1.id = 'sendButton';
        button1.textContent = 'Send';

        const button2 = document.createElement('button')
        button2.id = 'discardButton';
        button2.textContent = 'Discard';

        const li = document.createElement('li');
        li.className = 'gift';
        li.textContent = giftName.value;
        li.appendChild(button1);
        li.appendChild(button2);
        
        giftName.value = '';

        listOfGifts.children[1].appendChild(li);

        sortList();

        listOfGifts.children[1].addEventListener('click', function (e) {
            if (e.target.id == 'sendButton') {
                let sentGift = e.target.parentNode;
                sentGift.children[0].remove();
                sentGift.children[0].remove();
                sentGifts.children[1].appendChild(sentGift);
            }
            if (e.target.id == 'discardButton') {
                let discardGift = e.target.parentNode;
                discardGift.children[0].remove();
                discardGift.children[0].remove();
                discardedGifts.children[1].appendChild(discardGift);
            }
        })

        function sortList() {
            var list, i, switching, b, shouldSwitch; 5
            list = listOfGifts.children[1];
            switching = true;
            while (switching) {
                switching = false;
                b = list.getElementsByTagName("LI");
                for (i = 0; i < (b.length - 1); i++) {
                    shouldSwitch = false;
                    if (b[i].innerHTML.toLowerCase() > b[i + 1].innerHTML.toLowerCase()) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    b[i].parentNode.insertBefore(b[i + 1], b[i]);
                    switching = true;
                }
            }
        }
    })
}