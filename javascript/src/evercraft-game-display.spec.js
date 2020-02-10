import { EvercraftGame } from './evercraft-game';
import { EvercraftGameDisplay } from './evercraft-game-display';
import { DISPLAY_TYPE } from './display-type';

describe('EvercraftGameDisplay', () => {
  it('should render console game as console output', () => {
    const game = new EvercraftGame();
    game.start('Thing 1', 'Thing 2');

    const display = new EvercraftGameDisplay(DISPLAY_TYPE.Console);
    const content = display.render(game);

    expect(content).toEqual('Characters\n' +
      'Thing 1:\n' +
      '\tHit Points: 5\n' +
      '\tArmor: 10\n' +
      '\tStrength: N/A\n' +
      '\tDexterity: N/A\n' +
      '\tConstitution: N/A\n' +
      'Thing 2:\n' +
      '\tHit Points: 5\n' +
      '\tArmor: 10\n' +
      '\tStrength: N/A\n' +
      '\tDexterity: N/A\n' +
      '\tConstitution: N/A\n');
  });

  it('should render character attributes as console output when characters have attributes', () => {
    const game = new EvercraftGame();
    game.start('Thing 1', 'Thing 2');
    game.applyStrength(1, game.chars[0]);
    game.applyStrength(2, game.chars[1]);
    game.applyDexterity(3, game.chars[0]);
    game.applyDexterity(4, game.chars[1]);
    game.applyConstitution(5, game.chars[0]);
    game.applyConstitution(6, game.chars[1]);

    const display = new EvercraftGameDisplay(DISPLAY_TYPE.Console);
    const content = display.render(game);

    expect(content).toEqual('Characters\n' +
      'Thing 1:\n' +
      '\tHit Points: 5\n' +
      '\tArmor: 10\n' +
      '\tStrength: 1\n' +
      '\tDexterity: 3\n' +
      '\tConstitution: 5\n' +
      'Thing 2:\n' +
      '\tHit Points: 5\n' +
      '\tArmor: 10\n' +
      '\tStrength: 2\n' +
      '\tDexterity: 4\n' +
      '\tConstitution: 6\n');
  });

  it('should render game as html', () => {
    const game = new EvercraftGame();
    game.start('Thing 1', 'Thing 2');

    const display = new EvercraftGameDisplay(DISPLAY_TYPE.Web);
    const content = display.render(game);

    const element = document.createElement('div');
    element.id = 'delete-me';
    element.innerHTML = content;
    document.body.appendChild(element);

    expect(document.querySelectorAll('[data-character]')).toHaveLength(2);

    expect(document.querySelectorAll("[data-name]")[0].textContent).toContain('Thing 1');
    expect(document.querySelectorAll('[data-hit-points]')[0].textContent).toContain('5');
    expect(document.querySelectorAll("[data-armor]")[0].textContent).toContain("10");
    expect(document.querySelectorAll("[data-strength]")[0].textContent).toContain("N/A");
    expect(document.querySelectorAll("[data-dexterity]")[0].textContent).toContain("N/A");
    expect(document.querySelectorAll("[data-constitution]")[0].textContent).toContain("N/A");

    expect(document.querySelectorAll("[data-name]")[1].textContent).toContain("Thing 2");
    expect(document.querySelectorAll("[data-hit-points]")[1].textContent).toContain("5");
    expect(document.querySelectorAll("[data-armor]")[1].textContent).toContain("10");
    expect(document.querySelectorAll("[data-strength]")[1].textContent).toContain("N/A");
    expect(document.querySelectorAll("[data-dexterity]")[1].textContent).toContain("N/A");
    expect(document.querySelectorAll("[data-constitution]")[1].textContent).toContain("N/A");
  });

  it('should render character attributes as html when game rendered as html', () => {
    const game = new EvercraftGame();
    game.start('Thing 1', 'Thing 2');
    game.applyStrength(1, game.chars[0]);
    game.applyStrength(2, game.chars[1]);
    game.applyDexterity(3, game.chars[0]);
    game.applyDexterity(4, game.chars[1]);
    game.applyConstitution(5, game.chars[0]);
    game.applyConstitution(6, game.chars[1]);

    const display = new EvercraftGameDisplay(DISPLAY_TYPE.Web);
    const content = display.render(game);

    const element = document.createElement('div');
    element.id = 'delete-me';
    element.innerHTML = content;
    document.body.appendChild(element);

    expect(document.querySelectorAll('[data-character]')).toHaveLength(2);

    expect(document.querySelectorAll("[data-name]")[0].textContent).toContain('Thing 1');
    expect(document.querySelectorAll('[data-hit-points]')[0].textContent).toContain('5');
    expect(document.querySelectorAll("[data-armor]")[0].textContent).toContain("10");
    expect(document.querySelectorAll("[data-strength]")[0].textContent).toContain("1");
    expect(document.querySelectorAll("[data-dexterity]")[0].textContent).toContain("3");
    expect(document.querySelectorAll("[data-constitution]")[0].textContent).toContain("5");

    expect(document.querySelectorAll("[data-name]")[1].textContent).toContain("Thing 2");
    expect(document.querySelectorAll("[data-hit-points]")[1].textContent).toContain("5");
    expect(document.querySelectorAll("[data-armor]")[1].textContent).toContain("10");
    expect(document.querySelectorAll("[data-strength]")[1].textContent).toContain("2");
    expect(document.querySelectorAll("[data-dexterity]")[1].textContent).toContain("4");
    expect(document.querySelectorAll("[data-constitution]")[1].textContent).toContain("6");
  });

  afterEach(() => {
    const container = document.querySelector('#delete-me');
    if (container) {
      document.body.removeChild(container);
    }
  })
});
