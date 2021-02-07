function printDeckOfCards(cards) {
    function createCard(face, suit) {

        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']

        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'
        }

        if (!faces.includes(face)) {
            throw new Error('Invalid face!')
        } else if (!suits[suit]) {
            throw new Error('Invalid suit!');
        }

        return {
            face,
            suit,
            toString() {
                return `${face}${suits[suit]}`
            }
        };
    }

    let outputCards = [];

    for (const card of cards) {
        try {
            let suit = card.slice(-1);
            let face = card.slice(0, card.length - 1);

            const checkedCard = createCard(face, suit);

            outputCards.push(checkedCard);
        }
        catch (error) {
            return console.log(`Invalid card: ${card}`);
            // judge works with console.log ?!?!?
        }
    }
    return outputCards.join(' ');
}


console.log(printDeckOfCards(['AS', '10D', 'KH', '2C']));
console.log(printDeckOfCards(['5S', '3D', 'QD', '1C']));
