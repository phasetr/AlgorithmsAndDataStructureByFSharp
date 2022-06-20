function solve(n,xa){
  let adjM = [];
  for (let i = 0; i < n; i++) {
    adjM.push(new Array(n).fill(0));
  }

  for (let i = 0; i < n; i++) {
    const d = xa[i].trim().split(' ').map(Number);
    const r = d.slice(2);
    if(r.length) {
      for (let v of r) {
        adjM[d[0]-1][v-1] = 1;
      }
    }
  }
  return adjM;
}
(() => {
  const xa = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(xa.shift());
  solve(n,xa).forEach(r => console.log(r.join(" ")));
})();

function compare(xa,ya) { return JSON.stringify(xa) === JSON.stringify(ya); }
console.log(compare(solve(4,["1 2 2 4","2 1 4","3 0","4 1 3"]),[[0,1,0,1],[0,0,0,1],[0,0,0,0],[0,0,1,0]]));
