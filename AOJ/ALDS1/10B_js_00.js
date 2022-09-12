// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/6250769/sara3wati_3333/JavaScript
function solve(n, xa){
  let dp = [...Array(n+1)].map(v => [...Array(n+1)].map(c => 0));
  for (let i=2; i<=n; i++) {
    for (let j=1; j<=n-i+1; j++) {
      const end = j+i-1;
      dp[j][end] = Infinity;
      for (let k=j; k<end; k++) {
        const tmp = dp[j][k] + dp[k+1][end] + xa[j-1] * xa[k] * xa[end];
        dp[j][end] = Math.min(dp[j][end], tmp);
      }
    }
  }
  return dp[1][n];
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");
const n = parseInt(lines[0]);
let mtr = lines[1].split(" ");
for (let i = 2; i <= n; i++) {
  mtr.push((lines[i].split(" ")[1]));
}
console.log(solve(n,mtr));

console.log(solve(6,[30,35,15,5,10,20,25]) === 15125);
