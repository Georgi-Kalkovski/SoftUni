function WordsUppercase(input) {
 
    console.log(input.split(/[\W]+/).filter(w => w != '').map(w => w.toUpperCase()).join(', '));
 
}

WordsUppercase('Hi, how are you?');
WordsUppercase('hello');
WordsUppercase('Functions in JS can be nested, i.e. hold other functions');