function WordsUppercase(input){
let letters = input.toUpperCase();
letters = letters.replace(/[-!$%^&*()_+|~=`{}\[\]:";'<>?,\/]+/g, '');
letters = letters.replace(/[. ]+/g, ', ');
console.log(letters);
}

WordsUppercase('Hi, how are you?');
WordsUppercase('hello');
WordsUppercase('Functions in JS can be nested, i.e. hold other functions');