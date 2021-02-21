window.game = (function (ctx) {
    const events = {
        onTravel: createObserver(),
        onEncounter: createObserver(),
        onBeginTurn: createObserver(),
        onPlayerTargetting: createObserver(),
        onEndEncounter: createObserver(),
        onRun: createObserver(),
        onAction: createObserver(),
    };

    function createObserver() {
        const listeners = new Set();
        fire.subscribe = subscribe;
        fire.unsubscribe = unsubscribe;

        return fire;


        function subscribe(callback) {
            listeners.add(callback);
        }

        function unsubscribe(callback) {
            listeners.delete(callback);
        }

        function fire(...data) {
            listeners.forEach(l => l(...data));
        }
    }

    return {
        events
    };
})(window);