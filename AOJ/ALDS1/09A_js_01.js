// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/6235925/sara3wati_3333/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");

const h = parseInt(lines[0], 10);
const a = lines[1].split(" ").map(Number);
a.unshift("");
for (let i = 1; i <= h; i++) {
  let key = a[i],
      parent = a[Math.floor(i/2)],
      left_key = a[i*2],
      right_key = a[(i*2)+1];
  var ans = `node ${i}: key = ${key}, `;
  if (i > 1) ans += `parent key = ${parent}, `;
  if (i*2 <= h) ans += `left key = ${left_key}, `;
  if (i*2+1 <= h) ans += `right key = ${right_key}, `;
  console.log(ans);
}
