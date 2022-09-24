// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/6269570/sara3wati_3333/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");

T = lines[0];
P = lines[1];

for (i = T.indexOf(P, 0); i !== -1; i = T.indexOf(P, ++i)) {console.log(i);}
