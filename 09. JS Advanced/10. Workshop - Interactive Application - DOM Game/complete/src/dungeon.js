/* globals e, game */

Object.assign(window.game, (function () {
    const style = {
        'corridor': 'current-corridor',
        'transit': 'current-transit',
        'room': 'current-room'
    };

    return {
        dungeonController,
        generateDungeon
    };

    function dungeonController(topControls, bottomControls) {
        let enabled = false;
        topControls.addEventListener('click', onClick);
        bottomControls.addEventListener('click', onClick);

        return {
            enable,
            disable,
            displayOptions,
            activateNode,
        };

        function activateNode(previous, node) {
            Object.values(style).forEach(s => previous && previous.classList.remove(s));
            node.classList.add(Object.entries(style).find(([c]) => node.classList.contains(c))[1]);
            node.classList.add('visited');
        }

        function onClick({ target }) {
            if (enabled && target.classList.contains('travel-choice')) {
                game.events.onTravel(target.dataset.nodeId);
            }
        }

        function enable() {
            enabled = true;
            [...topControls.children].forEach(c => c.classList.add('active'));
            [...bottomControls.children].forEach(c => c.classList.add('active'));
        }

        function disable() {
            enabled = false;
            [...topControls.children].forEach(c => c.classList.remove('active'));
            [...bottomControls.children].forEach(c => c.classList.remove('active'));
        }

        function displayOptions(top, bottom) {
            topControls.innerHTML = '';
            bottomControls.innerHTML = '';

            top.map(c => topControls.appendChild(createOption(c, 'forward')));
            bottom.map(c => bottomControls.appendChild(createOption(c, 'back')));
        }

        function createOption(node, mode) {
            const element = e('div', { className: 'travel-choice ' + mode }, node.classList.contains('corridor') ? createCorridor() : createRoom());
            element.dataset.nodeId = node.dataset.nodeId;
            if (enabled) {
                element.classList.add('active');
            }

            return element;
        }

        function createCorridor() {
            return e('img', { src: 'assets/corridor.png' });
        }

        function createRoom() {
            return e('img', { src: 'assets/door.png' });
        }
    }

    function generateDungeon(source) {
        const dungeonAsText = source.innerHTML;

        const template = document.createElement('div');
        template.innerHTML = dungeonAsText;
        const level = document.createElement('section');
        const list = [];
        traverse(template, level, 0, list);

        let current;

        return { level, list, travelTo, goBack };

        function goBack() {
            const previousId = current.parentNode.dataset.nodeId;
            travelTo(previousId);
            return previousId;
        }

        function travelTo(nodeId) {
            const previous = current;
            current = list[nodeId];

            return {
                previous,
                current,
                top: [...current.children],
                bottom: current.parentNode == level ? [] : [current.parentNode]
            };
        }
    }

    /**
     * @param {HTMLElement} element 
     * @param {HTMLElement} registry 
     * @param {number} depth
     * @param {Object} list
     */
    function traverse(element, registry, depth, list) {
        const nodeId = Object.keys(list).length;

        const children = [...element.children];
        const node = document.createElement('div');
        node.dataset.depth = depth;
        node.dataset.nodeId = nodeId;
        registry.appendChild(node);
        list[nodeId] = node;

        const type = ['room', 'transit'][children.length] || 'corridor';
        node.dataset.type = type;
        node.setAttribute('class', type);

        children.forEach(c => traverse(c, node, depth + 1, list));
    }
})());