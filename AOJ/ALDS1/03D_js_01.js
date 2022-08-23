// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/2015153/keisuketsushima/JavaScript
const getPools = function(geo) {
  const downside = [];
  const pools = [];
  for (let i = 0; i < geo.length; i += 1) {
    if (geo[i] === '\\') {
      downside.push(i);
    } else if (geo[i] === '/' && downside.length > 0) {
      const d = downside.pop();
      const pool = i - d;
      while (pools.length > 0 && pools[pools.length - 1][0] > d) {
        pool += pools.pop()[1];
      }
      pools.push([d, pool]);
    }
  }
  return pools.length > 0 ? pools.map(function(p) {
    return p[1];
  }) : [];
};

const stdin = require('fs').readFileSync('/dev/stdin', 'utf8');
stdin.split('\n').forEach(function(line) {
  if (line !== '') {
    const geo = line.trim();
    const pools = getPools(geo);
    const total = pools.length > 0 ?
          pools.reduce(function(a, b) { return a + b; }) : 0;
    console.log(total);
    pools.unshift(pools.length);
    console.log(pools.join(' '));
  }
});
