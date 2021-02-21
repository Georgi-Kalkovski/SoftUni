window.game = (function() {
    return {
        events: {
            onBeginTurn: createObserver(),
            onEncounterEnd: createObserver(),
        }
    };

    function createObserver() {
        const listeners = new Set();
        fire.subscribe = subscribe;
        fire.unsubscribe = unsubscribe;

        return fire;

        function fire(...params) {
            listeners.forEach(l => l(...params));
        }

        function subscribe(listener) {
            listeners.add(listener);
        }

        function unsubscribe(listener) {
            listeners.delete(listener);
        }
    }
})();