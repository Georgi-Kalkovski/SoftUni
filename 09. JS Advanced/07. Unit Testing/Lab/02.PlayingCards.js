function PlayingCards(face, suit) {

    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
    
    const suits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }

    if (!faces.includes(face)) {
        throw new Error('Invalid face!')
    }
    
    return face + suits[suit];
}

console.log(PlayingCards('A', 'S'));
console.log(PlayingCards('10', 'H'));
console.log(PlayingCards('1', 'C'));