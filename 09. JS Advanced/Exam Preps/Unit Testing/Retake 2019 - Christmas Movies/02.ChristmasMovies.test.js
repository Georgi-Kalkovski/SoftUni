describe("Christmas movies tests", function() {
    let christmas;
    beforeEach(function() {
        christmas = new ChristmasMovies();
        christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

    })
    describe("Constructor tests", function() {
        it("all fields", function() {
            assert.equal(typeof(christmas.movieCollection), 'object');
            assert.equal(typeof(christmas.watched), 'object');
            assert.equal(typeof(christmas.actors), 'object');
        })
    })

    describe("Buy movie", function() {
        it("throws when movie is already in the collection", function() {
            assert.throw(() => {
                christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']),
                    'You already own Home Alone in your collection!'
            })
        });
        it("adds movie to collection", function() {
            assert.equal(christmas.movieCollection.length, 1);
        });
        it("adds unique actors", function() {
            christmas.buyMovie('movie', ['actor', 'actor', 'actor']);
            assert.equal(christmas.movieCollection[1].actors.length, 1);
        });
    })

    describe("Discard movie", function() {
        it("throws when movie is not in the collection", function() {
            assert.throw(() => {
                christmas.discardMovie('Movie'),
                    'Movie is not at your collection!'
            })
        });
        it("discards movie from collection and from watched list", function() {
            christmas.watchMovie('Home Alone');
            assert.equal(christmas.discardMovie('Home Alone'), 'You just threw away Home Alone!');
            assert.equal(christmas.movieCollection.length, 0);
        });
        it("throws when movie is not watched", function() {
            christmas.buyMovie('M', ['act']);
            assert.throw(() => {
                christmas.discardMovie('M', 'M is not watched!')
            });
        })
    })

    describe("Watch movie", function() {
        it("throws when movie is not in the collection", function() {
            assert.throw(() => {
                christmas.watchMovie('Movie'),
                    'No such movie in your collection!'
            })
        });
        it("adds movie to the watched list", function() {
            christmas.watchMovie('Home Alone');

            assert.isNotEmpty(christmas.watched);
            christmas.watchMovie('Home Alone');
            assert.equal(christmas.watched['Home Alone'], 2);

        });
    })

    describe("Favourite movie", function() {
        it("throws when movie collection is empty", function() {
            assert.throw(() => {
                christmas.favouriteMovie(),
                    'You have not watched a movie yet this year!'
            })
        });
        it("returns favourite movie", function() {
            christmas.watchMovie('Home Alone');
            christmas.watchMovie('Home Alone');
            assert.equal(christmas.favouriteMovie(), 'Your favourite movie is Home Alone and you have watched it 2 times!');
        });
    })

    describe("Most starred actors", function() {
        it("throws when collection is empty", function() {
            let christmas2 = new ChristmasMovies();
            assert.throw(() => {
                christmas2.mostStarredActor(),
                    'You have not watched a movie yet this year!'
            })
        });
        it("returns most starred actors", function() {
            christmas.buyMovie('m', ['actor']);
            christmas.buyMovie('v', ['actor']);
            christmas.buyMovie('n', ['actor']);
            assert.equal(christmas.mostStarredActor(), 'The most starred actor is actor and starred in 3 movies!');
        });
    })
})