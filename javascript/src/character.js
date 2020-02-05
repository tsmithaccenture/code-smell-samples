export class Character {
  name;
  hitPts;
  arm;
  str;
  dex;
  cst;

  constructor(name, hitPts, arm, str = null, dex = null, cst = null) {
    this.name = name;
    this.hitPts = hitPts;
    this.arm = arm;
    this.str = str;
    this.dex = dex;
    this.cst = cst;
  }
}
