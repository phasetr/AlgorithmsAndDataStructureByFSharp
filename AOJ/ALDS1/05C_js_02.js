// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2398835/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
const config = { input: '/dev/stdin', newline: '\n' }; // linux
const n = Number(require('fs').readFileSync(config.input, 'ascii').trim());

const SCALE = Math.sqrt(3)/6;

function get_koch(p1, p2) {
  const s = [(2*p1[0]+p2[0])/3, (2*p1[1]+p2[1])/3];
  const t = [(p1[0]+2*p2[0])/3, (p1[1]+2*p2[1])/3];
  const ux = (p1[0]+p2[0])/2 + SCALE*(p1[1]-p2[1]);
  const uy = (p1[1]+p2[1])/2 + SCALE*(p2[0]-p1[0]);
  return [p1, s, [ux, uy], t];
}
line = [[0, 0], [100, 0]];
for (let i = 0; i < n; i++) {
  next = [];
  for (j = 0; j < line.length - 1; j++) {
    next = next.concat(get_koch(line[j], line[j+1]));
  }
  next.push(line[line.length-1]);
  line = next;
}
for (i in line) {console.log(line[i].join(' '));}
