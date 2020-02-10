import { EvercraftGame } from './evercraft-game';
import { ARMOR_TYPE } from './armor-type';
import fs from 'fs';
import path from 'path';
import sqlite from 'sqlite';

const FILE_PATH = path.resolve(__dirname, 'characters.csv');
const OTHER_FILE_PATH = path.resolve(__dirname, 'characters.json');
const OTHER_OTHER_FILE_PATH = path.resolve(__dirname, 'characters.db');

describe('EvercraftGame', () => {
  beforeEach(() => {
    if (fs.existsSync(FILE_PATH)) {
      fs.unlinkSync(FILE_PATH);
    }

    if (fs.existsSync(OTHER_FILE_PATH)) {
      fs.unlinkSync(OTHER_FILE_PATH);
    }

    if (fs.existsSync(OTHER_OTHER_FILE_PATH)) {
      fs.unlinkSync(OTHER_OTHER_FILE_PATH);
    }
  });

  describe('start', () => {
    it('should have default characters', () => {
      const game = new EvercraftGame();

      game.start('Someone', 'Other');

      expect(game.chars[0].name).toEqual('Someone');
      expect(game.chars[0].hitPts).toEqual(5);
      expect(game.chars[0].arm).toEqual(10);
      expect(game.chars[0].str).toEqual(null);
      expect(game.chars[0].dex).toEqual(null);
      expect(game.chars[0].cst).toEqual(null);

      expect(game.chars[1].name).toEqual('Other');
      expect(game.chars[1].hitPts).toEqual(5);
      expect(game.chars[1].arm).toEqual(10);
      expect(game.chars[1].str).toEqual(null);
      expect(game.chars[1].dex).toEqual(null);
      expect(game.chars[1].cst).toEqual(null);
    });
  });

  describe('attack', () => {
    it('should deal damage to character when roll is greater than target\'s armor', () => {
      const game = new EvercraftGame();
      game.start();

      game.attack(11, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4);
    });

    it('should deal damage to the first character when roll is greater than their armor', () => {
      const game = new EvercraftGame();
      game.start();

      game.attack(11, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(4);
    });

    it('should deal damage to character when roll is equal to target\'s armor', () => {
      const game = new EvercraftGame();
      game.start();

      game.attack(10, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4);
    });

    it('should deal no damage to character when roll is less than target\'s armor', () => {
      const game = new EvercraftGame();
      game.start();

      game.attack(9, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(5);
    });

    it('should deal double damage to character when roll is a critical hit', () => {
      const game = new EvercraftGame();
      game.start();

      game.attack(20, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(3);
    });

    it('should kill character when character has one hit point left', () => {
      const game = new EvercraftGame();
      game.start();
      game.attack(11, game.chars[1]);
      game.attack(11, game.chars[1]);
      game.attack(11, game.chars[1]);
      game.attack(11, game.chars[1]);

      game.attack(11, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(0);
      expect(game.isDead(game.chars[1])).toEqual(true);
    });
  });

  describe('equipArmor', () => {
    it('should increase armor by one when steel is armor equipped', () => {
      const game = new EvercraftGame();
      game.start();

      game.equipArmor(ARMOR_TYPE.Steel, 50, game.chars[1]);

      expect(game.chars[1].arm).toEqual(11);
    });

    it('should decrease armor by one when bronze armor is equipped', () => {
      const game = new EvercraftGame();
      game.start();

      game.equipArmor(ARMOR_TYPE.Bronze, 50, game.chars[1]);

      expect(game.chars[1].arm).toEqual(9);
    });

    it('should not change armor when iron armor is equipped', () => {
      const game = new EvercraftGame();
      game.start();

      game.equipArmor(ARMOR_TYPE.Iron, 50, game.chars[1]);

      expect(game.chars[1].arm).toEqual(10);
    });

    it('should increase armor by two when heavy armor is equiped', () => {
      const game = new EvercraftGame();
      game.start();

      game.equipArmor(ARMOR_TYPE.Iron, 51, game.chars[1]);

      expect(game.chars[1].arm).toEqual(12);
    });
  });

  describe('applyStrength', () => {
    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('target will take one damage when roll is modified to be less than target\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[0]);
      game.attack(9 - modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4);
    });

    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('target will take two damage when roll is modified to be greater than target\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[0]);
      game.attack(10 - modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(3);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('target will take the damage of the modifier when roll is modified to be greater than the target\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[0]);
      game.attack(10 - modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4 - modifier);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('target will take one damage when roll is modified to be less than the target\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[0]);
      game.attack(9 - modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4);
    });

    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('first character will take one damage when roll is modified to be less than first character\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[1]);
      game.attack(9 - modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(4);
    });

    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('first character will take two damage when roll is modified to be greater than first character\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[1]);
      game.attack(10 - modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(3);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('first character will take the damage of the modifier when roll is modified to be greater than the first character\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[1]);
      game.attack(10 - modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(4 - modifier);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('first character will take one damage when roll is modified to be less than the first character\'s armor', (strength, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyStrength(strength, game.chars[1]);
      game.attack(9 - modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(4);
    });
  });

  describe('applyDexterity', () => {
    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('target will take damage when target\'s armor is modified to be less than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[1]);
      game.attack(10 + modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4);
    });

    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('target will not take damage when target\'s armor is modified to be greater than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[1]);
      game.attack(9 + modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(5);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('target will take one damage when target\'s armor is modified to be less than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[1]);
      game.attack(10 + modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(4);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('target will not take damage when target\'s armor is modified to be greater than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[1]);
      game.attack(9 + modifier, game.chars[1]);

      expect(game.chars[1].hitPts).toEqual(5);
    });

    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('first character will take damage when first character\'s armor is modified to be less than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[0]);
      game.attack(10 + modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(4);
    });

    test.each([
      [1, -5],
      [2, -4],
      [3, -4],
      [4, -3],
      [5, -3],
      [6, -2],
      [7, -2],
      [8, -1],
      [9, -1]
    ])('first character will not take damage when first character\'s armor is modified to be greater than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[0]);
      game.attack(9 + modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(5);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('first character will take one damage when first character\'s armor is modified to be less than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[0]);
      game.attack(10 + modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(4);
    });

    test.each([
      [12, 1],
      [13, 1],
      [14, 2],
      [15, 2],
      [16, 3],
      [17, 3],
      [18, 4],
      [19, 4],
      [20, 5],
    ])('first character will not take damage when first character\'s armor is modified to be greater than the roll', (dexterity, modifier) => {
      const game = new EvercraftGame();
      game.start();

      game.applyDexterity(dexterity, game.chars[0]);
      game.attack(9 + modifier, game.chars[0]);

      expect(game.chars[0].hitPts).toEqual(5);
    });
  });

  describe('applyConstitution', () => {
    it('should not mark second character as dead when constitution modifier is applied to character', () => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(1, game.chars[1]);

      expect(game.isDead(game.chars[1])).toEqual(false);
    });

    it('should not mark first character as dead when constitution modifier is applied to character', () => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(1, game.chars[0]);

      expect(game.isDead(game.chars[0])).toEqual(false);
    });

    it('should kill character once a successful attacks lands on character with -5 constitution modifier', () => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(1, game.chars[1]);
      game.attack(10, game.chars[1]);

      expect(game.isDead(game.chars[1])).toEqual(true);
    });

    test.each([
      [1, 1],
      [2, 1],
      [3, 1],
      [4, 2],
      [5, 2],
      [6, 3],
      [7, 3],
      [8, 4],
      [9, 4],
    ])('character should die after attacks when a negative constitution modifier is applied', (constitution, attacks) => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(constitution, game.chars[0]);
      for (let i = 0; i < attacks; i++) {
        game.attack(10, game.chars[0]);
      }

      expect(game.isDead(game.chars[0])).toEqual(true);
    });

    test.each([
      [4, 1],
      [5, 1],
      [6, 2],
      [7, 2],
      [8, 3],
      [9, 3],
    ])('character should not die after attacks when negative modifier is applied', (constitution, attacks) => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(constitution, game.chars[0]);
      for (let i = 0; i < attacks; i++) {
        game.attack(10, game.chars[0]);
      }

      expect(game.isDead(game.chars[0])).toEqual(false);
    });

    test.each([
      [12, 6],
      [13, 6],
      [14, 7],
      [15, 7],
      [16, 8],
      [17, 8],
      [18, 9],
      [19, 9],
      [20, 10],
    ])('character should die after attacks when positive constitution modifer is applied', (constitution, attacks) => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(constitution, game.chars[0]);
      for (let i = 0; i < attacks; i++) {
        game.attack(10, game.chars[0]);
      }

      expect(game.isDead(game.chars[0])).toEqual(true);
    });

    test.each([
      [12, 5],
      [13, 5],
      [14, 6],
      [15, 6],
      [16, 7],
      [17, 7],
      [18, 8],
      [19, 8],
      [20, 9],
    ])('character should not die after attacks when positive constitution modifer is applied', (constitution, attacks) => {
      const game = new EvercraftGame();
      game.start();

      game.applyConstitution(constitution, game.chars[0]);
      for (let i = 0; i < attacks; i++) {
        game.attack(10, game.chars[0]);
      }

      expect(game.isDead(game.chars[0])).toEqual(false);
    });
  });

  describe('load', () => {
    it('should load characters from csv file', async () => {
      fs.writeFileSync(FILE_PATH, 'Character,Armor,Strength,Dexterity,Constitution\n' +
        'Jack,12,13,14,15\n' +
        'Bob,13,14,15,16\n');

      const game = new EvercraftGame();
      await game.load(FILE_PATH);

      expect(game.chars[0].name).toEqual('Jack');
      expect(game.chars[0].arm).toEqual(12);
      expect(game.chars[0].str).toEqual(13);
      expect(game.chars[0].dex).toEqual(14);
      expect(game.chars[0].cst).toEqual(15);

      expect(game.chars[1].name).toEqual('Bob');
      expect(game.chars[1].arm).toEqual(13);
      expect(game.chars[1].str).toEqual(14);
      expect(game.chars[1].dex).toEqual(15);
      expect(game.chars[1].cst).toEqual(16);
    });

    it('should load characters from json file', async () => {
      fs.writeFileSync(OTHER_FILE_PATH, '{' +
        '"characters": [' +
        '{ "name": "bob", "arm": 13, "str": 14, "dex": 15, "const": 16 },' +
        '{ "name": "jack", "arm": 2, "str": 3, "dex": 4, "const": 5 }' +
        ']' +
        '}', { encoding: 'utf8' });

      const game = new EvercraftGame();
      await game.load(OTHER_FILE_PATH);

      expect(game.chars[0].name).toEqual('bob');
      expect(game.chars[0].arm).toEqual(13);
      expect(game.chars[0].str).toEqual(14);
      expect(game.chars[0].dex).toEqual(15);
      expect(game.chars[0].cst).toEqual(16);

      expect(game.chars[1].name).toEqual('jack');
      expect(game.chars[1].arm).toEqual(2);
      expect(game.chars[1].str).toEqual(3);
      expect(game.chars[1].dex).toEqual(4);
      expect(game.chars[1].cst).toEqual(5);
    });

    it('should load characters from sqlite', async () => {

      const db = await sqlite.open(OTHER_OTHER_FILE_PATH, { Promise });
      await db.run('create table [Characters] (Id integer primary key asc, Name Text, Armor integer, Str integer, Dex integer, Const integer);');
      await db.run('insert into [Characters] (Name, Armor, Str, Dex, Const) values (\'John\', 9, 8, 7, 6);');
      await db.run('insert into [Characters] (Name, Armor, Str, Dex, Const) values (\'Jim\', 20, 20, 20, 20);');
      await db.close();

      const game = new EvercraftGame();
      await game.load(OTHER_OTHER_FILE_PATH);

      expect(game.chars[0].name).toEqual('John');
      expect(game.chars[0].arm).toEqual(9);
      expect(game.chars[0].str).toEqual(8);
      expect(game.chars[0].dex).toEqual(7);
      expect(game.chars[0].cst).toEqual(6);

      expect(game.chars[1].name).toEqual('Jim');
      expect(game.chars[1].arm).toEqual(20);
      expect(game.chars[1].str).toEqual(20);
      expect(game.chars[1].dex).toEqual(20);
      expect(game.chars[1].cst).toEqual(20);
    });
  });
});
