import { DISPLAY_TYPE } from './display-type';

export class EvercraftGameDisplay {
  constructor(displayType) {
    this.displayType = displayType;
  }

  render = (game) => {
    var result = this.displayType === DISPLAY_TYPE.Console ? 'Characters\n' : '<div>';

    result += this.displayType === DISPLAY_TYPE.Web ? '<div data-character>' : '';
    result += this.displayType === DISPLAY_TYPE.Web ? `<div data-name>${game.chars[0].name}</div>` : `${game.chars[0].name}:\n`;
    result += this.displayType === DISPLAY_TYPE.Console ? `\tHit Points: ${game.chars[0].hitPts}\n` : `<div data-hit-points>${game.chars[0].hitPts}</div>`;
    result += this.displayType === DISPLAY_TYPE.Web ? `<div data-armor>${game.chars[0].arm}</div>` : `\tArmor: ${game.chars[0].arm}\n`;
    if (game.chars[0].str) {
      result += this.displayType === DISPLAY_TYPE.Console ? `\tStrength: ${game.chars[0].str}\n` : `<div data-strength>${game.chars[0].str}</div>`;
    } else {
      result += this.displayType === DISPLAY_TYPE.Web ? '<div data-strength>N/A</div>' : '\tStrength: N/A\n';
    }

    if (game.chars[0].dex) {
      result += this.displayType === DISPLAY_TYPE.Console ? `\tDexterity: ${game.chars[0].dex}\n` : `<div data-dexterity>${game.chars[0].dex}</div>`;
    } else {
      result += this.displayType === DISPLAY_TYPE.Web ? '<div data-dexterity>N/A</div>' : '\tDexterity: N/A\n';
    }

    if (game.chars[0].cst) {
      result += this.displayType === DISPLAY_TYPE.Console ? `\tConstitution: ${game.chars[0].cst}\n` : `<div data-constitution>${game.chars[0].cst}</div>`;
    } else {
      result += this.displayType === DISPLAY_TYPE.Web ? '<div data-constitution>N/A</div>' : '\tConstitution: N/A\n';
    }
    result += this.displayType === DISPLAY_TYPE.Web ? '</div>' : '';

    result += this.displayType === DISPLAY_TYPE.Web ? '<div data-character>' : '';
    result += this.displayType === DISPLAY_TYPE.Web ? `<div data-name>${game.chars[1].name}</div>` : `${game.chars[1].name}:\n`;
    result += this.displayType === DISPLAY_TYPE.Console ? `\tHit Points: ${game.chars[1].hitPts}\n` : `<div data-hit-points>${game.chars[1].hitPts}</div>`;
    result += this.displayType === DISPLAY_TYPE.Web ? `<div data-armor>${game.chars[1].arm}</div>` : `\tArmor: ${game.chars[1].arm}\n`;
    if (game.chars[1].str) {
      result += this.displayType === DISPLAY_TYPE.Console ? `\tStrength: ${game.chars[1].str}\n` : `<div data-strength>${game.chars[1].str}</div>`;
    } else {
      result += this.displayType === DISPLAY_TYPE.Web ? '<div data-strength>N/A</div>' : '\tStrength: N/A\n';
    }

    if (game.chars[1].dex) {
      result += this.displayType === DISPLAY_TYPE.Console ? `\tDexterity: ${game.chars[1].dex}\n` : `<div data-dexterity>${game.chars[1].dex}</div>`;
    } else {
      result += this.displayType === DISPLAY_TYPE.Web ? '<div data-dexterity>N/A</div>' : '\tDexterity: N/A\n';
    }

    if (game.chars[1].cst) {
      result += this.displayType === DISPLAY_TYPE.Console ? `\tConstitution: ${game.chars[1].cst}\n` : `<div data-constitution>${game.chars[1].cst}</div>`;
    } else {
      result += this.displayType === DISPLAY_TYPE.Web ? '<div data-constitution>N/A</div>' : '\tConstitution: N/A\n';
    }
    result += this.displayType === DISPLAY_TYPE.Web ? '</div>' : '';

    result += this.displayType === DISPLAY_TYPE.Web ? '</div>' : '';
    return result;
  };
}
