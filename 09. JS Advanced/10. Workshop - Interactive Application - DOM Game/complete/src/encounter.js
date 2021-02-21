/* globals e, game */

Object.assign(game, (function () {

    const items = {
        vial: {
            name: 'Crystal Vial',
            level: 1,
            effects: { hp: 10 },
            instant: true
        },
        rune: {
            name: 'Runic Gem',
            level: 1,
            effects: { mp: 10 },
            instant: true
        },
        flask: {
            name: 'Quartz Flask',
            level: 2,
            effects: { hp: 25 }
        },
        krater: {
            name: 'Krater of Might',
            level: 4,
            effects: { mp: 100 }
        },
        tome: {
            name: 'Tome of Power',
            level: 4,
            effects: { dmg: 100 }
        },
    };


    return {
        generateEncounter,
        encounterController
    };

    function generateEncounter(level) {
        let enemies = Object.entries(game.characters).filter(([k, v]) => v.ai && v.level <= level && v.level >= Math.floor(level / 3));
        const selected = [];
        let encounterLevel = 0;

        while (encounterLevel < level && enemies.length > 0) {
            const index = Math.floor(Math.random() * enemies.length);
            selected.push(enemies[index][0]);
            encounterLevel += enemies[index][1].level;
            enemies = enemies.filter(([k, v]) => v.level <= level - encounterLevel);
        }

        let validItems = Object.entries(items).filter(([k, v]) => v.level <= level && v.level >= Math.floor(level / 3));
        const loot = [];
        let lootLevel = 0;

        while (lootLevel < level && validItems.length > 0) {
            const index = Math.floor(Math.random() * validItems.length);
            loot.push(validItems[index][1]);
            lootLevel += validItems[index][1].level;
            validItems = validItems.filter(([k, v]) => v.level <= level - lootLevel);
        }

        return {
            enemies: selected.map(game.createCharacter),
            victory: selected.length == 0,
            loot
        };
    }

    function encounterController(enemySlots) {
        let enabled = false;
        let characters;
        let activeEncounter;
        let actionType;

        enemySlots.addEventListener('click', onClick);

        return {
            enter,
            enableTargetting,
            disableTargetting,
            selectTarget: (...params) => activeEncounter.selectTarget(...params)
        };

        function enableTargetting(source, type) {
            enabled = true;
            actionType = type;
            characters.filter(c => c != source && c.character.alive).forEach(c => c.element.classList.add('targettable'));
        }

        function disableTargetting() {
            enabled = false;
            actionType = null;
            characters.forEach(c => c.element.classList.remove('targettable'));
        }

        function onClick({ target }) {
            while (target && (!target.classList || target.classList.contains('targettable') == false)) {
                target = target.parentNode;
            }
            if (enabled && target) {
                activeEncounter.selectTarget(target, actionType);
            }
        }

        function enter(player, encounter) {
            characters = [player, ...encounter.enemies];
            const xpReward = encounter.enemies.map(e => e.character.hp).reduce((t, c) => t + c, 0);

            enemySlots.innerHTML = '';
            [...encounter.enemies].map(e => enemySlots.appendChild(e.element));

            let initiative = -1;
            nextTurn();

            activeEncounter = {
                selectTarget
            };

            function selectTarget(target, actionName = 'attack') {
                while (target && (!target.classList || target.classList.contains('targettable') == false)) {
                    target = target.parentNode;
                }
                if (target && target.classList.contains('targettable')) {
                    const selected = characters.find(c => c.element == target);
                    const { dmgResult, hp } = characters[initiative][actionName](selected);
                    game.events.onAction(`Player attacks enemy ${selected.character.name} for ${dmgResult} damage.`);
                    if (hp == 0) {
                        game.events.onAction(`${selected.character.name} killed.`);
                    }
                    disableTargetting();
                    nextTurn();
                } else {
                    disableTargetting();
                }
            }

            function nextTurn() {
                if (player.character.alive == false) {
                    return game.events.onEndEncounter(false);
                } else if (characters.filter(c => c.character.alive).length == 1) {
                    encounter.victory = true;
                    return game.events.onEndEncounter(true, xpReward, encounter);
                }

                do {
                    initiative = (initiative + 1) % characters.length;
                } while (characters[initiative].character.alive == false);

                characters.forEach(c => c.element.classList.remove('active'));
                const activeCharacter = characters[initiative];
                activeCharacter.element.classList.add('active');

                game.events.onBeginTurn(activeCharacter);
            }
        }
    }
})());


/*
const items = {
    vial: {
        name: 'Crystal Vial',
        level: 1,
        effects: { hp: 10 },
        instant: true
    },
    rune: {
        name: 'Runic Gem',
        level: 1,
        effects: { mp: 10 },
        instant: true
    },
    flask: {
        name: 'Quartz Flask',
        level: 2,
        effects: { hp: 25 }
    },
    krater: {
        name: 'Krater of Might',
        level: 4,
        effects: { mp: 100 }
    },
    tome: {
        name: 'Tome of Power',
        level: 4,
        effects: { dmg: 100 }
    },
};


export function generateEncounter(level) {
    let enemies = Object.entries(characters).filter(([k, v]) => v.ai && v.level <= level && v.level >= Math.floor(level / 3));
    const selected = [];
    let encounterLevel = 0;

    while (encounterLevel < level && enemies.length > 0) {
        const index = Math.floor(Math.random() * enemies.length);
        selected.push(enemies[index][0]);
        encounterLevel += enemies[index][1].level;
        enemies = enemies.filter(([k, v]) => v.level <= level - encounterLevel);
    }

    let validItems = Object.entries(items).filter(([k, v]) => v.level <= level && v.level >= Math.floor(level / 3));
    const loot = [];
    let lootLevel = 0;

    while (lootLevel < level && validItems.length > 0) {
        const index = Math.floor(Math.random() * validItems.length);
        loot.push(validItems[index][1]);
        lootLevel += validItems[index][1].level;
        validItems = validItems.filter(([k, v]) => v.level <= level - lootLevel);
    }

    return {
        enemies: selected.map(createCharacter),
        victory: selected.length == 0,
        loot
    };
}

export function createEncounterController(player, encounter) {
    const characters = [player, ...encounter.enemies];
    const xpReward = encounter.enemies.map(e => e.character.hp).reduce((t, c) => t + c, 0);

    let initiative = -1;
    nextTurn();

    return {
        beginAttack,
        selectTarget
    };

    function beginAttack() {
        enableTargetting(characters[initiative]);
    }

    function enableTargetting(source) {
        characters.filter(c => c != source && c.character.alive).forEach(c => c.element.classList.add('targettable'));
    }

    function disableTargetting() {
        characters.forEach(c => c.element.classList.remove('targettable'));
    }

    function selectTarget(ev, actionName = 'attack') {
        let target = ev.target;
        while (target && (!target.classList || target.classList.contains('targettable') == false)) {
            target = target.parentNode;
        }
        if (target && target.classList.contains('targettable')) {
            const selected = characters.find(c => c.element == target);
            const { dmgResult, hp } = characters[initiative][actionName](selected);
            game.events.onAction(`Player attacks enemy ${selected.character.name} for ${dmgResult} damage.`);
            if (hp == 0) {
                game.events.onAction(`${selected.character.name} killed.`);
            }
            nextTurn();
        }
        disableTargetting();
    }

    function nextTurn() {
        if (player.character.alive == false) {
            return game.events.onEndEncounter(false);
        } else if (characters.filter(c => c.character.alive).length == 1) {
            encounter.victory = true;
            return game.events.onEndEncounter(true, xpReward, encounter);
        }

        do {
            initiative = (initiative + 1) % characters.length;
        } while (characters[initiative].character.alive == false);

        characters.forEach(c => c.element.classList.remove('active'));
        const activeCharacter = characters[initiative];
        activeCharacter.element.classList.add('active');

        game.events.onBeginTurn(activeCharacter);
    }
}
*/