/* globals e, game */


Object.assign(game, (function () {
    const characters = {
        player: {
            name: 'Player',
            level: 1,
            xp: 0,
            img: 'player.png',
            alive: true,
            maxHp: 100,
            maxMp: 200,
            baseDmg: 25,
            items: {},
            inventory: []
        },
        rat: {
            name: 'Giant Rat',
            level: 1,
            ai: true,
            img: 'rat.png',
            alive: true,
            maxHp: 30,
            baseDmg: 10,
        },
        skeleton: {
            name: 'Skeleton',
            level: 2,
            ai: true,
            img: 'skeleton.png',
            alive: true,
            maxHp: 50,
            baseDmg: 15,
        },
        goblin: {
            name: 'Goblin',
            level: 4,
            ai: true,
            img: 'goblin.png',
            alive: true,
            maxHp: 100,
            baseDmg: 20,
        },
        guard: {
            name: 'Guard',
            level: 10,
            ai: true,
            img: 'guard.png',
            alive: true,
            maxHp: 500,
            baseDmg: 50,
        },
        dragon: {
            name: 'Dragon',
            level: 25,
            ai: true,
            img: 'dragon.png',
            alive: true,
            maxHp: 2500,
            baseDmg: 100,
        }
    };

    return {
        characters,
        createCharacter
    };

    function createCharacter(type, customStats = {}) {
        const character = Object.assign({}, characters[type], customStats);
        character.hp = character.maxHp;
        character.mp = character.maxMp;

        const element = characterCard(character);

        const result = {
            character,
            element,
            update,
            attack(target) {
                let dmg = character.baseDmg + getItemsStat(character.items, 'dmg');
                return target.takeDamage(dmg);
            },
            castSpell(target) {
                let dmg = 50;
                character.mp -= 50;
                update();

                return target.takeDamage(dmg, true);
            },
            takeDamage(dmg, ignoreArmor) {
                let armor = ignoreArmor ? 0 : getItemsStat(character.items, 'armor');
                const dmgResult = Math.max(1, dmg - armor);
                character.hp = Math.max(0, character.hp - dmgResult);

                update();

                return { dmgResult, hp: character.hp };
            },
            useItem,
            collectItem
        };

        return result;

        function useItem(item) {
            const itemIndex = character.inventory.indexOf(item);
            if (itemIndex > -1) {
                character.inventory.splice(itemIndex, 1);
            }
            Object.entries(item.effects).forEach(([stat, value]) => {
                const max = character['max' + stat[0].toUpperCase() + stat.substring(1)];
                character[stat] += value;
                if (max != undefined) {
                    character[stat] = Math.min(character[stat], max);
                }
            });
        }

        function collectItem(item) {
            if (item.instant) {
                result.useItem(item);
            } else {
                character.inventory.push(item);
            }
        }

        function update() {
            if (character.hp == 0) {
                character.alive = false;
            }
            element.update();
        }
    }

    function characterCard(character) {
        const status = {
            img: e('img', { src: 'assets/' + character.img }),
            level: e('span', null, ''),
            xp: e('span', null, ''),
            hp: e('span', null, ''),
            mp: e('span', null, ''),
            dmg: e('span', null, ''),
            armor: e('span', null, '')
        };

        const result = e('article', { className: 'character-card' },
            e('div', { className: 'portrait' }, status.img),
            e('div', { className: 'description' },
                e('h3', null, character.name),
                e('ul', { className: 'stats' },
                    e('li', null, 'Level: ', status.level),
                    e('li', null, 'XP: ', status.xp),
                    e('li', null, 'HP: ', status.hp),
                    e('li', null, 'MP: ', status.mp),
                    e('li', null, 'Damage: ', status.dmg),
                    e('li', null, 'Armor: ', status.armor),
                ),
            )
        );

        result.update = update;
        update();

        return result;

        function update() {
            const bonusDmg = getItemsStat(character.items, 'dmg');
            const armor = getItemsStat(character.items, 'armor');

            status.level.textContent = character.level;
            status.xp.textContent = character.xp;
            status.hp.textContent = `${character.hp} / ${character.maxHp}`;
            status.mp.textContent = `${character.mp || 0} / ${character.maxMp || 0}`;
            status.dmg.textContent = `${character.baseDmg}${bonusDmg ? ` + ${bonusDmg}` : ''}`;
            status.armor.textContent = armor;

            if (character.alive == false) {
                result.classList.add('wasted');
            }
        }
    }

    function getItemsStat(items = {}, statName) {
        return Object.values(items || {}).reduce((r, i) => r + (i[statName] || 0), 0);
    }
})());


/*
export const characters = {
    player: {
        name: 'Player',
        level: 1,
        xp: 0,
        img: 'player.png',
        alive: true,
        maxHp: 100,
        maxMp: 200,
        baseDmg: 5,
        items: {},
        inventory: []
    },
    rat: {
        name: 'Giant Rat',
        level: 1,
        ai: true,
        img: 'rat.png',
        alive: true,
        maxHp: 30,
        baseDmg: 10,
    },
    skeleton: {
        name: 'Skeleton',
        level: 2,
        ai: true,
        img: 'skeleton.png',
        alive: true,
        maxHp: 50,
        baseDmg: 15,
    },
    goblin: {
        name: 'Goblin',
        level: 4,
        ai: true,
        img: 'goblin.png',
        alive: true,
        maxHp: 100,
        baseDmg: 20,
    },
    guard: {
        name: 'Guard',
        level: 10,
        ai: true,
        img: 'guard.png',
        alive: true,
        maxHp: 500,
        baseDmg: 50,
    },
    dragon: {
        name: 'Dragon',
        level: 25,
        ai: true,
        img: 'dragon.png',
        alive: true,
        maxHp: 2500,
        baseDmg: 100,
    }
};

export function createCharacter(type, customStats = {}) {
    const character = Object.assign({}, characters[type], customStats);
    character.hp = character.maxHp;
    character.mp = character.maxMp;

    const element = characterCard(character);

    const result = {
        character,
        element,
        update,
        attack(target) {
            let dmg = character.baseDmg + getItemsStat(character.items, 'dmg');
            return target.takeDamage(dmg);
        },
        castSpell(target) {
            let dmg = 50;
            character.mp -= 50;
            update();

            return target.takeDamage(dmg, true);
        },
        takeDamage(dmg, ignoreArmor) {
            let armor = ignoreArmor ? 0 : getItemsStat(character.items, 'armor');
            const dmgResult = Math.max(1, dmg - armor);
            character.hp = Math.max(0, character.hp - dmgResult);

            update();

            return { dmgResult, hp: character.hp };
        },
        useItem,
        collectItem
    };

    return result;

    function useItem(item) {
        const itemIndex = character.inventory.indexOf(item);
        if (itemIndex > -1) {
            character.inventory.splice(itemIndex, 1);
        }
        Object.entries(item.effects).forEach(([stat, value]) => {
            const max = character['max' + stat[0].toUpperCase() + stat.substring(1)];
            character[stat] += value;
            if (max != undefined) {
                character[stat] = Math.min(character[stat], max);
            }
        });
    }

    function collectItem(item) {
        if (item.instant) {
            result.useItem(item);
        } else {
            character.inventory.push(item);
        }
    }

    function update() {
        if (character.hp == 0) {
            character.alive = false;
        }
        element.update();
    }
}

function characterCard(character) {
    const status = {
        img: e('img', { src: 'assets/' + character.img }),
        level: e('span', null, ''),
        xp: e('span', null, ''),
        hp: e('span', null, ''),
        mp: e('span', null, ''),
        dmg: e('span', null, ''),
        armor: e('span', null, '')
    };

    const result = e('article', { className: 'character-card' },
        e('div', { className: 'portrait' }, status.img),
        e('div', { className: 'description' },
            e('h3', null, character.name),
            e('ul', { className: 'stats' },
                e('li', null, 'Level: ', status.level),
                e('li', null, 'XP: ', status.xp),
                e('li', null, 'HP: ', status.hp),
                e('li', null, 'MP: ', status.mp),
                e('li', null, 'Damage: ', status.dmg),
                e('li', null, 'Armor: ', status.armor),
            ),
        )
    );

    result.update = update;
    update();

    return result;

    function update() {
        const bonusDmg = getItemsStat(character.items, 'dmg');
        const armor = getItemsStat(character.items, 'armor');

        status.level.textContent = character.level;
        status.xp.textContent = character.xp;
        status.hp.textContent = `${character.hp} / ${character.maxHp}`;
        status.mp.textContent = `${character.mp || 0} / ${character.maxMp || 0}`;
        status.dmg.textContent = `${character.baseDmg}${bonusDmg ? ` + ${bonusDmg}` : ''}`;
        status.armor.textContent = armor;

        if (character.alive == false) {
            result.classList.add('wasted');
        }
    }
}

function getItemsStat(items = {}, statName) {
    return Object.values(items || {}).reduce((r, i) => r + (i[statName] || 0), 0);
}
*/