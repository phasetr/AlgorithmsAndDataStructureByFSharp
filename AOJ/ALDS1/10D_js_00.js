let n = 5;
let p = [0.1500,0.1000,0.0500,0.1000,0.2000];
let q = [0.0500,0.1000,0.0500,0.0500,0.0500,0.1000];
function solve(n,p,q) {
  const dp = [...Array(n+1)].map((_, i) => [...Array(n+1)].map((_, i) => 0));
  const prs = [0,q[0]];

  let temp = q[0];
  for (let i=0; i<n; i++){
    temp += p[i];
    prs.push(temp);
    temp += q[i+1];
    prs.push(temp);
  }

  for (let i=0; i<n+1; i++){
    const dpi = dp[i];
    dpi[i] = q[i];
    for (let j=i-1; j>-1; j--){
      let ma = dp[j][j] + dpi[j+1];
      for (let k=1; k<i-j; k++){
        const mak = dp[j+k][j] + dpi[j+k+1];
        ma = mak < ma ? mak : ma;
      }
      dpi[j] = ma + prs[2*i+1] - prs[2*j];
    }
  }

  return dp[n][0];
}
(() => {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  const p = lines.shift().split(" ").map(i => Number(i));
  const q = lines.shift().split(" ").map(i => Number(i));
  console.log(solve(n,p,q));
})();

function cmp(a,b) { return Math.abs(a-b) <= 1e-4; }
console.log(cmp(solve(5,[0.1500,0.1000,0.0500,0.1000,0.2000],[0.0500,0.1000,0.0500,0.0500,0.0500,0.1000]), 2.75000000));
console.log(cmp(solve(7,[0.0400,0.0600,0.0800,0.0200,0.1000,0.1200,0.1400],[0.0600,0.0600,0.0600,0.0600,0.0500,0.0500,0.0500,0.0500]),3.12000000));
