import { Character } from './character';
import { ARMOR_TYPE } from './armor-type';
import fs from 'fs';
import sqlite from 'sqlite';

export class EvercraftGame {
  attacked = [false, false];
  chars = [null, null];

  start = (charOne = 'Jack', charTwo = 'Bob') => {
    this.chars = [
      new Character(charOne, 5, 10),
      new Character(charTwo, 5, 10)
    ];
  };

  attack = (roll, char) => {
    let sM = 0;
    let dM = 0;
    const charIndex = this.chars.indexOf(char);

    if (charIndex !== 0) {
      this.attacked[1] = true;
      if (this.chars[0].str === 1) {
        sM = -5;
      } else if (this.chars[0].str == 2 || this.chars[0].str == 3) {
        sM = -4;
      } else if (this.chars[0].str == 4 || this.chars[0].str == 5) {
        sM = -3;
      } else if (this.chars[0].str == 6 || this.chars[0].str == 7) {
        sM = -2;
      } else if (this.chars[0].str == 8 || this.chars[0].str == 9) {
        sM = -1;
      } else if (this.chars[0].str == 12 || this.chars[0].str == 13) {
        sM = 1;
      } else if (this.chars[0].str == 14 || this.chars[0].str == 15) {
        sM = 2;
      } else if (this.chars[0].str == 16 || this.chars[0].str == 17) {
        sM = 3;
      } else if (this.chars[0].str == 18 || this.chars[0].str == 19) {
        sM = 4;
      } else if (this.chars[0].str == 20) {
        sM = 5;
      }

      if (this.chars[1].dex == 1) {
        dM = -5;
      } else if (this.chars[1].dex == 2 || this.chars[1].dex == 3) {
        dM = -4;
      } else if (this.chars[1].dex == 4 || this.chars[1].dex == 5) {
        dM = -3;
      } else if (this.chars[1].dex == 6 || this.chars[1].dex == 7) {
        dM = -2;
      } else if (this.chars[1].dex == 8 || this.chars[1].dex == 9) {
        dM = -1;
      } else if (this.chars[1].dex == 12 || this.chars[1].dex == 13) {
        dM = 1;
      } else if (this.chars[1].dex == 14 || this.chars[1].dex == 15) {
        dM = 2;
      } else if (this.chars[1].dex == 16 || this.chars[1].dex == 17) {
        dM = 3;
      } else if (this.chars[1].dex == 18 || this.chars[1].dex == 19) {
        dM = 4;
      } else if (this.chars[1].dex == 20) {
        dM = 5;
      }

      if (roll + sM >= this.chars[1].arm + dM) {
        this.chars[1].hitPts = this.chars[1].hitPts - 1;
      }

      if (this.chars[0].str) {
        if (sM > 0 && roll + sM >= this.chars[1].arm) {
          this.chars[1].hitPts = this.chars[1].hitPts - sM;
        } else {
          this.chars[1].hitPts = this.chars[1].hitPts - 1;
        }
      }


      if (roll == 20) {
        this.chars[1].hitPts = this.chars[1].hitPts - 1;
      }
    } else {
      this.attacked[0] = true;
      if (this.chars[1].str == 1) {
        sM = -5;
      } else if (this.chars[1].str == 2 || this.chars[1].str == 3) {
        sM = -4;
      } else if (this.chars[1].str == 4 || this.chars[1].str == 5) {
        sM = -3;
      } else if (this.chars[1].str == 6 || this.chars[1].str == 7) {
        sM = -2;
      } else if (this.chars[1].str == 8 || this.chars[1].str == 9) {
        sM = -1;
      } else if (this.chars[1].str == 12 || this.chars[1].str == 13) {
        sM = 1;
      } else if (this.chars[1].str == 14 || this.chars[1].str == 15) {
        sM = 2;
      } else if (this.chars[1].str == 16 || this.chars[1].str == 17) {
        sM = 3;
      } else if (this.chars[1].str == 18 || this.chars[1].str == 19) {
        sM = 4;
      } else if (this.chars[1].str == 20) {
        sM = 5;
      }

      if (this.chars[0].dex == 1) {
        dM = -5;
      } else if (this.chars[0].dex == 2 || this.chars[0].dex == 3) {
        dM = -4;
      } else if (this.chars[0].dex == 4 || this.chars[0].dex == 5) {
        dM = -3;
      } else if (this.chars[0].dex == 6 || this.chars[0].dex == 7) {
        dM = -2;
      } else if (this.chars[0].dex == 8 || this.chars[0].dex == 9) {
        dM = -1;
      } else if (this.chars[0].dex == 12 || this.chars[0].dex == 13) {
        dM = 1;
      } else if (this.chars[0].dex == 14 || this.chars[0].dex == 15) {
        dM = 2;
      } else if (this.chars[0].dex == 16 || this.chars[0].dex == 17) {
        dM = 3;
      } else if (this.chars[0].dex == 18 || this.chars[0].dex == 19) {
        dM = 4;
      } else if (this.chars[0].dex == 20) {
        dM = 5;
      }

      if (roll + sM >= this.chars[0].arm + dM) {
        this.chars[0].hitPts = this.chars[0].hitPts - 1;
      }

      if (this.chars[1].str) {
        if (sM > 0 && roll + sM >= this.chars[0].arm) {
          this.chars[0].hitPts = this.chars[0].hitPts - sM;
        } else {
          this.chars[0].hitPts = this.chars[0].hitPts - 1;
        }
      }
    }
  };

  isDead = (character) => {
    const charIndex = this.chars.indexOf(character);
    const hitPoints = character.hitPts;
    let hM = 0;
    if (this.chars[charIndex].cst) {
      if (this.chars[charIndex].cst == 1) {
        hM = -5;
      } else if (this.chars[charIndex].cst == 2 || this.chars[charIndex].cst == 3) {
        hM = -4;
      } else if (this.chars[charIndex].cst == 4 || this.chars[charIndex].cst == 5) {
        hM = -3;
      } else if (this.chars[charIndex].cst == 6 || this.chars[charIndex].cst == 7) {
        hM = -2;
      } else if (this.chars[charIndex].cst == 8 || this.chars[charIndex].cst == 9) {
        hM = -1;
      } else if (this.chars[charIndex].cst == 12 || this.chars[charIndex].cst == 13) {
        hM = 1;
      } else if (this.chars[charIndex].cst == 14 || this.chars[charIndex].cst == 15) {
        hM = 2;
      } else if (this.chars[charIndex].cst == 16 || this.chars[charIndex].cst == 17) {
        hM = 3;
      } else if (this.chars[charIndex].cst == 18 || this.chars[charIndex].cst == 19) {
        hM = 4;
      } else if (this.chars[charIndex].cst == 20) {
        hM = 5;
      }
    }
    return hitPoints + hM <= 0 && this.attacked[charIndex];
  };

  equipArmor = (armorType, weight, character) => {
    switch (armorType) {
      case ARMOR_TYPE.Bronze:
        character.arm = character.arm - 1;
        break;
      case ARMOR_TYPE.Steel:
        character.arm = character.arm + 1;
        break;
    }

    if (weight > 50) {
      character.arm = character.arm + 2;
    }
  };

  applyStrength = (strength, character) => {
    var charIndex = this.chars.indexOf(character);
    this.chars[charIndex].str = strength;
  };

  applyDexterity = (dexterity, character) => {
    var charIndex = this.chars.indexOf(character);
    this.chars[charIndex].dex = dexterity;
  };

  applyConstitution = (constitution, character) => {
    var charIndex = this.chars.indexOf(character);
    this.chars[charIndex].cst = constitution;
  };

  load = (filePath) => {
    if (filePath.endsWith('.json')) {
      return new Promise((resolve, reject) => {
        fs.readFile(filePath, { encoding: 'utf8' }, (err, contents) => {
          const json = JSON.parse(contents);
          const characters = json.characters;
          for (let i = 0; i < characters.length; i++) {
            this.chars[i] = new Character(characters[i].name, 5, characters[i].arm, characters[i].str, characters[i].dex, characters[i].const);
          }
          resolve();
        });
      });
    } else if (filePath.endsWith('.db')) {
      return new Promise(async (resolve, reject) => {
        const db = await sqlite.open(filePath, { Promise });
        const rows = await db.all('select Name, Armor, Str, Dex, Const from [Characters]');
        for (let i = 0; i < rows.length; i++) {
          this.chars[i] = new Character(rows[i].Name, 5, rows[i].Armor, rows[i].Str, rows[i].Dex, rows[i].Const);
        }
        await db.close();
        resolve();
      });
    } else {
      return new Promise((resolve, reject) => {
        fs.readFile(filePath, { encoding: 'utf8' }, (err, contents) => {
          const lines = contents.split('\n');
          for (let i = 1; i < lines.length; i++) {
            const values = lines[i].split(',');
            this.chars[i - 1] = new Character(values[0], 5, parseInt(values[1]), parseInt(values[2]), parseInt(values[3]), parseInt(values[4]));
          }
          resolve();
        });
      });
    }
  };
}
