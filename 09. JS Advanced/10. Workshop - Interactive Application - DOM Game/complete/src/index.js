/* globals e, game */


function start() {
    const map = document.getElementById('map');
    const arena = document.getElementById('arena');
    const log = document.getElementById('log');
    log.value = '';

    document.getElementById('toggleMap').addEventListener('click', () => {
        if (map.style.display == 'none') {
            map.style.display = 'inline-block';
            arena.style.display = 'none';
        } else {
            map.style.display = 'none';
            arena.style.display = 'inline-block';
        }
    });

    const { list: roomList, mapController, travelTo, goBack } = initMap(map);
    const { player, enable: enableControls, disable: disableControls } = initPlayer();
    const { encounters, encounterController } = initArena(roomList);

    game.events.onTravel.subscribe(onTravel);
    game.events.onEncounter.subscribe(onEncounter);
    game.events.onBeginTurn.subscribe(onBeginTurn);
    game.events.onPlayerTargetting.subscribe(onPlayerTargetting);
    game.events.onEndEncounter.subscribe(onEndEncounter);
    game.events.onAction.subscribe(onAction);
    game.events.onRun.subscribe(onRun);

    function onTravel(nodeId) {
        const { previous, current, top, bottom } = travelTo(nodeId);
        mapController.displayOptions(top, bottom);
        mapController.activateNode(previous, current);
        game.events.onEncounter(nodeId);
    }

    function onEncounter(roomId) {
        if (encounters[roomId].victory == false) {
            mapController.disable();
        }
        encounterController.enter(player, encounters[roomId]);
    }

    function onBeginTurn(controller) {
        if (controller.character.ai) {
            disableControls();
            setTimeout(() => {
                encounterController.enableTargetting(controller, 'attack');
                encounterController.selectTarget(player.element, 'attack');
            }, 500);
        } else {
            enableControls();
        }
    }

    function onPlayerTargetting(type) {
        encounterController.enableTargetting(player, type);
    }

    function onEndEncounter(victory, xpReward, encounter) {
        disableControls();
        if (victory == false) {
            alert('You Died');
        } else {
            player.character.xp += xpReward;

            encounter.loot.forEach(i => {
                onAction(`Collected ${i.name}.`);
                player.collectItem(i);
            });
            encounter.loot.length = 0;

            player.update();
            if (Object.values(encounters).every(e => e.victory)) {
                alert('Dungeon Conquered');
            } else {
                mapController.enable();
            }
        }
    }

    function onRun() {
        onAction('Running away');
        const nodeId = goBack();
        onTravel(nodeId);
    }

    function onAction(message) {
        log.value += message;
        log.value += '\n';
        log.scrollTop = 9999;
    }
}

function initMap(map) {
    const topControls = document.getElementById('top-controls');
    const bottomControls = document.getElementById('bottom-controls');

    const { level, list, travelTo, goBack } = game.generateDungeon(document.getElementById('dungeon'));
    map.appendChild(level);

    const mapController = game.dungeonController(topControls, bottomControls);
    const initialTravelOptions = travelTo(level.firstChild.dataset.nodeId);
    mapController.displayOptions(initialTravelOptions.top, initialTravelOptions.bottom);
    mapController.activateNode(null, initialTravelOptions.current);
    mapController.enable();

    return { list, mapController, travelTo, goBack };
}

function initPlayer() {
    const playerSlot = document.getElementById('player');

    const input = {
        attack: e('button', {
            onClick: (ev) => game.events.onPlayerTargetting('attack')
        }, 'Attack'),
        spell: e('button', {
            onClick: (ev) => game.events.onPlayerTargetting('castSpell')
        }, 'Magic Missile'),
        run: e('button', {
            onClick: (ev) => game.events.onRun()
        }, 'Run'),
    };
    Object.values(input).forEach(i => i.disabled = true);
    const controls = e('div', { id: 'controls' },
        input.attack,
        input.spell,
        input.run
    );

    const player = game.createCharacter('player', { maxHp: 100 });
    playerSlot.appendChild(player.element);
    playerSlot.appendChild(controls);

    return { player, enable, disable };

    function enable() {
        input.attack.disabled = false;
        input.spell.disabled = player.character.mp < 50;
        input.run.disabled = false;
    }

    function disable() {
        Object.values(input).forEach(i => i.disabled = true);
    }
}

function initArena(roomList) {
    const enemySlots = document.getElementById('enemies');

    const encounters = {};
    for (let roomId in roomList) {
        const room = roomList[roomId];
        if (room.dataset.type != 'corridor') {
            encounters[roomId] = game.generateEncounter(room.dataset.depth);
        } else {
            encounters[roomId] = {
                enemies: [],
                victory: true,
                loot: []
            };
        }
    }

    const encounterController = game.encounterController(enemySlots);

    return { encounters, encounterController };
}


start();